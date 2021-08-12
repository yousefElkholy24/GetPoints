using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_OrderItemDto
    {
        public int OrderItemID { get; set; }

        public Nullable<int> ItemID { get; set; }

        public int OrderID { get; set; }

        public Nullable<double> Qty { get; set; }

        public Nullable<double> ItemPrice { get; set; }

        public Nullable<double> ItemTotal { get; set; }

        public Nullable<int> ItemColorID { get; set; }

        public Nullable<int> ItemSizeID { get; set; }

        public string Remarks { get; set; }

        public Nullable<double> Points { get; set; }

        public Nullable<double> PointsCredit { get; set; }

        public tbl_ItemDto tbl_Item { get; set; }

        public tbl_OrderDto tbl_Order { get; set; }

        public static tbl_OrderItemDto FromModel(tbl_OrderItem model)
        {
            return new tbl_OrderItemDto()
            {
                OrderItemID = model.OrderItemID, 
                ItemID = model.ItemID, 
                OrderID = model.OrderID, 
                Qty = model.Qty, 
                ItemPrice = model.ItemPrice, 
                ItemTotal = model.ItemTotal, 
                ItemColorID = model.ItemColorID, 
                ItemSizeID = model.ItemSizeID, 
                Remarks = model.Remarks, 
                Points = model.Points, 
                PointsCredit = model.PointsCredit, 
                tbl_Item = tbl_ItemDto.FromModel(model.tbl_Item), 
                tbl_Order = tbl_OrderDto.FromModel(model.tbl_Order), 
            }; 
        }

        public tbl_OrderItem ToModel()
        {
            return new tbl_OrderItem()
            {
                OrderItemID = OrderItemID, 
                ItemID = ItemID, 
                OrderID = OrderID, 
                Qty = Qty, 
                ItemPrice = ItemPrice, 
                ItemTotal = ItemTotal, 
                ItemColorID = ItemColorID, 
                ItemSizeID = ItemSizeID, 
                Remarks = Remarks, 
                Points = Points, 
                PointsCredit = PointsCredit, 
                tbl_Item = tbl_Item.ToModel(), 
                tbl_Order = tbl_Order.ToModel(), 
            }; 
        }
    }
}