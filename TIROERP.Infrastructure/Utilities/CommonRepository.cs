using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Infrastructure.DBModel;

namespace TIROERP.Infrastructure.Utilities
{
    public class CommonRepository
    {
        ArbabTravelsERPEntities _entities;

        public static List<UDT_USER_DETAILS> GetLstUserDetails(Candidate candidate)
        {
            List<UDT_USER_DETAILS> lstUserDetails = new List<UDT_USER_DETAILS>();
            UDT_USER_DETAILS _udtuser = new UDT_USER_DETAILS();
            _udtuser.REGISTRATION_NO = candidate.REGISTRATION_NO;
            _udtuser.FIRST_NAME = candidate.FIRST_NAME;
            _udtuser.MIDDLE_NAME = candidate.MIDDLE_NAME;
            _udtuser.LAST_NAME = candidate.LAST_NAME;
            _udtuser.GAMCA_NO = candidate.GAMCA_NO;
            _udtuser.FILE_NAME = candidate.FILE_NAME;
            _udtuser.FILE_PATH = candidate.FILE_PATH;
            _udtuser.WEBSITE = candidate.WEBSITE;
            _udtuser.SKYPE = candidate.SKYPE;
            _udtuser.REMARK = candidate.REMARK;
            _udtuser.CONTACT_REMARK = candidate.CONTACT_REMARK;
            _udtuser.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            _udtuser.AVAILING_TYPE_ID = candidate.AVAILING_TYPE_ID;
            _udtuser.SOURCE_ID = candidate.SOURCE_ID;
            _udtuser.OTHER_SOURCE = candidate.OTHER_SOURCE;
            _udtuser.REFERRER_NAME = candidate.REFERRER_NAME;
            _udtuser.STATUS_ID = candidate.STATUS_ID;
            _udtuser.REQUIREMENT_ID = Convert.ToInt16(candidate.REQUIREMENT_ID);
            if (candidate.USER_TYPE_ID == 2)
            {
                candidate.LOGIN_ACCESS = true;
                candidate.LOGIN_PASSWORD = "pass123$";
            }
            _udtuser.LOGIN_ACCESS = candidate.LOGIN_ACCESS;
            _udtuser.LOGIN_PASSWORD = candidate.LOGIN_PASSWORD;
            _udtuser.IS_EXPERIENCED = candidate.IS_EXPERIENCED;
            _udtuser.EDUCATION_REMARK = candidate.EDUCATION_REMARK;
            _udtuser.WORK_REMARK = candidate.WORK_REMARK;
            _udtuser.BRANCH_CODE = candidate.BRANCH_CODE;
            _udtuser.LOCATION_CODE = candidate.LOCATION_CODE;
            _udtuser.COMPANY_NAME = candidate.COMPANY_NAME;
            _udtuser.TOTAL_WORK_EXPERIENCE = candidate.TOTAL_WORK_EXPERIENCE;
            _udtuser.TOTAL_GULF_EXPERIENCE = candidate.TOTAL_GULF_EXPERIENCE;
            _udtuser.SKILLS = candidate.SKILLS;
            _udtuser.FATHER_NAME = candidate.FATHER_NAME;
            _udtuser.MOTHER_NAME = candidate.MOTHER_NAME;
            _udtuser.GENDER_CODE = candidate.GENDER_CODE;
            _udtuser.DATE_OF_BIRTH = (candidate.DATE_OF_BIRTH);
            _udtuser.PLACE_OF_BIRTH = candidate.PLACE_OF_BIRTH;
            _udtuser.MARITAL_STATUS_ID = candidate.MARITAL_STATUS_ID;
            _udtuser.NATIONALITY_ID = candidate.NATIONALITY_ID;
            _udtuser.CURRENT_LOCATION = candidate.CURRENT_LOCATION;
            _udtuser.RELIGION_ID = candidate.RELIGION_ID;

            if (candidate.DESIGNATION != null)
            {
                _udtuser.DESIGNATION = string.Join(",", candidate.DESIGNATION);
            }
            if (candidate.INDUSTRY != null)
            {
                _udtuser.INDUSTRY = string.Join(",", candidate.INDUSTRY);
            }
            _udtuser.REFERENCE = candidate.REFERENCE;
            _udtuser.POST_APPLIED_FOR = candidate.POST_APPLIED_FOR;
            _udtuser.CIVILIAN_NO = candidate.CIVILIAN_NO;
            _udtuser.CLINIC_NAME = candidate.CLINIC_NAME;
            _udtuser.VISA_ID = candidate.VISA_ID;
            _udtuser.FILE_NO = candidate.FILE_NO;
            _udtuser.PERSONAL_REMARK = candidate.DRIVING_REMARK;
            lstUserDetails.Add(_udtuser);
            return lstUserDetails;
        }

        public static List<UDT_USER_ADDRESS> GetLstUserAddress(Candidate candidate)
        {
            List<UDT_USER_ADDRESS> lstUdtUserAddress = new List<UDT_USER_ADDRESS>();

            if (candidate.LST_USER_ADDRESS != null && candidate.LST_USER_ADDRESS.Count > 0)
            {
                lstUdtUserAddress = candidate.LST_USER_ADDRESS.Where(c => c.IsNew == true).Select(x => new UDT_USER_ADDRESS
                {
                    ADDRESS = x.ADDRESS,
                    ADDRESS_TYPE_ID = x.ADDRESS_TYPE_ID,
                    CITY_CODE = x.CITY_CODE,
                    CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO),
                    USER_PINCODE = x.USER_PINCODE,
                    USER_VILLAGE = x.USER_VILLAGE,
                    REGISTRATION_NO = candidate.REGISTRATION_NO,
                    USER_ADDRESS_ID = x.USER_ADDRESS_ID,
                    ISNEW = x.IsNew,
                    STATE_CODE = x.STATE_CODE

                }).ToList();
            }
            return lstUdtUserAddress;
        }

        public static List<UDT_USER_EMAIL> GetLstUserEmail(Candidate candidate)
        {
            List<UDT_USER_EMAIL> lstUdtUserEmail = new List<UDT_USER_EMAIL>();
            if (candidate.LST_USER_EMAIL != null && candidate.LST_USER_EMAIL.Count > 0)
            {
                lstUdtUserEmail = candidate.LST_USER_EMAIL.Where(c => c.IsNew == true).Select(x => new UDT_USER_EMAIL
                {
                    USER_EMAIL = x.USER_EMAIL,
                    REGISTRATION_NO = candidate.REGISTRATION_NO,
                    USER_EMAIL_ID = x.USER_EMAIL_ID,
                    ISNEW = x.IsNew
                }).ToList();
            }
            return lstUdtUserEmail;
        }

        public static List<UDT_USER_CONTACT> GetLstUserContact(Candidate candidate)
        {
            List<UDT_USER_CONTACT> lstUdtUserContact = new List<UDT_USER_CONTACT>();
            if (candidate.LST_USER_CONTACT != null && candidate.LST_USER_CONTACT.Count > 0)
            {
                lstUdtUserContact = candidate.LST_USER_CONTACT.Where(c => c.IsNew == true).Select(x => new UDT_USER_CONTACT
                {
                    CONTACT_NO = x.CONTACT_NO,
                    CONTACT_TYPE_ID = Convert.ToInt16(x.CONTACT_TYPE_ID),
                    CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO),
                    REGISTRATION_NO = candidate.REGISTRATION_NO,
                    USER_CONTACT_ID = x.USER_CONTACT_ID,
                    ISNEW = x.IsNew
                }).ToList();
            }
            return lstUdtUserContact;
        }

        public static List<UDT_USER_EDUCATION> GetLstUserEducation(Candidate candidate)
        {
            List<UDT_USER_EDUCATION> lstUdtUserEducation = new List<UDT_USER_EDUCATION>();
            if (candidate.LST_USER_EDUCATION != null && candidate.LST_USER_EDUCATION.Count > 0)
            {
                lstUdtUserEducation = candidate.LST_USER_EDUCATION.Where(c => c.IsNew == true).Select(x => new UDT_USER_EDUCATION
                {
                    EDUCATION_TYPE_ID = x.EDUCATION_TYPE_ID,
                    SPECIALIZATION_TYPE_ID = x.SPECIALIZATION_TYPE_ID,
                    UNIVERSITY_ID = x.UNIVERSITY_ID,
                    UNIVERSITY_YEAR_OF_PASSING = x.UNIVERSITY_YEAR_OF_PASSING,
                    IS_HIGHEST_QUALIFICATION = x.IS_HIGHEST_QUALIFICATION,
                    CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO),
                    IsNEW = x.IsNew,
                    USER_EDUCATION_ID = x.USER_EDUCATION_ID,
                    REGISTRATION_NO = candidate.REGISTRATION_NO
                }).ToList();
            }
            return lstUdtUserEducation;
        }

        public static List<UDT_USER_DOCUMENT> GetLstUserDocument(Candidate candidate)
        {
            List<UDT_USER_DOCUMENT> lstUdtUserDocument = new List<UDT_USER_DOCUMENT>();
            if (candidate.LST_USER_DOCUMENT != null && candidate.LST_USER_DOCUMENT.Count > 0)
            {
                lstUdtUserDocument = candidate.LST_USER_DOCUMENT.Where(c => c.IsNew == true).Select(x => new UDT_USER_DOCUMENT
                {
                    DOCUMENT_TYPE_ID = x.DOCUMENT_TYPE_ID,
                    DOCUMENT_PATH = x.DOCUMENT_PATH,
                    CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO),
                    REGISTRATION_NO = candidate.REGISTRATION_NO,
                    DOCUMENT_ID = x.DOCUMENT_ID,
                    ISNEW = x.IsNew

                }).ToList();
            }
            return lstUdtUserDocument;
        }

        public static List<UDT_USER_PASSPORT> GetLstUserPassport(Candidate candidate)
        {

            List<UDT_USER_PASSPORT> lstUdtUserPassport = new List<UDT_USER_PASSPORT>();
            try
            {

                if (!string.IsNullOrEmpty(candidate.PASSPORT_NUMBER))
                {
                    UDT_USER_PASSPORT _udtuser = new UDT_USER_PASSPORT();
                    _udtuser.PASSPORT_NUMBER = candidate.PASSPORT_NUMBER;
                    _udtuser.DATE_OF_ISSUE = (candidate.DATE_OF_ISSUE);
                    _udtuser.PLACE_OF_ISSUE = candidate.PLACE_OF_ISSUE;
                    _udtuser.DATE_OF_EXPIRY = (candidate.DATE_OF_EXPIRY);
                    _udtuser.EMIGRATION_CLEARANCE_REQUIRED = candidate.EMIGRATION_CLEARANCE_REQUIRED;
                    _udtuser.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                    _udtuser.PASSPORT_ID = Convert.ToInt32(candidate.PASSPORT_ID);
                    _udtuser.REGISTATION_NUMBER = candidate.REGISTRATION_NO;
                    lstUdtUserPassport.Add(_udtuser);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstUdtUserPassport;
        }

        public static List<UDT_USER_DRIVING> GetLstUserDriving(Candidate candidate)
        {
            List<UDT_USER_DRIVING> lstUdtUserDriving = new List<UDT_USER_DRIVING>();
            if (!string.IsNullOrEmpty(candidate.DRIVING_LICENCE_NUMBER))
            {
                UDT_USER_DRIVING _udtuser = new UDT_USER_DRIVING();
                _udtuser.DRIVING_LICENCE_NUMBER = candidate.DRIVING_LICENCE_NUMBER;
                _udtuser.PLACE_OF_ISSUE = candidate.DRIVING_PLACE_OF_ISSUE;
                _udtuser.DATE_OF_ISSUE = (candidate.DRIVING_DATE_OF_ISSUE);
                _udtuser.DATE_OF_EXPIRY = (candidate.DRIVING_EXPIRY_DATE);
                _udtuser.VEHICLE_TYPE_ID = candidate.VEHICLE_TYPE_ID;
                _udtuser.REMARK = candidate.DRIVING_REMARK;
                _udtuser.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                _udtuser.REGISTRATION_NO = candidate.REGISTRATION_NO;
                _udtuser.DRIVING_LICENCE_ID = Convert.ToInt32(candidate.DRIVING_LICENCE_ID);
                lstUdtUserDriving.Add(_udtuser);
            }
            return lstUdtUserDriving;
        }

        public static List<UDT_USER_LANGUAGE> GetLstUserLanguage(Candidate candidate)
        {
            List<UDT_USER_LANGUAGE> lstUdtUserLanguage = new List<UDT_USER_LANGUAGE>();

            if (candidate.LST_USER_LANGUAGE != null && candidate.LST_USER_LANGUAGE.Count > 0)
            {
                lstUdtUserLanguage = candidate.LST_USER_LANGUAGE.Where(c => c.IsNew == true).Select(x => new UDT_USER_LANGUAGE
                {
                    LANGUAGE_ID = x.LANGUAGE_ID,
                    IS_READ = x.IS_READ,
                    IS_WRITE = x.IS_WRITE,
                    IS_SPEAK = x.IS_SPEAK,
                    REGISTRATION_NO = candidate.REGISTRATION_NO,
                    USER_LANGUAGE_ID = x.USER_LANGUAGE_ID,
                    ISNEW = x.IsNew
                }).ToList();
            }
            return lstUdtUserLanguage;
        }

        public List<UDT_USER_CERTIFICATION> GetLstUserCertification(Candidate candidate)
        {
            _entities = new ArbabTravelsERPEntities();
            List<UDT_USER_CERTIFICATION> lstUdtUserCertification = new List<UDT_USER_CERTIFICATION>();
            if (candidate.LST_USER_CERTIFICATION != null && candidate.LST_USER_CERTIFICATION.Count > 0)
            {
                foreach (var certification in candidate.LST_USER_CERTIFICATION)
                {
                    UDT_USER_CERTIFICATION udtCert = new UDT_USER_CERTIFICATION();
                    if (certification.IsNew)
                    {

                        if (!string.IsNullOrEmpty(certification.OTHER_CERTIFICATION))
                        {
                            TBL_CERTIFICATION_MASTER tblcertification = new TBL_CERTIFICATION_MASTER();
                            tblcertification.CERTIFICATION_NAME = certification.OTHER_CERTIFICATION;
                            tblcertification.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                            tblcertification.CREATED_DATE = DateTime.Now;
                            tblcertification.IS_ACTIVE = true;
                            _entities.TBL_CERTIFICATION_MASTER.Add(tblcertification);
                            _entities.SaveChanges();
                            certification.CERTIFICATION_ID = tblcertification.CERTIFICATION_ID;
                            udtCert.CERTIFICATION = tblcertification.CERTIFICATION_ID.ToString();
                        }
                        else
                        {
                            udtCert.CERTIFICATION = certification.CERTIFICATION_ID.ToString();
                        }
                        udtCert.CERTIFICATION_LEVEL = certification.CERTIFICATION_LEVEL;
                        udtCert.INSTITUTE = certification.INSTITUTE;
                        udtCert.YEAR_OF_PASSING = certification.YEAR_OF_PASSING;
                        udtCert.REGISTRATION_NO = candidate.REGISTRATION_NO;
                        udtCert.ISNEW = certification.IsNew;
                        udtCert.USER_CERTIFICATION_ID = certification.USER_CERTIFICATION_ID;

                        lstUdtUserCertification.Add(udtCert);
                    }
                }
            }
            return lstUdtUserCertification;
        }

        public List<UDT_USER_EXPERIENCE> GetLstUserExperience(Candidate candidate)
        {
            _entities = new ArbabTravelsERPEntities();
            List<UDT_USER_EXPERIENCE> lstUdtUserExperiecne = new List<UDT_USER_EXPERIENCE>();

            if (candidate.LST_USER_EXPERIENCE != null && candidate.LST_USER_EXPERIENCE.Count > 0)
            {
                foreach (var experience in candidate.LST_USER_EXPERIENCE)
                {
                    UDT_USER_EXPERIENCE udtExp = new UDT_USER_EXPERIENCE();
                    if (experience.ISNEW)
                    {

                        if (!string.IsNullOrEmpty(experience.OTHER_COMPANY))
                        {
                            int companyId = _entities.TBL_COMPANY_MASTER.Where(x => x.COMPANY_NAME.Trim().ToLower() == experience.OTHER_COMPANY.Trim().ToLower()).Select(c => c.COMPANY_ID).FirstOrDefault();
                            if (companyId > 0)
                            {
                                experience.USER_COMPANY_NAME = Convert.ToString(companyId);
                            }
                            else
                            {
                                TBL_COMPANY_MASTER tblcompany = new TBL_COMPANY_MASTER();
                                tblcompany.COMPANY_NAME = experience.OTHER_COMPANY;
                                tblcompany.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                                tblcompany.CREATED_DATE = DateTime.Now;
                                tblcompany.IS_ACTIVE = true;
                                _entities.TBL_COMPANY_MASTER.Add(tblcompany);
                                _entities.SaveChanges();
                                experience.USER_COMPANY_NAME = Convert.ToString(tblcompany.COMPANY_ID);
                            }
                        }

                        if (!string.IsNullOrEmpty(experience.OTHER_DESIGNATION))
                        {
                            int designationId = _entities.TBL_DESIGNATION_MASTER.Where(x => x.DESIGNATION_NAME.Trim().ToLower() == experience.OTHER_DESIGNATION.Trim().ToLower()).Select(c => c.DESIGNATION_ID).FirstOrDefault();
                            if (designationId > 0)
                            {
                                experience.DESIGNATION_ID = Convert.ToInt32(designationId);
                            }
                            else
                            {
                                TBL_DESIGNATION_MASTER tbldesignation = new TBL_DESIGNATION_MASTER();
                                tbldesignation.DESIGNATION_NAME = experience.OTHER_DESIGNATION;
                                tbldesignation.INDUSTRY_ID = Convert.ToInt16(experience.INDUSTRY_ID);
                                tbldesignation.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                                tbldesignation.CREATED_DATE = DateTime.Now;
                                tbldesignation.IS_ACTIVE = true;
                                _entities.TBL_DESIGNATION_MASTER.Add(tbldesignation);
                                _entities.SaveChanges();
                                experience.DESIGNATION_ID = Convert.ToInt32(tbldesignation.DESIGNATION_ID);
                            }
                        }
                        udtExp.USER_COMPANY_NAME = experience.USER_COMPANY_NAME;
                        udtExp.IS_CURRENT_COMPANY = experience.IS_CURRENT_COMPANY;
                        udtExp.DESIGNATION_ID = experience.DESIGNATION_ID;
                        udtExp.INDUSTRY_ID = experience.INDUSTRY_ID;
                        udtExp.CITY_CODE = experience.WORK_CITY_CODE;
                        udtExp.WORK_PERIOD_FROM = (experience.WORK_PERIOD_FROM);
                        udtExp.WORK_PERIOD_TO = (experience.WORK_PERIOD_TO);
                        udtExp.TOTAL_WORK_EXPERIENCE = experience.TOTAL_WORK_EXPERIENCE;
                        udtExp.REMARK = experience.REMARK;
                        udtExp.ISNEW = experience.ISNEW;
                        udtExp.EXPERIENCE_ID = experience.EXPERIENCE_ID;
                        udtExp.REGISTRATION_NO = candidate.REGISTRATION_NO;
                        udtExp.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                        udtExp.STATE_CODE = experience.WORK_STATE_CODE;
                        udtExp.COUNTRY_CODE = experience.COUNTRY_CODE;
                        lstUdtUserExperiecne.Add(udtExp);
                    }
                }
            }
            return lstUdtUserExperiecne;
        }

        public List<Country> LstGetCountryStateCity(string code)
        {
            _entities = new ArbabTravelsERPEntities();
            var lstresult = _entities.TBL_STATE_MASTER.Where(x => x.COUNTRY_CODE.Trim().ToLower() == code.Trim().ToLower() && x.IS_ACTIVE == true).Select(c => new Country
            {
                STATE_CODE = c.ID.ToString(),
                STATE_NAME = c.STATE_NAME
            }).OrderBy(d => d.STATE_NAME).ToList();
            return lstresult;
        }

        public List<EducationSpeciaization> LstGetSpecializationByEducation(int educationId)
        {
            _entities = new ArbabTravelsERPEntities();
            var lstresult = (_entities.TBL_SPECIALIZATION_MASTER.Where(x => x.EDUCATION_TYPE_ID == educationId && x.IS_ACTIVE == true))
                .Select(d => new EducationSpeciaization
                {
                    SPECIALIZATION_ID = d.SPECIALIZATION_ID,
                    SPECIALIZATION_TYPE = d.SPECIALIZATION_TYPE
                }).ToList();
            return lstresult;
        }

        public List<IndustryDesignation> LstGetDesignationByIndustry(int industryId)
        {
            _entities = new ArbabTravelsERPEntities();
            var lstresult = (_entities.TBL_DESIGNATION_MASTER.Where(x => x.INDUSTRY_ID == industryId && x.IS_ACTIVE == true)).Select(x => new IndustryDesignation
            {
                DESIGNATION_ID = x.DESIGNATION_ID,
                DESIGNATION_NAME = x.DESIGNATION_NAME
            }).ToList();
            return lstresult;
        }

        public List<IndustryDesignation> LstGetDesignationByIndustry(int[] industry)
        {
            _entities = new ArbabTravelsERPEntities();

            var lstdesignation = _entities.TBL_DESIGNATION_MASTER.Where(c => c.IS_ACTIVE == true && industry.Contains(c.INDUSTRY_ID)).ToList()
                .Select(c => new IndustryDesignation
                {
                    DESIGNATION_ID = c.DESIGNATION_ID,
                    DESIGNATION_NAME = c.DESIGNATION_NAME,
                }).ToList();

            return lstdesignation;
        }

        public string GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            _entities = new ArbabTravelsERPEntities();
            candidateName = _entities.PROC_GET_CANDIDATE_NAME_BASED_ON_PASPPORT_NO(userRequirementId).Select(x => x).FirstOrDefault().ToString();
            return candidateName;
        }

        public List<Passport_Details> GetPassportNumbers(string status)
        {
            _entities = new ArbabTravelsERPEntities();
            var result = _entities.PROC_GET_PASSPORT_DETAILS(status).ToList().Select(x => new Passport_Details
            {
                PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID
            }).ToList();

            return result;
        }

        public static List<UDT_PROCESS_MEDICAL> GetProcessMedical(Candidate candidate)
        {
            List<UDT_PROCESS_MEDICAL> lstUdtMedical = new List<UDT_PROCESS_MEDICAL>();
            if (candidate.Medical_Details != null)
            {
                UDT_PROCESS_MEDICAL _udtmedical = new UDT_PROCESS_MEDICAL();
                _udtmedical.MedicalId = candidate.Medical_Details.MedicalId;
                _udtmedical.USER_REQUIREMENT_ID = candidate.Medical_Details.USER_REQUIREMENT_ID;
                _udtmedical.DoctorID = candidate.Medical_Details.DoctorID;
                _udtmedical.CheckupDate = !string.IsNullOrEmpty(candidate.Medical_Details.CheckupDate) ? Convert.ToDateTime(candidate.Medical_Details.CheckupDate) : (DateTime?)null;
                _udtmedical.TokenNumber = candidate.Medical_Details.TokenNumber;
                _udtmedical.ReportDate = !string.IsNullOrEmpty(candidate.Medical_Details.ReportDate) ? Convert.ToDateTime(candidate.Medical_Details.ReportDate) : (DateTime?)null;
                _udtmedical.MedicalStatus = candidate.Medical_Details.MedicalStatus;
                _udtmedical.ReportPath = candidate.Medical_Details.ReportPath;
                _udtmedical.Remark = candidate.Medical_Details.Remark;
                _udtmedical.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);

                lstUdtMedical.Add(_udtmedical);
            }
            return lstUdtMedical;
        }

        public static List<UDT_PROCESS_MOFA> GetProcessMofa(Candidate candidate)
        {
            List<UDT_PROCESS_MOFA> lstUdtMofa = new List<UDT_PROCESS_MOFA>();
            if (candidate.MOFA_Details != null)
            {
                UDT_PROCESS_MOFA _udtmofa = new UDT_PROCESS_MOFA();
                _udtmofa.MofaID = candidate.MOFA_Details.MofaID;
                _udtmofa.USER_REQUIREMENT_ID = candidate.MOFA_Details.USER_REQUIREMENT_ID;
                _udtmofa.MofaNumber = candidate.MOFA_Details.MofaNumber;
                _udtmofa.MofaDate = !string.IsNullOrEmpty(candidate.MOFA_Details.MofaDate) ? Convert.ToDateTime(candidate.MOFA_Details.MofaDate) : (DateTime?)null;
                _udtmofa.ApplicationNumber = candidate.MOFA_Details.ApplicationNumber;
                _udtmofa.ApplicationDate = !string.IsNullOrEmpty(candidate.MOFA_Details.ApplicationDate) ? Convert.ToDateTime(candidate.MOFA_Details.ApplicationDate) : (DateTime?)null;
                _udtmofa.HealthNumber = candidate.MOFA_Details.HealthNumber;
                _udtmofa.HealthDate = !string.IsNullOrEmpty(candidate.MOFA_Details.HealthDate) ? Convert.ToDateTime(candidate.MOFA_Details.HealthDate) : (DateTime?)null;
                _udtmofa.DDNumber = candidate.MOFA_Details.DDNumber;
                _udtmofa.DDDate = !string.IsNullOrEmpty(candidate.MOFA_Details.DDDate) ? Convert.ToDateTime(candidate.MOFA_Details.DDDate) : (DateTime?)null;
                _udtmofa.MofaFilePath = candidate.MOFA_Details.MofaFilePath;
                _udtmofa.MofaRemark = candidate.MOFA_Details.MofaRemark;
                _udtmofa.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);

                lstUdtMofa.Add(_udtmofa);
            }
            return lstUdtMofa;
        }

        public static List<UDT_PROCESS_VISA_ENDORSEMENT> GetProcessVisaEndorsement(Candidate candidate)
        {
            List<UDT_PROCESS_VISA_ENDORSEMENT> lstUdtVisa = new List<UDT_PROCESS_VISA_ENDORSEMENT>();
            if (candidate.VisaEndorsement_Details != null)
            {
                UDT_PROCESS_VISA_ENDORSEMENT _udtvisa = new UDT_PROCESS_VISA_ENDORSEMENT();
                _udtvisa.VisaEndorsementId = candidate.VisaEndorsement_Details.VisaEndorsementId;
                _udtvisa.USER_REQUIREMENT_ID = candidate.VisaEndorsement_Details.USER_REQUIREMENT_ID;
                _udtvisa.SubmissionDate = !string.IsNullOrEmpty(candidate.VisaEndorsement_Details.SubmissionDate) ? Convert.ToDateTime(candidate.VisaEndorsement_Details.SubmissionDate) : (DateTime?)null;
                _udtvisa.SubmissionStatusID = candidate.VisaEndorsement_Details.SubmissionStatusID;
                _udtvisa.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                _udtvisa.VisaEndorsementFilePath = candidate.VisaEndorsement_Details.VisaEndorsementFilePath;
                lstUdtVisa.Add(_udtvisa);
            }
            return lstUdtVisa;
        }

        public static List<UDT_PROCESS_POLICY> GetProcessPolicy(Candidate candidate)
        {
            List<UDT_PROCESS_POLICY> lstUdtPolicy = new List<UDT_PROCESS_POLICY>();
            if (candidate.Policy_Details != null)
            {
                UDT_PROCESS_POLICY _udtpolicy = new UDT_PROCESS_POLICY();
                _udtpolicy.POLICYID = candidate.Policy_Details.POLICYID;
                _udtpolicy.USER_REQUIREMENT_ID = candidate.Policy_Details.USER_REQUIREMENT_ID;
                _udtpolicy.Policy = candidate.Policy_Details.PolicyNumber;
                _udtpolicy.PolicyDate = candidate.Policy_Details.PolicyDate;
                _udtpolicy.PolicyFees = candidate.Policy_Details.PolicyFees;
                _udtpolicy.PolicyRemark = candidate.Policy_Details.PolicyRemark;
                _udtpolicy.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                lstUdtPolicy.Add(_udtpolicy);
            }
            return lstUdtPolicy;
        }

        public static List<UDT_PROCESS_EMIGRATION> GetProcessEmigration(Candidate candidate)
        {
            List<UDT_PROCESS_EMIGRATION> lstUdtEmigration = new List<UDT_PROCESS_EMIGRATION>();
            if (candidate.Emigration_Details != null)
            {
                UDT_PROCESS_EMIGRATION _udtemigration = new UDT_PROCESS_EMIGRATION();
                _udtemigration.EMIGRATION_ID = candidate.Emigration_Details.EMIGRATION_ID;
                _udtemigration.USER_REQUIREMENT_ID = candidate.Emigration_Details.USER_REQUIREMENT_ID;
                _udtemigration.FE_NO = candidate.Emigration_Details.FE_NO;
                _udtemigration.PT_NO = candidate.Emigration_Details.PT_NO;
                _udtemigration.DM_NO = candidate.Emigration_Details.DM_NO;
                _udtemigration.DM_DATE = candidate.Emigration_Details.DM_DATE;
                _udtemigration.POLICY_NO = candidate.Emigration_Details.POLICY_NO;
                _udtemigration.POLICY_DATE = candidate.Emigration_Details.POLICY_DATE;
                _udtemigration.POLICY_AMOUNT = candidate.Emigration_Details.POLICY_AMOUNT;
                _udtemigration.POLICY_COMPANYNAME = candidate.Emigration_Details.POLICY_COMPANYNAME;
                _udtemigration.POLICY_ATTACHMENT = candidate.Emigration_Details.POLICY_ATTACHMENT;
                _udtemigration.SUBMISSION_DATE = candidate.Emigration_Details.SUBMISSION_DATE;
                _udtemigration.EMIGRATION_CLEARANCENO = candidate.Emigration_Details.EMIGRATION_CLEARANCENO;
                _udtemigration.EMIGRATION_ATTACHMENT = candidate.Emigration_Details.EMIGRATION_ATTACHMENT;
                _udtemigration.POE = candidate.Emigration_Details.POE;
                _udtemigration.REMARK = candidate.Emigration_Details.REMARK;
                _udtemigration.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                _udtemigration.IS_ECR = candidate.Emigration_Details.IS_ECR;

                lstUdtEmigration.Add(_udtemigration);
            }
            return lstUdtEmigration;
        }

        public List<UDT_TICKET_DETAILS> GetProcessTicket(Ticket ticket)
        {
            List<UDT_TICKET_DETAILS> ticket_details_list = new List<UDT_TICKET_DETAILS>();
            if (ticket != null)
            {
                _entities = new ArbabTravelsERPEntities();
                UDT_TICKET_DETAILS udt_ticket_object = new UDT_TICKET_DETAILS();

                //ticket details
                udt_ticket_object.TicketId = ticket.TicketID;
                udt_ticket_object.USER_REQUIREMENT_ID = ticket.USER_REQUIREMENT_ID;

                if (!string.IsNullOrEmpty(ticket.OtherAirlines))
                {
                    int airlinesId = _entities.TBL_AIRLINES_MASTER.Where(x => x.AirlinesName.Trim().ToLower() == ticket.OtherAirlines.Trim().ToLower()).Select(c => c.AirlinesId).FirstOrDefault();
                    if (airlinesId > 0)
                    {
                        ticket.AirlinesID = Convert.ToInt32(airlinesId);
                    }
                    else
                    {
                        TBL_AIRLINES_MASTER tblairline = new TBL_AIRLINES_MASTER();
                        tblairline.AirlinesName = ticket.OtherAirlines;
                        tblairline.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                        tblairline.CreatedDate = DateTime.Now;
                        tblairline.IsActive = true;
                        _entities.TBL_AIRLINES_MASTER.Add(tblairline);
                        _entities.SaveChanges();
                        ticket.AirlinesID = Convert.ToInt32(tblairline.AirlinesId);
                    }
                }

                udt_ticket_object.AirlinesID = ticket.AirlinesID;
                udt_ticket_object.IsDirect = ticket.IsDirect == "D" ? true : false;
                udt_ticket_object.PnrNumber = ticket.PnrNumber;
                udt_ticket_object.TicketNumber = ticket.TicketNumber;
                udt_ticket_object.FlightNumber = ticket.FlightNumber;
                udt_ticket_object.IsBooked = ticket.IsBooked == "B" ? true : false;
                udt_ticket_object.IsCancelled = ticket.IsCancelled == "C" ? true : false;
                udt_ticket_object.DepartureCityCode = ticket.DepartureCityCode;
                udt_ticket_object.DepartureDate = !string.IsNullOrEmpty(ticket.DepartureDate) ? Convert.ToDateTime(ticket.DepartureDate) : (DateTime?)null;
                udt_ticket_object.DepartureTime = ticket.DepartureTime;
                udt_ticket_object.ArivalDate = !string.IsNullOrEmpty(ticket.ArivalDate) ? Convert.ToDateTime(ticket.ArivalDate) : (DateTime?)null;
                udt_ticket_object.ArrivalTime = ticket.ArrivalTime;
                udt_ticket_object.DestinationCityCode = ticket.DestinationCityCode;
                udt_ticket_object.ReportPath = ticket.ReportPath;
                udt_ticket_object.Remark = ticket.Remark;
                udt_ticket_object.createdBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);

                //connected ticket details
                udt_ticket_object.Conn_PnrNumber = ticket.Conn_PnrNumber;
                udt_ticket_object.Conn_TicketNumber = ticket.Conn_TicketNumber;
                udt_ticket_object.Conn_FlightNumber = ticket.Conn_FlightNumber;
                udt_ticket_object.Conn_IsBooked = ticket.Conn_IsBooked == "B" ? true : false;
                udt_ticket_object.Conn_IsCancelled = ticket.Conn_IsCancelled == "C" ? true : false;
                udt_ticket_object.Conn_DepartureCityCode = ticket.Conn_DepartureCityCode;
                udt_ticket_object.Conn_DepartureDate = !string.IsNullOrEmpty(ticket.Conn_DepartureDate) ? Convert.ToDateTime(ticket.Conn_DepartureDate) : (DateTime?)null;
                udt_ticket_object.Conn_DepartureTime = ticket.Conn_DepartureTime;
                udt_ticket_object.Conn_ArivalDate = !string.IsNullOrEmpty(ticket.Conn_ArivalDate) ? Convert.ToDateTime(ticket.Conn_ArivalDate) : (DateTime?)null;
                udt_ticket_object.Conn_ArrivalTime = ticket.Conn_ArrivalTime;
                udt_ticket_object.Conn_DestinationCityCode = ticket.Conn_DestinationCityCode;

                ticket_details_list.Add(udt_ticket_object);
            }
            return ticket_details_list;
        }

        public static void LogError(string Controller, string PageUrl, string Action, string ErrorMessage = null, string InnerException = null, string userCode = null, string UserIp = null)
        {

            string LOG_FILE = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory) + "Log\\" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt";
            //set up a filestream
            FileStream fs = new FileStream(LOG_FILE, FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text
            sw.WriteLine("==================================================================\r\nDateTime" + DateTime.Now.ToString() + "\r\n Controller: " +
                Controller + "\r\n URL: " + PageUrl + "\r\n Action: " + Action + "\r\n Error Message: " + ErrorMessage + "\r\n Inner Exception: " + InnerException + "\r\n User: " + userCode + "\r\n UserIP: " + UserIp + "\r\n==================================================================");
            //add the text to the underlying filestream

            sw.Flush();
            //close the writersw.Close();

            sw.Close();
        }
    }
}
