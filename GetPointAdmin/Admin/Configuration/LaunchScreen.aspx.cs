using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Configuration
{
    public partial class LaunchScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            GetPointEntities db = new GetPointEntities();
            int RecordId = 1;
            tbl_Systemconfig RecordItems = db.tbl_Systemconfig.Where(c => c.ID == RecordId).FirstOrDefault();

            if (EditImage.UploadedFiles[0].FileName != "")
            {
                string fileName = EditImage.UploadedFiles[0].FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
                string resultFileUrl = "~/Images/" + resultFileName;
                string resultFilePath = MapPath(resultFileUrl);
                EditImage.UploadedFiles[0].SaveAs(resultFilePath);
                RecordItems.Info = resultFileName;
            }
            db.Entry(RecordItems).State = EntityState.Modified;
            db.SaveChanges();
            Response.Redirect("~/Admin/Configuration/LaunchScreen.aspx");
        }
    }
}