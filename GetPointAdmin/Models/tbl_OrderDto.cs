using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_OrderDto
    {
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

        public tbl_CustomerDto tbl_Customer { get; set; }

        public tbl_PaymentTypeDto tbl_PaymentType { get; set; }

        public ICollection<tbl_OrderItem> tbl_OrderItem { get; set; }

        public static tbl_OrderDto FromModel(tbl_Order model)
        {
            return new tbl_OrderDto()
            {
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
                tbl_Customer = tbl_CustomerDto.FromModel(model.tbl_Customer), 
                tbl_PaymentType = tbl_PaymentTypeDto.FromModel(model.tbl_PaymentType), 
                tbl_OrderItem = model.tbl_OrderItem, 
            }; 
        }

        public tbl_Order ToModel()
        {
            return new tbl_Order()
            {
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
                tbl_Customer = tbl_Customer.ToModel(), 
                tbl_PaymentType = tbl_PaymentType.ToModel(), 
                tbl_OrderItem = tbl_OrderItem, 
            }; 
        }
    }
}