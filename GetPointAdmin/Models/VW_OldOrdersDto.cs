using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class VW_OldOrdersDto
    {
        public int ItemID { get; set; }

        public int CategoryID { get; set; }

        public string ItemTitle { get; set; }

        public string ItemDescription { get; set; }

        public Nullable<double> ItemPrice { get; set; }

        public string ItemPic { get; set; }

        public int SupplierID { get; set; }

        public Nullable<int> SubCategoryId { get; set; }

        public Nullable<double> Points { get; set; }

        public Nullable<double> PointsCredit { get; set; }

        public Nullable<int> NoOfViews { get; set; }

        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public Nullable<System.DateTime> OrderDate { get; set; }

        public Nullable<double> Total { get; set; }

        public Nullable<double> Discount { get; set; }

        public Nullable<double> DeliveryFees { get; set; }

        public Nullable<double> Net { get; set; }

        public string Remarks { get; set; }

        public Nullable<int> OrderStatusID { get; set; }

        public Nullable<int> PaymentType { get; set; }

        public Nullable<int> CustomerAddressID { get; set; }

        public Nullable<double> UsedPoints { get; set; }

        public Nullable<double> UsedPointsCredit { get; set; }

        public Nullable<double> Qty { get; set; }

        public Nullable<int> ItemColorID { get; set; }

        public Nullable<int> ItemSizeID { get; set; }

        public static VW_OldOrdersDto FromModel(VW_OldOrders model)
        {
            return new VW_OldOrdersDto()
            {
                ItemID = model.ItemID, 
                CategoryID = model.CategoryID, 
                ItemTitle = model.ItemTitle, 
                ItemDescription = model.ItemDescription, 
                ItemPrice = model.ItemPrice, 
                ItemPic = model.ItemPic, 
                SupplierID = model.SupplierID, 
                SubCategoryId = model.SubCategoryId, 
                Points = model.Points, 
                PointsCredit = model.PointsCredit, 
                NoOfViews = model.NoOfViews, 
                OrderID = model.OrderID, 
                CustomerID = model.CustomerID, 
                OrderDate = model.OrderDate, 
                Total = model.Total, 
                Discount = model.Discount, 
                DeliveryFees = model.DeliveryFees, 
                Net = model.Net, 
                Remarks = model.Remarks, 
                OrderStatusID = model.OrderStatusID, 
                PaymentType = model.PaymentType, 
                CustomerAddressID = model.CustomerAddressID, 
                UsedPoints = model.UsedPoints, 
                UsedPointsCredit = model.UsedPointsCredit, 
                Qty = model.Qty, 
                ItemColorID = model.ItemColorID, 
                ItemSizeID = model.ItemSizeID, 
            }; 
        }

        public VW_OldOrders ToModel()
        {
            return new VW_OldOrders()
            {
                ItemID = ItemID, 
                CategoryID = CategoryID, 
                ItemTitle = ItemTitle, 
                ItemDescription = ItemDescription, 
                ItemPrice = ItemPrice, 
                ItemPic = ItemPic, 
                SupplierID = SupplierID, 
                SubCategoryId = SubCategoryId, 
                Points = Points, 
                PointsCredit = PointsCredit, 
                NoOfViews = NoOfViews, 
                OrderID = OrderID, 
                CustomerID = CustomerID, 
                OrderDate = OrderDate, 
                Total = Total, 
                Discount = Discount, 
                DeliveryFees = DeliveryFees, 
                Net = Net, 
                Remarks = Remarks, 
                OrderStatusID = OrderStatusID, 
                PaymentType = PaymentType, 
                CustomerAddressID = CustomerAddressID, 
                UsedPoints = UsedPoints, 
                UsedPointsCredit = UsedPointsCredit, 
                Qty = Qty, 
                ItemColorID = ItemColorID, 
                ItemSizeID = ItemSizeID, 
            }; 
        }
    }
}