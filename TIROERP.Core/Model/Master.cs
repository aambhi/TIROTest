using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Source
    {
        public int SOURCE_ID { get; set; }
        public string SOURCE_NAME { get; set; }
    }

    public class AvailingType
    {
        public int AVAILING_TYPE_ID { get; set; }
        public string AVAILING_TYPE { get; set; }
    }

    public class Status
    {
        public int STATUS_ID { get; set; }
        public string STATUS_NAME { get; set; }
        public string DESCRIPTION { get; set; }
    }

    public class MaritalStatus
    {
        public int MARITAL_STATUS_ID { get; set; }
        public string MARITAL_STATUS { get; set; }
    }

    public class Nationality
    {
        public int NATIONALITY_ID { get; set; }
        public string NATIONALITY { get; set; }
    }


    public class Language
    {
        public int LANGUAGE_ID { get; set; }
        public string LANGUAGE_NAME { get; set; }
    }
    public class University
    {
        public int UNIVERSITY_ID { get; set; }
        public string UNIVERSITY_NAME { get; set; }
    }

    public class Company
    {
        public int COMPANY_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CONTACT_PERSON { get; set; }
    }

    public class IndustryDesignation
    {
        public int? DESIGNATION_ID { get; set; }
        public string DESIGNATION_NAME { get; set; }
        public int? INDUSTRY_ID { get; set; }
        public string INDUSTRY_TYPE { get; set; }
    }
    public class EducationSpeciaization
    {
        public int? EDUCATION_TYPE_ID { get; set; }
        public string EDUCATION_TYPE { get; set; }
        public string SPECIALIZATION_TYPE { get; set; }
        public int? SPECIALIZATION_ID { get; set; }
    }

    public class Speciaization
    {
        public string SPECIALIZATION_TYPE { get; set; }
        public int SPECIALIZATION_ID { get; set; }
    }

    public class VehicleType
    {
        public int VEHICLE_TYPE_ID { get; set; }
        public string VEHICLE_TYPE { get; set; }
    }
    public class Branch
    {
        public string BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
    }
    public class VisaMaster
    {
        public int VISA_ID { get; set; }
        public string VISA_NUMBER { get; set; }
    }
    public class RequirementMaster
    {
        public int REQUIREMENT_ID { get; set; }
        public string REQUIREMENT { get; set; }
    }

    public class Gender
    {
        public string GENDER_CODE { get; set; }
        public string GENDER_NAME { get; set; }
        public int GENDER_ORDER { get; set; }
        public bool IS_ACTIVE { get; set; }
    }

    public class Religion
    {
        public int RELIGION_ID { get; set; }
        public string RELIGION_NAME { get; set; }
    }

    public class OtherSource
    {
        public string ID { get; set; }
        public string NAME { get; set; }
    }
}
