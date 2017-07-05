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

namespace TIROERP.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisement _iAdvertisementRepository;
        public AdvertisementController(IAdvertisement iAdvertisementRepository)
        {
            _iAdvertisementRepository = iAdvertisementRepository;
        }

        // GET: Advertisement
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            List<Advertisement> advert_list = _iAdvertisementRepository.GetAllAdvertisements(0);
            return View(advert_list);
        }

        public ActionResult Create()
        {
            ViewBag.Requirements = getRequirements("");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Advertisement advertisement, HttpPostedFileBase advFile)
        {
            if (ModelState.IsValid)
            {
                if (advFile != null)
                {
                    // Get the complete file path
                    string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["AdvertisementUploadedFiles"]));
                    advertisement.FILE_PATH = Common.UploadFile(advFile, filepath);
                }

                _iAdvertisementRepository.Create(advertisement);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            else
            {
                ViewBag.Requirements = getRequirements("");
                return View("Create", advertisement);
            }

        }

        public ActionResult Edit(int id)
        {
            var advert_object = _iAdvertisementRepository.GetAllAdvertisements(id);
            ViewBag.Requirements = getRequirements("");

            var advert_list = advert_object.Select(x => new Advertisement
            {
                PAPER_NAME = x.PAPER_NAME,
                AD_AGENCY_NAME = x.AD_AGENCY_NAME,
                EXPENSES = Convert.ToDecimal(x.EXPENSES),
                REQUIREMENT_ID = x.REQUIREMENT_ID,
                ADV_DATE = x.ADV_DATE,
                FILE_PATH = x.FILE_PATH,
                ADV_ID = x.ADV_ID,
                REQUIREMENT_NAME = x.REQUIREMENT_NAME,
                CREATED_BY = x.CREATED_BY,
                CREATED_DATE = x.CREATED_DATE
            }).SingleOrDefault();
            return View(advert_list);
        }

        [HttpPost]
        public ActionResult Edit(Advertisement advertisement, HttpPostedFileBase advFile)
        {
            if (ModelState.IsValid)
            {
                if (advFile != null)
                {
                    string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["AdvertisementUploadedFiles"]));
                    advertisement.FILE_PATH = Common.UploadFile(advFile, filepath);
                }

                _iAdvertisementRepository.Edit(advertisement);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            else
            {
                ViewBag.Requirements = getRequirements("");
                return View("Edit", advertisement);
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var advert_object = _iAdvertisementRepository.GetAllAdvertisements(id);

                var advert_list = advert_object.Select(x => new Advertisement
                {
                    PAPER_NAME = x.PAPER_NAME,
                    AD_AGENCY_NAME = x.AD_AGENCY_NAME,
                    EXPENSES = Convert.ToDecimal(x.EXPENSES),
                    REQUIREMENT_ID = x.REQUIREMENT_ID,
                    ADV_DATE = x.ADV_DATE,
                    FILE_PATH = x.FILE_PATH,
                    ADV_ID = x.ADV_ID,
                    REQUIREMENT_NAME = x.REQUIREMENT_NAME,
                    CREATED_BY = x.CREATED_BY,
                    CREATED_DATE = x.CREATED_DATE
                }).SingleOrDefault();

                return View(advert_list);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Advertisement advertisement)
        {
            try
            {
                _iAdvertisementRepository.Delete(advertisement);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(advertisement);
            }

        }

        private IEnumerable<SelectListItem> getRequirements(string requirementName)
        {
            List<Advertisement_Requirements> requirementListDetails = _iAdvertisementRepository.GetAllRequirements();

            IEnumerable<SelectListItem> getAllRequirements = requirementListDetails.Where(x => x.RequirementName != requirementName).Select(x => new SelectListItem
            {
                Value = x.REQUIREMENT_ID.ToString(),
                Text = x.RequirementName
            });

            return getAllRequirements;
        }

    }

}