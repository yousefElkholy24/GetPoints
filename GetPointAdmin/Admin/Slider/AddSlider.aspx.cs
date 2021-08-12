using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Slider
{
    public partial class AddSlider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();

            tbl_Slider RecordData = new tbl_Slider();

            RecordData.SliderTitle = txtTitle.Text;
            RecordData.ItemID = Convert.ToInt32(Item.Value);
            RecordData.IsActive = chkActive.Checked;

            if(SliderImage.UploadedFiles[0].FileName!="")
            {
            string fileName = SliderImage.UploadedFiles[0].FileName;
            string resultExtension = Path.GetExtension(fileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = "~/Images/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            SliderImage.UploadedFiles[0].SaveAs(resultFilePath);

            RecordData.SliderPic = resultFileName;
            }
            db.tbl_Slider.Add(RecordData);
            db.SaveChanges();


            Response.Redirect("~/Admin/Slider/SlidersList.aspx");


        }
    }
}