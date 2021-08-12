using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPointAdmin.Admin.Item
{
    public partial class AddItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveItem_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            GetPointEntities db = new GetPointEntities();

            tbl_Item RecordData = new tbl_Item();

            tbl_ItemGroup itemgroup = new tbl_ItemGroup();

            var x = GroupSelect.SelectedItem;

            //RecordData.CategoryID = Convert.ToInt32(CatID.Value);

            var cattext = db.tbl_Category.Where(c => c.CategoryTitleAr == CatCombo.Text).FirstOrDefault();
            var subcattext = db.tbl_SubCategory.Where(c => c.SubCategoryTitleAr == SubcatID.Text).FirstOrDefault();

            var suptext = db.tbl_Supplier.Where(c => c.SupplierTitle == SupID.Text).FirstOrDefault();

            RecordData.CategoryID = Convert.ToInt32(cattext.CategoryID);
            RecordData.ItemDescription = txtDescription.Text;
            RecordData.ItemPrice = Convert.ToInt32(Price.Value);
            RecordData.ItemTitle = txtTitle.Text;
            RecordData.Points = Convert.ToInt32(Points.Value);
            RecordData.PointsCredit = Convert.ToInt32(PointsCred.Value);
            RecordData.SupplierID = Convert.ToInt32(suptext.SupplierID);
            RecordData.SubCategoryId = Convert.ToInt32(subcattext.SubCategoryID);

            if(ItemImage.UploadedFiles[0].FileName!="")
            { 
            string fileName = ItemImage.UploadedFiles[0].FileName;
            string resultExtension = Path.GetExtension(fileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = "~/Images/" + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            ItemImage.UploadedFiles[0].SaveAs(resultFilePath);
            RecordData.ItemPic = resultFileName;

            }
            db.tbl_Item.Add(RecordData);
            db.SaveChanges();


            if (x != null)
            {
                itemgroup.GroupId = Convert.ToInt32(x.Value);
                itemgroup.ItemId = RecordData.ItemID;
                db.tbl_ItemGroup.Add(itemgroup);
                db.SaveChanges();
            }


            Response.Redirect("~/Admin/Item/ItemsList.aspx");
        }

    }
}