using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class VW_ShoppingCartDto
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

        public string ItemTitle { get; set; }

        public string ItemPic { get; set; }

        public Nullable<double> Expr1 { get; set; }

        public string ItemDescription { get; set; }

        public string ItemSizeTitle { get; set; }

        public string ItemColorTitle { get; set; }

        public Nullable<double> PointsCredit { get; set; }

        public Nullable<double> Points { get; set; }

        public static VW_ShoppingCartDto FromModel(VW_ShoppingCart model)
        {
            return new VW_ShoppingCartDto()
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
                ItemTitle = model.ItemTitle, 
                ItemPic = model.ItemPic, 
                Expr1 = model.Expr1, 
                ItemDescription = model.ItemDescription, 
                ItemSizeTitle = model.ItemSizeTitle, 
                ItemColorTitle = model.ItemColorTitle, 
                PointsCredit = model.PointsCredit, 
                Points = model.Points, 
            }; 
        }

        public VW_ShoppingCart ToModel()
        {
            return new VW_ShoppingCart()
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
                ItemTitle = ItemTitle, 
                ItemPic = ItemPic, 
                Expr1 = Expr1, 
                ItemDescription = ItemDescription, 
                ItemSizeTitle = ItemSizeTitle, 
                ItemColorTitle = ItemColorTitle, 
                PointsCredit = PointsCredit, 
                Points = Points, 
            }; 
        }
    }
}