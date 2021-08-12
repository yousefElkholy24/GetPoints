using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_CustomerAddressDto
    {
        public int CustomerAddressID { get; set; }

        public string CustomerAddressTitle { get; set; }

        public Nullable<int> CustomerAddressCityID { get; set; }

        public Nullable<int> CustomerAddressAreaID { get; set; }

        public string CustomerAddressDetails { get; set; }

        public int CustomerID { get; set; }

        public string CustomerAddressLat { get; set; }

        public string CustomerAddressLng { get; set; }

        public string CustomerAddressMapLocation { get; set; }

        public tbl_CustomerDto tbl_Customer { get; set; }

        public static tbl_CustomerAddressDto FromModel(tbl_CustomerAddress model)
        {
            return new tbl_CustomerAddressDto()
            {
                CustomerAddressID = model.CustomerAddressID, 
                CustomerAddressTitle = model.CustomerAddressTitle, 
                CustomerAddressCityID = model.CustomerAddressCityID, 
                CustomerAddressAreaID = model.CustomerAddressAreaID, 
                CustomerAddressDetails = model.CustomerAddressDetails, 
                CustomerID = model.CustomerID, 
                CustomerAddressLat = model.CustomerAddressLat, 
                CustomerAddressLng = model.CustomerAddressLng, 
                CustomerAddressMapLocation = model.CustomerAddressMapLocation, 
                tbl_Customer = tbl_CustomerDto.FromModel(model.tbl_Customer), 
            }; 
        }

        public tbl_CustomerAddress ToModel()
        {
            return new tbl_CustomerAddress()
            {
                CustomerAddressID = CustomerAddressID, 
                CustomerAddressTitle = CustomerAddressTitle, 
                CustomerAddressCityID = CustomerAddressCityID, 
                CustomerAddressAreaID = CustomerAddressAreaID, 
                CustomerAddressDetails = CustomerAddressDetails, 
                CustomerID = CustomerID, 
                CustomerAddressLat = CustomerAddressLat, 
                CustomerAddressLng = CustomerAddressLng, 
                CustomerAddressMapLocation = CustomerAddressMapLocation, 
                tbl_Customer = tbl_Customer.ToModel(), 
            }; 
        }
    }
}