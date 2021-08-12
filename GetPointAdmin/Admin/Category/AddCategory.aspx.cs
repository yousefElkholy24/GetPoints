using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Category
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
         
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //txtTitleAr.Text
            GetPointEntities dbContext = new GetPointEntities();
            tbl_Category NewRecord = new tbl_Category();

            NewRecord.CategoryTitleAr = txtTitleAr.Text;
            NewRecord.CategoryTitleEn= txtTitleEn.Text;
            NewRecord.CategorySort = Convert.ToInt32( txtOrder.Value);
            NewRecord.CategoryIsActive =chkActive.Checked;
            NewRecord.CategoryDescription=txtDescription.Text;


            if(F1.UploadedFiles[0].FileName !="")
            {

            
            string fileName =F1.UploadedFiles[0].FileName;
            string resultExtension = Path.GetExtension(fileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = "~/Images/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            F1.UploadedFiles[0].SaveAs(resultFilePath);
            NewRecord.CategoryPic= resultFileName;
            }

            dbContext.tbl_Category.Add(NewRecord);
            dbContext.SaveChanges();

            Response.Redirect("~/Admin/Category/CategoryList.aspx");
        }
    }
}