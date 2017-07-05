using System;

namespace TIROERP.Core.Model
{

    public class UserAddress
    {
        public int USER_ADDRESS_ID { get; set; }

        public string REGISTRATION_NUMBER { get; set; }

        public int ADDRESS_TYPE_ID { get; set; }

        public string ADDRESS_TYPE { get; set; }

        public string ADDRESS { get; set; }

        public string CITY_CODE { get; set; }

        public string USER_VILLAGE { get; set; }

        public string USER_PINCODE { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public string COUNTRY_CODE { get; set; }

        public string STATE_CODE { get; set; }

        public bool IsNew { get; set; }

        public string USER_CITY { get; set; }

        public string USER_STATE { get; set; }

        public string USER_COUNTRY { get; set; }

        public string Contact_No { get; set; }

        public string USER_EMAIL { get; set; }

        public string WEBSITE { get; set; }

        public string SKYPE { get; set; }

        public string CONTACT_REMARK { get; set; }
    }
}

