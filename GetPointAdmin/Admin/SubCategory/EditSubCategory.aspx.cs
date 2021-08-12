using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.SubCategory
{
    public partial class EditSubCategory : System.Web.UI.Page
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
                    int RecordId = Convert.ToInt32(Request.QueryString["id"]);
                    tbl_SubCategory Record = db.tbl_SubCategory.Where(c => c.SubCategoryID == RecordId).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues

                        txtDescription.Text = Record.SubCategoryDescription;
                        txtTitleAr.Text = Record.SubCategoryTitleAr;
                        txtTitleEn.Text = Record.SubCategoryTitleEn;

                        CatID.Value = Record.CategoryID;
                        chkActive.Value = Record.SubCategoryIsActive;
                        chkSort.Value = Record.SubCategorySort;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


        protected void UpdateSub_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();
            int RecordId = Convert.ToInt32(Request.QueryString["id"]);
            tbl_SubCategory RecordItems = db.tbl_SubCategory.Where(c => c.SubCategoryID == RecordId).FirstOrDefault();



            RecordItems.SubCategoryDescription = txtDescription.Text;
            RecordItems.CategoryID = Convert.ToInt32(CatID.Value);
            RecordItems.SubCategoryIsActive = chkActive.Checked;
            RecordItems.SubCategorySort = Convert.ToInt32(chkSort.Value);
            RecordItems.SubCategoryTitleAr = txtTitleAr.Text;
            RecordItems.SubCategoryTitleEn = txtTitleEn.Text;


            string fileName = SubImage.UploadedFiles[0].FileName;
            string resultExtension = Path.GetExtension(fileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = "~/Images/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            SubImage.UploadedFiles[0].SaveAs(resultFilePath);

            RecordItems.SubCategoryPic = resultFileName;

            db.Entry(RecordItems).State = EntityState.Modified;
            db.SaveChanges();
            Response.Redirect("~/Admin/SubCategory/SubCategoryList.aspx");

        }
    }
}