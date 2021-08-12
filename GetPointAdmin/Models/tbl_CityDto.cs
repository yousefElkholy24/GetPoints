using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_CityDto
    {
        public int CityID { get; set; }

        public string CityTitle { get; set; }

        public static tbl_CityDto FromModel(tbl_City model)
        {
            return new tbl_CityDto()
            {
                CityID = model.CityID, 
                CityTitle = model.CityTitle, 
            }; 
        }

        public tbl_City ToModel()
        {
            return new tbl_City()
            {
                CityID = CityID, 
                CityTitle = CityTitle, 
            }; 
        }
    }
}