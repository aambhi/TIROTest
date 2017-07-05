﻿using System;

namespace TIROERP.Core.Model
{
    public class UserContact
    {
        public int USER_CONTACT_ID { get; set; }
        public string REGISTRATION_NUMBER { get; set; }
        public int? CONTACT_TYPE_ID { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string CONTACT_NO { get; set; }

        public string CONTACT_TYPE { get; set; }
        public bool IsNew { get; set; }
    }
}