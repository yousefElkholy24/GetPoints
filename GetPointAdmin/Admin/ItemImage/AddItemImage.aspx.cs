using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.ItemImage
{
    public partial class AddItemImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();

            tbl_ItemImage RecordData = new tbl_ItemImage();
            int QItemID = Convert.ToInt32(Request.QueryString["id"]);
            RecordData.ItemID = QItemID;
            RecordData.tbl_ItemImageTitle = txtTitle.Text;

            if (ItemImage.UploadedFiles[0].FileName != "")
            {
                string fileName = ItemImage.UploadedFiles[0].FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
                string resultFileUrl = "~/Images/" + resultFileName;
                string resultFilePath = MapPath(resultFileUrl);
                ItemImage.UploadedFiles[0].SaveAs(resultFilePath);
                RecordData.tbl_ItemImagePic = resultFileName;

            }
            db.tbl_ItemImage.Add(RecordData);
            db.SaveChanges();


            Response.Redirect("~/Admin/ItemImage/ItemImageList.aspx?id="+RecordData.ItemID);
        }
    }
}