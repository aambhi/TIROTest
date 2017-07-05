using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers.Process
{
    
    [Authenticate]
    [ErrorFilter]
    public class PolicyController : Controller
    {
        private readonly IPolicy _iPolicyRepository;

        public PolicyController(IPolicy iPolicyRepository)
        {
            _iPolicyRepository = iPolicyRepository;
        }
        // GET: Policy
        public ActionResult Policy()
        {
            ViewBag.GetPassportNo = getPassportNo();
            return View();
        }

        [HttpPost]
        public ActionResult Policy(Policy policy)
        {
            if (ModelState.IsValid)
            {
                _iPolicyRepository.Create(policy);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });

            }
            else
            {
                ViewBag.GetPassportNo = getPassportNo();
                return View("Policy", policy);
            }
        }

        private IEnumerable<SelectListItem> getPassportNo()
        {
            List<Passport_Details> passportNumbers = _iPolicyRepository.GetPassportNumbers();

            IEnumerable<SelectListItem> passportDetailsList = passportNumbers.Select(x => new SelectListItem
            {
                Value = x.USER_REQUIREMENT_ID.ToString(),
                Text = x.PASSPORT_NUMBER
            });

            return passportDetailsList;
        }

        [HttpPost]
        public JsonResult GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            if (userRequirementId > 0)
            {
                candidateName = _iPolicyRepository.GetCandidateName(userRequirementId);
            }
            return Json(candidateName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(int? id, string success = null)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;

            _fromDate = DateTime.Now.AddDays(-15);
            _toDate = DateTime.Now.AddDays(60);

            ViewBag.Success = success;
            var result = _iPolicyRepository.GetAllProcess(Convert.ToInt16(id), "POLICY", _fromDate, _toDate);
            return View(result);
        }


        [HttpPost]
        public ActionResult Index(string PassportNo, string FromDate, string ToDate)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;
            if (!string.IsNullOrEmpty(FromDate))
            {
                _fromDate = DateTime.ParseExact(FromDate, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                _fromDate = DateTime.Now.AddDays(-15);
            }

            if (!string.IsNullOrEmpty(ToDate))
            {
                _toDate = DateTime.ParseExact(ToDate, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                _toDate = _fromDate.Value.AddDays(60);
            }
            var result = _iPolicyRepository.GetAllProcess(0, "POLICY", _fromDate, _toDate, PassportNo);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.GetPassportNo = getPassportNo();
            var result = _iPolicyRepository.GetAllProcess(id, "POLICY");
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
            return View(policy);
        }

        [HttpPost]
        public ActionResult Edit(Policy policy)
        {
            if (ModelState.IsValid)
            {
                _iPolicyRepository.Update(policy);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                ViewBag.GetPassportNo = getPassportNo();
                return View("Edit", policy);
            }
        }
    }
}