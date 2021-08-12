using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_ItemColorDto
    {
        public int ItemColorID { get; set; }

        public string ItemColorTitle { get; set; }

        public int ItemID { get; set; }

        public string ColorCode { get; set; }

        public tbl_ItemDto tbl_Item { get; set; }

        public static tbl_ItemColorDto FromModel(tbl_ItemColor model)
        {
            return new tbl_ItemColorDto()
            {
                ItemColorID = model.ItemColorID, 
                ItemColorTitle = model.ItemColorTitle, 
                ItemID = model.ItemID, 
                ColorCode = model.ColorCode, 
                tbl_Item = tbl_ItemDto.FromModel(model.tbl_Item), 
            }; 
        }

        public tbl_ItemColor ToModel()
        {
            return new tbl_ItemColor()
            {
                ItemColorID = ItemColorID, 
                ItemColorTitle = ItemColorTitle, 
                ItemID = ItemID, 
                ColorCode = ColorCode, 
                tbl_Item = tbl_Item.ToModel(), 
            }; 
        }
    }
}