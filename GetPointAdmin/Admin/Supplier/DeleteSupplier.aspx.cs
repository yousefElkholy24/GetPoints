using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Supplier
{
    public partial class DeleteSupplier : System.Web.UI.Page
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
                GetPointEntities dbContext = new GetPointEntities();
                if (Request.QueryString["id"] != null)
                {
                    int RecordID = Convert.ToInt32(Request.QueryString["id"]);
                    tbl_Supplier Record = dbContext.tbl_Supplier.Where(c => c.SupplierID == RecordID).FirstOrDefault();


                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitle.Text = Record.SupplierTitle;
                        txtEmail.Text = Record.SupplierEmail;
                        txtContactMobile.Text = Record.SupplierContactMobile;
                        txtContact.Value = Record.SupplierContactPerson;
                        chkActive.Value = Record.SupplierIsActive;
                        txtTelephone.Value = Record.SupplierTele;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    int RecordID = Convert.ToInt32(Request.QueryString["id"]);
                    GetPointEntities dbContext = new GetPointEntities();
                    bool HasItems = dbContext.tbl_Item.Any(c => c.SupplierID == RecordID);

                    if (HasItems)
                    {
                        //Show Error Message

                        lblError.Text = "Can't Delete Category, it has items";
                        lblError.Visible = true;
                    }
                    else
                    {
                        //Delete Record

                        var ItemToDelete = dbContext.tbl_Supplier.Where(c => c.SupplierID == RecordID).FirstOrDefault();

                        if (ItemToDelete == null)
                        {
                            lblError.Text = "Can't Delete Supplier, Something happened";
                            lblError.Visible = true;
                        }
                        else
                        {
                            dbContext.tbl_Supplier.Remove(ItemToDelete);
                            dbContext.SaveChanges();
                            Response.Redirect("~/admin/Supplier/SuppliersList.aspx");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}