using System;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_CustomerFavDto
    {
        public int CustomerFavID { get; set; }

        public Nullable<int> ItemID { get; set; }

        public Nullable<int> CustomerID { get; set; }

        public static tbl_CustomerFavDto FromModel(tbl_CustomerFav model)
        {
            return new tbl_CustomerFavDto()
            {
                CustomerFavID = model.CustomerFavID, 
                ItemID = model.ItemID, 
                CustomerID = model.CustomerID, 
            }; 
        }

        public tbl_CustomerFav ToModel()
        {
            return new tbl_CustomerFav()
            {
                CustomerFavID = CustomerFavID, 
                ItemID = ItemID, 
                CustomerID = CustomerID, 
            }; 
        }
    }
}