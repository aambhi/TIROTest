using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;
using TIROERP.Web.Utilities;

namespace TIROERP.Web.Controllers.Process
{
    
    [Authenticate]
    [ErrorFilter]
    public class EmigrationController : Controller
    {
        private readonly IEmigration _iEmigrationRepository;

        public EmigrationController(IEmigration iEmigrationRepository)
        {
            _iEmigrationRepository = iEmigrationRepository;
        }
        // GET: Emigration
        public ActionResult Index(int? id, string success = null)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;

            _fromDate = DateTime.Now.AddDays(-15);
            _toDate = DateTime.Now.AddDays(60);

            ViewBag.Success = success;
            var result = _iEmigrationRepository.GetAllProcess(Convert.ToInt16(id), "EMIGRATION", _fromDate, _toDate);
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
            var result = _iEmigrationRepository.GetAllProcess(0, "EMIGRATION", _fromDate, _toDate, PassportNo);
            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.GetPassportNo = getPassportNo();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Emigration emigration, HttpPostedFileBase policyFile, HttpPostedFileBase emigrationFile)
        {
            if (ModelState.IsValid)
            {
                if (policyFile != null)
                {
                    emigration.POLICY_ATTACHMENT = UploadImageFile(policyFile);
                }
                if (emigrationFile != null)
                {
                    emigration.EMIGRATION_ATTACHMENT = UploadImageFile(emigrationFile);
                }
                _iEmigrationRepository.Create(emigration);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                ViewBag.GetPassportNo = getPassportNo();
                return View("Create", emigration);
            }
        }

        [HttpPost]
        public JsonResult GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            if (userRequirementId > 0)
            {
                candidateName = _iEmigrationRepository.GetCandidateName(userRequirementId);
            }
            return Json(candidateName, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SelectListItem> getPassportNo()
        {
            List<Passport_Details> passportNumbers = _iEmigrationRepository.GetPassportNumbers();

            IEnumerable<SelectListItem> passportDetailsList = passportNumbers.Select(x => new SelectListItem
            {
                Value = x.USER_REQUIREMENT_ID.ToString(),
                Text = x.PASSPORT_NUMBER
            });

            return passportDetailsList;
        }

        public ActionResult Edit(int id)
        {
            ViewBag.GetPassportNo = getPassportNo();
            var result = _iEmigrationRepository.GetAllProcess(id, "EMIGRATION");
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
            return View(emigration);
        }

        [HttpPost]
        public ActionResult Edit(Emigration emigration, HttpPostedFileBase policyFile, HttpPostedFileBase emigrationFile)
        {
            if (ModelState.IsValid)
            {
                if (policyFile != null)
                {
                    emigration.POLICY_ATTACHMENT = UploadImageFile(policyFile);
                }
                if (emigrationFile != null)
                {
                    emigration.EMIGRATION_ATTACHMENT = UploadImageFile(emigrationFile);
                }
                _iEmigrationRepository.Update(emigration);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                ViewBag.GetPassportNo = getPassportNo();
                return View("Edit", emigration);
            }
        }

        private string UploadImageFile(HttpPostedFileBase httpPostedFile)
        {
            try
            {
                // Get the complete file path
                string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["EmigrationUploadedFiles"]));
                return Common.UploadFile(httpPostedFile, filepath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}