using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class RequirementSearchController : Controller
    {
        private readonly IRequirement _iRequirementRepository;

        public RequirementSearchController(IRequirement iRequirementRepository)
        {
            this._iRequirementRepository = iRequirementRepository;
        }

        public ActionResult RequirementSearch(RequirementSearch requirementSearch, string success = null)
        {
            requirementSearch.STATUS = true;
            ViewData["Status"] = true;
            ViewData["Success"] = success;
            GetMasterData();
            var requirementSearchresult = _iRequirementRepository.requirementSearchResult(requirementSearch);
            return View(requirementSearchresult);
        }

        public void GetMasterData()
        {
            var result = _iRequirementRepository.GetMasterData();
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

            List<RequirementStatus> lstStatus = (List<RequirementStatus>)result[9];
            var lstStatusData = (from status in lstStatus
                                 select status).ToList().Select(c => new SelectListItem
                                 {
                                     Value = c.STATUS_VAL.ToString(),
                                     Text = c.STATUS_NAME
                                 });
            ViewData["GetStatus"] = new SelectList(lstStatusData, "Value", "Text");

        }

        [HttpPost]
        public ActionResult RequirementSearch(RequirementSearch requirementSearch)
        {
            GetMasterData();
            var result = _iRequirementRepository.requirementSearchResult(requirementSearch);
            return View(result);
        }

        public ActionResult ViewRequirementDetails(int requirementID)
        {

            var result = _iRequirementRepository.GetRequirementDetailsById(requirementID);
            var reqSearchVM = (List<RequirementSearchViewModel>)result[0];
            reqSearchVM[0].reqAllowance = (List<RequirementAllowance>)result[1];
            return View(reqSearchVM[0]);
        }

        public PartialViewResult GetAgentDetails()
        {
            AgentEmail agentEmail = new AgentEmail();
            var agentList = _iRequirementRepository.GetAgentEmailList();
            return PartialView("_AgentEmailList", agentList);
        }

        public string SendEmailToAgents(string requirementIdList, string emailIdList)
        {
            try
            {
                var requirementDetails = _iRequirementRepository.GetRequirementDetailList(requirementIdList);
                DateTime dt = DateTime.Now;
                string timeStamp = dt.Day + "_" + dt.Month + "_" + dt.Year + "_" + dt.Second;
                string filePath = Server.MapPath(ConfigurationManager.AppSettings["RequirementFiles"]) + timeStamp + ".xlsx";

                filePath = Common.GenerateExcelFile(requirementDetails, filePath);
                string SubjectLine = "Requirement Details";
                string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                if (!string.IsNullOrEmpty(fromEmailAddress))
                {
                    Common.SendEmail(fromEmailAddress, emailIdList, filePath, SubjectLine, "");
                }
                return "Requirement Details sent successfully!!!";
            }
            catch (Exception ex)
            {
                Common.LogError("SendEmailToAgents", "", "SendEmailToAgents", "EXCEPTION OCCURED", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                return "Error occurred while sending mail.";
            }
        }
    }
}