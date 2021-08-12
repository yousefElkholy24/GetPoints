using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin
{ 
    public partial class CustomersList : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void grdList_ToolbarItemClick(object sender, BootstrapGridViewToolbarItemClickEventArgs e)
        {
            //string TARGET_URL = "~/Admin/Customer/AddCustomer.aspx";
            //if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            if (e.Item.Name == "btnAddNew")
            {
                string TARGET_URL = "~/Admin/Customer/AddCustomer.aspx";
                if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            }
            else if (e.Item.Name=="btnReport")
            {
                string TARGET_URL = "~/Admin/Customer/CustomersReport.aspx";
                if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            }
        }

        protected void grdList_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int RecordID = Convert.ToInt32(grdList.GetRowValues(e.VisibleIndex, "CustomerID"));
            string TARGET_URL;
            switch (e.ButtonID)
            {
                case "btnEdit":
                    TARGET_URL = "~/Admin/Customer/EditCustomer.aspx?id=" + RecordID.ToString(); 
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                case "btnAddresses":
                    TARGET_URL = "~/Admin/Customer/CustomerAddress.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                case "btnDelete":
                    TARGET_URL = "~/Admin/Customer/DeleteCustomer.aspx?id=" + RecordID.ToString();
                    if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
                    break;
                default:
                    break;
            }
        }


    }
}
