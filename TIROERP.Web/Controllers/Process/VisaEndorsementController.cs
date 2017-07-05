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
    public class VisaEndorsementController : Controller
    {
        private readonly IVisaEndorsement _iVisaEndorsementRepository;

        public VisaEndorsementController(IVisaEndorsement iVisaRepository)
        {
            _iVisaEndorsementRepository = iVisaRepository;
        }
        // GET: VisaEndorsement
        public ActionResult VisaEndorsement()
        {

            GetMasterData();
            return View();
        }

        [HttpPost]
        public ActionResult VisaEndorsement(VisaEndorsement visaEndorsement, HttpPostedFileBase visaendorsementFile)
        {
            if (ModelState.IsValid)
            {
                if (visaendorsementFile != null)
                {
                    visaEndorsement.VisaEndorsementFilePath = UploadImageFile(visaendorsementFile);
                }
                _iVisaEndorsementRepository.Create(visaEndorsement);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                GetMasterData();
                return View("VisaEndorsement", visaEndorsement);

            }
        }

        private void GetMasterData()
        {
            ViewBag.GetPassportDetails = getPassportNo();
            ViewBag.GetSubmissionDetails = getSubmissionDetails();
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

        private IEnumerable<SelectListItem> getPassportNo()
        {
            List<Passport_Details> passportDetailsList = _iVisaEndorsementRepository.GetPassportDetails();

            IEnumerable<SelectListItem> passportList = passportDetailsList.Select(x => new SelectListItem
            {
                Value = x.USER_REQUIREMENT_ID.ToString(),
                Text = x.PASSPORT_NUMBER
            }).ToList();

            return passportList;
        }

        [HttpPost]
        public JsonResult GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            if (userRequirementId > 0)
            {
                candidateName = _iVisaEndorsementRepository.GetCandidateName(userRequirementId);
            }
            return Json(candidateName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(int? id, string success = null)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;

            _fromDate = DateTime.Now.AddDays(-60);
            _toDate = DateTime.Now;

            ViewBag.Success = success;
            var result = _iVisaEndorsementRepository.GetAllProcess(Convert.ToInt16(id), "VISA", _fromDate, _toDate);
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
            //else
            //{
            //    _fromDate = DateTime.Now.AddDays(-15);
            //}

            if (!string.IsNullOrEmpty(ToDate))
            {
                _toDate = DateTime.ParseExact(ToDate, @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            //else
            //{
            //    _toDate = _fromDate.Value.AddDays(60);
            //}
            var result = _iVisaEndorsementRepository.GetAllProcess(0, "VISA", _fromDate, _toDate, PassportNo);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            GetMasterData();
            var result = _iVisaEndorsementRepository.GetAllProcess(id, "VISA");
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
            return View(visa);
        }

        [HttpPost]
        public ActionResult Edit(VisaEndorsement visa, HttpPostedFileBase visaendorsementFile)
        {
            if (ModelState.IsValid)
            {
                if (visaendorsementFile != null)
                {
                    visa.VisaEndorsementFilePath = UploadImageFile(visaendorsementFile);
                }
                _iVisaEndorsementRepository.Update(visa);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                GetMasterData();
                return View("Edit", visa);
            }
        }

        private string UploadImageFile(HttpPostedFileBase httpPostedFile)
        {
            try
            {
                // Get the complete file path
                string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["VisaEndorsementUploadedFiles"]));
                return Common.UploadFile(httpPostedFile, filepath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}