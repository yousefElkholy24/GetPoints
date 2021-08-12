using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_ItemImageDto
    {
        public int tbl_ItemImageID { get; set; }

        public string tbl_ItemImageTitle { get; set; }

        public string tbl_ItemImagePic { get; set; }

        public int ItemID { get; set; }


        public tbl_ItemDto tbl_Item { get; set; }

        public static tbl_ItemImageDto FromModel(tbl_ItemImage model)
        {
            return new tbl_ItemImageDto()
            {
                tbl_ItemImageID = model.tbl_ItemImageID, 
                tbl_ItemImageTitle = model.tbl_ItemImageTitle, 
                tbl_ItemImagePic = model.tbl_ItemImagePic, 
                ItemID = model.ItemID, 
                tbl_Item = tbl_ItemDto.FromModel(model.tbl_Item), 
            }; 
        }

        public tbl_ItemImage ToModel()
        {
            return new tbl_ItemImage()
            {
                tbl_ItemImageID = tbl_ItemImageID, 
                tbl_ItemImageTitle = tbl_ItemImageTitle, 
                tbl_ItemImagePic = tbl_ItemImagePic, 
                ItemID = ItemID, 
                tbl_Item = tbl_Item.ToModel(), 
            }; 
        }
    }
}