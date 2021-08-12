using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Customer
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

  
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();

            tbl_Customer NewCustomer = new tbl_Customer();

            NewCustomer.CustomerEmail = txtEmail.Text;
            NewCustomer.CustomerFullName = txtFullName.Text;
            NewCustomer.CustomerUserName = txtUser.Text;
            NewCustomer.CustomerTele = txtTelephone.Text;
            NewCustomer.CustomerMobile = txtMobile.Text;
            NewCustomer.CustomerPassword = txtPassword.Text;
            NewCustomer.CustomerIsActive = chkActive.Checked;
            NewCustomer.CustomerIsVerified = chkVerified.Checked;

            if(F2.UploadedFiles[0].FileName!="")
            {

            
            string fileName = F2.UploadedFiles[0].FileName;
            string resultExtension = Path.GetExtension(fileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = "~/Images/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            F2.UploadedFiles[0].SaveAs(resultFilePath);
            NewCustomer.CustomerProfilePic = resultFileName;
            }

            db.tbl_Customer.Add(NewCustomer);
            db.SaveChanges();
            Response.Redirect("~/Admin/Customer/CustomersList.aspx");
        }
    }
}