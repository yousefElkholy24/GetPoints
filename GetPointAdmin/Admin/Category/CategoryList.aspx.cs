using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Category
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

        }

        protected void BootstrapGridView1_ToolbarItemClick(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewToolbarItemClickEventArgs e)
        {
            if (e.Item.Name == "btnAddNew")
            {
                string TARGET_URL = "~/Admin/Category/AddCategory.aspx";
                if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            }
        }

        protected void BootstrapGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int RecordID = Convert.ToInt32(BootstrapGridView1.GetRowValues(e.VisibleIndex, "CategoryID"));

            string TARGET_URL;
            switch (e.ButtonID)
            {
                case "btnEdit":
                    TARGET_URL = "~/Admin/Category/EditCategory.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                case "btnSub":
                    TARGET_URL = "~/Admin/Category/RelatedSubcategories.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                case "btnDelete":
                    TARGET_URL = "~/Admin/Category/DeleteCategory.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                default:
                    break;
            }
        }
    }
}