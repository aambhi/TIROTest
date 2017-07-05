using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Certification
    {
        public int USER_CERTIFICATION_ID { get; set; }
        public int CERTIFICATION_ID { get; set; }
        public string CERTIFICATION_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public bool? IS_ACTIVE { get; set; }
        public int? CERTIFICATION_LEVEL { get; set; }
        public string INSTITUTE { get; set; }
        public int? YEAR_OF_PASSING { get; set; }
    }
}