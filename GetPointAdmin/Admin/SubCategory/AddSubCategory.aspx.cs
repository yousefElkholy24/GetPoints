using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.SubCategory
{
    public partial class AddSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {


            if (Request.QueryString["id"] != null)
            {

                int RecordID = Convert.ToInt32(Request.QueryString["id"]);

                GetPointEntities db = new GetPointEntities();

                tbl_SubCategory SubRecord = new tbl_SubCategory();




                SubRecord.SubCategoryDescription = txtDescription.Text;
                SubRecord.CategoryID = RecordID;
                SubRecord.SubCategoryIsActive = chkActive.Checked;
                SubRecord.SubCategorySort = Convert.ToInt32(chkSort.Value);
                SubRecord.SubCategoryTitleAr = txtTitleAr.Text;
                SubRecord.SubCategoryTitleEn = txtTitleEn.Text;

                if (SubImage.UploadedFiles[0].FileName != "")
                {
                string fileName = SubImage.UploadedFiles[0].FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
                string resultFileUrl = "~/Images/" + resultFileName;
                string resultFilePath = MapPath(resultFileUrl);
                SubImage.UploadedFiles[0].SaveAs(resultFilePath);

                SubRecord.SubCategoryPic = resultFileName;
                }
              

                db.tbl_SubCategory.Add(SubRecord);
                db.SaveChanges();

                Response.Redirect("~/Admin/Category/RelatedSubcategories.aspx?id="+ RecordID.ToString());
            }


           

        }
    }
}