//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GetPointAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_CustomerAddress
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
    
        public virtual tbl_Customer tbl_Customer { get; set; }
    }
}
