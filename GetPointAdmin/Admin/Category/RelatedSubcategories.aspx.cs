using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Category
{
    public partial class RelatedSubcategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BootstrapGridView1_ToolbarItemClick(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewToolbarItemClickEventArgs e)
        {
            if (e.Item.Name == "btnAddNew")
            {
                if (Request.QueryString["id"] != null)
                {
                    int RecordID = Convert.ToInt32(Request.QueryString["id"]);
                    string TARGET_URL = "~/Admin/SubCategory/AddSubCategory.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                }
               
            }
        }

        protected void BootstrapGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int RecordID = Convert.ToInt32(BootstrapGridView1.GetRowValues(e.VisibleIndex, "SubCategoryID"));
            string TARGET_URL;
            switch (e.ButtonID)
            {
                case "btnEdit":
                    TARGET_URL = "~/Admin/SubCategory/EditSubCategory.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                case "btnDelete":
                    TARGET_URL = "~/Admin/SubCategory/DeleteSubCategory.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                default:
                    break;
            }
        }
    }
}
