using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Category
{
    public partial class DeleteCategory : System.Web.UI.Page
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
                    tbl_Category Record = dbContext.tbl_Category.Where(c => c.CategoryID == RecordID).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitleAr.Text = Record.CategoryTitleAr;
                        txtTitleEn.Text = Record.CategoryTitleEn;
                        txtDescription.Text = Record.CategoryDescription;
                        txtOrder.Value = Record.CategorySort;
                        chkActive.Value = Record.CategoryIsActive;
                        pic.ImageUrl = "~/Images/" + Record.CategoryPic;
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
                    bool HasSubs = dbContext.tbl_SubCategory.Any(c => c.CategoryID == RecordID);
                    bool HasItems = dbContext.tbl_Item.Any(c => c.CategoryID == RecordID);

                    if (HasSubs || HasItems)
                    {
                        //Show Error Message

                        lblError.Text = "Can't Delete Category, it has sub or items";
                        lblError.Visible = true;
                    }
                    else
                    {
                        //Delete Record

                        var ItemToDelete = dbContext.tbl_Category.Where(c => c.CategoryID == RecordID).FirstOrDefault();

                        if (ItemToDelete == null)
                        {
                            lblError.Text = "Can't Delete Category, Something happened";
                            lblError.Visible = true;
                        }
                        else
                        {
                            dbContext.tbl_Category.Remove(ItemToDelete);
                            dbContext.SaveChanges();
                            Response.Redirect("~/admin/Category/CategoryList.aspx");
                        }
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