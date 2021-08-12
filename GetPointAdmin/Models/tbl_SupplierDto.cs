using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_SupplierDto
    {
        public int SupplierID { get; set; }

        public string SupplierTitle { get; set; }

        public Nullable<bool> SupplierIsActive { get; set; }

        public string SupplierEmail { get; set; }

        public string SupplierMobile { get; set; }

        public string SupplierTele { get; set; }

        public string SupplierContactPerson { get; set; }

        public string SupplierContactMobile { get; set; }

        public ICollection<tbl_Item> tbl_Item { get; set; }

        public static tbl_SupplierDto FromModel(tbl_Supplier model)
        {
            return new tbl_SupplierDto()
            {
                SupplierID = model.SupplierID, 
                SupplierTitle = model.SupplierTitle, 
                SupplierIsActive = model.SupplierIsActive, 
                SupplierEmail = model.SupplierEmail, 
                SupplierMobile = model.SupplierMobile, 
                SupplierTele = model.SupplierTele, 
                SupplierContactPerson = model.SupplierContactPerson, 
                SupplierContactMobile = model.SupplierContactMobile, 
                tbl_Item = model.tbl_Item, 
            }; 
        }

        public tbl_Supplier ToModel()
        {
            return new tbl_Supplier()
            {
                SupplierID = SupplierID, 
                SupplierTitle = SupplierTitle, 
                SupplierIsActive = SupplierIsActive, 
                SupplierEmail = SupplierEmail, 
                SupplierMobile = SupplierMobile, 
                SupplierTele = SupplierTele, 
                SupplierContactPerson = SupplierContactPerson, 
                SupplierContactMobile = SupplierContactMobile, 
                tbl_Item = tbl_Item, 
            }; 
        }
    }
}