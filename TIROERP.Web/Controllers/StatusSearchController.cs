using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;
using TIROERP.Web.Utilities;

namespace TIROERP.Web.Controllers
{

    [Authenticate]
    [ErrorFilter]
    public class StatusSearchController : Controller
    {
        private readonly IStatusSearch _iStatusSearchRepository;
        private readonly IMedical _iMedicalRepository;
        private readonly IMofa _iMofaRepository;
        private readonly IVisaEndorsement _iVisaEndorsementRepository;
        private readonly IPolicy _iPolicyRepository;
        private readonly ITicket _iTicketRepository;
        private readonly IEmigration _iEmigrationRepository;

        public static List<UserEducation> lstEducationSpeciaization;
        public static List<Certification> lstCertification;
        public static List<ContactType> lstContactType;
        public static List<Country> lstCountry;
        public static List<Company> lstCompany;
        public static List<IndustryDesignation> lstIndustryDesignation;
        public StatusSearchController(IStatusSearch iStatusSearchRepository, IMedical iMedicalRepository, IMofa iMofaRepository, IVisaEndorsement iVisaRepository
            , IPolicy iPolicyRepository, ITicket iTicketRepository, IEmigration iEmigrationRepository)
        {
            _iStatusSearchRepository = iStatusSearchRepository;
            _iMedicalRepository = iMedicalRepository;
            _iMofaRepository = iMofaRepository;
            _iVisaEndorsementRepository = iVisaRepository;
            _iPolicyRepository = iPolicyRepository;
            _iTicketRepository = iTicketRepository;
            _iEmigrationRepository = iEmigrationRepository;
        }

        // GET: StatusSearch
        public ActionResult CandidateSearch(int id, string success = null)
        {
            CandidateSearch search = new CandidateSearch();
            search.USER_TYPE_ID = id;
            ViewData["Success"] = success;
            var candidateresult = _iStatusSearchRepository.GetCandidateResult(search);
            ViewBag.UserTtypeId = id;
            if (id == 1)
            {
                return View("CandidateSearch", candidateresult);
            }
            else if (id == 2)
            {
                return View("EmployeeSearch", candidateresult);
            }
            else if (id == 3)
            {
                return View("AgentSearch", candidateresult);
            }
            else if (id == 4)
            {
                return View("DoctorSearch", candidateresult);
            }
            else
            {
                return View("ClientSearch", candidateresult);
            }
        }

        [HttpPost]
        public ActionResult CandidateSearch(CandidateSearch search)
        {
            var candidateresult = _iStatusSearchRepository.GetCandidateResult(search);
            ViewBag.UserTtypeId = search.USER_TYPE_ID;
            if (search.USER_TYPE_ID == 1)
            {
                return View("CandidateSearch", candidateresult);
            }
            else if (search.USER_TYPE_ID == 2)
            {
                return View("EmployeeSearch", candidateresult);
            }
            else if (search.USER_TYPE_ID == 3)
            {
                return View("AgentSearch", candidateresult);
            }
            else if (search.USER_TYPE_ID == 4)
            {
                return View("DoctorSearch", candidateresult);
            }
            else
            {
                return View("ClientSearch", candidateresult);
            }
        }

        public ActionResult GetCandidateDetails(string registrationNo)
        {
            var candidateresult = _iStatusSearchRepository.GetCandidateDetails(registrationNo, "Get");

            Candidate candidatedetails = new Candidate();
            var personaldetails = ((List<Candidate>)candidateresult[0])
                .Select(x => new Candidate
                {
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    REGISTRATION_DATE = Convert.ToDateTime(Convert.ToDateTime(x.REGISTRATION_DATE).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    Candidate_Name = x.Candidate_Name,
                    AVAILING_TYPE = x.AVAILING_TYPE,
                    SOURCE_NAME = x.SOURCE_NAME,
                    SOURCE_ID = x.SOURCE_ID,
                    OTHER_SOURCE = x.OTHER_SOURCE,
                    REFERRER_NAME = x.REFERRER_NAME,
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
                    STATUS_ID = x.STATUS_ID,
                    REQUIREMENT_ID = x.REQUIREMENT_ID,
                    VISA_ID = x.VISA_ID,
                    LOGIN_ACCESS = x.LOGIN_ACCESS,
                    AVAILING_TYPE_ID = x.AVAILING_TYPE_ID,

                }).ToList();

            candidatedetails = personaldetails[0];
            candidatedetails.LST_USER_EDUCATION = ((List<UserEducation>)candidateresult[1]);
            candidatedetails.LST_USER_CERTIFICATION = ((List<UserCertification>)candidateresult[2]);
            candidatedetails.LST_USER_EXPERIENCE = ((List<UserExperience>)candidateresult[3]);
            candidatedetails.LST_USER_DOCUMENT = ((List<UserDocument>)candidateresult[4]);
            candidatedetails.LST_USER_REQUIREMENT = ((List<UserRequirement>)candidateresult[5]);
            candidatedetails.LST_USER_LANGUAGE = ((List<UserLanguage>)candidateresult[6]);
            candidatedetails.LST_USER_ADDRESS = ((List<UserAddress>)candidateresult[7]);
            candidatedetails.LST_USER_CONTACT = ((List<UserContact>)candidateresult[8]);
            candidatedetails.LST_USER_EMAIL = ((List<UserEmail>)candidateresult[9]);

            ViewBag.OtherSource = candidatedetails.OTHER_SOURCE;

            GetMasterData(candidatedetails);
            return View(candidatedetails);

        }

        private void GetMasterData(Candidate candidate)
        {
            var result = _iStatusSearchRepository.GetMasterData();

            lstCountry = (List<Country>)result[0];
            var lstCountryres = (from country in lstCountry
                                 group country by new { country.COUNTRY_CODE, country.COUNTRY_NAME } into c
                                 select c).Select(c => new SelectListItem
                                 {
                                     Value = c.Key.COUNTRY_CODE,
                                     Text = c.Key.COUNTRY_NAME
                                 });

            ViewData["GetCountry"] = new SelectList(lstCountryres, "Value", "Text");


            List<City> lstLocation = (List<City>)result[19];
            var location = lstLocation.Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.CITY_NAME
            });
            ViewData["GetLocation"] = new SelectList(location, "Value", "Text");


            lstContactType = (List<ContactType>)result[1];
            var lstAddressType = lstContactType.Where(x => x.TYPE_FOR == "ADDRESS").Select(c => new SelectListItem
            {
                Value = c.CONTACT_TYPE_ID.ToString(),
                Text = c.CONTACT_TYPE
            });
            ViewData["GetAddressType"] = new SelectList(lstAddressType, "Value", "Text");

            var lstConType = lstContactType.Where(x => x.TYPE_FOR == "PHONE").Select(c => new SelectListItem
            {
                Value = c.CONTACT_TYPE_ID.ToString(),
                Text = c.CONTACT_TYPE
            });
            ViewData["GetContactType"] = new SelectList(lstConType, "Value", "Text");

            var lstAvailingType = ((List<AvailingType>)result[2]).
                Select(c => new SelectListItem
                {
                    Value = c.AVAILING_TYPE_ID.ToString(),
                    Text = c.AVAILING_TYPE
                });
            ViewData["GetAvailingType"] = new SelectList(lstAvailingType, "Value", "Text");

            var lstSource = ((List<Source>)result[3]).
                Select(c => new SelectListItem
                {
                    Value = c.SOURCE_ID.ToString(),
                    Text = c.SOURCE_NAME
                });
            ViewData["GetSource"] = new SelectList(lstSource, "Value", "Text");

            var lstStatus = ((List<Status>)result[4]).
                Select(c => new SelectListItem
                {
                    Value = c.STATUS_ID.ToString(),
                    Text = c.STATUS_NAME
                });
            ViewData["GetStatus"] = new SelectList(lstStatus, "Value", "Text");

            var lstMaritalStatus = ((List<MaritalStatus>)result[5]).
                Select(c => new SelectListItem
                {
                    Value = c.MARITAL_STATUS_ID.ToString(),
                    Text = c.MARITAL_STATUS
                });
            ViewData["GetMaritalStatus"] = new SelectList(lstMaritalStatus, "Value", "Text");

            var lstNationality = ((List<Nationality>)result[6]).
                Select(c => new SelectListItem
                {
                    Value = c.NATIONALITY_ID.ToString(),
                    Text = c.NATIONALITY
                });
            ViewData["GetNationality"] = new SelectList(lstNationality, "Value", "Text");

            var lstLanguage = ((List<Language>)result[7]).
                Select(c => new SelectListItem
                {
                    Value = c.LANGUAGE_ID.ToString(),
                    Text = c.LANGUAGE_NAME
                });
            ViewData["GetLanguage"] = new SelectList(lstLanguage, "Value", "Text");

            var University = ((List<University>)result[8]).
                Select(c => new SelectListItem
                {
                    Value = c.UNIVERSITY_ID.ToString(),
                    Text = c.UNIVERSITY_NAME
                });
            ViewData["GetUniversity"] = new SelectList(University, "Value", "Text");

            lstCompany = ((List<Company>)result[9]).ToList();
            var Company = lstCompany.Select(c => new SelectListItem
            {
                Value = c.COMPANY_ID.ToString(),
                Text = c.COMPANY_NAME
            });
            ViewData["GetCompany"] = new SelectList(Company, "Value", "Text");

            lstIndustryDesignation = (List<IndustryDesignation>)result[10];
            var IndustryDesignation = (from ind in lstIndustryDesignation
                                       group ind by new { ind.INDUSTRY_ID, ind.INDUSTRY_TYPE } into c
                                       select c).Select(c => new SelectListItem
                                       {
                                           Value = c.Key.INDUSTRY_ID.ToString(),
                                           Text = c.Key.INDUSTRY_TYPE
                                       });
            ViewData["GetIndustryDesignation"] = new SelectList(IndustryDesignation, "Value", "Text");

            lstEducationSpeciaization = (List<UserEducation>)result[11];
            var EducationSpeciaization = (from ind in lstEducationSpeciaization
                                          group ind by new { ind.EDUCATION_TYPE_ID, ind.EDUCATION_TYPE } into c
                                          select c).Select(c => new SelectListItem
                                          {
                                              Value = c.Key.EDUCATION_TYPE_ID.ToString(),
                                              Text = c.Key.EDUCATION_TYPE
                                          });
            ViewData["GetEducationSpeciaization"] = new SelectList(EducationSpeciaization, "Value", "Text");

            var VehicleType = ((List<VehicleType>)result[12]).
                Select(c => new SelectListItem
                {
                    Value = c.VEHICLE_TYPE_ID.ToString(),
                    Text = c.VEHICLE_TYPE
                });
            ViewData["GetVehicleType"] = new SelectList(VehicleType, "Value", "Text");

            var Branch = ((List<Branch>)result[13]).
               Select(c => new SelectListItem
               {
                   Value = c.BRANCH_CODE.ToString(),
                   Text = c.BRANCH_NAME
               });
            ViewData["GetBranch"] = new SelectList(Branch, "Value", "Text");


            lstCertification = ((List<Certification>)result[14]);

            var Certification = lstCertification.Select(c => new SelectListItem
            {
                Value = c.CERTIFICATION_ID.ToString(),
                Text = c.CERTIFICATION_NAME
            });
            ViewData["GetCertification"] = new SelectList(Certification, "Value", "Text");

            var VisaMaster = ((List<VisaMaster>)result[15]).
               Select(c => new SelectListItem
               {
                   Value = c.VISA_ID.ToString(),
                   Text = c.VISA_NUMBER
               });
            ViewData["GetVisaMaster"] = new SelectList(VisaMaster, "Value", "Text");

            var RequirementMaster = ((List<RequirementMaster>)result[16]).
              Select(c => new SelectListItem
              {
                  Value = c.REQUIREMENT_ID.ToString(),
                  Text = c.REQUIREMENT
              });
            ViewData["GetRequirementMaster"] = new SelectList(RequirementMaster, "Value", "Text");

            var Gender = ((List<Gender>)result[17]).
              Select(c => new SelectListItem
              {
                  Value = c.GENDER_CODE.ToString(),
                  Text = c.GENDER_NAME
              });
            ViewData["GetGender"] = new SelectList(Gender, "Value", "Text");

            var Religion = ((List<Religion>)result[18]).
              Select(c => new SelectListItem
              {
                  Value = c.RELIGION_ID.ToString(),
                  Text = c.RELIGION_NAME
              });
            ViewData["GetReligion"] = new SelectList(Religion, "Value", "Text");

        }

        private void GetPeopleMasterData(Candidate candidate)
        {
            var result = _iStatusSearchRepository.GetPeopleMasterData();

            lstCountry = (List<Country>)result[0];
            var lstCountryres = (from country in lstCountry
                                 group country by new { country.COUNTRY_CODE, country.COUNTRY_NAME } into c
                                 select c).Select(c => new SelectListItem
                                 {
                                     Value = c.Key.COUNTRY_CODE,
                                     Text = c.Key.COUNTRY_NAME
                                 });

            ViewData["GetCountry"] = new SelectList(lstCountryres, "Value", "Text");

            List<City> lstLocation = (List<City>)result[3];
            var location = lstLocation.Where(x => x.CITY_NAME != candidate.CURRENT_LOCATION)
                .Select(c => new SelectListItem
                {
                    Value = c.CityId.ToString(),
                    Text = c.CITY_NAME
                });
            ViewData["GetLocation"] = new SelectList(location, "Value", "Text");


            lstContactType = (List<ContactType>)result[1];
            var lstAddressType = lstContactType.Where(x => x.TYPE_FOR == "ADDRESS").Select(c => new SelectListItem
            {
                Value = c.CONTACT_TYPE_ID.ToString(),
                Text = c.CONTACT_TYPE
            });
            ViewData["GetAddressType"] = new SelectList(lstAddressType, "Value", "Text");

            var lstConType = lstContactType.Where(x => x.TYPE_FOR == "PHONE").Select(c => new SelectListItem
            {
                Value = c.CONTACT_TYPE_ID.ToString(),
                Text = c.CONTACT_TYPE
            });
            ViewData["GetContactType"] = new SelectList(lstConType, "Value", "Text");



            lstIndustryDesignation = (List<IndustryDesignation>)result[2];
            var IndustryDesignation = (from ind in lstIndustryDesignation
                                       group ind by new { ind.INDUSTRY_ID, ind.INDUSTRY_TYPE } into c
                                       select c).Select(c => new SelectListItem
                                       {
                                           Value = c.Key.INDUSTRY_ID.ToString(),
                                           Text = c.Key.INDUSTRY_TYPE
                                       });
            ViewData["GetIndustryDesignation"] = new SelectList(IndustryDesignation, "Value", "Text");
        }

        [HttpGet]
        public JsonResult LoadEducationPartialView(string registrationNo)
        {
            var result = _iStatusSearchRepository.GetUserEducationDetails(registrationNo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadCertificationPartialView(string registrationNo)
        {
            var result = _iStatusSearchRepository.GetUserCertificationDetails(registrationNo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadContactDetailsPartialView(string registrationNo)
        {
            Candidate userContactDetails = _iStatusSearchRepository.GetCandidateContactDetails(registrationNo);
            var result = new { candidate = userContactDetails };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDocumentsPartialView(string registrationNo)
        {
            var result = _iStatusSearchRepository.GetCandidateDocumentDetails(registrationNo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadExpPartialView(string registrationNo)
        {
            var result = _iStatusSearchRepository.GetCandidateExperienceDetails(registrationNo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadCandidatePersonalDetails(string registrationNo)
        {
            Candidate candidate = new Candidate();
            candidate = _iStatusSearchRepository.GetCandidatePersonalDetails(registrationNo);

            return Json(candidate, JsonRequestBehavior.AllowGet);
        }

        private void GetViewDataForExpView()
        {
            //Company data
            var Company = lstCompany.Select(c => new SelectListItem
            {
                Value = c.COMPANY_ID.ToString(),
                Text = c.COMPANY_NAME
            });
            ViewData["GetCompany"] = new SelectList(Company, "Value", "Text");

            //Industry Data
            var IndustryDesignation = (from ind in lstIndustryDesignation
                                       group ind by new { ind.INDUSTRY_ID, ind.INDUSTRY_TYPE } into c
                                       select c).Select(c => new SelectListItem
                                       {
                                           Value = c.Key.INDUSTRY_ID.ToString(),
                                           Text = c.Key.INDUSTRY_TYPE
                                       });
            ViewData["GetIndustryDesignation"] = new SelectList(IndustryDesignation, "Value", "Text");

            //Country data
            var lstCountryres = (from country in lstCountry
                                 group country by new { country.COUNTRY_CODE, country.COUNTRY_NAME } into c
                                 select c).Select(c => new SelectListItem
                                 {
                                     Value = c.Key.COUNTRY_CODE,
                                     Text = c.Key.COUNTRY_NAME
                                 });

            ViewData["GetCountry"] = new SelectList(lstCountryres, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Update(Candidate candidate)
        {
            try
            {
                var result = _iStatusSearchRepository.UpdateCandidateDetails(candidate);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Common.LogError("CANDIDATE Update", "", "Update", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                throw ex;
            }

        }

        [HttpGet]
        public JsonResult GetProcessDetails(int userRequirementId)
        {
            var candDetails = _iStatusSearchRepository.GetProcessDetails(userRequirementId);

            var mofa = ((List<Mofa>)candDetails[0])
                .Select(x => new Mofa
                {
                    MofaNumber = x.MofaNumber,
                    MofaDate = (Convert.ToDateTime(x.MofaDate).ToString("dd/MMM/yyyy")),
                    ApplicationNumber = x.ApplicationNumber,
                    ApplicationDate = x.ApplicationDate,
                    HealthNumber = x.HealthNumber,
                    HealthDate = x.HealthDate,
                    DDNumber = x.DDNumber,
                    DDDate = x.DDDate,
                    MofaID = x.MofaID
                });

            var medical = ((List<Medical>)candDetails[1])
                .Select(x => new Medical
                {
                    STATUS_NAME = x.STATUS_NAME,
                    CheckupDate = x.CheckupDate,
                    DoctorName = x.DoctorName,
                    TokenNumber = x.TokenNumber,
                    MedicalId = x.MedicalId
                });

            var visa = ((List<VisaEndorsement>)candDetails[2])
                .Select(x => new VisaEndorsement
                {
                    VisaSubmissionStatus = x.VisaSubmissionStatus,
                    SubmissionDate = x.SubmissionDate,
                    VisaEndorsementId = x.VisaEndorsementId
                });

            var emigration = ((List<Emigration>)candDetails[3])
                .Select(x => new Emigration
                {
                    EMIGRATION_ID = x.EMIGRATION_ID,
                    USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                    FE_NO = x.FE_NO,
                    PT_NO = x.PT_NO,
                    DM_NO = x.DM_NO,
                    DM_DATE = x.DM_DATE,
                    POLICY_NO = x.POLICY_NO,
                    POLICY_DATE = x.POLICY_DATE,
                    POLICY_AMOUNT = x.POLICY_AMOUNT,
                    POLICY_COMPANYNAME = x.POLICY_COMPANYNAME,
                    POLICY_ATTACHMENT = x.POLICY_ATTACHMENT,
                    SUBMISSION_DATE = x.SUBMISSION_DATE,
                    EMIGRATION_CLEARANCENO = x.EMIGRATION_CLEARANCENO,
                    EMIGRATION_ATTACHMENT = x.EMIGRATION_ATTACHMENT,
                    POE = x.POE,
                    REMARK = x.REMARK,
                    CREATED_BY = x.CREATED_BY,
                    MODIFIED_BY = x.MODIFIED_BY,
                    CREATED_DATE = x.CREATED_DATE,
                    MODIFIED_DATE = x.MODIFIED_DATE,
                    CANDIDATE_NAME = x.CANDIDATE_NAME,
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                    IS_ECR = x.IS_ECR
                });

            var ticket = ((List<Ticket>)candDetails[4])
                .Select(x => new Ticket
                {
                    TravelStatus = x.TravelStatus,
                    DepartureDate = x.DepartureDate,
                    PnrNumber = x.PnrNumber,
                    AirlinesName = x.AirlinesName,
                    DepartureCity = x.DepartureCity,
                    DestinationCity = x.DestinationCity,
                    ArrivalTime = x.ArrivalTime,
                    TicketID = x.TicketID
                });

            var result = new { mofa = mofa, medical = medical, visa = visa, emigration = emigration, ticket = ticket };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddUpdateUserRequirement(string userRequirementId, string regno, int requirementid, int candidateStatus, bool status)
        {
            if (string.IsNullOrEmpty(userRequirementId))
            {
                userRequirementId = "0";
            }
            var lstReq = _iStatusSearchRepository.AddUpdateUserRequirement(Convert.ToInt16(userRequirementId), regno, requirementid, candidateStatus, status);
            return Json(lstReq, JsonRequestBehavior.AllowGet);
        }

        #region Agent 
        public ActionResult GetAgentDetails(string registrationNo)
        {
            Candidate candidatedetails = GetPeopleDetails(registrationNo);

            GetPeopleMasterData(candidatedetails);
            return View(candidatedetails);
        }

        private Candidate GetPeopleDetails(string registrationNo)
        {
            var candidateresult = _iStatusSearchRepository.GetPeopleDetails(registrationNo, "GET_PEOPLE_DETAILS");

            Candidate candidatedetails = new Candidate();
            var personaldetails = ((List<Candidate>)candidateresult[0])
                .Select(x => new Candidate
                {
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    REGISTRATION_DATE = Convert.ToDateTime(Convert.ToDateTime(x.REGISTRATION_DATE).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    Candidate_Name = x.Candidate_Name,
                    MULTIPLE_INDUSTRY_ID = x.MULTIPLE_INDUSTRY_ID,
                    MULTIPLE_DESIGNATION_ID = x.MULTIPLE_DESIGNATION_ID,
                    INDUSTRY_TYPE = x.INDUSTRY_TYPE == null ? "" : x.INDUSTRY_TYPE,
                    DESIGNATION_NAME = x.DESIGNATION_NAME == null ? "" : x.DESIGNATION_NAME,
                    CURRENT_LOCATION = x.CURRENT_LOCATION,
                    CURRENT_LOCATION_NAME = x.CURRENT_LOCATION_NAME,
                    REMARK = x.REMARK,
                    Contact_No = x.Contact_No,
                    USER_EMAIL = x.USER_EMAIL,
                    FILE_PATH = x.FILE_PATH,
                    WEBSITE = x.WEBSITE,
                    SKYPE = x.SKYPE,
                    CONTACT_REMARK = x.CONTACT_REMARK,
                    CLINIC_NAME = x.CLINIC_NAME,
                    GAMCA_NO = x.GAMCA_NO,
                    COMPANY_NAME = x.COMPANY_NAME,
                    REFERENCE = x.REFERENCE,
                    CIVILIAN_NO = x.CIVILIAN_NO,
                    FIRST_NAME = x.FIRST_NAME,
                    MIDDLE_NAME = x.MIDDLE_NAME,
                    LAST_NAME = x.LAST_NAME
                }).ToList();

            candidatedetails = personaldetails[0];
            candidatedetails.LST_USER_ADDRESS = ((List<UserAddress>)candidateresult[1]);
            candidatedetails.LST_USER_CONTACT = ((List<UserContact>)candidateresult[2]);
            candidatedetails.LST_USER_EMAIL = ((List<UserEmail>)candidateresult[3]);
            return candidatedetails;
        }
        #endregion

        #region DOCTOR
        public ActionResult GetDoctorDetails(string registrationNo)
        {
            Candidate candidatedetails = GetPeopleDetails(registrationNo);

            GetPeopleMasterData(candidatedetails);
            return View(candidatedetails);
        }
        #endregion

        #region CLIENT
        public ActionResult GetClientDetails(string registrationNo)
        {
            Candidate candidatedetails = GetPeopleDetails(registrationNo);

            GetPeopleMasterData(candidatedetails);
            return View(candidatedetails);

        }
        #endregion

        #region EMPLOYEE
        public ActionResult GetEmployeeDetails(string registrationNo)
        {
            var candidateresult = _iStatusSearchRepository.GetCandidateDetails(registrationNo, "GET_PEOPLE_DETAILS");

            Candidate candidatedetails = new Candidate();
            var personaldetails = ((List<Candidate>)candidateresult[0])
                .Select(x => new Candidate
                {
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    REGISTRATION_DATE = Convert.ToDateTime(Convert.ToDateTime(x.REGISTRATION_DATE).ToString("dd/MMM/yyyy")),
                    Candidate_Name = x.Candidate_Name,
                    Contact_No = x.Contact_No,
                    USER_EMAIL = x.USER_EMAIL,
                    DATE_OF_BIRTH = Convert.ToDateTime(Convert.ToDateTime(x.DATE_OF_BIRTH).ToString("dd/MMM/yyyy")),
                    Age = x.Age,
                    STATUS_NAME = x.STATUS_NAME,
                    FILE_PATH = x.FILE_PATH,
                    SOURCE_NAME = x.SOURCE_NAME,
                    STATUS_ID = x.STATUS_ID,
                    BRANCH_NAME = x.BRANCH_NAME,
                    SOURCE_ID = x.SOURCE_ID,
                    OTHER_SOURCE = x.OTHER_SOURCE,
                    BRANCH_CODE = x.BRANCH_CODE

                }).ToList();

            candidatedetails = personaldetails[0];
            candidatedetails.LST_USER_EDUCATION = ((List<UserEducation>)candidateresult[1]);
            candidatedetails.LST_USER_CERTIFICATION = ((List<UserCertification>)candidateresult[2]);
            candidatedetails.LST_USER_EXPERIENCE = ((List<UserExperience>)candidateresult[3]);
            candidatedetails.LST_USER_DOCUMENT = ((List<UserDocument>)candidateresult[4]);
            candidatedetails.LST_USER_REQUIREMENT = ((List<UserRequirement>)candidateresult[5]);
            candidatedetails.LST_USER_ADDRESS = ((List<UserAddress>)candidateresult[6]);
            candidatedetails.LST_USER_CONTACT = ((List<UserContact>)candidateresult[7]);
            candidatedetails.LST_USER_EMAIL = ((List<UserEmail>)candidateresult[8]);

            GetMasterData(candidatedetails);
            return View(candidatedetails);
        }
        #endregion

        #region Procress Details

        public PartialViewResult LoadMedicalDetails(string id)
        {
            ViewBag.GetDoctor = getDoctorDetails();
            if (string.IsNullOrEmpty(id))
                id = "-1";

            var medicalresult = _iMedicalRepository.GetAllProcess(Convert.ToInt32(id), "MEDICAL");
            var medical = medicalresult.Select(x => new Medical
            {
                STATUS_NAME = x.STATUS_NAME,
                CheckupDate = x.CheckupDate,
                DoctorName = x.DoctorName,
                ReportDate = x.ReportDate,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                MedicalId = x.MedicalId,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                DoctorID = x.DoctorID,
                TokenNumber = x.TokenNumber,
                MedicalStatus = x.MedicalStatus,
                ReportPath = x.ReportPath,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                Remark = x.Remark
            }).SingleOrDefault();

            return PartialView("_Medical", medical);
        }

        private IEnumerable<SelectListItem> getDoctorDetails()
        {
            List<Doctor_Details> passportNumbers = _iMedicalRepository.GetDoctorsList();

            IEnumerable<SelectListItem> doctorList = passportNumbers.Select(x => new SelectListItem
            {
                Value = x.REGISTATION_NUMBER.ToString(),
                Text = x.First_Name + x.Last_Name
            });

            return doctorList;
        }

        public PartialViewResult LoadMofaDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = "-1";
            var result = _iMofaRepository.GetAllProcess(Convert.ToInt32(id), "MOFA");
            var mofa = result.Select(x => new Mofa
            {
                MofaID = x.MofaID,
                MofaNumber = x.MofaNumber,
                MofaDate = x.MofaDate,
                ApplicationNumber = x.ApplicationNumber,
                ApplicationDate = x.ApplicationDate,
                HealthNumber = x.HealthNumber,
                HealthDate = x.HealthDate,
                DDNumber = x.DDNumber,
                DDDate = x.DDDate,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                MofaFilePath = x.MofaFilePath,
                MofaRemark = x.MofaRemark,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate
            }).SingleOrDefault();

            return PartialView("_MOFA", mofa);
        }

        public PartialViewResult LoadVisaDetails(string id)
        {
            ViewBag.GetSubmissionDetails = getSubmissionDetails();

            if (string.IsNullOrEmpty(id))
                id = "-1";

            var result = _iVisaEndorsementRepository.GetAllProcess(Convert.ToInt32(id), "VISA");
            var visa = result.Select(x => new VisaEndorsement
            {
                VisaEndorsementId = x.VisaEndorsementId,
                VisaSubmissionStatus = x.VisaSubmissionStatus,
                SubmissionDate = x.SubmissionDate,
                SubmissionStatusID = x.SubmissionStatusID,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                VisaEndorsementFilePath = x.VisaEndorsementFilePath
            }).SingleOrDefault();

            return PartialView("_VisaEndorsement", visa);
        }

        private IEnumerable<SelectListItem> getSubmissionDetails()
        {
            List<SubmissionStatus> submissionStatusDetailsList = _iVisaEndorsementRepository.GetSubmissionStatusDetails();

            IEnumerable<SelectListItem> submissionList = submissionStatusDetailsList.Select(x => new SelectListItem
            {
                Value = x.SubmissionStatusId.ToString(),
                Text = x.VisaEndorsementSubmissionStatus.Replace("VISA ENDROSMENT", "").Trim()
            }).ToList();

            return submissionList;
        }

        public PartialViewResult LoadPolicyDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = "-1";

            var result = _iPolicyRepository.GetAllProcess(Convert.ToInt32(id), "POLICY");
            var policy = result.Select(x => new Policy
            {
                POLICYID = x.POLICYID,
                PolicyDate = x.PolicyDate,
                PolicyFees = x.PolicyFees,
                PolicyNumber = x.PolicyNumber,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                PolicyRemark = x.PolicyRemark
            }).SingleOrDefault();

            return PartialView("_Policy", policy);
        }

        public PartialViewResult LoadEmigrationDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = "-1";

            var result = _iEmigrationRepository.GetAllProcess(Convert.ToInt32(id), "EMIGRATION");
            var emigration = result.Select(x => new Emigration
            {
                EMIGRATION_ID = x.EMIGRATION_ID,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                FE_NO = x.FE_NO,
                PT_NO = x.PT_NO,
                DM_NO = x.DM_NO,
                DM_DATE = x.DM_DATE,
                POLICY_NO = x.POLICY_NO,
                POLICY_DATE = x.POLICY_DATE,
                POLICY_AMOUNT = x.POLICY_AMOUNT,
                POLICY_COMPANYNAME = x.POLICY_COMPANYNAME,
                POLICY_ATTACHMENT = x.POLICY_ATTACHMENT,
                SUBMISSION_DATE = x.SUBMISSION_DATE,
                EMIGRATION_CLEARANCENO = x.EMIGRATION_CLEARANCENO,
                EMIGRATION_ATTACHMENT = x.EMIGRATION_ATTACHMENT,
                POE = x.POE,
                REMARK = x.REMARK,
                CREATED_BY = x.CREATED_BY,
                MODIFIED_BY = x.MODIFIED_BY,
                CREATED_DATE = x.CREATED_DATE,
                MODIFIED_DATE = x.MODIFIED_DATE,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                IS_ECR = x.IS_ECR
            }).SingleOrDefault();

            return PartialView("_Emigration", emigration);
        }

        public PartialViewResult LoadTicketDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = "-1";

            ViewBag.GetAirlineDetails = getAirlineDetails();

            List<Country> lstCountry = _iTicketRepository.GetCountryData();

            var lstCountryres = (from country in lstCountry
                                 group country by new { country.COUNTRY_CODE, country.COUNTRY_NAME } into c
                                 select c).Select(c => new SelectListItem
                                 {
                                     Value = c.Key.COUNTRY_CODE,
                                     Text = c.Key.COUNTRY_NAME
                                 });

            ViewBag.GetCountry = lstCountryres;

            var result = _iTicketRepository.GetAllProcess(Convert.ToInt32(id), "TICKET");
            var ticket = result.Select(x => new Ticket
            {
                TicketID = x.TicketID,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                AirlinesID = x.AirlinesID,
                AirlinesName = x.AirlinesName,
                IsDirect = x.IsDirect,
                PnrNumber = x.PnrNumber,
                TicketNumber = x.TicketNumber,
                FlightNumber = x.FlightNumber,
                IsBooked = x.IsBooked,
                IsCancelled = x.IsCancelled,
                DepartureCountryCode = x.DepartureCountryCode,
                DepartureCityCode = x.DepartureCityCode,
                DepartureDate = x.DepartureDate,
                DepartureTime = x.DepartureTime,
                DestinationCountryCode = x.DestinationCountryCode,
                DestinationCityCode = x.DestinationCityCode,
                ArivalDate = x.ArivalDate,
                ArrivalTime = x.ArrivalTime,
                ReportPath = x.ReportPath,
                Remark = x.Remark,

                ConnectTicketID = x.ConnectTicketID,
                Conn_PnrNumber = x.Conn_PnrNumber,
                Conn_TicketNumber = x.Conn_TicketNumber,
                Conn_FlightNumber = x.Conn_FlightNumber,
                Conn_IsBooked = x.Conn_IsBooked,
                Conn_IsCancelled = x.Conn_IsCancelled,
                Conn_DestinationCountryCode = x.Conn_DestinationCountryCode,
                Conn_DestinationCityCode = x.Conn_DestinationCityCode,
                Conn_ArivalDate = x.Conn_ArivalDate,
                Conn_ArrivalTime = x.Conn_ArrivalTime,
                Conn_DepartureDate = x.Conn_DepartureDate,
                Conn_DepartureTime = x.Conn_DepartureTime,
                Conn_DepartureCountryCode = x.Conn_DepartureCountryCode,
                Conn_DepartureCityCode = x.Conn_DepartureCityCode,

                TravelStatus = x.TravelStatus,
                DestinationCity = x.DestinationCity,
                DepartureCity = x.DepartureCity,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                createdBy = x.createdBy,
                CreatedDate = x.CreatedDate
            }).SingleOrDefault();

            return PartialView("_Ticket", ticket);
        }

        private IEnumerable<SelectListItem> getAirlineDetails()
        {
            List<Airline> airlineDetails = _iTicketRepository.GetAirlineDetails();

            IEnumerable<SelectListItem> airlinesList = airlineDetails.Select(x => new SelectListItem
            {
                Value = x.AirlinesId.ToString(),
                Text = x.AirlinesName
            }).ToList();

            return airlinesList;
        }

        [HttpPost]
        public ActionResult GetDestinationCityByCountryCode(string Country_code)
        {
            List<Country> cityNames = _iTicketRepository.GetDestinationCity(Country_code);

            IEnumerable<SelectListItem> cityList = cityNames.Select(x => new SelectListItem
            {
                Value = x.CITY_CODE.ToString(),
                Text = x.CITY_NAME
            });

            return Json(cityList, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpPost]
        public string UploadImageFile()
        {
            if (HttpContext.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Request.Files["UploadedImage"];
                if (httpPostedFile != null)
                {
                    try
                    {
                        var uploadfrom = HttpContext.Request["UploadFrom"];
                        string path = string.Empty;
                        if (uploadfrom.Equals("Medical"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["MedicalUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Candidate"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("MOFA"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["MofaUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Ticket"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["TicketUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Agent"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["AgentUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Client"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["ClientUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Doctor"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["DoctorUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Employee"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["EmployeeUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("Emigration_Policy") || uploadfrom.Equals("Emigration_emigration"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["EmigrationUploadedFiles"]);
                        }
                        else if (uploadfrom.Equals("VISA_ENDORSEMENT"))
                        {
                            path = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["VisaEndorsementUploadedFiles"]);
                        }

                        // Get the complete file path
                        string filepath = Path.Combine(path);
                        return Common.UploadFile(httpPostedFile, filepath);
                    }
                    catch (Exception)
                    {
                        return "Error";
                    }

                }
            }
            return "Error";
        }

        public ActionResult CandidateResumeDownload(string registrationNo)
        {
            var result = _iStatusSearchRepository.CandidateResumeDownload(registrationNo);
            var lstCandidate = (List<Candidate>)result[0];
            var lstLanguage = (List<UserLanguage>)result[1];
            var lstEducation = (List<UserEducation>)result[2];
            var lstCertification = (List<UserCertification>)result[3];
            var lstExperience = (List<UserExperience>)result[4];
            var lstAddress = (List<UserAddress>)result[5];
            var lstContact = (List<UserContact>)result[6];
            var lstEmail = (List<UserEmail>)result[7];


            foreach (var cand in lstCandidate)
            {
                if (string.IsNullOrEmpty(cand.FILE_PATH))
                    cand.FILE_PATH = "file:///" + Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]) + "\\no_img.png";
                else
                    cand.FILE_PATH = "file:///" + Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]) + cand.FILE_PATH;
            }

            DataTable dtCandidate = Common.GetDataTableFromObjects(lstCandidate, "Candidate");
            DataTable dtLanguage = Common.GetDataTableFromObjects(lstLanguage, "Language");
            DataTable dtEducation = Common.GetDataTableFromObjects(lstEducation, "Education");
            DataTable dtCertification = Common.GetDataTableFromObjects(lstCertification, "Certification");
            DataTable dtExperience = Common.GetDataTableFromObjects(lstExperience, "Experience");
            DataTable dtAddress = Common.GetDataTableFromObjects(lstAddress, "Address");
            DataTable dtContact = Common.GetDataTableFromObjects(lstContact, "Contact");
            DataTable dtEmail = Common.GetDataTableFromObjects(lstEmail, "Email");

            ReportViewer rs = new ReportViewer();
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Remote;
            viewer.LocalReport.ReportPath = "Reports/Download.rdlc";
            viewer.AsyncRendering = false;
            viewer.SizeToReportContent = true;

            //Add Report Data Source              
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Candidate", dtCandidate));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Language", dtLanguage));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Education", dtEducation));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Certification", dtCertification));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Experience", dtExperience));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Address", dtAddress));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Contact", dtContact));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Email", dtEmail));

            viewer.LocalReport.Refresh();
            viewer.LocalReport.EnableExternalImages = true;

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            string savePath = @Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]) + "_" + registrationNo + "_Resume.pdf";
            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            Response.BufferOutput = true;
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            return File(savePath, "application/force-download", Path.GetFileName(savePath));
        }

        public ActionResult DeleteEmployee(string registrationNo)
        {
            var result = _iStatusSearchRepository.DeleteEployee(registrationNo);
            return RedirectToAction("CandidateSearch", new { id = 2, success = "Success!!! Record updated successfully." });
        }

        public ActionResult ResetPassword(string registrationNo, string password)
        {
            if (registrationNo != null)
            {
                var result = _iStatusSearchRepository.ResetPassword(registrationNo, password);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}