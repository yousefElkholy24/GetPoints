using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Slider
{
    public partial class DeleteSlider : System.Web.UI.Page
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
                GetPointEntities dbContext = new GetPointEntities();
                if (Request.QueryString["id"] != null)
                {
                    int RecordID = Convert.ToInt32(Request.QueryString["id"]);
                    tbl_Slider Record = dbContext.tbl_Slider.Where(c => c.SliderId == RecordID).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitle.Text = Record.SliderTitle;
                        chkActive.Value = Record.IsActive;
                        Item.Value = Record.ItemID;

                        Image.ImageUrl = "~/Images/" + Record.SliderPic;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    int RecordID = Convert.ToInt32(Request.QueryString["id"]);
                    GetPointEntities dbContext = new GetPointEntities();
                   
                        //Delete Record

                        var ItemToDelete = dbContext.tbl_Slider.Where(c => c.SliderId == RecordID).FirstOrDefault();

                        if (ItemToDelete == null)
                        {
                            lblError.Text = "Can't Delete Category, Something happened";
                            lblError.Visible = true;
                        }
                        else
                        {
                            dbContext.tbl_Slider.Remove(ItemToDelete);
                            dbContext.SaveChanges();
                            Response.Redirect("~/admin/Slider/SlidersList.aspx");
                        }
                    }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}