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
    
    public partial class tbl_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Order()
        {
            this.tbl_OrderItem = new HashSet<tbl_OrderItem>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_OrderItem> tbl_OrderItem { get; set; }
        public virtual tbl_Customer tbl_Customer { get; set; }
        public virtual tbl_PaymentType tbl_PaymentType { get; set; }
    }
}