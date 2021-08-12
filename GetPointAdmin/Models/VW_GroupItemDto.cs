using System;
using System.Linq;
using Newtonsoft.Json;

namespace GetPointAdmin.Models.Dto
{
    public class VW_GroupItemDto
    {
        [JsonProperty("itemID")]
        public int itemID { get; set; }

        [JsonProperty("itemTitle")]
        public string itemTitle { get; set; }

        [JsonProperty("itemDescription")]
        public string itemDescription { get; set; }

        [JsonProperty("itemPrice")]
        public Nullable<double> itemPrice { get; set; }

        [JsonProperty("itemPic")]
        public string itemPic { get; set; }

        [JsonProperty("categoryTitleAr")]
        public string categoryTitleAr { get; set; }

        [JsonProperty("categoryTitleEn")]
        public string categoryTitleEn { get; set; }

        [JsonProperty("categoryID")]
        public int categoryID { get; set; }

        [JsonProperty("groupTitleAr")]
        public string groupTitleAr { get; set; }

        [JsonProperty("groupTitleEn")]
        public string groupTitleEn { get; set; }

        [JsonProperty("sort")]
        public Nullable<int> sort { get; set; }

        [JsonProperty("groupPic")]
        public string groupPic { get; set; }

        [JsonProperty("isActive")]
        public Nullable<bool> isActive { get; set; }

        [JsonProperty("itemSizeTitle")]
        public string itemSizeTitle { get; set; }

        [JsonProperty("itemColorTitle")]
        public string itemColorTitle { get; set; }

        [JsonProperty("colorCode")]
        public string colorCode { get; set; }

        [JsonProperty("groupId")]
        public int groupId { get; set; }

        public static VW_GroupItemDto FromModel(VW_GroupItem model)
        {
            return new VW_GroupItemDto()
            {
                itemID = model.ItemID, 
                itemTitle = model.ItemTitle, 
                itemDescription = model.ItemDescription, 
                itemPrice = model.ItemPrice, 
                itemPic = model.ItemPic, 
                categoryTitleAr = model.CategoryTitleAr, 
                categoryTitleEn = model.CategoryTitleEn, 
                categoryID = model.CategoryID, 
                groupTitleAr = model.GroupTitleAr, 
                groupTitleEn = model.GroupTitleEn, 
                sort = model.Sort, 
                groupPic = model.GroupPic, 
                isActive = model.IsActive, 
                itemSizeTitle = model.ItemSizeTitle, 
                itemColorTitle = model.ItemColorTitle, 
                colorCode = model.ColorCode, 
                groupId = model.GroupId, 
            }; 
        }

        public VW_GroupItem ToModel()
        {
            return new VW_GroupItem()
            {
                ItemID = itemID, 
                ItemTitle = itemTitle, 
                ItemDescription = itemDescription, 
                ItemPrice = itemPrice, 
                ItemPic =itemPic, 
                CategoryTitleAr = categoryTitleAr, 
                CategoryTitleEn = categoryTitleEn, 
                CategoryID = categoryID, 
                GroupTitleAr = groupTitleAr, 
                GroupTitleEn = groupTitleEn, 
                Sort = sort, 
                GroupPic = groupPic, 
                IsActive = isActive, 
                ItemSizeTitle = itemSizeTitle, 
                ItemColorTitle = itemColorTitle, 
                ColorCode = colorCode, 
                GroupId = groupId, 
            }; 
        }
    }
}