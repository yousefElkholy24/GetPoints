using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_CategoryDto
    {
        public int CategoryID { get; set; }

        public string CategoryTitleAr { get; set; }

        public string CategoryTitleEn { get; set; }

        public string CategoryPic { get; set; }

        public Nullable<bool> CategoryIsActive { get; set; }

        public Nullable<int> CategorySort { get; set; }

        public string CategoryDescription { get; set; }


        public ICollection<tbl_Item> tbl_Item { get; set; }

        public ICollection<tbl_SubCategory> tbl_SubCategory { get; set; }

        public static tbl_CategoryDto FromModel(tbl_Category model)
        {
            return new tbl_CategoryDto()
            {
                CategoryID = model.CategoryID, 
                CategoryTitleAr = model.CategoryTitleAr, 
                CategoryTitleEn = model.CategoryTitleEn, 
                CategoryPic = model.CategoryPic, 
                CategoryIsActive = model.CategoryIsActive, 
                CategorySort = model.CategorySort, 
                CategoryDescription = model.CategoryDescription, 
                tbl_Item = model.tbl_Item, 
                tbl_SubCategory = model.tbl_SubCategory, 
            }; 
        }

        public tbl_Category ToModel()
        {
            return new tbl_Category()
            {
                CategoryID = CategoryID, 
                CategoryTitleAr = CategoryTitleAr, 
                CategoryTitleEn = CategoryTitleEn, 
                CategoryPic = CategoryPic, 
                CategoryIsActive = CategoryIsActive, 
                CategorySort = CategorySort, 
                CategoryDescription = CategoryDescription, 
                tbl_Item = tbl_Item, 
                tbl_SubCategory = tbl_SubCategory, 
            }; 
        }
    }
}