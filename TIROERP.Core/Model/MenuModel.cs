using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class MenuModel
    {
        public int? LMS_MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public string MENU_TITLE { get; set; }
        public string MENU_URL { get; set; }
        public int? PARENT_MENU_ID { get; set; }
        public bool? IS_PARENT { get; set; }


        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string REMARK { get; set; }
        public string CONDITIONAL_OPERATOR { get; set; }
        public string CHANNEL_CODE { get; set; }
        public int? CHANNEL_USER_TYPE_ID { get; set; }

        public int? MENU_ID { get; set; }
        public string USER_TYPE_ID { get; set; }
        public string PAGE_NAME { get; set; }
        public string CONTROLLER_NAME { get; set; }

    }

    public class MenuResult
    {
        public int MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public string MENU_TITLE { get; set; }
        public string MENU_URL { get; set; }
        public string PAGE_NAME { get; set; }
        public string CONTROLLER_NAME { get; set; }
        public string PAGE_URL { get; set; }
        public bool? IS_PARENT { get; set; }
        public int? PARENT_MENU_ID { get; set; }
        public string PARENT_MENU_NAME { get; set; }
        public string REMARK { get; set; }
        public string MENU_ICON { get; set; }
        public int USER_TYPE_MENU_ID { get; set; }
    }

    public class UserType
    {
        public string USER_TYPE_ID { get; set; }
        public string USER_TYPE { get; set; }
    }
}
