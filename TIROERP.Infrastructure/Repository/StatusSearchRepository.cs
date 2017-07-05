using EntityFrameworkExtras.EF6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.DBModel;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class StatusSearchRepository : IStatusSearch
    {
        ArbabTravelsERPEntities _entities;
        CommonRepository commonRepoObj = new CommonRepository();

        public List<CandidateSearch> GetCandidateResult(CandidateSearch search)
        {
            _entities = new ArbabTravelsERPEntities();

            var candidateresult = (_entities.PROC_STATUS_SEARCH_CANDIDATE(search.REGISTRATION_NO, search.PASSPORT_NO, search.NAME, search.DOB, search.CONTACT_NO, search.USER_TYPE_ID)).ToList()
                .Select(x => new CandidateSearch
                {
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    NAME = x.CANDIDATE_NAME,
                    DOB = x.DATE_OF_BIRTH,
                    PASSPORT_NO = x.PASSPORT_NUMBER,
                    CONTACT_NO = x.CONTACT_NO
                }).ToList();
            return candidateresult;
        }

        public List<IEnumerable> GetCandidateDetails(string registrationNo, string conditional_operator)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = conditional_operator };

            var results = new ArbabTravelsERPEntities()
                            .MultipleResults("[dbo].[PROC_CANDIDATE_STATUS_SEARCH]")
                            .With<Candidate>()
                            .With<UserEducation>()
                            .With<UserCertification>()
                            .With<UserExperience>()
                            .With<UserDocument>()
                            .With<UserRequirement>()
                            .With<UserLanguage>()
                            .With<UserAddress>()
                            .With<UserContact>()
                            .With<UserEmail>()
                            .Execute(REGISTRATION_NO, CONDITIONAL_OPERATOR);

            return results;
        }

        public List<IEnumerable> GetPeopleDetails(string registrationNo, string conditional_operator)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = conditional_operator };

            var results = new ArbabTravelsERPEntities()
                            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_PEOPLE_DETAILS]")
                            .With<Candidate>()
                            .With<UserAddress>()
                            .With<UserContact>()
                            .With<UserEmail>()
                            .Execute(REGISTRATION_NO, CONDITIONAL_OPERATOR);
            return results;
        }

        public List<IEnumerable> GetProcessDetails(int userRequirementId)
        {
            var USER_REQUIREMENT_ID = new SqlParameter { ParameterName = "USER_REQUIREMENT_ID", Value = userRequirementId };

            var results = new ArbabTravelsERPEntities()
                            .MultipleResults("[dbo].[PROC_GET_PROCESS_DETAILS]")
                            .With<Mofa>()
                            .With<Medical>()
                            .With<VisaEndorsement>()
                            .With<Emigration>()
                            .With<Ticket>()
                            .Execute(USER_REQUIREMENT_ID);
            return results;
        }

        public List<IEnumerable> GetMasterData()
        {
            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_USER_GETMASTER]")
                .With<Country>()
                .With<ContactType>()
                .With<AvailingType>()
                .With<Source>()
                .With<Status>()
                .With<MaritalStatus>()
                .With<Nationality>()
                .With<Language>()
                .With<University>()
                .With<Company>()
                .With<IndustryDesignation>()
                .With<UserEducation>()
                .With<VehicleType>()
                .With<Branch>()
                .With<Certification>()
                .With<VisaMaster>()
                .With<RequirementMaster>()
                .With<Gender>()
                .With<Religion>()
                .With<City>()
                .Execute();

            return results;
        }

        public List<IEnumerable> GetPeopleMasterData()
        {
            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_USER_GETMASTER_PEOPLE]")
                .With<Country>()
                .With<ContactType>()
                .With<IndustryDesignation>()
                .With<City>()
                .Execute();

            return results;
        }

        public List<UserEducation> GetUserEducationDetails(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };

            var results = new ArbabTravelsERPEntities()
            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_EDUCATION_DETAILS]")
            .With<UserEducation>()
            .Execute(REGISTRATION_NO);

            return (List<UserEducation>)results[0];
        }

        public List<UserCertification> GetUserCertificationDetails(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };

            var userCertificationDetails = new ArbabTravelsERPEntities()
            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_CERTIFICATION_DETAILS]")
            .With<UserCertification>()
            .Execute(REGISTRATION_NO);

            return (List<UserCertification>)userCertificationDetails[0];
        }

        public Candidate GetCandidateContactDetails(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };

            var results = new ArbabTravelsERPEntities()
            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_USER_CONTACT_DETAILS]")
            .With<UserAddress>()
            .With<UserContact>()
            .With<UserEmail>()
            .With<Candidate>()
            .Execute(REGISTRATION_NO);

            Candidate candidateObj = new Candidate();

            candidateObj.LST_USER_ADDRESS = (List<UserAddress>)results[0];
            candidateObj.LST_USER_CONTACT = (List<UserContact>)results[1];
            candidateObj.LST_USER_EMAIL = (List<UserEmail>)results[2];
            var otherdetails = (List<Candidate>)results[3];
            candidateObj.WEBSITE = otherdetails[0].WEBSITE;
            candidateObj.SKYPE = otherdetails[0].SKYPE;
            candidateObj.CONTACT_REMARK = otherdetails[0].CONTACT_REMARK;

            return candidateObj;

        }

        public Candidate GetCandidateDocumentDetails(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };

            var results = new ArbabTravelsERPEntities()
            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_USER_DOCUMENT_DETAILS]")
            .With<UserDocument>()
            .Execute(REGISTRATION_NO);

            Candidate candidateObj = new Candidate();

            candidateObj.LST_USER_DOCUMENT = (List<UserDocument>)results[0];

            return candidateObj;
        }

        public Candidate GetCandidateExperienceDetails(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };

            var results = new ArbabTravelsERPEntities()
            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_USER_EXPERIENCE_DETAILS]")
            .With<UserExperience>()
            .Execute(REGISTRATION_NO);

            Candidate candidateObj = new Candidate();

            candidateObj.LST_USER_EXPERIENCE = (List<UserExperience>)results[0];

            return candidateObj;
        }

        public Candidate GetCandidatePersonalDetails(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = "UPDATE" };

            var results = new ArbabTravelsERPEntities()
            .MultipleResults("[dbo].[PROC_STATUS_SEARCH_GET_USER_PERSONAL_DETAILS]")
            .With<Candidate>()
            .With<UserLanguage>()
            .Execute(REGISTRATION_NO, CONDITIONAL_OPERATOR);

            Candidate candidateObj = new Candidate();

            var lstcand = (List<Candidate>)results[0];
            candidateObj = lstcand[0];
            candidateObj.LST_USER_LANGUAGE = (List<UserLanguage>)results[1];

            return candidateObj;
        }

        public Candidate UpdateCandidateDetails(Candidate candidate)
        {
            _entities = new ArbabTravelsERPEntities();
            Candidate candidateresult = new Candidate();
            candidateresult.CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR;
            try
            {
                var procedure = new PROC_UPDATE_CANDIDATE()
                {
                    UDT_USER_DETAIL = CommonRepository.GetLstUserDetails(candidate),//lstUserDetails,
                    Conditional_Operator = candidate.CONDITIONAL_OPERATOR,
                    UDT_USER_PASSPORT = CommonRepository.GetLstUserPassport(candidate),
                    UDT_USER_DRIVING = CommonRepository.GetLstUserDriving(candidate),
                    UDT_USER_EDUCATION = CommonRepository.GetLstUserEducation(candidate),
                    UDT_USER_CERTIFICATION = commonRepoObj.GetLstUserCertification(candidate),
                    UDT_USER_ADDRESS = CommonRepository.GetLstUserAddress(candidate),
                    UDT_USER_CONTACT = CommonRepository.GetLstUserContact(candidate),
                    UDT_USER_EMAIL = CommonRepository.GetLstUserEmail(candidate),
                    UDT_USER_DOCUMENTS = CommonRepository.GetLstUserDocument(candidate),
                    UDT_USER_EXPERIENCE = commonRepoObj.GetLstUserExperience(candidate),
                    UDT_USER_LANGUAGE = CommonRepository.GetLstUserLanguage(candidate),
                    UDT_PROCESS_MEDICAL = CommonRepository.GetProcessMedical(candidate),
                    UDT_PROCESS_MOFA = CommonRepository.GetProcessMofa(candidate),
                    UDT_PROCESS_VISA_ENDORSEMENT = CommonRepository.GetProcessVisaEndorsement(candidate),
                    UDT_PROCESS_POLICY = CommonRepository.GetProcessPolicy(candidate),
                    UDT_TICKET_DETAILS = commonRepoObj.GetProcessTicket(candidate.Ticket_Details),
                    UDT_PROCESS_EMIGRATION = CommonRepository.GetProcessEmigration(candidate),
                };
                if (candidate.CONDITIONAL_OPERATOR == "UPDATE_PERSONAL_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    var personaldetails = results
                        .Select(x => new Candidate
                        {
                            REGISTRATION_NO = x.REGISTRATION_NO,
                            REGISTRATION_DATE = Convert.ToDateTime(Convert.ToDateTime(x.REGISTRATION_DATE).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                            Candidate_Name = x.Candidate_Name,
                            AVAILING_TYPE = x.AVAILING_TYPE,
                            SOURCE_NAME = x.SOURCE_NAME,
                            STATUS_NAME = x.STATUS_NAME,
                            POST_APPLIED_FOR = x.POST_APPLIED_FOR,
                            FILE_NO = x.FILE_NO,
                            REQUIREMENT = x.REQUIREMENT,
                            VISA_NUMBER = x.VISA_NUMBER,
                            REMARK = x.REMARK,
                            FATHER_NAME = x.FATHER_NAME,
                            MOTHER_NAME = x.MOTHER_NAME,
                            GENDER_NAME = x.GENDER_NAME,
                            DATE_OF_BIRTH = Convert.ToDateTime(Convert.ToDateTime(x.DATE_OF_BIRTH).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                            Age = x.Age,
                            PLACE_OF_BIRTH = x.PLACE_OF_BIRTH,
                            MARITAL_STATUS = x.MARITAL_STATUS,
                            NATIONALITY = x.NATIONALITY,
                            CURRENT_LOCATION = x.CURRENT_LOCATION,
                            RELIGION_NAME = x.RELIGION_NAME,
                            PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                            PLACE_OF_ISSUE = x.PLACE_OF_ISSUE,
                            DATE_OF_ISSUE = x.DATE_OF_ISSUE != null ? Convert.ToDateTime(Convert.ToDateTime(x.DATE_OF_ISSUE).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)) : (DateTime?)null,
                            DATE_OF_EXPIRY = x.DATE_OF_EXPIRY != null ? Convert.ToDateTime(Convert.ToDateTime(x.DATE_OF_EXPIRY).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)) : (DateTime?)null,
                            EMIGRATION_CLEARANCE_REQUIRED = x.EMIGRATION_CLEARANCE_REQUIRED,
                            DRIVING_LICENCE_NUMBER = x.DRIVING_LICENCE_NUMBER,
                            DRIVING_PLACE_OF_ISSUE = x.DRIVING_PLACE_OF_ISSUE,
                            DRIVING_DATE_OF_ISSUE = x.DRIVING_DATE_OF_ISSUE != null ? Convert.ToDateTime(Convert.ToDateTime(x.DRIVING_DATE_OF_ISSUE).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)) : (DateTime?)null,
                            DRIVING_EXPIRY_DATE = x.DRIVING_EXPIRY_DATE != null ? Convert.ToDateTime(Convert.ToDateTime(x.DRIVING_EXPIRY_DATE).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)) : (DateTime?)null,
                            VEHICLE_TYPE = x.VEHICLE_TYPE,
                            FILE_PATH = x.FILE_PATH,
                            WEBSITE = x.WEBSITE,
                            SKYPE = x.SKYPE,
                            SKILLS = x.SKILLS,
                            CONTACT_REMARK = x.CONTACT_REMARK,
                            WORK_REMARK = x.WORK_REMARK,
                            EDUCATION_REMARK = x.EDUCATION_REMARK,
                            DRIVING_REMARK = x.DRIVING_REMARK,
                            REFERRER_NAME = x.REFERRER_NAME,
                            TOTAL_WORK_EXPERIENCE = x.TOTAL_WORK_EXPERIENCE,
                            TOTAL_GULF_EXPERIENCE = x.TOTAL_GULF_EXPERIENCE,
                            GENDER_CODE = x.GENDER_CODE,
                            MARITAL_STATUS_ID = x.MARITAL_STATUS_ID,
                            NATIONALITY_ID = x.NATIONALITY_ID,
                            RELIGION_ID = x.RELIGION_ID,
                            VEHICLE_TYPE_ID = x.VEHICLE_TYPE_ID,
                            FIRST_NAME = x.FIRST_NAME,
                            MIDDLE_NAME = x.MIDDLE_NAME,
                            LAST_NAME = x.LAST_NAME,
                            PASSPORT_ID = x.PASSPORT_ID,
                            DRIVING_LICENCE_ID = x.DRIVING_LICENCE_ID,
                            LANGUAGES = x.LANGUAGES,
                            CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR
                        }).ToList();

                    candidateresult = personaldetails[0];

                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_EDUCATION_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserEducation>(procedure).ToList();
                    candidateresult.LST_USER_EDUCATION = results;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_CERTIFICATION_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserCertification>(procedure).ToList();
                    candidateresult.LST_USER_CERTIFICATION = results;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_OFFICIAL_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    candidateresult = results[0];
                    candidateresult.CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_DOCUMENT_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserDocument>(procedure).ToList();
                    candidateresult.LST_USER_DOCUMENT = results;
                    candidateresult.SERVER_MAP_PATH = HttpContext.Current.Server.MapPath("~/Uploads/");
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_EXPERIENCE_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserExperience>(procedure).ToList();
                    candidateresult.LST_USER_EXPERIENCE = results;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_CONTACT_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserAddress>(procedure).ToList();
                    candidateresult.LST_USER_ADDRESS = results;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_AGENT_PERSONAL_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    candidateresult = results[0];
                    candidateresult.CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_DOCTOR_PERSONAL_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    candidateresult = results[0];
                    candidateresult.CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_CLIENT_PERSONAL_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    candidateresult = results[0];
                    candidateresult.CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_PROCESS_MEDICAL")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Medical>(procedure).ToList();
                    candidateresult.Medical_Details = results[0];
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_PROCESS_MOFA")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Mofa>(procedure).ToList();
                    candidateresult.MOFA_Details = results[0];
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_PROCESS_VISA_ENDORSEMENT")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<VisaEndorsement>(procedure).ToList();
                    candidateresult.VisaEndorsement_Details = results[0];
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_PROCESS_EMIGRATION")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Emigration>(procedure).ToList();
                    candidateresult.Emigration_Details = results[0];
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "UPDATE_PROCESS_TICKET")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Ticket>(procedure).ToList();
                    candidateresult.Ticket_Details = results[0];
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "CANDIDATE_EDUCATION_CERTIFICATION_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    candidateresult = results[0];
                    candidateresult.CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "CANDIDATE_DOCUMENT_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserDocument>(procedure).ToList();
                    candidateresult.LST_USER_DOCUMENT = results;
                    candidateresult.SERVER_MAP_PATH = HttpContext.Current.Server.MapPath("~/Uploads/");
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "CANDIDATE_EXPERIENCE_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserExperience>(procedure).ToList();
                    candidateresult.LST_USER_EXPERIENCE = results;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "CANDIDATE_CONTACT_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<UserAddress>(procedure).ToList();
                    candidateresult.LST_USER_ADDRESS = results;
                    return candidateresult;
                }
                else if (candidate.CONDITIONAL_OPERATOR == "CANDIDATE_PERSONAL_DETAILS")
                {
                    var results = _entities.Database.ExecuteStoredProcedure<Candidate>(procedure).ToList();
                    var personaldetails = results
                        .Select(x => new Candidate
                        {
                            REGISTRATION_NO = x.REGISTRATION_NO,
                            REGISTRATION_DATE = Convert.ToDateTime(Convert.ToDateTime(x.REGISTRATION_DATE).ToString("dd/MMM/yyyy")),
                            Candidate_Name = x.Candidate_Name,
                            PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                            Contact_No = x.Contact_No,
                            USER_EMAIL = x.USER_EMAIL,
                            DATE_OF_BIRTH = Convert.ToDateTime(Convert.ToDateTime(x.DATE_OF_BIRTH).ToString("dd/MMM/yyyy")),
                            Age = x.Age,
                            AVAILING_TYPE = x.AVAILING_TYPE,
                            CURRENT_LOCATION = x.CURRENT_LOCATION,
                            STATUS_NAME = x.STATUS_NAME,
                            TOTAL_WORK_EXPERIENCE = x.TOTAL_WORK_EXPERIENCE,
                            TOTAL_GULF_EXPERIENCE = x.TOTAL_GULF_EXPERIENCE,
                            FILE_PATH = x.FILE_PATH,
                            CONDITIONAL_OPERATOR = candidate.CONDITIONAL_OPERATOR,
                            PASSPORT_ID = x.PASSPORT_ID,
                            DRIVING_LICENCE_ID = x.DRIVING_LICENCE_ID
                        }).ToList();

                    candidateresult = personaldetails[0];

                    return candidateresult;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserRequirement> AddUpdateUserRequirement(int userRequirementId, string regno, int requirementid, int candidateStatus, bool status)
        {
            _entities = new ArbabTravelsERPEntities();

            var lstUserReq = _entities.PROC_USER_ADDUPDATE_REQUIREMENT(userRequirementId, regno, requirementid, candidateStatus, status, Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO))
                .Select(c => new UserRequirement
                {
                    USER_REQUIREMENT_ID = c.USER_REQUIREMENT_ID,
                    REGISTRATION_NO = c.REGISTRATION_NO,
                    REQUIREMENT_ID = c.REQUIREMENT_ID,
                    REQUIREMENT = c.REQUIREMENT,
                    CANDIDATE_STATUS = c.CANDIDATE_STATUS,
                    STATUS_NAME = c.STATUS_NAME,
                    CURRENT_STATUS = c.CURRENT_STATUS,
                    CREATED_BY = c.CREATED_BY
                }).ToList();

            return lstUserReq;
        }

        public List<IEnumerable> CandidateResumeDownload(string registrationNo)
        {
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };

            var results = new ArbabTravelsERPEntities()
                            .MultipleResults("[dbo].[PROC_CANDIDATE_RESUME_DOWNLOAD]")
                            .With<Candidate>()
                            .With<UserLanguage>()
                            .With<UserEducation>()
                            .With<UserCertification>()
                            .With<UserExperience>()
                            .With<UserAddress>()
                            .With<UserContact>()
                            .With<UserEmail>()
                            .Execute(REGISTRATION_NO);
            return results;
        }

        public bool DeleteEployee(string registrationNo)
        {
            _entities = new ArbabTravelsERPEntities();

            var emp = _entities.TBL_USER_PERSONAL_DETAILS.Where(x => x.REGISTRATION_NO == registrationNo).SingleOrDefault();
            emp.IS_ACTIVE = false;
            _entities.SaveChanges();

            var cand = _entities.TBL_USER_DETAILS.Where(x => x.REGISTRATION_NO == registrationNo).SingleOrDefault();
            cand.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            cand.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
            return true;
        }

        public bool ResetPassword(string registrationNo, string password)
        {
            _entities = new ArbabTravelsERPEntities();

            var emp = _entities.TBL_USER_DETAILS.Where(x => x.REGISTRATION_NO == registrationNo).SingleOrDefault();
            emp.LOGIN_PASSWORD = password;
            emp.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            emp.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
            return true;
        }

        public List<IEnumerable> GetDocument(string passportNo, string registrationNo = null, string conditional_Operator = null)
        {
            var PASSPORT_NO = new SqlParameter { ParameterName = "PASSPORT_NO", Value = passportNo };
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = registrationNo };
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = conditional_Operator };

            var results = new ArbabTravelsERPEntities()
                            .MultipleResults("[dbo].[PROC_DOCUMENT_DOWNLOAD]")
                            .With<CandidateSearch>()
                            .Execute(PASSPORT_NO, REGISTRATION_NO, CONDITIONAL_OPERATOR);
            return results;
        }
    }
}

