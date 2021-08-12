using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Item
{
    public partial class DeleteItem : System.Web.UI.Page
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
                    tbl_Item Record = dbContext.tbl_Item.Where(c => c.ItemID == RecordID).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitle.Text = Record.ItemTitle;
                        txtDescription.Text = Record.ItemDescription;
                        Price.Value = Record.ItemPrice;
                        SubCat.Value = Record.SubCategoryId;
                        Supplier.Value = Record.SupplierID;
                        Image.ImageUrl = "~/Images/" + Record.ItemPic;
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

                        var ItemToDelete = dbContext.tbl_Item.Where(c => c.ItemID == RecordID).FirstOrDefault();

                        if (ItemToDelete == null)
                        {
                            lblError.Text = "Can't Delete Category, Something happened";
                            lblError.Visible = true;
                        }
                        else
                        {
                            dbContext.tbl_Item.Remove(ItemToDelete);
                            dbContext.SaveChanges();
                            Response.Redirect("~/admin/Item/ItemsList.aspx");
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