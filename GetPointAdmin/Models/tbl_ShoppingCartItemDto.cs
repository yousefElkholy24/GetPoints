using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_ShoppingCartItemDto
    {
        public int ShoppingCartItemID { get; set; }

        public Nullable<int> ItemID { get; set; }

        public Nullable<double> Qty { get; set; }

        public Nullable<double> ItemPrice { get; set; }

        public Nullable<double> ItemTotal { get; set; }

        public Nullable<int> ItemColorID { get; set; }

        public Nullable<int> ItemSizeID { get; set; }

        public string Remarks { get; set; }

        public Nullable<int> CustomerID { get; set; }

        public Nullable<bool> Closed { get; set; }

        public Nullable<double> Points { get; set; }

        public Nullable<double> PointsCredit { get; set; }

        public static tbl_ShoppingCartItemDto FromModel(tbl_ShoppingCartItem model)
        {
            return new tbl_ShoppingCartItemDto()
            {
                ShoppingCartItemID = model.ShoppingCartItemID, 
                ItemID = model.ItemID, 
                Qty = model.Qty, 
                ItemPrice = model.ItemPrice, 
                ItemTotal = model.ItemTotal, 
                ItemColorID = model.ItemColorID, 
                ItemSizeID = model.ItemSizeID, 
                Remarks = model.Remarks, 
                CustomerID = model.CustomerID, 
                Closed = model.Closed, 
                Points = model.Points, 
                PointsCredit = model.PointsCredit, 
            }; 
        }

        public tbl_ShoppingCartItem ToModel()
        {
            return new tbl_ShoppingCartItem()
            {
                ShoppingCartItemID = ShoppingCartItemID, 
                ItemID = ItemID, 
                Qty = Qty, 
                ItemPrice = ItemPrice, 
                ItemTotal = ItemTotal, 
                ItemColorID = ItemColorID, 
                ItemSizeID = ItemSizeID, 
                Remarks = Remarks, 
                CustomerID = CustomerID, 
                Closed = Closed, 
                Points = Points, 
                PointsCredit = PointsCredit, 
            }; 
        }
    }
}