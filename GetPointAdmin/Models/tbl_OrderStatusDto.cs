using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_OrderStatusDto
    {
        public int OrderStatusID { get; set; }

        public string OrderStatusTitle { get; set; }

        public static tbl_OrderStatusDto FromModel(tbl_OrderStatus model)
        {
            return new tbl_OrderStatusDto()
            {
                OrderStatusID = model.OrderStatusID, 
                OrderStatusTitle = model.OrderStatusTitle, 
            }; 
        }

        public tbl_OrderStatus ToModel()
        {
            return new tbl_OrderStatus()
            {
                OrderStatusID = OrderStatusID, 
                OrderStatusTitle = OrderStatusTitle, 
            }; 
        }
    }
}