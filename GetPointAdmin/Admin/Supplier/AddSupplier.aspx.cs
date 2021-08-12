using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Supplier
{
    public partial class AddSuppplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetPointEntities dbContext = new GetPointEntities();
            tbl_Supplier NewRecord = new tbl_Supplier();

            NewRecord.SupplierTitle = txtTitle.Text;
            NewRecord.SupplierEmail = txtEmail.Text;
            NewRecord.SupplierContactPerson = txtContact.Text;
            NewRecord.SupplierContactMobile = txtContactMobile.Text;
            NewRecord.SupplierMobile = txtMobile.Text;

            NewRecord.SupplierTele = txtTelephone.Text;
            NewRecord.SupplierIsActive = chkActive.Checked;


      
            dbContext.tbl_Supplier.Add(NewRecord);
            dbContext.SaveChanges();

            Response.Redirect("~/Admin/Supplier/SuppliersList.aspx");
        }
    }
}