using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Supplier
{
    public partial class EditSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                RetrieveData();
            } 
        }


        private void RetrieveData()
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                if(Request.QueryString["id"]!=null)
                {
                    int RecordId = Convert.ToInt32(Request.QueryString["id"]);
                    tbl_Supplier Record = db.tbl_Supplier.Where(c => c.SupplierID == RecordId).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitle.Text = Record.SupplierTitle;
                        txtEmail.Text = Record.SupplierEmail;
                        txtContact.Text = Record.SupplierContactPerson;
                        txtContactMobile.Text = Record.SupplierContactMobile;
                        txtMobile.Text = Record.SupplierMobile;
                        txtTelephone.Text = Record.SupplierTele;
                        chkActive.Value = Record.SupplierIsActive;

                    }
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        protected void btnSave_Click(object sender, EventArgs e)
        {


            GetPointEntities db = new GetPointEntities();
            var RecordId = Convert.ToInt32(Request.QueryString["id"]);
            tbl_Supplier Record = db.tbl_Supplier.Where(c => c.SupplierID == RecordId).FirstOrDefault();

            Record.SupplierTitle = txtTitle.Text;
            Record.SupplierEmail = txtEmail.Text;
            Record.SupplierContactPerson = txtContact.Text;
            Record.SupplierContactMobile = txtContactMobile.Text;
            Record.SupplierMobile = txtMobile.Text;
            Record.SupplierTele = txtTelephone.Text;
            Record.SupplierIsActive = chkActive.Checked;


            db.Entry(Record).State = EntityState.Modified;
            db.SaveChanges();

            Response.Redirect("~/Admin/Supplier/SuppliersList.aspx");
        }
    }
}