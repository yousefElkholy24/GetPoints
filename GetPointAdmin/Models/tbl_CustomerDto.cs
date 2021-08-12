using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_CustomerDto
    {
        public int CustomerID { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerUserName { get; set; }

        public string CustomerPassword { get; set; }

        public Nullable<bool> CustomerIsActive { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerTele { get; set; }

        public Nullable<bool> CustomerIsVerified { get; set; }

        public string CustomerProfilePic { get; set; }

        public ICollection<tbl_CustomerAddress> tbl_CustomerAddress { get; set; }

        public ICollection<tbl_Order> tbl_Order { get; set; }

        public static tbl_CustomerDto FromModel(tbl_Customer model)
        {
            return new tbl_CustomerDto()
            {
                CustomerID = model.CustomerID, 
                CustomerFullName = model.CustomerFullName, 
                CustomerUserName = model.CustomerUserName, 
                CustomerPassword = model.CustomerPassword, 
                CustomerIsActive = model.CustomerIsActive, 
                CustomerEmail = model.CustomerEmail, 
                CustomerMobile = model.CustomerMobile, 
                CustomerTele = model.CustomerTele, 
                CustomerIsVerified = model.CustomerIsVerified, 
                CustomerProfilePic = model.CustomerProfilePic, 
                tbl_CustomerAddress = model.tbl_CustomerAddress, 
                tbl_Order = model.tbl_Order, 
            }; 
        }

        public tbl_Customer ToModel()
        {
            return new tbl_Customer()
            {
                CustomerID = CustomerID, 
                CustomerFullName = CustomerFullName, 
                CustomerUserName = CustomerUserName, 
                CustomerPassword = CustomerPassword, 
                CustomerIsActive = CustomerIsActive, 
                CustomerEmail = CustomerEmail, 
                CustomerMobile = CustomerMobile, 
                CustomerTele = CustomerTele, 
                CustomerIsVerified = CustomerIsVerified, 
                CustomerProfilePic = CustomerProfilePic, 
                tbl_CustomerAddress = tbl_CustomerAddress, 
                tbl_Order = tbl_Order, 
            }; 
        }
    }
}