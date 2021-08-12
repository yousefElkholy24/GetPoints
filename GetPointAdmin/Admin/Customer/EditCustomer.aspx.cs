using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Customer
{
    public partial class EditCustomer : System.Web.UI.Page
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
                GetPointEntities db = new GetPointEntities();

                if (Request.QueryString["id"] != null)
                {
                    var RecordID = Convert.ToInt32(Request.QueryString["id"]);

                    tbl_Customer Record = db.tbl_Customer.Where(c => c.CustomerID == RecordID).FirstOrDefault();
                    if(Record!=null)
                    { 
                    txtFullName.Text = Record.CustomerFullName;
                    txtEmail.Text = Record.CustomerEmail;
                    txtMobile.Text = Record.CustomerMobile;
                    txtUser.Text = Record.CustomerUserName;
                    txtTelephone.Text = Record.CustomerTele;
                    chkActive.Value = Record.CustomerIsActive;
                    chkVerified.Value = Record.CustomerIsVerified;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {

            GetPointEntities db = new GetPointEntities();

            int RecordID = Convert.ToInt32(Request.QueryString["id"]);
            tbl_Customer Record = db.tbl_Customer.Where(c => c.CustomerID == RecordID).FirstOrDefault();

            Record.CustomerFullName = txtFullName.Text;
            Record.CustomerEmail = txtEmail.Text;
            Record.CustomerMobile = txtMobile.Text;
            Record.CustomerTele = txtTelephone.Text;
            Record.CustomerUserName = txtUser.Text;
            Record.CustomerIsActive = chkActive.Checked;
            Record.CustomerIsVerified = chkVerified.Checked;

            if (F2.UploadedFiles[0].FileName != "")
            {
                string fileName = F2.UploadedFiles[0].FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
                string resultFileUrl = "~/Images/" + resultFileName;
                string resultFilePath = MapPath(resultFileUrl);
                F2.UploadedFiles[0].SaveAs(resultFilePath);


                Record.CustomerProfilePic = resultFileName;
            }


            db.Entry(Record).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}