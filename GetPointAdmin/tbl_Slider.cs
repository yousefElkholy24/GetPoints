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
    
    public partial class tbl_Slider
    {
        public int SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderPic { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> ItemID { get; set; }
    
        public virtual tbl_Item tbl_Item { get; set; }
    }
}
