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
    public class MofaController : Controller
    {
        private readonly IMofa _iMofaRepository;

        public MofaController(IMofa iMofaRepository)
        {
            _iMofaRepository = iMofaRepository;
        }
        // GET: Mofa
        public ActionResult Mofa()
        {
            ViewBag.GetPassportNo = getPassportNo();
            return View();
        }

        [HttpPost]
        public ActionResult Mofa(Mofa mofa, HttpPostedFileBase mofaFile)
        {
            if (ModelState.IsValid)
            {
                if (mofaFile != null)
                {
                    mofa.MofaFilePath = UploadImageFile(mofaFile);
                }
                _iMofaRepository.Create(mofa);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                ViewBag.GetPassportNo = getPassportNo();
                return View("Mofa", mofa);
            }

        }
        private IEnumerable<SelectListItem> getPassportNo()
        {
            List<Passport_Details> passportNumbers = _iMofaRepository.GetPassportNumbers();

            IEnumerable<SelectListItem> passportDetailsList = passportNumbers.Select(x => new SelectListItem
            {
                Value = x.USER_REQUIREMENT_ID.ToString(),
                Text = x.PASSPORT_NUMBER
            });

            return passportDetailsList;
        }

        private string UploadImageFile(HttpPostedFileBase httpPostedFile)
        {

            try
            {
                // Get the complete file path
                string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["MofaUploadedFiles"]));
                return Common.UploadFile(httpPostedFile, filepath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public JsonResult GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            if (userRequirementId > 0)
            {
                candidateName = _iMofaRepository.GetCandidateName(userRequirementId);
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
            var result = _iMofaRepository.GetAllProcess(Convert.ToInt16(id), "MOFA", _fromDate, _toDate);
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
            var result = _iMofaRepository.GetAllProcess(0, "MOFA", _fromDate, _toDate, PassportNo);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = _iMofaRepository.GetAllProcess(id, "MOFA");
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
            return View(mofa);
        }

        [HttpPost]
        public ActionResult Edit(Mofa mofa, HttpPostedFileBase mofaFile)
        {
            if (ModelState.IsValid)
            {
                if (mofaFile != null)
                {
                    mofa.MofaFilePath = UploadImageFile(mofaFile);
                }
                _iMofaRepository.Update(mofa);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {

                return View("Edit", mofa);
            }
        }
    }
}