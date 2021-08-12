using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_AreaDto
    {
        public int AreaID { get; set; }

        public Nullable<int> CityID { get; set; }

        public string AreaTitle { get; set; }

        public static tbl_AreaDto FromModel(tbl_Area model)
        {
            return new tbl_AreaDto()
            {
                AreaID = model.AreaID, 
                CityID = model.CityID, 
                AreaTitle = model.AreaTitle, 
            }; 
        }

        public tbl_Area ToModel()
        {
            return new tbl_Area()
            {
                AreaID = AreaID, 
                CityID = CityID, 
                AreaTitle = AreaTitle, 
            }; 
        }
    }
}