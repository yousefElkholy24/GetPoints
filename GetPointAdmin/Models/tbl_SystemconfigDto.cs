using System;
using System.Linq;

namespace GetPointAdmin.Models.Dto
{
    public class tbl_SystemconfigDto
    {
        public int iD { get; set; }

        public string title { get; set; }

        public string info { get; set; }

        public string description { get; set; }

        public static tbl_SystemconfigDto FromModel(tbl_Systemconfig model)
        {
            return new tbl_SystemconfigDto()
            {
                iD = model.ID, 
                title = model.Title, 
                info = model.Info, 
                description = model.Description, 
            }; 
        }

        public tbl_Systemconfig ToModel()
        {
            return new tbl_Systemconfig()
            {
                ID = iD, 
                Title = title, 
                Info = info, 
                Description = description, 
            }; 
        }
    }
}