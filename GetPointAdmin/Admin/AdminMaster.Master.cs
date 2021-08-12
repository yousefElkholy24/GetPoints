using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Check Login
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                }
                else
                {
                    Response.Redirect("~/Admin/Account/Login.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}