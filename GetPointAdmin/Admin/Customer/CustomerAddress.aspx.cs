using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Customer
{
    public partial class CustomerAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddressGrid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }

        protected void AddressGrid_ToolbarItemClick(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewToolbarItemClickEventArgs e)
        {
            if(e.Item.Name== "GoBack")
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Response.Redirect("~/Admin/Customer/CustomerAddress.aspx?id=" +id);
            }
        }
    }
}