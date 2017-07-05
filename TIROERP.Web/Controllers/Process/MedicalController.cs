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
    public class MedicalController : Controller
    {
        private readonly IMedical _iMedicalRepository;

        public MedicalController(IMedical iMedicalRepository)
        {
            _iMedicalRepository = iMedicalRepository;
        }
        // GET: Medical
        public ActionResult Create()
        {
            ViewBag.GetPassportNo = getPassportNo();
            ViewBag.GetDoctor = getDoctorDetails();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Medical medical, HttpPostedFileBase medicalFile)
        {
            if (ModelState.IsValid)
            {
                if (medicalFile != null)
                {
                    medical.ReportPath = UploadImageFile(medicalFile);
                }
                _iMedicalRepository.Create(medical);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                ViewBag.GetPassportNo = getPassportNo();
                ViewBag.GetDoctor = getDoctorDetails();
                return View("Create", medical);
            }

        }

        private IEnumerable<SelectListItem> getPassportNo()
        {
            List<Passport_Details> passportNumbers = _iMedicalRepository.GetPassportNumbers();

            IEnumerable<SelectListItem> passportDetailsList = passportNumbers.Select(x => new SelectListItem
            {
                Value = x.USER_REQUIREMENT_ID.ToString(),
                Text = x.PASSPORT_NUMBER
            });

            return passportDetailsList;
        }

        private IEnumerable<SelectListItem> getDoctorDetails()
        {
            List<Doctor_Details> passportNumbers = _iMedicalRepository.GetDoctorsList();

            IEnumerable<SelectListItem> doctorList = passportNumbers.Select(x => new SelectListItem
            {
                Value = x.REGISTATION_NUMBER.ToString(),
                Text = x.ClinicName + " | " + x.First_Name + x.Last_Name
            });

            return doctorList;
        }

        [HttpPost]
        public JsonResult GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            if (userRequirementId > 0)
            {
                candidateName = _iMedicalRepository.GetCandidateName(userRequirementId);
            }
            return Json(candidateName, JsonRequestBehavior.AllowGet);
        }

        private string UploadImageFile(HttpPostedFileBase httpPostedFile)
        {

            try
            {
                // Get the complete file path
                string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["MedicalUploadedFiles"]));
                return Common.UploadFile(httpPostedFile, filepath);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult Index(int? id, string success = null)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;

            _fromDate = DateTime.Now.AddDays(-60);
            _toDate = DateTime.Now;

            ViewBag.Success = success;
            var medicalresult = _iMedicalRepository.GetAllProcess(Convert.ToInt16(id), "MEDICAL", _fromDate, _toDate);
            return View(medicalresult);
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

            var medicalresult = _iMedicalRepository.GetAllProcess(0, "MEDICAL", _fromDate, _toDate, PassportNo);
            return View(medicalresult);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.GetDoctor = getDoctorDetails();
            var medicalresult = _iMedicalRepository.GetAllProcess(id, "MEDICAL");
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
            return View(medical);
        }

        [HttpPost]
        public ActionResult Edit(Medical medical, HttpPostedFileBase medicalFile)
        {
            if (ModelState.IsValid)
            {
                if (medicalFile != null)
                {
                    medical.ReportPath = UploadImageFile(medicalFile);
                }
                _iMedicalRepository.Update(medical);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                ViewBag.GetDoctor = getDoctorDetails();
                return View("Edit", medical);
            }
        }

        public FileResult Download(string filepath)
        {
            var FileVirtualPath = filepath;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}