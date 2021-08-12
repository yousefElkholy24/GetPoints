using System;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_ItemGroupDto
    {
        public int ItemGroupId { get; set; }

        public Nullable<int> ItemId { get; set; }

        public Nullable<int> GroupId { get; set; }

        public tbl_GroupsDto tbl_Groups { get; set; }

        public tbl_ItemDto tbl_Item { get; set; }

        public static tbl_ItemGroupDto FromModel(tbl_ItemGroup model)
        {
            return new tbl_ItemGroupDto()
            {
                ItemGroupId = model.ItemGroupId, 
                ItemId = model.ItemId, 
                GroupId = model.GroupId, 
                tbl_Groups = tbl_GroupsDto.FromModel(model.tbl_Groups), 
                tbl_Item = tbl_ItemDto.FromModel(model.tbl_Item), 
            }; 
        }

        public tbl_ItemGroup ToModel()
        {
            return new tbl_ItemGroup()
            {
                ItemGroupId = ItemGroupId, 
                ItemId = ItemId, 
                GroupId = GroupId, 
                tbl_Groups = tbl_Groups.ToModel(), 
                tbl_Item = tbl_Item.ToModel(), 
            }; 
        }
    }
}