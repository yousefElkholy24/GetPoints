using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Slider
{
    public partial class EditSlider : System.Web.UI.Page
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
                    tbl_Slider Record = db.tbl_Slider.Where(c => c.SliderId == RecordId).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues

                        txtTitle.Text = Record.SliderTitle;
                        chkActive.Value = Record.IsActive;
                        Item.Value = Record.ItemID;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();
            int RecordId = Convert.ToInt32(Request.QueryString["id"]);
            tbl_Slider Record = db.tbl_Slider.Where(c => c.SliderId == RecordId).FirstOrDefault();


            Record.SliderTitle = txtTitle.Text;
            Record.ItemID = Convert.ToInt32(Item.Value);
            Record.IsActive = chkActive.Checked;

            if (SliderImage.UploadedFiles[0].FileName != "")
            {
                string fileName = SliderImage.UploadedFiles[0].FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
                string resultFileUrl = "~/Images/" + resultFileName;
                string resultFilePath = MapPath(resultFileUrl);
                SliderImage.UploadedFiles[0].SaveAs(resultFilePath);
                Record.SliderPic = resultFileName;
            }


            db.Entry(Record).State = EntityState.Modified;
            db.SaveChanges();
            Response.Redirect("~/Admin/Slider/SlidersList.aspx");


        }
    }
}