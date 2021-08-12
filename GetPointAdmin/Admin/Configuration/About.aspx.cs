using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Configuration
{
    public partial class About : System.Web.UI.Page
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
                var Config = db.tbl_Systemconfig.Where(c => c.ID == 2).FirstOrDefault();
                //txtInfo.Text = Config.Info;
                HtmlEditor.Html = Config.Info;            
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void AboutSave_Click(object sender, EventArgs e)
        {

            GetPointEntities db = new GetPointEntities();
            tbl_Systemconfig Config = db.tbl_Systemconfig.Where(c => c.ID == 2).FirstOrDefault();

            Config.Info = HtmlEditor.Html;
            //Config.Info = txtInfo.Text;

            db.Entry(Config).State = EntityState.Modified;
            db.SaveChanges();
            Response.Redirect("~/Admin/Configuration/About.aspx");

        }
    }
}