using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.SubCategory
{
    public partial class DeleteSubCategory : System.Web.UI.Page
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
                    tbl_SubCategory Record = dbContext.tbl_SubCategory.Where(c => c.SubCategoryID == RecordID).FirstOrDefault();
                    if (Record != null)
                    {
                        //Set Vaues
                        txtTitleAr.Text = Record.SubCategoryTitleAr;
                        txtTitleEn.Text = Record.SubCategoryTitleEn;
                        txtDescription.Text = Record.SubCategoryDescription;
                        chkSort.Value = Record.SubCategorySort;
                        chkActive.Value = Record.SubCategoryIsActive;
                        pic.ImageUrl = "~/Images/" + Record.SubCategoryPic;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    int RecordID = Convert.ToInt32(Request.QueryString["id"]);
                    GetPointEntities dbContext = new GetPointEntities();
                    bool HasItems = dbContext.tbl_Item.Any(c => c.SubCategoryId == RecordID);

                    if (HasItems)
                    {
                        //Show Error Message

                        lblError.Text = "Can't Delete Category, it has items";
                        lblError.Visible = true;
                    }
                    else
                    {
                        //Delete Record

                        var ItemToDelete = dbContext.tbl_SubCategory.Where(c => c.SubCategoryID == RecordID).FirstOrDefault();

                        if (ItemToDelete == null)
                        {
                            lblError.Text = "Can't Delete Category, Something happened";
                            lblError.Visible = true;
                        }
                        else
                        {
                            dbContext.tbl_SubCategory.Remove(ItemToDelete);
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