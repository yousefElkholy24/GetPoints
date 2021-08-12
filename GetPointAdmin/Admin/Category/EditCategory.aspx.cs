using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Category
{
    public partial class EditCategory : System.Web.UI.Page
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
                    tbl_Category Record = dbContext.tbl_Category.Where(c => c.CategoryID == RecordID).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitleAr.Text = Record.CategoryTitleAr;
                        txtTitleEn.Text = Record.CategoryTitleEn;
                        txtDescription.Text = Record.CategoryDescription;
                        txtOrder.Value = Record.CategorySort;
                        chkActive.Value = Record.CategoryIsActive;

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

            GetPointEntities dbContext = new GetPointEntities();
            int RecordID = Convert.ToInt32(Request.QueryString["id"]);
            tbl_Category Record = dbContext.tbl_Category.Where(c => c.CategoryID == RecordID).FirstOrDefault();

            Record.CategoryTitleAr = txtTitleAr.Text;
            Record.CategoryTitleEn = txtTitleEn.Text;
            Record.CategorySort = Convert.ToInt32(txtOrder.Value);
            Record.CategoryIsActive = chkActive.Checked;
            Record.CategoryDescription = txtDescription.Text;

            if (F1.UploadedFiles[0].FileName != "")
            {
                string fileName = F1.UploadedFiles[0].FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
                string resultFileUrl = "~/Images/" + resultFileName;
                string resultFilePath = MapPath(resultFileUrl);
                F1.UploadedFiles[0].SaveAs(resultFilePath);


                Record.CategoryPic = resultFileName;
            }




            dbContext.Entry(Record).State = EntityState.Modified;
            dbContext.SaveChanges();

            Response.Redirect("~/Admin/Category/CategoryList.aspx");
        }
    }
}