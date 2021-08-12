using DevExpress.XtraReports.Web.ReportDesigner.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Order
{
    public partial class OrdersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OrdersGrid_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {


        }

        //public ReportOrderDataSet Ds;
        //public Report.OrdersReport rpt = new Report.OrdersReport();
        //public Order.OrdersReport frm = new Order.OrdersReport();
        //private void SaveButton()
        //{
        //    GetPointEntities db = new GetPointEntities();
        //    var Instance = db.tbl_Order.Where(c => c.CustomerID == 10).ToList();
        //    rpt.DataSource = Instance;
        //    rpt.RequestParameters = false;
            
        //}
        protected void OrdersGrid_ToolbarItemClick(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewToolbarItemClickEventArgs e)
        {

            GetPointEntities db = new GetPointEntities();
            var inst = db.tbl_Order.Where(c => c.OrderDate == DateEntered.Date).ToList();

            if (e.Item.Name == "btnReport")
            {
                string TARGET_URL = "~/Admin/Order/OrdersReport.aspx";
                if (Page.IsCallback) DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL); else Response.Redirect(TARGET_URL);
            }
        }
    }
}