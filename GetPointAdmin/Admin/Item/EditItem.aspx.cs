using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Item
{
    public partial class EditItem : System.Web.UI.Page
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
                        //Set Vaues
                        txtDescription.Text = Record.ItemDescription;
                        txtTitle.Text = Record.ItemTitle;
                        CatCombo.Text = db.tbl_Category.Where(c => c.CategoryID == Record.CategoryID).FirstOrDefault().CategoryTitleAr;
                        SupID.Text = db.tbl_Supplier.Where(c => c.SupplierID == Record.SupplierID).FirstOrDefault().SupplierTitle;
                        SubcatID.Text = db.tbl_SubCategory.Where(c => c.SubCategoryID == Record.SupplierID).FirstOrDefault().SubCategoryTitleAr;
                        Price.Value = Record.ItemPrice;
                        Points.Value = Record.Points;
                        PointsCred.Value = Record.PointsCredit;

                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();
            int RecordId = Convert.ToInt32(Request.QueryString["id"]);
            tbl_Item RecordItems = db.tbl_Item.Where(c => c.ItemID == RecordId).FirstOrDefault();

            var cattext = db.tbl_Category.Where(c => c.CategoryTitleAr == CatCombo.Text).FirstOrDefault();
            var subcattext = db.tbl_SubCategory.Where(c => c.SubCategoryTitleAr == SubcatID.Text).FirstOrDefault();

            var suptext = db.tbl_Supplier.Where(c => c.SupplierTitle == SupID.Text).FirstOrDefault();


            RecordItems.CategoryID = cattext.CategoryID;
            RecordItems.ItemDescription = txtDescription.Text;
            RecordItems.ItemPrice = Convert.ToDouble(Price.Value);
            RecordItems.ItemTitle = txtTitle.Text;
            RecordItems.Points = Convert.ToInt32(Points.Value);
            RecordItems.PointsCredit = Convert.ToDouble(PointsCred.Value);
            RecordItems.SupplierID = suptext.SupplierID;
            RecordItems.SubCategoryId =subcattext.SubCategoryID;


            if (EditImage.UploadedFiles[0].FileName != "")
            { 
            string fileName = EditImage.UploadedFiles[0].FileName;
            string resultExtension = Path.GetExtension(fileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = "~/Images/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            EditImage.UploadedFiles[0].SaveAs(resultFilePath);
            RecordItems.ItemPic = resultFileName;
            }
            db.Entry(RecordItems).State = EntityState.Modified;
            db.SaveChanges();
            Response.Redirect("~/Admin/Item/ItemsList.aspx");


        }
    }
}