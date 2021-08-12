using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void TopMenu_ItemClick1(object source, DevExpress.Web.Bootstrap.BootstrapMenuItemEventArgs e)
        {
            try
            {
                if (e.Item.Name == "RegisterCustomer")
                {
                    Response.Redirect("~/SitePages/RegisterCustomer.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}