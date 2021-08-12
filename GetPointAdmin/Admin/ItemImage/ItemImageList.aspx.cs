using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.ItemImage
{
    public partial class ItemImageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ItemImageGrid_CustomButtonCallback(object sender,ASPxGridViewCustomButtonCallbackEventArgs e)
        {
        
        }

        protected void ItemImageGrid_ToolbarItemClick(object sender, BootstrapGridViewToolbarItemClickEventArgs e)
        {
            if (e.Item.Name == "btnAddNew")
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                string TARGET_URL = "~/Admin/ItemImage/AddItemImage.aspx?id="+id;
                if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            }
        }

        protected void ItemImageGrid2_ToolbarItemClick(object sender, BootstrapGridViewToolbarItemClickEventArgs e)
        {

        }
    }
}