using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_ItemSizeDto
    {
        public int ItemSizeID { get; set; }

        public string ItemSizeTitle { get; set; }

        public int ItemID { get; set; }

        public tbl_ItemDto tbl_Item { get; set; }

        public static tbl_ItemSizeDto FromModel(tbl_ItemSize model)
        {
            return new tbl_ItemSizeDto()
            {
                ItemSizeID = model.ItemSizeID, 
                ItemSizeTitle = model.ItemSizeTitle, 
                ItemID = model.ItemID, 
                tbl_Item = tbl_ItemDto.FromModel(model.tbl_Item), 
            }; 
        }

        public tbl_ItemSize ToModel()
        {
            return new tbl_ItemSize()
            {
                ItemSizeID = ItemSizeID, 
                ItemSizeTitle = ItemSizeTitle, 
                ItemID = ItemID, 
                tbl_Item = tbl_Item.ToModel(), 
            }; 
        }
    }
}