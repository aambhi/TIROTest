﻿namespace TIROERP.Core.Model
{
    public class UserLanguage
    {
        public string REGISTRATION_NO { get; set; }
        public int USER_LANGUAGE_ID { get; set; }
        public int LANGUAGE_ID { get; set; }
        public bool? IS_READ { get; set; }
        public bool? IS_WRITE { get; set; }
        public bool? IS_SPEAK { get; set; }
        public bool IsNew { get; set; }
        public string LANGUAGE_NAME { get; set; }
    }
}
