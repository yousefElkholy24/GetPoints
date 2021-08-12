using GetPointAdmin.Models.Dto;
using MailChimp.Net.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymentGateway;
using RestSharp;

namespace GetPointAdmin.API
{
    public class CustomerController : ApiController
    {
        // --> Customer APIs

        [HttpPost]
        public dynamic CanCustomerLogin([FromBody] tbl_Customer tbl_Customer)
        {
            try
            {
                using (GetPointEntities dbContext = new GetPointEntities())
                {
                    var LoginResult = dbContext.tbl_Customer.FirstOrDefault(c => c.CustomerEmail == tbl_Customer.CustomerEmail && c.CustomerPassword == tbl_Customer.CustomerPassword);

                    if (LoginResult != null)
                    {
                        var OrderObject = dbContext.tbl_Order.Where(c => c.CustomerID == LoginResult.CustomerID).ToList();
                        var SumOfUsedPointsInOrder = OrderObject.Select(uf => uf.UsedPoints).DefaultIfEmpty().Sum();
                        var SumOfUsedPointsCreditInOrder = OrderObject.Select(uf => uf.UsedPointsCredit).DefaultIfEmpty().Sum();

                        var ShoppingCartObject = dbContext.tbl_ShoppingCartItem.Where(c => c.CustomerID == LoginResult.CustomerID).ToList();
                        var SumOfPointsInCart = ShoppingCartObject.Select(uf => uf.Points).DefaultIfEmpty().Sum();
                        var SumOfPointsCreditInCart = ShoppingCartObject.Select(uf => uf.PointsCredit).DefaultIfEmpty().Sum();


                        var response = new
                        {
                            Message = "Logged in Successfully",
                            CustomerID = LoginResult.CustomerID,
                            CustomerPic = LoginResult.CustomerProfilePic,
                            CustomerEmail = LoginResult.CustomerEmail,
                            Points = SumOfPointsInCart - SumOfUsedPointsInOrder,
                            Credit = SumOfPointsCreditInCart - SumOfUsedPointsCreditInOrder
                        };
                        var Request = new HttpRequestMessage();
                        Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                        Request.Content = new StringContent("Hello", Encoding.UTF8, "application/json");
                        return Request.CreateResponse(HttpStatusCode.OK, new { response.Message, response.CustomerID, response.CustomerEmail, response.CustomerPic, response.Points, response.Credit }, JsonMediaTypeFormatter.DefaultMediaType);
                    }
                    else
                    {
                        var response = new
                        {
                            Message = "Error Occured",
                            Data = -1
                        };
                        var Request = new HttpRequestMessage();
                        Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                        Request.Content = new StringContent("Hello", Encoding.UTF8, "application/json");
                        return Request.CreateResponse(HttpStatusCode.OK, new { response.Message, response.Data }, JsonMediaTypeFormatter.DefaultMediaType);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public dynamic CustomerRegister(tbl_Customer tbl_Customer)
        {

            GetPointEntities db = new GetPointEntities();

            //Add To Database
            db.tbl_Customer.Add(tbl_Customer);
            db.SaveChanges();

            //copy from oject to DTO, the n return DTO
            //Retrieve from DB and return as json

            var lst = db.tbl_Customer.Where(c => c.CustomerID == tbl_Customer.CustomerID).Select(l => new tbl_CustomerDto
            {
                CustomerID = l.CustomerID,
                CustomerFullName = l.CustomerFullName,
                CustomerUserName = l.CustomerUserName,
                CustomerPassword = l.CustomerPassword,
                CustomerIsActive = l.CustomerIsActive,
                CustomerEmail = l.CustomerEmail,
                CustomerMobile = l.CustomerMobile,
                CustomerTele = l.CustomerTele,
                CustomerIsVerified = l.CustomerIsVerified,
                CustomerProfilePic = l.CustomerProfilePic,
                tbl_CustomerAddress = l.tbl_CustomerAddress.ToList(),
            });

            return new { Data = lst };
        }
        public dynamic GetCustomerInfoByID([FromUri] int id)
        {
            try
            {

                GetPointEntities db = new GetPointEntities();
                var OrderObject = db.tbl_Order.Where(c => c.CustomerID == id).ToList();
                var SumOfUsedPointsInOrder = OrderObject.Select(uf => uf.UsedPoints).DefaultIfEmpty().Sum();
                var SumOfUsedPointsCreditInOrder = OrderObject.Select(uf => uf.UsedPointsCredit).DefaultIfEmpty().Sum();

                var ShoppingCartObject = db.tbl_ShoppingCartItem.Where(c => c.CustomerID == id && c.Closed == true).ToList();
                var SumOfPointsInCart = ShoppingCartObject.Select(uf => uf.Points).DefaultIfEmpty().Sum();
                var SumOfPointsCreditInCart = ShoppingCartObject.Select(uf => uf.PointsCredit).DefaultIfEmpty().Sum();

                var lst = db.tbl_Customer.Where(c => c.CustomerID == id).Select(l => new tbl_CustomerDto
                {
                    CustomerID = l.CustomerID,
                    CustomerFullName = l.CustomerFullName,
                    CustomerUserName = l.CustomerUserName,
                    CustomerPassword = l.CustomerPassword,
                    CustomerIsActive = l.CustomerIsActive,
                    CustomerEmail = l.CustomerEmail,
                    CustomerMobile = l.CustomerMobile,
                    CustomerTele = l.CustomerTele,
                    CustomerIsVerified = l.CustomerIsVerified,
                    CustomerProfilePic = l.CustomerProfilePic,

                    //tbl_CustomerAddress = l.tbl_CustomerAddress.ToList(),
                    //tbl_Order = l.tbl_Order.ToList()
                });

                return new
                {
                    Data = lst.FirstOrDefault(),
                    Points = SumOfPointsInCart - SumOfUsedPointsInOrder,
                    PointsCredit = SumOfPointsCreditInCart - SumOfUsedPointsCreditInOrder
                };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public dynamic CheckExistanceOfEmail([FromBody] tbl_Customer tbl_Customer)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                var Check = db.tbl_Customer.Where(c => c.CustomerEmail == tbl_Customer.CustomerEmail).ToList();


                if (Check.Count != 0)
                {
                    return new
                    {
                        Data = true
                    };
                }
                else
                {
                    return new
                    {
                        Data = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }


        [HttpPost]
        public dynamic ChangePassword([FromBody] tbl_Customer tbl_Customer)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                var Change = db.tbl_Customer.Where(c => c.CustomerID == tbl_Customer.CustomerID).FirstOrDefault();
                Change.CustomerPassword = tbl_Customer.CustomerPassword;
                db.Entry(Change).State = EntityState.Modified;
                db.SaveChanges();
                return new
                {
                    Data = "Password Changed Successfully"
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }
        public dynamic GetFavByCustomerId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_CustomerFav.Where(c => c.CustomerID == id).Select(l => new
                {
                    CustomerFavID = l.CustomerFavID,
                    CustomerID = l.CustomerID,
                    ItemID = l.ItemID,
                    ItemInfo = db.tbl_Item.Where(c => c.ItemID == l.ItemID).ToList()
                });

                return new
                {
                    Data = lst,
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public dynamic MakeFavorite(tbl_CustomerFav tbl_CustomerFav)
        {
            GetPointEntities db = new GetPointEntities();

            //Add To Database
            db.tbl_CustomerFav.Add(tbl_CustomerFav);
            db.SaveChanges();

            //copy from oject to DTO, the n return DTO
            //Retrieve from DB and return as json

            var lst = db.tbl_CustomerFav.Where(c => c.CustomerID == tbl_CustomerFav.CustomerID).Select(l => new tbl_CustomerFavDto
            {
                CustomerFavID = l.CustomerFavID,
                ItemID = l.ItemID,
                CustomerID = l.CustomerID
            });

            return new { Data = lst };
        }


        [HttpPost] 
        public dynamic DeleteFromFavorite(tbl_CustomerFav tbl_CustomerFav)
        {
            GetPointEntities db = new GetPointEntities();

            var FavItem = db.tbl_CustomerFav.Where(c => c.CustomerID == tbl_CustomerFav.CustomerID && c.ItemID == tbl_CustomerFav.ItemID).FirstOrDefault();

            //Delete from Database
            if (FavItem == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item Not Found To Delete");
            }
            else
            {
                db.tbl_CustomerFav.Remove(FavItem);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "The Item was deleted successfully from Favorite");
            }
        }


        [HttpPost]
        public dynamic EditCustomerInfo([FromBody] tbl_Customer tbl_Customer)
        {
            GetPointEntities db = new GetPointEntities();
            var EditItem = db.tbl_Customer.Where(c => c.CustomerID == tbl_Customer.CustomerID).FirstOrDefault();

            EditItem.CustomerFullName = tbl_Customer.CustomerFullName;
            EditItem.CustomerEmail = tbl_Customer.CustomerEmail;
            EditItem.CustomerMobile = tbl_Customer.CustomerMobile;
            EditItem.CustomerPassword = tbl_Customer.CustomerPassword;

            db.Entry(EditItem).State = EntityState.Modified;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Customer.CustomerID }, tbl_Customer);
        }



        // --> Category APIs
        public dynamic GetCategoryList()
        {

            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Category.Select(l => new tbl_CategoryDto
            {
                CategoryID = l.CategoryID,
                CategoryTitleAr = l.CategoryTitleAr,
                CategoryTitleEn = l.CategoryTitleEn,
                CategoryPic = l.CategoryPic,
                CategoryIsActive = l.CategoryIsActive,
                CategorySort = l.CategorySort,
                CategoryDescription = l.CategoryDescription,
            }).OrderBy(c=>c.CategorySort);

            return new { Data = lst };
        }

        // --> Subcategory API
        public dynamic GetSubCategoryListByCategoryID([FromUri] int id)
        {

            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_SubCategory.Where(c => c.CategoryID == id).Select(l => new tbl_SubCategoryDto
                {
                    SubCategoryID = l.SubCategoryID,
                    SubCategoryTitleAr = l.SubCategoryTitleAr,
                    SubCategoryTitleEn = l.SubCategoryTitleEn,
                    SubCategoryPic = l.SubCategoryPic,
                    SubCategoryIsActive = l.SubCategoryIsActive,
                    SubCategorySort = l.SubCategorySort,
                    SubCategoryDescription = l.SubCategoryDescription,
                    CategoryID = l.CategoryID,
                    //tbl_Category = l.tbl_Category
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);


            }


        }

        // --> Item APIs
        public dynamic GetItemsListByCategoryID([FromUri] int id)
        {

            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_Item.Where(c => c.CategoryID == id).Select(l => new tbl_ItemDto
                {
                    ItemID = l.ItemID,
                    CategoryID = l.CategoryID,
                    ItemTitle = l.ItemTitle,
                    ItemDescription = l.ItemDescription,
                    ItemPrice = l.ItemPrice,
                    ItemPic = l.ItemPic,
                    SupplierID = l.SupplierID,
                    SubCategoryId = l.SubCategoryId,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit,
                    NoOfViews = l.NoOfViews,
                    //tbl_Category = l.tbl_Category,
                    //tbl_Supplier = l.tbl_Supplier,
                    //tbl_ItemColor = l.tbl_ItemColor.ToList(),
                    //tbl_ItemImage = l.tbl_ItemImage.ToList(),
                    //tbl_ItemSize = l.tbl_ItemSize.ToList(),
                    //tbl_OrderItem = l.tbl_OrderItem.ToList(),
                    //tbl_Slider = l.tbl_Slider.ToList(),
                    //tbl_ItemGroup = l.tbl_ItemGroup.ToList()
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);


            }


        }
        public dynamic GetItemsListBySubCategoryID([FromUri] int id)
        {

            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_Item.Where(c => c.SubCategoryId == id).Select(l => new tbl_ItemDto
                {
                    ItemID = l.ItemID,
                    CategoryID = l.CategoryID,
                    ItemTitle = l.ItemTitle,
                    ItemDescription = l.ItemDescription,
                    ItemPrice = l.ItemPrice,
                    ItemPic = l.ItemPic,
                    SupplierID = l.SupplierID,
                    SubCategoryId = l.SubCategoryId,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit,
                    NoOfViews = l.NoOfViews,
                    //tbl_Category = l.tbl_Category,
                    //tbl_Supplier = l.tbl_Supplier,
                    //tbl_ItemColor = l.tbl_ItemColor.ToList(),
                    //tbl_ItemImage = l.tbl_ItemImage.ToList(),
                    //tbl_ItemSize = l.tbl_ItemSize.ToList(),
                    //tbl_OrderItem = l.tbl_OrderItem.ToList(),
                    //tbl_Slider = l.tbl_Slider.ToList(),
                    //tbl_ItemGroup = l.tbl_ItemGroup.ToList()
                });

                return new { Data = lst };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);


            }


        }
        public dynamic GetItemByItemID([FromUri] int ItemID, [FromUri] int CustomerID)
        {

            try
            {
                GetPointEntities db = new GetPointEntities();

                var Fav = true;
                var increment = db.tbl_Item.Where(c => c.ItemID == ItemID).FirstOrDefault().NoOfViews;
                var Upd = db.tbl_Item.Where(c => c.ItemID == ItemID).FirstOrDefault();


                if (increment == null)
                {
                    increment = 0;
                }
                else
                {
                    increment += 1;
                    goto c;
                }

                increment += 1;

            c:

                Upd.NoOfViews = increment;

                db.Entry(Upd).State = EntityState.Modified;
                db.SaveChanges();

                var lst = db.tbl_Item.Where(c => c.ItemID == ItemID).Select(l => new tbl_ItemDto
                {
                    ItemID = l.ItemID,
                    CategoryID = l.CategoryID,
                    ItemTitle = l.ItemTitle,
                    ItemDescription = l.ItemDescription,
                    ItemPrice = l.ItemPrice,
                    ItemPic = l.ItemPic,
                    SupplierID = l.SupplierID,
                    SubCategoryId = l.SubCategoryId,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit,
                    NoOfViews = increment,
                }).FirstOrDefault();

                var FavInfo = db.tbl_CustomerFav.Where(c => c.CustomerID == CustomerID && c.ItemID == ItemID).FirstOrDefault();

                if (CustomerID != -1)
                {
                    if (FavInfo != null)
                        Fav = true;
                    else
                        Fav = false;

                    return new
                    {
                        Data = lst,
                        Fav

                    };
                }
                else
                {
                    return new
                    {
                        Data = lst,
                    };
                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // --> Supplier API
        public dynamic GetSuppliersList()
        {

            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Supplier.Select(l => new tbl_SupplierDto
            {
                SupplierID = l.SupplierID,
                SupplierTitle = l.SupplierTitle,
                SupplierIsActive = l.SupplierIsActive,
                SupplierEmail = l.SupplierEmail,
                SupplierMobile = l.SupplierMobile,
                SupplierTele = l.SupplierTele,
                SupplierContactPerson = l.SupplierContactPerson,
                SupplierContactMobile = l.SupplierContactMobile,
                //tbl_Item = l.tbl_Item.ToList()
            });

            return new { Data = lst };
        }
        public dynamic GetSupplierInfoBySupplierID([FromUri] int id)
        {
            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_Supplier.Where(c => c.SupplierID == id).Select(l => new tbl_SupplierDto
                {
                    SupplierID = l.SupplierID,
                    SupplierTitle = l.SupplierTitle,
                    SupplierIsActive = l.SupplierIsActive,
                    SupplierEmail = l.SupplierEmail,
                    SupplierMobile = l.SupplierMobile,
                    SupplierTele = l.SupplierTele,
                    SupplierContactPerson = l.SupplierContactPerson,
                    SupplierContactMobile = l.SupplierContactMobile,
                    //tbl_Item = l.tbl_Item.ToList()
                });

                return new { Data = lst.FirstOrDefault() };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetSupplierInfoByItemID([FromUri] int id)
        {
            try
            {
                using (GetPointEntities dbContext = new GetPointEntities())
                {


                    var CatList = dbContext.tbl_Item.Where(c => c.ItemID == id).FirstOrDefault().tbl_Supplier;// .tbl_Supplier.Where(c => c.ItemID == id).ToList();

                    var response = new MyCustomResponse()
                    {
                        Message = "Successful",
                        Data = CatList
                    };
                    var Request = new HttpRequestMessage();
                    Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
                    Request.Content = new StringContent("Hello", Encoding.UTF8, "application/json");
                    return Request.CreateResponse(HttpStatusCode.OK, new { response.Message, response.Data }, JsonMediaTypeFormatter.DefaultMediaType);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // --> Order API
        public dynamic GetOrdersList()
        {

            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Order.Select(l => new tbl_OrderDto
            {
                OrderID = l.OrderID,
                CustomerID = l.CustomerID,
                OrderDate = l.OrderDate,
                Total = l.Total,
                Discount = l.Discount,
                DeliveryFees = l.DeliveryFees,
                Net = l.Net,
                Remarks = l.Remarks,
                OrderStatusID = l.OrderStatusID,
                PaymentType = l.PaymentType,
                CustomerAddressID = l.CustomerAddressID,
                UsedPoints = l.UsedPoints,
                UsedPointsCredit = l.UsedPointsCredit,
                //tbl_Customer = l.tbl_Customer,
                //tbl_OrderStatus = l.tbl_OrderStatus,
                //tbl_PaymentType = l.tbl_PaymentType,
                tbl_OrderItem = l.tbl_OrderItem.ToList()
            });

            return new { Data = lst };
        }
        public dynamic GetOrderById([FromUri] int id)
        {
            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_Order.Where(c => c.OrderID == id).Select(l => new tbl_OrderDto
                {
                    OrderID = l.OrderID,
                    CustomerID = l.CustomerID,
                    OrderDate = l.OrderDate,
                    Total = l.Total,
                    Discount = l.Discount,
                    DeliveryFees = l.DeliveryFees,
                    Net = l.Net,
                    Remarks = l.Remarks,
                    OrderStatusID = l.OrderStatusID,
                    PaymentType = l.PaymentType,
                    CustomerAddressID = l.CustomerAddressID,
                    UsedPoints = l.UsedPoints,
                    UsedPointsCredit = l.UsedPointsCredit

                    //tbl_Customer = l.tbl_Customer,
                    //tbl_OrderStatus = l.tbl_OrderStatus,
                    //tbl_PaymentType = l.tbl_PaymentType,
                    //tbl_OrderItem = l.tbl_OrderItem.ToList()
                });

                return new { Data = lst.FirstOrDefault() };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetOrderListByCustomerId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_Order.Where(c => c.CustomerID == id).Select(l => new tbl_OrderDto
                {
                    OrderID = l.OrderID,
                    CustomerID = l.CustomerID,
                    OrderDate = l.OrderDate,
                    Total = l.Total,
                    Discount = l.Discount,
                    DeliveryFees = l.DeliveryFees,
                    Net = l.Net,
                    Remarks = l.Remarks,
                    OrderStatusID = l.OrderStatusID,
                    PaymentType = l.PaymentType,
                    CustomerAddressID = l.CustomerAddressID,
                    UsedPoints = l.UsedPoints,
                    UsedPointsCredit = l.UsedPointsCredit,
                    //tbl_Customer = l.tbl_Customer,
                    //tbl_OrderStatus = l.tbl_OrderStatus,
                    //tbl_PaymentType = l.tbl_PaymentType,
                    //tbl_OrderItem = l.tbl_OrderItem.ToList()
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }
        public dynamic GetOldOrdersByViewCustomerId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                var lst = db.VW_OldOrders.Where(c => c.CustomerID == id).Select(l => new VW_OldOrdersDto
                {
                    OrderID = l.OrderID,
                    ItemID = l.ItemID,
                    Qty = l.Qty,
                    CategoryID = l.CategoryID,
                    ItemTitle = l.ItemTitle,
                    ItemDescription = l.ItemDescription,
                    ItemPrice = l.ItemPrice,
                    ItemPic = l.ItemPic,
                    SupplierID = l.SupplierID,
                    SubCategoryId = l.SubCategoryId,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit,
                    NoOfViews = l.NoOfViews,
                    OrderDate = l.OrderDate,
                    Total = l.Total,
                    Discount = l.Discount,
                    DeliveryFees = l.DeliveryFees,
                    Net = l.Net,
                    Remarks = l.Remarks,
                    OrderStatusID = l.OrderStatusID,
                    PaymentType = l.PaymentType,
                    CustomerAddressID = l.CustomerAddressID,
                    UsedPoints = l.UsedPoints,
                    UsedPointsCredit = l.UsedPointsCredit,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }
        public dynamic GetOldOrdersByCustomerId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                var lst = db.tbl_Order.Include(t => t.tbl_OrderItem).Where(c => c.CustomerID == id).Select(l => new
                {
                    OrderID = l.OrderID,
                    CustomerID = l.CustomerID,
                    OrderDate = l.OrderDate,
                    Total = l.Total,
                    Discount = l.Discount,
                    DeliveryFees = l.DeliveryFees,
                    Net = l.Net,
                    Remarks = l.Remarks,
                    OrderStatusID = l.OrderStatusID,
                    PaymentType = l.PaymentType,
                    CustomerAddressID = l.CustomerAddressID,
                    UsedPoints = l.UsedPoints,
                    UsedPointsCredit = l.UsedPointsCredit,
                    OrderItems = db.tbl_OrderItem.Where(c => c.OrderID == l.OrderID).Select(t => new
                    {
                        t.ItemID,
                        t.Qty,
                        ItemDetails = db.tbl_Item.Where(a => a.ItemID == t.ItemID).ToList()
                    }
                      )

                }).ToList();

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }



        // -->Order Item API
        public dynamic GetOrderItemList()
        {
            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_OrderItem.Select(l => new tbl_OrderItemDto
            {
                OrderItemID = l.OrderItemID,
                ItemID = l.ItemID,
                OrderID = l.OrderID,
                Qty = l.Qty,
                ItemPrice = l.ItemPrice,
                ItemTotal = l.ItemTotal,
                ItemColorID = l.ItemColorID,
                ItemSizeID = l.ItemSizeID,
                Remarks = l.Remarks,
                Points = l.Points,
                PointsCredit = l.PointsCredit
                //tbl_Item = l.tbl_Item,
                //tbl_Order = l.tbl_Order
            });

            return new { Data = lst };
        }
        public dynamic GetOrderItemByItemId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_OrderItem.Where(c => c.ItemID == id).Select(l => new tbl_OrderItemDto
                {
                    OrderItemID = l.OrderItemID,
                    ItemID = l.ItemID,
                    OrderID = l.OrderID,
                    Qty = l.Qty,
                    ItemPrice = l.ItemPrice,
                    ItemTotal = l.ItemTotal,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID,
                    Remarks = l.Remarks,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit
                    //tbl_Item = l.tbl_Item,
                    //tbl_Order = l.tbl_Order
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetOrderItemByOrderItemId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_OrderItem.Where(c => c.OrderItemID == id).Select(l => new tbl_OrderItemDto
                {
                    OrderItemID = l.OrderItemID,
                    ItemID = l.ItemID,
                    OrderID = l.OrderID,
                    Qty = l.Qty,
                    ItemPrice = l.ItemPrice,
                    ItemTotal = l.ItemTotal,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID,
                    Remarks = l.Remarks,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit
                    //tbl_Item = l.tbl_Item,
                    //tbl_Order = l.tbl_Order
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetOrderItemByOrderId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_OrderItem.Where(c => c.OrderID == id).Select(l => new tbl_OrderItemDto
                {
                    OrderItemID = l.OrderItemID,
                    ItemID = l.ItemID,
                    OrderID = l.OrderID,
                    Qty = l.Qty,
                    ItemPrice = l.ItemPrice,
                    ItemTotal = l.ItemTotal,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID,
                    Remarks = l.Remarks,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit
                    //tbl_Item = l.tbl_Item,
                    //tbl_Order = l.tbl_Order
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }



        // --> Shopping Cart APIs
        public dynamic GetShoppingCartItemList()
        {
            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_ShoppingCartItem.Select(l => new tbl_ShoppingCartItemDto
            {
                ShoppingCartItemID = l.ShoppingCartItemID,
                ItemID = l.ItemID,
                Qty = l.Qty,
                ItemPrice = l.ItemPrice,
                ItemTotal = l.ItemTotal,
                ItemColorID = l.ItemColorID,
                ItemSizeID = l.ItemSizeID,
                Remarks = l.Remarks,
                CustomerID = l.CustomerID,
                Closed = l.Closed,
                Points = l.Points,
                PointsCredit = l.PointsCredit
            });

            return new { Data = lst };
        }
        public dynamic GetShoppingCartItemByItemId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_ShoppingCartItem.Where(c => c.ItemID == id).Select(l => new tbl_ShoppingCartItemDto
                {
                    ShoppingCartItemID = l.ShoppingCartItemID,
                    ItemID = l.ItemID,
                    Qty = l.Qty,
                    ItemPrice = l.ItemPrice,
                    ItemTotal = l.ItemTotal,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID,
                    Remarks = l.Remarks,
                    CustomerID = l.CustomerID,
                    Closed = l.Closed,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetShoppingCartItemByCartId([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_ShoppingCartItem.Where(c => c.ShoppingCartItemID == id).Select(l => new tbl_ShoppingCartItemDto
                {
                    ShoppingCartItemID = l.ShoppingCartItemID,
                    ItemID = l.ItemID,
                    Qty = l.Qty,
                    ItemPrice = l.ItemPrice,
                    ItemTotal = l.ItemTotal,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID,
                    Remarks = l.Remarks,
                    CustomerID = l.CustomerID,
                    Closed = l.Closed,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetVW_ShoppingCartListByCustomerID([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                var CatList = db.VW_ShoppingCart.Where(c => c.CustomerID == id && c.Closed == false).ToList();

                var TotalPrice = CatList.Select(uf => uf.ItemTotal).DefaultIfEmpty().Sum();

                var lst = db.VW_ShoppingCart.Where(c => c.CustomerID == id && c.Closed == false).Select(l => new VW_ShoppingCartDto
                {
                    ShoppingCartItemID = l.ShoppingCartItemID,
                    ItemID = l.ItemID,
                    Qty = l.Qty,
                    ItemPrice = l.ItemPrice,
                    ItemTotal = l.ItemTotal,
                    ItemColorID = l.ItemColorID,
                    ItemSizeID = l.ItemSizeID,
                    Remarks = l.Remarks,
                    CustomerID = l.CustomerID,
                    Closed = l.Closed,
                    ItemTitle = l.ItemTitle,
                    ItemPic = l.ItemPic,
                    Expr1 = l.Expr1,
                    ItemDescription = l.ItemDescription,
                    ItemSizeTitle = l.ItemSizeTitle,
                    ItemColorTitle = l.ItemColorTitle,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit
                });

                return new { Data = lst, TotalPrice };

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public dynamic DeleteItemInShoppingCartByShoppingCartItemId([FromUri] int id)
        {
            using (GetPointEntities dbContext = new GetPointEntities())
            {
                try
                {
                    var ItemToDelete = dbContext.tbl_ShoppingCartItem.Where(e => e.ShoppingCartItemID == id).FirstOrDefault();

                    if (ItemToDelete == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item Not Found To Delete");
                    }
                    else
                    {
                        dbContext.tbl_ShoppingCartItem.Remove(ItemToDelete);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "The Item was deleted successfully");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }

            }
        }


        [HttpPost]
        public dynamic AddToShoppingCart([FromBody] tbl_ShoppingCartItem tbl_ShoppingCartItem)
        {
            GetPointEntities db = new GetPointEntities();

            var GetPointsFromItem = db.tbl_Item.Where(c => c.ItemID == tbl_ShoppingCartItem.ItemID).FirstOrDefault();

            tbl_ShoppingCartItem.Points = GetPointsFromItem.Points;
            tbl_ShoppingCartItem.PointsCredit = GetPointsFromItem.PointsCredit;
            tbl_ShoppingCartItem.Closed = false;
            db.tbl_ShoppingCartItem.Add(tbl_ShoppingCartItem);
            db.SaveChanges();

            var lst = db.tbl_ShoppingCartItem.Select(l => new tbl_ShoppingCartItemDto
            {
                ShoppingCartItemID = l.ShoppingCartItemID,
                ItemID = l.ItemID,
                Qty = l.Qty,
                ItemPrice = l.ItemPrice,
                ItemTotal = l.ItemTotal,
                ItemColorID = l.ItemColorID,
                ItemSizeID = l.ItemSizeID,
                Remarks = l.Remarks,
                CustomerID = l.CustomerID,
                Closed = l.Closed,
                Points = l.Points,
                PointsCredit = l.PointsCredit
            }).Where(c => c.CustomerID == tbl_ShoppingCartItem.CustomerID).ToList();
            return new { Data = lst };
        }


        [HttpPost]
        public dynamic EditToShoppingCart([FromBody] tbl_ShoppingCartItem tbl_ShoppingCartItem)
        {
            GetPointEntities db = new GetPointEntities();
            var EditItem = db.tbl_ShoppingCartItem.Where(c => c.ShoppingCartItemID == tbl_ShoppingCartItem.ShoppingCartItemID).FirstOrDefault();

            EditItem.ItemID = tbl_ShoppingCartItem.ItemID;
            EditItem.Qty = tbl_ShoppingCartItem.Qty;
            EditItem.ItemPrice = tbl_ShoppingCartItem.ItemPrice;
            EditItem.ItemTotal = tbl_ShoppingCartItem.ItemTotal;
            EditItem.ItemColorID = tbl_ShoppingCartItem.ItemColorID;
            EditItem.ItemSizeID = tbl_ShoppingCartItem.ItemSizeID;
            EditItem.Remarks = tbl_ShoppingCartItem.Remarks;


            db.Entry(EditItem).State = EntityState.Modified;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_ShoppingCartItem.ShoppingCartItemID }, tbl_ShoppingCartItem);
        }

        // ----------------------------------------------------------------------------- //
        // --> Add address
        [HttpPost]
        public dynamic AddCustomerAddress([FromBody] tbl_CustomerAddress tbl_CustomerAddress)
        {
            GetPointEntities db = new GetPointEntities();

            db.tbl_CustomerAddress.Add(tbl_CustomerAddress);
            db.SaveChanges();

            var lst = db.tbl_CustomerAddress.Select(l => new tbl_CustomerAddressDto
            {
                CustomerAddressID = l.CustomerAddressID,
                CustomerAddressTitle = l.CustomerAddressTitle,
                CustomerAddressCityID = l.CustomerAddressCityID,
                CustomerAddressAreaID = l.CustomerAddressAreaID,
                CustomerAddressDetails = l.CustomerAddressDetails,
                CustomerID = l.CustomerID,
                CustomerAddressLat = l.CustomerAddressLat,
                CustomerAddressLng = l.CustomerAddressLng,
                CustomerAddressMapLocation = l.CustomerAddressMapLocation,
                //tbl_Customer = l.tbl_Customer
            });
            return new { Data = lst };

            //return CreatedAtRoute("DefaultApi","Succeed", "The Address was added successfully");
        }


        [HttpPost]
        public dynamic EditCustomerAddress([FromBody] tbl_CustomerAddress tbl_CustomerAddress)
        {
            GetPointEntities db = new GetPointEntities();
            var EditItem = db.tbl_CustomerAddress.Where(c => c.CustomerAddressID == tbl_CustomerAddress.CustomerAddressID).FirstOrDefault();

            EditItem.CustomerAddressTitle = tbl_CustomerAddress.CustomerAddressTitle;
            EditItem.CustomerAddressAreaID = tbl_CustomerAddress.CustomerAddressAreaID;
            EditItem.CustomerAddressCityID = tbl_CustomerAddress.CustomerAddressCityID;
            EditItem.CustomerAddressDetails = tbl_CustomerAddress.CustomerAddressDetails;
            EditItem.CustomerAddressLat = tbl_CustomerAddress.CustomerAddressLat;
            EditItem.CustomerAddressLng = tbl_CustomerAddress.CustomerAddressLng;


            db.Entry(EditItem).State = EntityState.Modified;
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = tbl_CustomerAddress.CustomerAddressID }, tbl_CustomerAddress);
        }


        [HttpPost]
        public dynamic DeleteCustomerAddressByCustomerAddressId([FromUri] int id)
        {
            using (GetPointEntities dbContext = new GetPointEntities())
            {
                try
                {
                    var ItemToDelete = dbContext.tbl_CustomerAddress.Where(e => e.CustomerAddressID == id).FirstOrDefault();

                    if (ItemToDelete == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Address Not Found To Delete");
                    }
                    else
                    {
                        dbContext.tbl_CustomerAddress.Remove(ItemToDelete);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "The Address was deleted successfully");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }

            }
        }

        public dynamic GetAddressInfoByAddressID([FromUri] int id)
        {
            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_CustomerAddress.Where(c => c.CustomerAddressID == id).Select(l => new tbl_CustomerAddressDto
                {
                    CustomerAddressID = l.CustomerAddressID,
                    CustomerAddressTitle = l.CustomerAddressTitle,
                    CustomerAddressCityID = l.CustomerAddressCityID,
                    CustomerAddressAreaID = l.CustomerAddressAreaID,
                    CustomerAddressDetails = l.CustomerAddressDetails,
                    CustomerID = l.CustomerID,
                    CustomerAddressLat = l.CustomerAddressLat,
                    CustomerAddressLng = l.CustomerAddressLng,
                    CustomerAddressMapLocation = l.CustomerAddressMapLocation,
                    //tbl_Customer = l.tbl_Customer
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public dynamic GetAddressListByCustomerID([FromUri] int id)
        {

            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_CustomerAddress.Where(c => c.CustomerID == id).Select(l => new tbl_CustomerAddressDto
                {
                    CustomerAddressID = l.CustomerAddressID,
                    CustomerAddressTitle = l.CustomerAddressTitle,
                    CustomerAddressCityID = l.CustomerAddressCityID,
                    CustomerAddressAreaID = l.CustomerAddressAreaID,
                    CustomerAddressDetails = l.CustomerAddressDetails,
                    CustomerID = l.CustomerID,
                    CustomerAddressLat = l.CustomerAddressLat,
                    CustomerAddressLng = l.CustomerAddressLng,
                    CustomerAddressMapLocation = l.CustomerAddressMapLocation,
                    //tbl_Customer = l.tbl_Customer
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);


            }


        }
        public dynamic GetCityWithArea()
        {

            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_City.Select(l => new
            {
                CityID = l.CityID,
                CityTitle = l.CityTitle,
                Areas = db.tbl_Area.Where(c => c.CityID == l.CityID).Select(c => new { c.AreaID, c.AreaTitle }).ToList()
            });

            return new { Data = lst };
            //return lst;
        }
        public dynamic GetAreaList()
        {
            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Area.Select(l => new tbl_AreaDto
            {
                AreaID = l.AreaID,
                CityID = l.CityID,
                AreaTitle = l.AreaTitle
            });

            return new { Data = lst };
        }


        [HttpPost]
        public dynamic MakeOrder([FromBody] BodyParameterObject bodyParameter)
        {

            if (bodyParameter.PaymentTypeId == 1)//Knet
            {

                GetPointEntities db = new GetPointEntities();

                //Get Shooping Cart List to convert into order
                List<tbl_ShoppingCartItem> lstShopping = new List<tbl_ShoppingCartItem>();
                var PaymentCustomerInfo = db.tbl_Customer.Where(c => c.CustomerID == bodyParameter.CustomerId).FirstOrDefault();

                lstShopping = db.tbl_ShoppingCartItem.Where(c => c.CustomerID == bodyParameter.CustomerId && c.Closed == false).ToList();

                //Create order record
                tbl_Order Order = new tbl_Order();


                Order.CustomerID = bodyParameter.CustomerId;
                Order.OrderDate = DateTime.Now;

                Order.Total = lstShopping.Sum(c => c.ItemTotal);
                Order.Discount = bodyParameter.Used_PointsCredit;
                Order.DeliveryFees = 0;
                Order.Net = lstShopping.Sum(c => c.ItemTotal) - bodyParameter.Used_PointsCredit;
                Order.Remarks = "";
                Order.PaymentType = bodyParameter.PaymentTypeId;
                Order.CustomerAddressID = bodyParameter.CustomerAddressID;


                Order.UsedPoints = bodyParameter.Used_Points;
                Order.UsedPointsCredit = bodyParameter.Used_PointsCredit;
                Order.OrderStatusID = 4; //Pending Payment

                db.tbl_Order.Add(Order);

                foreach (var item in lstShopping)
                {
                    tbl_OrderItem OrderItem = new tbl_OrderItem();
                    OrderItem.ItemID = item.ItemID;
                    OrderItem.ItemColorID = item.ItemColorID;
                    OrderItem.ItemPrice = item.ItemPrice;
                    OrderItem.ItemSizeID = item.ItemSizeID;
                    OrderItem.ItemTotal = item.ItemTotal;
                    OrderItem.Qty = item.Qty;
                    OrderItem.Remarks = item.Remarks;
                    OrderItem.Points = item.Points;
                    OrderItem.PointsCredit = item.PointsCredit;

                    db.tbl_OrderItem.Add(OrderItem);
                }

                db.SaveChanges();


                TAPGateway inst = new TAPGateway();

                IRestResponse res = inst.GoPayLive2(Order.Net.ToString(), Order.OrderID.ToString(), PaymentCustomerInfo.CustomerFullName, PaymentCustomerInfo.CustomerEmail, bodyParameter.CustomerId.ToString());

                JObject json = JObject.Parse(res.Content);
                string str = inst.GetJArrayValue(json, "transaction");
                string strURL = inst.GetJArrayValue(JObject.Parse(str), "url");


                return CreatedAtRoute("DefaultApi", "The Order Is Created Successfully", strURL);

                //Close Old shopping cart items

              
            }
            else
            {
                GetPointEntities db = new GetPointEntities();

                //Get Shooping Cart List to convert into order
                List<tbl_ShoppingCartItem> lstShopping = new List<tbl_ShoppingCartItem>();
                var PaymentCustomerInfo = db.tbl_Customer.Where(c => c.CustomerID == bodyParameter.CustomerId).FirstOrDefault();

                lstShopping = db.tbl_ShoppingCartItem.Where(c => c.CustomerID == bodyParameter.CustomerId && c.Closed == false).ToList();

                //Create order record
                tbl_Order Order = new tbl_Order();


                Order.CustomerID = bodyParameter.CustomerId;
                Order.OrderDate = DateTime.Now;

                Order.Total = lstShopping.Sum(c => c.ItemTotal);
                Order.Discount = bodyParameter.Used_PointsCredit;
                Order.DeliveryFees = 0;
                Order.Net = lstShopping.Sum(c => c.ItemTotal) - bodyParameter.Used_PointsCredit;
                Order.Remarks = "";
                Order.OrderStatusID = 1;
                Order.PaymentType = bodyParameter.PaymentTypeId;
                Order.CustomerAddressID = bodyParameter.CustomerAddressID;


                Order.UsedPoints = bodyParameter.Used_Points;
                Order.UsedPointsCredit = bodyParameter.Used_PointsCredit;






                db.tbl_Order.Add(Order);

                foreach (var item in lstShopping)
                {
                    tbl_OrderItem OrderItem = new tbl_OrderItem();
                    OrderItem.ItemID = item.ItemID;
                    OrderItem.ItemColorID = item.ItemColorID;
                    OrderItem.ItemPrice = item.ItemPrice;
                    OrderItem.ItemSizeID = item.ItemSizeID;
                    OrderItem.ItemTotal = item.ItemTotal;
                    OrderItem.Qty = item.Qty;
                    OrderItem.Remarks = item.Remarks;
                    OrderItem.Points = item.Points;
                    OrderItem.PointsCredit = item.PointsCredit;

                    db.tbl_OrderItem.Add(OrderItem);
                }

                //Close Old shopping cart items

                foreach (var item in lstShopping)
                {
                    item.Closed = true;
                }
                db.SaveChanges();



                return CreatedAtRoute("DefaultApi", "The Order Is Created Successfully", "");
            }
        }




        public dynamic GetSliderImages()
        {

            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Slider.Select(l => new tbl_SliderDto
            {
                sliderId = l.SliderId,
                sliderTitle = l.SliderTitle,
                sliderPic = l.SliderPic,
                isActive = l.IsActive,
                itemID = l.ItemID,
                //tbl_Item = l.tbl_Item
            });

            return new { Data = lst };
        }

        public dynamic GetSliderImagesByItemID([FromUri] int id)
        {
            try
            {
                GetPointEntities db = new GetPointEntities();

                var lst = db.tbl_ItemImage.Where(c => c.ItemID == id).Select(l => new tbl_ItemImageDto
                {
                    tbl_ItemImageID = l.tbl_ItemImageID,
                    tbl_ItemImageTitle = l.tbl_ItemImageTitle,
                    tbl_ItemImagePic = l.tbl_ItemImagePic,
                    ItemID = l.ItemID,
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        public dynamic GetGroupsList()
        {
            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Groups.Select(l => new tbl_GroupsDto
            {
                GroupId = l.GroupId,
                GroupTitleAr = l.GroupTitleAr,
                GroupTitleEn = l.GroupTitleEn,
                Sort = l.Sort,
                IsActive = l.IsActive,
                GroupPic = l.GroupPic,
                //tbl_ItemGroup = l.tbl_ItemGroup.ToList()
            });

            return new { Data = lst };
        }
        public dynamic GetGroupItemViewList()
        {
            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Groups.Select(l => new
            {
                GroupId = l.GroupId,
                GroupItemInfo = db.VW_GroupItem.Where(c => c.GroupId == l.GroupId).Select(c => new
                {
                    c.GroupTitleAr,
                    c.GroupTitleEn,
                    c.GroupPic,
                    c.IsActive,
                    c.Sort,
                    c.ItemID,
                    c.ItemTitle,
                    c.ItemDescription,
                    c.ItemPrice,
                    c.ItemPic,
                    c.ItemSizeTitle,
                    c.ItemColorTitle,
                    c.ColorCode,
                    c.CategoryID,
                    c.CategoryTitleAr,
                    c.CategoryTitleEn
                }).ToList()
            });

            return new { Data = lst };
        }
        public dynamic GetGroupItemViewByGroupId([FromUri] int id)
        {

            try
            {

                GetPointEntities db = new GetPointEntities();

                var lst = db.VW_GroupItem.Where(c => c.GroupId == id).Select(l => new VW_GroupItemDto
                {
                    itemID = l.ItemID,
                    itemTitle = l.ItemTitle,
                    itemDescription = l.ItemDescription,
                    itemPrice = l.ItemPrice,
                    itemPic = l.ItemPic,
                    categoryTitleAr = l.CategoryTitleAr,
                    categoryTitleEn = l.CategoryTitleEn,
                    categoryID = l.CategoryID,
                    groupTitleAr = l.GroupTitleAr,
                    groupTitleEn = l.GroupTitleEn,
                    sort = l.Sort,
                    groupPic = l.GroupPic,
                    isActive = l.IsActive,
                    itemSizeTitle = l.ItemSizeTitle,
                    itemColorTitle = l.ItemColorTitle,
                    colorCode = l.ColorCode,
                    groupId = l.GroupId
                    //Areas = db.tbl_Area.Where(c => c.CityID == l.CityID).Select(c => new { c.AreaID, c.AreaTitle }).ToList()
                });

                return new { Data = lst };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public dynamic GetSysConfigDetails()
        {
            GetPointEntities db = new GetPointEntities();

            var lst = db.tbl_Systemconfig.Select(l => new tbl_SystemconfigDto
            {
                iD = l.ID,
                title = l.Title,
                info = l.Info,
                description = l.Description
            });

            return new { Data = lst };
        }
        public dynamic GetSearchResultOfItem([FromUri] string Searchtxt)
        {
            GetPointEntities db = new GetPointEntities();
            try
            {
                var lst = db.tbl_Item.Where(c => c.ItemTitle.Contains(Searchtxt)).Select(l => new tbl_ItemDto
                {
                    ItemID = l.ItemID,
                    CategoryID = l.CategoryID,
                    ItemTitle = l.ItemTitle,
                    ItemDescription = l.ItemDescription,
                    ItemPrice = l.ItemPrice,
                    ItemPic = l.ItemPic,
                    SupplierID = l.SupplierID,
                    SubCategoryId = l.SubCategoryId,
                    Points = l.Points,
                    PointsCredit = l.PointsCredit,
                    NoOfViews = l.NoOfViews,
                    //tbl_Category = l.tbl_Category,
                    //tbl_Supplier = l.tbl_Supplier,
                    //tbl_ItemColor = l.tbl_ItemColor.ToList(),
                    //tbl_ItemImage = l.tbl_ItemImage.ToList(),
                    //tbl_ItemSize = l.tbl_ItemSize.ToList(),
                    //tbl_OrderItem = l.tbl_OrderItem.ToList(),
                    //tbl_Slider = l.tbl_Slider.ToList(),
                    //tbl_ItemGroup = l.tbl_ItemGroup.ToList()
                }
           );

                return new
                {
                    Data = lst
                };
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }

        [HttpPost]
        public Boolean ForgetVerificationCode([FromUri] string CustomerEmail)
        {
            string subject = "Verification code";
            string body = "1234";
            string from = "yousef241997@gmail.com";
            string pass = "##yousef123";

            try
            {

                using (MailMessage message = new MailMessage(from, CustomerEmail))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential cred = new NetworkCredential(from, pass);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = cred;
                        smtp.Port = 587;
                        smtp.Send(message);
                        return true;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }










            //try
            //{
            //    string subject = "Verification code";
            //    string body = "1234";

            //    WebMail.Send(CustomerEmail, subject, body, null, null, null, true, null, null, null, null, null, null);
            //    return new HttpResponseMessage(HttpStatusCode.OK);
            //}
            //catch (Exception)
            //{
            //    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            //}


            //try
            //{
            //    // Gmail Address from where you send the mail 
            //    var fromAddress = "yousefahmed2497@gmail.com";
            //    // any address where the email will be sending 
            //    var toAddress = "ma3152 @fayoum.edu.eg";
            //    //Password of your gmail address 
            //    const string fromPassword = "##MMmm12zikaxp..";
            //    // Passing the values and make a email formate to display 
            //    string subject = "Verification code";
            //    string body = "From: " + "GetPoint" + "\n";
            //    body += "Email: " + fromAddress + "\n";
            //    body += "Subject: " + subject + "\n";
            //    body += "Question: \n" + "11111" + "\n";
            //    // smtp settings 
            //    var smtp = new System.Net.Mail.SmtpClient();
            //    {
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.Port = 587; smtp.EnableSsl = true;
            //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //        smtp.Timeout = 20000;
            //    }


            //    // Passing values to smtp object
            //    smtp.Send(fromAddress, toAddress, subject, body);
            //    return new HttpResponseMessage(HttpStatusCode.OK);

            //}
            //catch (Exception)
            //{

            //    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            //}


            //MailMessage mail = new MailMessage();
            //mail.From = new System.Net.Mail.MailAddress("yousefahmed2497@gmail.com");

            //// The important part -- configuring the SMTP client
            //SmtpClient smtp = new SmtpClient();
            //smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
            //smtp.EnableSsl = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            //smtp.UseDefaultCredentials = false; // [3] Changed this
            //smtp.Credentials = new NetworkCredential(mail.From, "##MMmm12zikaxp..");  // [4] Added this. Note, first parameter is NOT string.
            //smtp.Host = "smtp.gmail.com";

            ////recipient address
            //mail.To.Add(new MailAddress("ma3152 @fayoum.edu.eg"));

            ////Formatted mail body
            //mail.IsBodyHtml = true;
            //string st = "Test";

            //mail.Body = st;
            //smtp.Send(mail);
            //return new HttpResponseMessage(HttpStatusCode.BadRequest);


            //var client = new SmtpClient("smtp.gmail.com", 587)
            //{
            //    Credentials = new NetworkCredential("yousefahmed2497@gmail.com", "##MMmm12zikaxp.."),
            //    EnableSsl = true
            //};
            //try
            //{
            //    client.Send("yousefahmed2497@gmail.com", "ma3152 @fayoum.edu.eg", "Get Points Verification Code", "1122333");
            //    return new HttpResponseMessage(HttpStatusCode.OK);
            //}
            //catch (Exception)
            //{

            //    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            //}



            //string to = "kolarov3x@gmial.com"; //To address    
            //string from = "yousefahmed2497@gmail.com"; //From address    
            //MailMessage message = new MailMessage(from, to);

            //string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            //message.Subject = "Sending Email Using Asp.Net & C#";
            //message.Body = mailbody;
            //message.BodyEncoding = Encoding.UTF8;
            //message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            //System.Net.NetworkCredential basicCredential1 = new
            //System.Net.NetworkCredential("yousefahmed2497@gmail.com", "##MMmm12zikaxp..");
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.Credentials = basicCredential1;

            //try
            //{
            //    client.Send(message);
            //    return new
            //    {
            //        Data = "Code Sent Successfully"
            //    };
            //}

            //catch (Exception ex)
            //{
            //    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            //}

        }

        [HttpPost]
        public Boolean SendEmailUsingGmail()
        {
            //string Name = "yousef";
            string EmailAddress = "yousef241997@gmail.com";
            //string Subject = "Verification";
            //string Message = "123";
            string To = "yousefahmed2497@gmail.com";
            string Password = "##yousef123";

            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();
                //Add your email address to the recipients
                msg.To.Add(To);
                //Configure the address we are sending the mail from
                MailAddress address = new MailAddress(EmailAddress);
                msg.From = address;
                msg.Subject = "anything";
                msg.Body = "anything";

                //Configure an SmtpClient to send the mail.
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential(EmailAddress, Password);
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);

                //Display some feedback to the user to let them know it was sent
                return true;
            }
            catch (Exception ex)
            {
                //If the message failed at some point, let the user know
                return false;
                //"Your message failed to send, please try again."
            }


        }

 


        [HttpPost]
        public dynamic UploadImage([FromBody] ImageModel base64image, [FromUri] int CustomerID)//or (Ima a) ,it works too
        {
            GetPointEntities db = new GetPointEntities();
            var custInfo = db.tbl_Customer.Where(c => c.CustomerID == CustomerID).FirstOrDefault();

            String path = HttpContext.Current.Server.MapPath("~/Images"); //Path
            string imageName = Guid.NewGuid() + ".jpg";
            
            // update customer profile picture name
            custInfo.CustomerProfilePic = imageName;
            db.Entry(custInfo).State = EntityState.Modified;
            db.SaveChanges();

            //set the image path
            string imgPath = Path.Combine(path, imageName);
            byte[] imageBytes = Convert.FromBase64String(base64image.base64Image);

            File.WriteAllBytes(imgPath, imageBytes);

            return new
            {
                Data = imageName
            };
        }


        [HttpPost]
        public Boolean SendEmail()
        {
            string to = "yousefahmed2497@gmail.com"; //To address    
            string from = "yousef241997@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("yousef241997", "##yousef123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }


        [HttpPost]
        public dynamic sendEmailViaWebApi()
        {
            try
            {
                string subject = "Email Subject";
                string body = "Email body";
                string FromMail = "yousef241997@gmail.com";
                string emailTo = "yousefahmed2497@gmail.com";
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("yousef241997@gmail.com", "##yousef123");
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        [HttpGet]
        public dynamic GetItemsInShoppingCart([FromUri] int CustomerID)
        {
            GetPointEntities db = new GetPointEntities();
            var Info = db.tbl_ShoppingCartItem.Where(c => c.CustomerID == CustomerID && c.Closed == false).Count();

            return new
            {
                Data = Info
            };

        }

    }
}