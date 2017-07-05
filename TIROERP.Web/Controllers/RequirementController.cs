using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{

    [Authenticate]
    [ErrorFilter]
    public class RequirementController : Controller
    {
        IRequirement _iRequirementRepository;
        IDesignation _iDesignationRepository;

        public RequirementController(IRequirement _iRequirementRepository, IDesignation iDesignationRepository)
        {
            this._iRequirementRepository = _iRequirementRepository;
            this._iDesignationRepository = iDesignationRepository;
        }

        public ActionResult CreateReq()
        {
            GetMasterData(null);
            return View();
        }

        private void GetMasterData(RequirementModel RequirementModel)
        {
            var result = _iRequirementRepository.GetMasterData();

            List<Allowance> lstAllowance = (List<Allowance>)result[0];
            var lstAllowanceData = (from allowance in lstAllowance
                                    select allowance).ToList().Select(c => new SelectListItem
                                    {
                                        Value = c.ALLOWANCE_ID.ToString(),
                                        Text = c.ALLOWANCE_NAME
                                    });
            ViewData["GetAllowance"] = new SelectList(lstAllowanceData, "Value", "Text");

            List<ClientCompany> lstCompany = (List<ClientCompany>)result[1];
            var lstCompanyData = (from company in lstCompany
                                  select company).ToList().Select(c => new SelectListItem
                                  {
                                      Value = c.COMPANY_ID.ToString(),
                                      Text = c.COMPANY_NAME
                                  });
            ViewData["GetCompany"] = new SelectList(lstCompanyData, "Value", "Text");

            List<ContactPerson> lstContactPerson = (List<ContactPerson>)result[2];
            var lstContactPersonData = (from contactPerson in lstContactPerson
                                        select contactPerson).ToList().Select(c => new SelectListItem
                                        {
                                            Value = c.REGISTRATION_NO.ToString(),
                                            Text = c.NAME
                                        });
            ViewData["GetClient"] = new SelectList(lstContactPersonData, "Value", "Text");

            List<Currency> lstCurrency = (List<Currency>)result[3];
            var lstCurrencyData = (from currency in lstCurrency
                                   select currency).ToList().Select(c => new SelectListItem
                                   {
                                       Value = c.CURRENCY_ID.ToString(),
                                       Text = c.CURRENCY_SYMBOL
                                   });
            ViewData["GetCurrency"] = new SelectList(lstCurrencyData, "Value", "Text");



            List<EducationType> lstEducationType = (List<EducationType>)result[4];
            var lstEducationTypeData = (from education in lstEducationType
                                        select education).ToList().Select(c => new SelectListItem
                                        {
                                            Value = c.EDUCATION_TYPE_ID.ToString(),
                                            Text = c.EDUCATION_TYPE
                                        });
            ViewData["GetEducation"] = new SelectList(lstEducationTypeData, "Value", "Text");

            List<Gender> lstGender = (List<Gender>)result[5];
            var lstGenderData = (from gender in lstGender
                                 select gender).ToList().Select(c => new SelectListItem
                                 {
                                     Value = c.GENDER_CODE.ToString(),
                                     Text = c.GENDER_NAME
                                 });
            ViewData["GetGender"] = new SelectList(lstGenderData, "Value", "Text");


            List<InterviewMode> lstInterviewMode = (List<InterviewMode>)result[6];
            var lstInterviewModeData = (from interviewMode in lstInterviewMode
                                        select interviewMode).ToList().Select(c => new SelectListItem
                                        {
                                            Value = c.INTERVIEW_MODE_ID.ToString(),
                                            Text = c.INTERVIEW_MODE
                                        });
            ViewData["GetModeOfInterview"] = new SelectList(lstInterviewModeData, "Value", "Text");

            List<Language> lstLanguage = (List<Language>)result[7];
            var lstLanguageData = (from language in lstLanguage
                                   select language).ToList().Select(c => new SelectListItem
                                   {
                                       Value = c.LANGUAGE_ID.ToString(),
                                       Text = c.LANGUAGE_NAME
                                   });
            ViewData["GetLanguage"] = new SelectList(lstLanguageData, "Value", "Text");

            List<Religion> lstReligion = (List<Religion>)result[8];
            var lstReligionData = (from religion in lstReligion
                                   select religion).ToList().Select(c => new SelectListItem
                                   {
                                       Value = c.RELIGION_ID.ToString(),
                                       Text = c.RELIGION_NAME
                                   });
            ViewData["GetReligion"] = new SelectList(lstReligionData, "Value", "Text");



            List<RequirementStatus> lstStatus = (List<RequirementStatus>)result[9];
            var lstStatusData = (from status in lstStatus
                                 select status).ToList().Select(c => new SelectListItem
                                 {
                                     Value = c.STATUS_VAL.ToString(),
                                     Text = c.STATUS_NAME

                                 });
            ViewData["GetStatus"] = new SelectList(lstStatusData, "Value", "Text");

            List<Industry> lstIndustry = (List<Industry>)result[10];
            var lstIndustryData = (from industry in lstIndustry
                                   select industry).ToList().Select(c => new SelectListItem
                                   {
                                       Value = c.INDUSTRY_ID.ToString(),
                                       Text = c.INDUSTRY_TYPE
                                   });
            ViewData["GetIndustry"] = new SelectList(lstIndustryData, "Value", "Text");



            List<Certification> lstCertification = (List<Certification>)result[11];
            var lstCertificcationData = (from certification in lstCertification
                                         select certification).ToList().Select(c => new SelectListItem
                                         {
                                             Value = c.CERTIFICATION_ID.ToString(),
                                             Text = c.CERTIFICATION_NAME

                                         });
            ViewData["GetCertification"] = new SelectList(lstCertificcationData, "Value", "Text");

            List<AllowanceType> lstAllowanceType = (List<AllowanceType>)result[12];

            foreach (AllowanceType item in lstAllowanceType)
            {
                ViewData[item.ALLOWANCE_TYPE.ToString()] = item.ALLOWANCE_TYPE_ID;
            }
        }

        [ActionName("GetRoleByIndustry")]
        public ActionResult GetSDesignationByIndustry(string[] Industry_Ids)
        {
            if (Industry_Ids.Length > 0)
            {
                int[] industryIdList = Industry_Ids.Select(int.Parse).ToArray();
                var designationByIdList = _iDesignationRepository.GetDesignationByIndustry(industryIdList);
                return Json(designationByIdList);
            }
            return Json("");
        }

        public ActionResult GetSpecializationByEducation(string[] Education_Ids)
        {
            if (Education_Ids.Length > 0)
            {
                int[] educationList = Education_Ids.Select(int.Parse).ToArray();
                var specilizationByIdList = _iRequirementRepository.GetSpecilizationByEducationType(educationList);
                return Json(specilizationByIdList);
            }
            return Json("");
        }

        [HttpPost]
        public ActionResult CreateReq(RequirementModel requirementModel)
        {

            string foodTypeDetails = Request.Form["foodTypeDetails"].ToString();
            string medicalTypeDetails = Request.Form["medicalTypeDetails"].ToString();
            string housingTypeDetails = Request.Form["housingTypeDetails"].ToString();
            string travelTypeDetails = Request.Form["travelTypeDetails"].ToString();
            List<string> detailsList = new List<string>();

            if (!string.IsNullOrWhiteSpace(foodTypeDetails))
                detailsList.Add(foodTypeDetails + "," + (requirementModel.FOOD_ALLOWANCE == null ? "0" : requirementModel.FOOD_ALLOWANCE.ToString()));
            if (!string.IsNullOrWhiteSpace(medicalTypeDetails))
                detailsList.Add(medicalTypeDetails + "," + (requirementModel.MEDICAL_ALLOWANCE == null ? "0" : requirementModel.MEDICAL_ALLOWANCE.ToString()));
            if (!string.IsNullOrWhiteSpace(housingTypeDetails))
                detailsList.Add(housingTypeDetails + "," + (requirementModel.HOUSING_ALLOWANCE == null ? "0" : requirementModel.HOUSING_ALLOWANCE.ToString()));
            if (!string.IsNullOrWhiteSpace(travelTypeDetails))
                detailsList.Add(travelTypeDetails + "," + (requirementModel.TRAVELLING_ALLOWANCE == null ? "0" : requirementModel.TRAVELLING_ALLOWANCE.ToString()));

            string allowanceDetails = String.Join("|", detailsList);

            requirementModel.ALLOWANCE_IDS = allowanceDetails;
            requirementModel.LANGUAGE = Request.Form["hdnLanguageIds"].ToString();
            var requirementId = _iRequirementRepository.Create(requirementModel);
            TempData["Success"] = string.Format("Success! Well done its submitted. Requirement ID :R00{0}", requirementId);
            return RedirectToAction("CreateReq");

        }

        public ActionResult EditRequirementDetails(int requirementID)
        {

            var result = _iRequirementRepository.EditRequirementDetailsById(requirementID);
            GetMasterData(result);
            if (!string.IsNullOrEmpty(result.LANGUAGE))
                ViewBag.hdnLanguageIds = result.LANGUAGE;
            if (!string.IsNullOrEmpty(result.ALLOWANCE_IDS))
            {
                var tempArr = result.ALLOWANCE_IDS.Split('|');
                foreach (var item in tempArr)
                {
                    switch (Convert.ToInt16(item.Split(',')[1]))
                    {
                        case (int)ALLOWANCE_IDS.FOOD:
                            ViewBag.foodTypeDetails = Convert.ToInt16(item.Split(',')[0]) + "," + Convert.ToInt16(item.Split(',')[1]); ;
                            result.SELECTD_FOOD_ALLOWANCE = Convert.ToInt16(item.Split(',')[0]);
                            result.FOOD_ALLOWANCE = Convert.ToDecimal(item.Split(',')[2]);
                            break;
                        case (int)ALLOWANCE_IDS.HOUSE:
                            ViewBag.housingTypeDetails = Convert.ToInt16(item.Split(',')[0]) + "," + Convert.ToInt16(item.Split(',')[1]); ;
                            result.SELECTD_HOUSE_ALLOWANCE = Convert.ToInt16(item.Split(',')[0]);
                            result.HOUSING_ALLOWANCE = Convert.ToDecimal(item.Split(',')[2]);
                            break;
                        case (int)ALLOWANCE_IDS.MEDICAL:
                            ViewBag.medicalTypeDetails = Convert.ToInt16(item.Split(',')[0]) + "," + Convert.ToInt16(item.Split(',')[1]);
                            result.SELECTD_MEDICAL_ALLOWANCE = Convert.ToInt16(item.Split(',')[0]);
                            result.MEDICAL_ALLOWANCE = Convert.ToDecimal(item.Split(',')[2]);
                            break;
                        case (int)ALLOWANCE_IDS.TRAVEL:
                            ViewBag.travelTypeDetails = Convert.ToInt16(item.Split(',')[0]) + "," + Convert.ToInt16(item.Split(',')[1]); ;
                            result.SELECTD_TRAVEL_ALLOWANCE = Convert.ToInt16(item.Split(',')[0]);
                            result.TRAVELLING_ALLOWANCE = Convert.ToDecimal(item.Split(',')[2]);
                            break;

                    }
                }
            }
            if (result.INDUSTRY != null && result.INDUSTRY.Length > 0)
            {
                var designationByIdList = _iDesignationRepository.GetDesignationByIndustry(result.INDUSTRY);

                var lstDesignationData = (from designation in designationByIdList
                                          select designation).ToList().Select(c => new SelectListItem
                                          {
                                              Value = c.DESIGNATION_ID.ToString(),
                                              Text = c.DESIGNATION_NAME,
                                          });
                ViewData["GetDesignation"] = new SelectList(lstDesignationData, "Value", "Text");


            }
            if (result.EDUCATION != null && result.EDUCATION.Length > 0)
            {
                var specilizationByIdList = _iRequirementRepository.GetSpecilizationByEducationType(result.EDUCATION);
                var lstSpecializationData = (from specialization in specilizationByIdList
                                             select specialization).ToList().Select(c => new SelectListItem
                                             {
                                                 Value = c.SPECIALIZATION_ID.ToString(),
                                                 Text = c.SPECIALIZATION_TYPE,
                                             });
                ViewData["GetSpecialization"] = new SelectList(lstSpecializationData, "Value", "Text");

            }


            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateReq(RequirementModel requirementModel)
        {

            string foodTypeDetails = Request.Form["foodTypeDetails"].ToString();
            string medicalTypeDetails = Request.Form["medicalTypeDetails"].ToString();
            string housingTypeDetails = Request.Form["housingTypeDetails"].ToString();
            string travelTypeDetails = Request.Form["travelTypeDetails"].ToString();
            List<string> detailsList = new List<string>();

            if (!string.IsNullOrWhiteSpace(foodTypeDetails))
                detailsList.Add(foodTypeDetails + "," + (requirementModel.FOOD_ALLOWANCE == null ? "0" : requirementModel.FOOD_ALLOWANCE.ToString()));
            if (!string.IsNullOrWhiteSpace(medicalTypeDetails))
                detailsList.Add(medicalTypeDetails + "," + (requirementModel.MEDICAL_ALLOWANCE == null ? "0" : requirementModel.MEDICAL_ALLOWANCE.ToString()));
            if (!string.IsNullOrWhiteSpace(housingTypeDetails))
                detailsList.Add(housingTypeDetails + "," + (requirementModel.HOUSING_ALLOWANCE == null ? "0" : requirementModel.HOUSING_ALLOWANCE.ToString()));
            if (!string.IsNullOrWhiteSpace(travelTypeDetails))
                detailsList.Add(travelTypeDetails + "," + (requirementModel.TRAVELLING_ALLOWANCE == null ? "0" : requirementModel.TRAVELLING_ALLOWANCE.ToString()));

            string allowanceDetails = String.Join("|", detailsList);

            requirementModel.ALLOWANCE_IDS = allowanceDetails;
            requirementModel.LANGUAGE = Request.Form["hdnLanguageIds"].ToString();
            bool IsUpdated = _iRequirementRepository.Update(requirementModel);
            if (IsUpdated)
                ViewData["Success"] = string.Format("Success! Record saved successfully. Requirement ID :R00{0}", requirementModel.REQUIREMENT_ID);
            return RedirectToAction("RequirementSearch", "RequirementSearch", new { success = ViewData["Success"] });

        }

        public JsonResult DuplicateCheck(string companyName, string contactPerson, string jobTitle)
        {
            if (_iRequirementRepository.CheckDuplicate(companyName, contactPerson, jobTitle))
                return Json(false, JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}