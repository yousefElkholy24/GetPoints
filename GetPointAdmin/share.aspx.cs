using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin
{
    public partial class share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                RetrieveData();
            }
        }

        private void RetrieveData()
        {
            try
            {
                GetPointEntities db = new GetPointEntities();
                if (Request.QueryString["id"] != null)
                {
                    int RecordId = Convert.ToInt32(Request.QueryString["id"]);
                    tbl_Item Record = db.tbl_Item.Where(c => c.ItemID == RecordId).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vauesaljnfnwwrfnwnrgnq
                        txtDescription.Text = Record.ItemDescription;
                        txtTitle.Text = Record.ItemTitle;
                        Price.Value = Record.ItemPrice;
                    }
                }            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}