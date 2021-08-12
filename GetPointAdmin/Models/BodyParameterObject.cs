using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPointAdmin.Models.Dto
{
    public class BodyParameterObject
    {
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }

        public int CustomerAddressID { get; set; }
        public double? Used_PointsCredit { get;  set; }
        public double? Used_Points { get;  set; }
    }
}