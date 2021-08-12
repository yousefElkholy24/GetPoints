using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Customer
{
    public partial class DeleteCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                    tbl_Customer Record = dbContext.tbl_Customer.Where(c => c.CustomerID == RecordID).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtFullName.Text = Record.CustomerFullName;
                        txtEmail.Text = Record.CustomerEmail;
                        txtUser.Text = Record.CustomerUserName;
                        chkActive.Value = Record.CustomerIsActive;
                        chkVerfied.Value = Record.CustomerIsVerified;
                        txtMobile.Text = Record.CustomerMobile;
                        txtTele.Text = Record.CustomerTele;

                        Image.ImageUrl = "~/Images/" + Record.CustomerProfilePic;
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
                     //Delete Record

                        var ItemToDelete = dbContext.tbl_Customer.Where(c => c.CustomerID == RecordID).FirstOrDefault();

                        if (ItemToDelete == null)
                        {
                            lblError.Text = "Can't Delete Customer, Something happened";
                            lblError.Visible = true;
                        }
                        else
                        {
                            dbContext.tbl_Customer.Remove(ItemToDelete);
                            dbContext.SaveChanges();
                            Response.Redirect("~/admin/Customer/CustomersList.aspx");
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