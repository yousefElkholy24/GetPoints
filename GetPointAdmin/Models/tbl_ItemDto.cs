using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_ItemDto
    {
        public int ItemID { get; set; }

        public int CategoryID { get; set; }

        public string ItemTitle { get; set; }

        public string ItemDescription { get; set; }

        public Nullable<double> ItemPrice { get; set; }

        public string ItemPic { get; set; }

        public int SupplierID { get; set; }

        public Nullable<int> SubCategoryId { get; set; }

        public Nullable<double> Points { get; set; }

        public Nullable<double> PointsCredit { get; set; }

        public Nullable<int> NoOfViews { get; set; }


        public tbl_CategoryDto tbl_Category { get; set; }

        public tbl_SupplierDto tbl_Supplier { get; set; }

        public ICollection<tbl_ItemColor> tbl_ItemColor { get; set; }

        public ICollection<tbl_ItemGroup> tbl_ItemGroup { get; set; }

        public ICollection<tbl_ItemImage> tbl_ItemImage { get; set; }

        public ICollection<tbl_ItemSize> tbl_ItemSize { get; set; }

        public ICollection<tbl_OrderItem> tbl_OrderItem { get; set; }

        public ICollection<tbl_Slider> tbl_Slider { get; set; }

        public static tbl_ItemDto FromModel(tbl_Item model)
        {
            return new tbl_ItemDto()
            {
                ItemID = model.ItemID, 
                CategoryID = model.CategoryID, 
                ItemTitle = model.ItemTitle, 
                ItemDescription = model.ItemDescription, 
                ItemPrice = model.ItemPrice, 
                ItemPic = model.ItemPic, 
                SupplierID = model.SupplierID, 
                SubCategoryId = model.SubCategoryId, 
                Points = model.Points, 
                PointsCredit = model.PointsCredit, 
                NoOfViews = model.NoOfViews, 
                tbl_Category = tbl_CategoryDto.FromModel(model.tbl_Category), 
                tbl_Supplier = tbl_SupplierDto.FromModel(model.tbl_Supplier), 
                tbl_ItemColor = model.tbl_ItemColor, 
                tbl_ItemGroup = model.tbl_ItemGroup, 
                tbl_ItemImage = model.tbl_ItemImage, 
                tbl_ItemSize = model.tbl_ItemSize, 
                tbl_OrderItem = model.tbl_OrderItem, 
                tbl_Slider = model.tbl_Slider, 
            }; 
        }

        public tbl_Item ToModel()
        {
            return new tbl_Item()
            {
                ItemID = ItemID, 
                CategoryID = CategoryID, 
                ItemTitle = ItemTitle, 
                ItemDescription = ItemDescription, 
                ItemPrice = ItemPrice, 
                ItemPic = ItemPic, 
                SupplierID = SupplierID, 
                SubCategoryId = SubCategoryId, 
                Points = Points, 
                PointsCredit = PointsCredit, 
                NoOfViews = NoOfViews, 
                tbl_Category = tbl_Category.ToModel(), 
                tbl_Supplier = tbl_Supplier.ToModel(), 
                tbl_ItemColor = tbl_ItemColor, 
                tbl_ItemGroup = tbl_ItemGroup, 
                tbl_ItemImage = tbl_ItemImage, 
                tbl_ItemSize = tbl_ItemSize, 
                tbl_OrderItem = tbl_OrderItem, 
                tbl_Slider = tbl_Slider, 
            }; 
        }
    }
}