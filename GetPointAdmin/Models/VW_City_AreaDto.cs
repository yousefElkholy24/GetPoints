using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class VW_City_AreaDto
    {
        public int CityID { get; set; }

        public string CityTitle { get; set; }

        public string AreaTitle { get; set; }

        public int AreaID { get; set; }

        public static VW_City_AreaDto FromModel(VW_City_Area model)
        {
            return new VW_City_AreaDto()
            {
                CityID = model.CityID, 
                CityTitle = model.CityTitle, 
                AreaTitle = model.AreaTitle, 
                AreaID = model.AreaID, 
            }; 
        }

        public VW_City_Area ToModel()
        {
            return new VW_City_Area()
            {
                CityID = CityID, 
                CityTitle = CityTitle, 
                AreaTitle = AreaTitle, 
                AreaID = AreaID, 
            }; 
        }
    }
}