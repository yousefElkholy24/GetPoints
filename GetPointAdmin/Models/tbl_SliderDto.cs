using System;
using System.Linq;
using Newtonsoft.Json;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_SliderDto
    {
        [JsonProperty("sliderId")]
        public int sliderId { get; set; }

        [JsonProperty("sliderTitle")]
        public string sliderTitle { get; set; }

        [JsonProperty("sliderPic")]
        public string sliderPic { get; set; }

        [JsonProperty("isActive")]
        public Nullable<bool> isActive { get; set; }

        [JsonProperty("itemID")]
        public Nullable<int> itemID { get; set; }


        [JsonProperty("tbl_Item")]
        public tbl_ItemDto tbl_Item { get; set; }

        public static tbl_SliderDto FromModel(tbl_Slider model)
        {
            return new tbl_SliderDto()
            {
                sliderId = model.SliderId, 
                sliderTitle = model.SliderTitle, 
                sliderPic = model.SliderPic, 
                isActive = model.IsActive, 
                itemID = model.ItemID, 
                tbl_Item = tbl_ItemDto.FromModel(model.tbl_Item), 
            }; 
        }

        public tbl_Slider ToModel()
        {
            return new tbl_Slider()
            {
                SliderId = sliderId, 
                SliderTitle = sliderTitle, 
                SliderPic = sliderPic, 
                IsActive = isActive, 
                ItemID = itemID, 
                tbl_Item = tbl_Item.ToModel(), 
            }; 
        }
    }
}