using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class CandidateController : Controller
    {
        private readonly ICandidate _iCandidateRepository;

        public CandidateController(ICandidate iCandidateRepository)
        {
            this._iCandidateRepository = iCandidateRepository;
        }

        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id, string RegNo = null)
        {
            Candidate candidate = new Candidate();
            candidate.USER_TYPE_ID = id;
            GetMasterData();
            ViewBag.RegNo = RegNo;
            if (id == 1)
            {
                return View("Create", candidate);
            }
            else if (id == 2)
            {
                return View("Employee", candidate);
            }
            else if (id == 3)
            {
                return View("Agent", candidate);
            }
            else if (id == 4)
            {
                return View("Doctor", candidate);
            }
            else
            {
                return View("Client", candidate);
            }
        }

        private void GetMasterData()
        {
            var result = _iCandidateRepository.GetMasterData();

            List<Country> lstCountry = (List<Country>)result[0];
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


            List<ContactType> lstContactType = (List<ContactType>)result[1];
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

            var Company = ((List<Company>)result[9]).
                Select(c => new SelectListItem
                {
                    Value = c.COMPANY_ID.ToString(),
                    Text = c.COMPANY_NAME
                });
            ViewData["GetCompany"] = new SelectList(Company, "Value", "Text");

            List<IndustryDesignation> lstIndustryDesignation = (List<IndustryDesignation>)result[10];
            var IndustryDesignation = (from ind in lstIndustryDesignation
                                       group ind by new { ind.INDUSTRY_ID, ind.INDUSTRY_TYPE } into c
                                       select c).Select(c => new SelectListItem
                                       {
                                           Value = c.Key.INDUSTRY_ID.ToString(),
                                           Text = c.Key.INDUSTRY_TYPE
                                       });
            ViewData["GetIndustryDesignation"] = new SelectList(IndustryDesignation, "Value", "Text");

            List<EducationSpeciaization> lstEducationSpeciaization = (List<EducationSpeciaization>)result[11];
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


            var Certification = ((List<Certification>)result[14]).
               Select(c => new SelectListItem
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

        [HttpPost]
        public ActionResult Create(Candidate candidate)
        {
            bool isSessionActive = true;
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(((UserLoginResult)HttpContext.Session["UserDetails"]).REGISTRATION_NO)))
                {
                    isSessionActive = false;
                    var data = new { regno = "Error: Session Expired", candidate.USER_TYPE_ID, isSessionActive };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }

                if (_iCandidateRepository.CheckDuplicate(candidate))
                {
                    string regno = _iCandidateRepository.Create(candidate);
                    var data = new { regno, candidate.USER_TYPE_ID, isSessionActive };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = new { regno = "Error: Record Already Exists.", candidate.USER_TYPE_ID, isSessionActive };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Common.LogError("CANDIDATE", "", "CREATE", "EXCEPTION OCCURED", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                var data = new { regno = "Error: Record Not created", isSessionActive };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCountryStateCity(string code, string type)
        {
            var lstState = _iCandidateRepository.GetCountryStateCity(code).Select(c => new SelectListItem
            {
                Value = c.STATE_CODE,
                Text = c.STATE_NAME
            });

            //if (type == "S")
            //{
            //    iitem = (from country in lstCountry
            //             where country.COUNTRY_CODE == code
            //             group country by new { country.STATE_CODE, country.STATE_NAME } into state
            //             select state).Select(c => new SelectListItem
            //             {
            //                 Value = c.Key.STATE_CODE,
            //                 Text = c.Key.STATE_NAME
            //             });
            //}
            //else
            //{
            //    iitem = (from country in lstCountry
            //             where country.STATE_CODE == code
            //             group country by new { country.CITY_CODE, country.CITY_NAME } into city
            //             select city).Select(c => new SelectListItem
            //             {
            //                 Value = c.Key.CITY_CODE,
            //                 Text = c.Key.CITY_NAME
            //             });
            //}

            var selectlist = new SelectList(lstState, "Value", "Text");

            var data = new { selectList = selectlist };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSourceByAvailingType(int availTypeID)
        {
            var lstsource = (_iCandidateRepository.GetSourceByAvailingType(availTypeID))
                .Select(c => new SelectListItem
                {
                    Value = c.SOURCE_ID.ToString(),
                    Text = c.SOURCE_NAME
                }).OrderBy(c => c.Text);
            var selectlist = new SelectList(lstsource, "Value", "Text");

            bool isSessionActive = true;
            if (string.IsNullOrEmpty(Convert.ToString(((UserLoginResult)HttpContext.Session["UserDetails"]).REGISTRATION_NO)))
            {
                isSessionActive = false;
            }
            var data = new { selectList = selectlist, isSessionActive };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOtherSourceBySource(int sourceId)
        {
            var lstsource = (_iCandidateRepository.GetOtherSourceBySource(sourceId)).OrderBy(x => x.NAME)
                .Select(c => new SelectListItem
                {
                    Value = c.ID,
                    Text = c.NAME
                });
            var selectlist = new SelectList(lstsource, "Value", "Text");

            bool isSessionActive = true;
            if (string.IsNullOrEmpty(Convert.ToString(((UserLoginResult)HttpContext.Session["UserDetails"]).REGISTRATION_NO)))
            {
                isSessionActive = false;
            }
            var data = new { selectList = selectlist, isSessionActive };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecializationByEducation(int educationId)
        {
            var lstsource = (_iCandidateRepository.GetSpecializationByEducation(educationId))
                .Select(c => new SelectListItem
                {
                    Value = c.SPECIALIZATION_ID.ToString(),
                    Text = c.SPECIALIZATION_TYPE
                });
            var selectlist = new SelectList(lstsource, "Value", "Text");

            bool isSessionActive = true;
            if (string.IsNullOrEmpty(Convert.ToString(((UserLoginResult)HttpContext.Session["UserDetails"]).REGISTRATION_NO)))
            {
                isSessionActive = false;
            }
            var data = new { selectList = selectlist, isSessionActive };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDesignationByIndustry(int industryId)
        {
            var lstsource = (_iCandidateRepository.GetDesignationByIndustry(industryId)).ToList();
            var iitem = (from designation in lstsource
                         group designation by new { designation.DESIGNATION_ID, designation.DESIGNATION_NAME } into design
                         select design).Select(c => new SelectListItem
                         {
                             Value = c.Key.DESIGNATION_ID.ToString(),
                             Text = c.Key.DESIGNATION_NAME
                         });

            var selectlist = new SelectList(iitem, "Value", "Text");

            bool isSessionActive = true;
            if (string.IsNullOrEmpty(Convert.ToString(((UserLoginResult)HttpContext.Session["UserDetails"]).REGISTRATION_NO)))
            {
                isSessionActive = false;
            }
            var data = new { selectList = selectlist, isSessionActive };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIndustryDesignation(int[] code)
        {
            var result = _iCandidateRepository.GetDesignationByIndustry(code);
            var item = result.Select(c => new SelectListItem
            {
                Value = c.DESIGNATION_ID.ToString(),
                Text = c.DESIGNATION_NAME
            }).ToList();

            var selectlist = new SelectList(item, "Value", "Text");

            bool isSessionActive = true;
            if (string.IsNullOrEmpty(Convert.ToString(((UserLoginResult)HttpContext.Session["UserDetails"]).REGISTRATION_NO)))
            {
                isSessionActive = false;
            }
            var data = new { selectList = selectlist, isSessionActive };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UploadFile(string docpath, string doctype, string regno)
        {
            if (HttpContext.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    try
                    {
                        // Get the complete file path
                        string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]));
                        string fileName = Common.UploadFile(httpPostedFile, filepath);

                        return Json(fileName, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return null;
        }

        public JsonResult DuplicateCheck(string FIRST_NAME, string LAST_NAME, string DATE_OF_BIRTH, string PLACE_OF_BIRTH, string USER_TYPE_ID)
        {
            Candidate candidate = new Candidate();
            candidate.FIRST_NAME = FIRST_NAME;
            candidate.LAST_NAME = LAST_NAME;
            candidate.DATE_OF_BIRTH = DATE_OF_BIRTH != null ? Convert.ToDateTime(DATE_OF_BIRTH) : (DateTime?)null;
            candidate.PLACE_OF_BIRTH = PLACE_OF_BIRTH;
            candidate.USER_TYPE_ID = Convert.ToInt32(USER_TYPE_ID);

            if (_iCandidateRepository.CheckDuplicate(candidate))
                return Json(false, JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

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
                        // Get the complete file path
                        string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]));
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

        public JsonResult CalculateExperience(Candidate experience)
        {
            double totalyear = 0;
            double totalmonth = 0;
            double totalday = 0;
            double remainingDays = 0;

            double gulftotalyear = 0;
            double gulftotalmonth = 0;
            double gulftotalday = 0;
            double gulfremainingDays = 0;

            foreach (var item in experience.LST_USER_EXPERIENCE)
            {
                if (item.ISNEW)
                {
                    var diffDays = (Convert.ToDateTime(item.WORK_PERIOD_TO) - Convert.ToDateTime(item.WORK_PERIOD_FROM)).TotalDays;
                    totalday = totalday + diffDays;

                    if (item.COUNTRY_CODE != "3")
                    {
                        var gulfdiffDays = (Convert.ToDateTime(item.WORK_PERIOD_TO) - Convert.ToDateTime(item.WORK_PERIOD_FROM)).TotalDays;
                        gulftotalday = gulftotalday + gulfdiffDays;
                    }
                }
            }

            //Total Experience
            totalyear = Math.Truncate(totalday / 365);
            totalmonth = Math.Truncate((totalday % 365) / 30.4368);
            remainingDays = Math.Truncate((totalday % 365) % 30.4368);

            //Total Gulf Experience
            gulftotalyear = Math.Truncate(gulftotalday / 365);
            gulftotalmonth = Math.Truncate((gulftotalday % 365) / 30.4368);
            gulfremainingDays = Math.Truncate((gulftotalday % 365) % 30.4368);

            string totalYearofExp = totalyear + " Year(s), " + totalmonth + " month(s), " + remainingDays + " day(s)";
            string gulftotalYearofExp = gulftotalyear + " Year(s), " + gulftotalmonth + " month(s), " + gulfremainingDays + " day(s)";

            var data = new { totalYearofExp, gulftotalYearofExp };



            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public static void GetDifference(DateTime date1, DateTime date2, out int Years,
    out int Months, out int Weeks, out int Days)
        {
            //assumes date2 is the bigger date for simplicity

            //years
            TimeSpan diff = date2 - date1;
            Years = diff.Days / 366;
            DateTime workingDate = date1.AddYears(Years);

            while (workingDate.AddYears(1) <= date2)
            {
                workingDate = workingDate.AddYears(1);
                Years++;
            }

            //months
            diff = date2 - workingDate;
            Months = diff.Days / 31;
            workingDate = workingDate.AddMonths(Months);

            while (workingDate.AddMonths(1) <= date2)
            {
                workingDate = workingDate.AddMonths(1);
                Months++;
            }

            //weeks and days
            diff = date2 - workingDate;
            Weeks = diff.Days / 7; //weeks always have 7 days
            Days = diff.Days % 7;
        }
    }
}