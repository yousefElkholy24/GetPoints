using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_SubCategoryDto
    {
        public int SubCategoryID { get; set; }

        public string SubCategoryTitleAr { get; set; }

        public string SubCategoryTitleEn { get; set; }

        public string SubCategoryPic { get; set; }

        public Nullable<bool> SubCategoryIsActive { get; set; }

        public Nullable<int> SubCategorySort { get; set; }

        public string SubCategoryDescription { get; set; }

        public int CategoryID { get; set; }


        public tbl_CategoryDto tbl_Category { get; set; }

        public static tbl_SubCategoryDto FromModel(tbl_SubCategory model)
        {
            return new tbl_SubCategoryDto()
            {
                SubCategoryID = model.SubCategoryID, 
                SubCategoryTitleAr = model.SubCategoryTitleAr, 
                SubCategoryTitleEn = model.SubCategoryTitleEn, 
                SubCategoryPic = model.SubCategoryPic, 
                SubCategoryIsActive = model.SubCategoryIsActive, 
                SubCategorySort = model.SubCategorySort, 
                SubCategoryDescription = model.SubCategoryDescription, 
                CategoryID = model.CategoryID, 
                tbl_Category = tbl_CategoryDto.FromModel(model.tbl_Category), 
            }; 
        }

        public tbl_SubCategory ToModel()
        {
            return new tbl_SubCategory()
            {
                SubCategoryID = SubCategoryID, 
                SubCategoryTitleAr = SubCategoryTitleAr, 
                SubCategoryTitleEn = SubCategoryTitleEn, 
                SubCategoryPic = SubCategoryPic, 
                SubCategoryIsActive = SubCategoryIsActive, 
                SubCategorySort = SubCategorySort, 
                SubCategoryDescription = SubCategoryDescription, 
                CategoryID = CategoryID, 
                tbl_Category = tbl_Category.ToModel(), 
            }; 
        }
    }
}