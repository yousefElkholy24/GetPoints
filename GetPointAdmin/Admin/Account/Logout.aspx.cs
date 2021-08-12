using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpContext.Current.GetOwinContext().Authentication.SignOut();

                Response.Redirect("~/Admin/Account/Login.aspx");

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}