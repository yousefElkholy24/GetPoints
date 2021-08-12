using Newtonsoft.Json.Linq;
using PaymentGateway;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin
{
    public partial class TestPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int CustomerID = 139;
            int Used_PointsCredit = 0;
            int PaymentTypeId = 1;
            int CustomerAddressID = 0;
            int Used_Points = 0;

            GetPointEntities db = new GetPointEntities();

            //Get Shooping Cart List to convert into order
            List<tbl_ShoppingCartItem> lstShopping = new List<tbl_ShoppingCartItem>();
            var PaymentCustomerInfo = db.tbl_Customer.Where(c => c.CustomerID == CustomerID).FirstOrDefault();

            lstShopping = db.tbl_ShoppingCartItem.Where(c => c.CustomerID == CustomerID && c.Closed == false).ToList();

            //Create order record
            tbl_Order Order = new tbl_Order();


            Order.CustomerID = CustomerID;
            Order.OrderDate = DateTime.Now;

            Order.Total = lstShopping.Sum(c => c.ItemTotal);
            Order.Discount = Used_PointsCredit;
            Order.DeliveryFees = 0;
            Order.Net = lstShopping.Sum(c => c.ItemTotal) - Used_PointsCredit;
            Order.Remarks = "";
            Order.PaymentType = PaymentTypeId;
            Order.CustomerAddressID = CustomerAddressID;


            Order.UsedPoints = Used_Points;
            Order.UsedPointsCredit = Used_PointsCredit;
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
            IRestResponse res = inst.GoPayLive2(Order.Net.ToString(), Order.OrderID.ToString(), PaymentCustomerInfo.CustomerFullName, PaymentCustomerInfo.CustomerEmail, CustomerID.ToString());

            //JObject json = JObject.Parse(res);
            //string str = inst.GetJArrayValue(json, "transaction");
            //string strURL = inst.GetJArrayValue(JObject.Parse(str), "url");

            //Response.Redirect(strURL);

            Response.Write(res.ErrorException);
        }
    }
}