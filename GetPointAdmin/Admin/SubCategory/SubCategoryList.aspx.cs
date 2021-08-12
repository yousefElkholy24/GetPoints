using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin
{
    public partial class SubCategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubGrid_ToolbarItemClick(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewToolbarItemClickEventArgs e)
        {
            if (e.Item.Name == "btnAddNew")
            {
                string TARGET_URL = "~/Admin/SubCategory/AddSubCategory.aspx";
                if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            }
        }

        protected void SubGrid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int RecordID = Convert.ToInt32(SubCatGrid.GetRowValues(e.VisibleIndex, "SubCategoryID"));
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