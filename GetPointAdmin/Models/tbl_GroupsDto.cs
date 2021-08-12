using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_GroupsDto
    {
        public int GroupId { get; set; }

        public string GroupTitleAr { get; set; }

        public string GroupTitleEn { get; set; }

        public Nullable<int> Sort { get; set; }

        public Nullable<bool> IsActive { get; set; }

        public string GroupPic { get; set; }

        public ICollection<tbl_ItemGroup> tbl_ItemGroup { get; set; }

        public static tbl_GroupsDto FromModel(tbl_Groups model)
        {
            return new tbl_GroupsDto()
            {
                GroupId = model.GroupId, 
                GroupTitleAr = model.GroupTitleAr, 
                GroupTitleEn = model.GroupTitleEn, 
                Sort = model.Sort, 
                IsActive = model.IsActive, 
                GroupPic = model.GroupPic, 
                tbl_ItemGroup = model.tbl_ItemGroup, 
            }; 
        }

        public tbl_Groups ToModel()
        {
            return new tbl_Groups()
            {
                GroupId = GroupId, 
                GroupTitleAr = GroupTitleAr, 
                GroupTitleEn = GroupTitleEn, 
                Sort = Sort, 
                IsActive = IsActive, 
                GroupPic = GroupPic, 
                tbl_ItemGroup = tbl_ItemGroup, 
            }; 
        }
    }
}