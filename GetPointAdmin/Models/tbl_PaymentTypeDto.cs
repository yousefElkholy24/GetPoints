using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_PaymentTypeDto
    {
        public int PaymentTypeID { get; set; }

        public string PaymentTypeTitleAr { get; set; }

        public string PaymentTypeTitleEn { get; set; }

        public ICollection<tbl_Order> tbl_Order { get; set; }

        public static tbl_PaymentTypeDto FromModel(tbl_PaymentType model)
        {
            return new tbl_PaymentTypeDto()
            {
                PaymentTypeID = model.PaymentTypeID, 
                PaymentTypeTitleAr = model.PaymentTypeTitleAr, 
                PaymentTypeTitleEn = model.PaymentTypeTitleEn, 
                tbl_Order = model.tbl_Order, 
            }; 
        }

        public tbl_PaymentType ToModel()
        {
            return new tbl_PaymentType()
            {
                PaymentTypeID = PaymentTypeID, 
                PaymentTypeTitleAr = PaymentTypeTitleAr, 
                PaymentTypeTitleEn = PaymentTypeTitleEn, 
                tbl_Order = tbl_Order, 
            }; 
        }
    }
}