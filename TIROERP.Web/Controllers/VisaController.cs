using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;
using TIROERP.Web.Utilities;

namespace TIROERP.Web.Controllers
{

    [Authenticate]
    [ErrorFilter]
    public class VisaController : Controller
    {
        IVisa _iVisaRepository;

        public VisaController(IVisa iVisaRepository)
        {
            this._iVisaRepository = iVisaRepository;
        }

        // GET: Visa
        public ActionResult Index(int? id, bool isDashboard = false, string success = null)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;

            _fromDate = DateTime.Now.AddDays(-60);
            _toDate = DateTime.Now;

            ViewBag.Success = success;
            string conditionOperator = string.Empty;
            if (isDashboard)
                conditionOperator = "DASHBOARD";
            return View(_iVisaRepository.GetAllVisa(Convert.ToInt32(id), _fromDate, _toDate, null, conditionOperator));
        }

        [HttpPost]
        public ActionResult Index(string VisaNo, string FromDate, string ToDate)
        {
            try
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

                var result = _iVisaRepository.GetAllVisa(0, _fromDate, _toDate, VisaNo);

                //ViewBag.FromDate = FromDate;
                //ViewBag.ToDate = ToDate;
                //ViewBag.VisaNo = VisaNo;
                //ViewBag.HijriFromDate = ConvertDateCalendar(Convert.ToDateTime(_fromDate), "Hijri", "en-GB");
                //ViewBag.HijriToDate = ConvertDateCalendar(Convert.ToDateTime(_toDate), "Hijri", "en-GB");

                return View(result);
            }
            catch (Exception ex)
            {
                Common.LogError("VISA", "", "exception", ex.ToString(), ex.InnerException.ToString());
                throw ex;
            }
        }

        public ActionResult Create()
        {
            GetClient(null);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Visa visa, HttpPostedFileBase visaFile)
        {
            if (ModelState.IsValid)
            {
                if (visaFile != null)
                {
                    string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["VisaUploadedFiles"]));
                    visa.FILE_PATH = Common.UploadFile(visaFile, filepath);
                }
                _iVisaRepository.Create(visa);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                GetClient();
                return View("Create", visa);
            }
        }

        public ActionResult Edit(int id)
        {
            GetClient();
            var getdetailsbyId = _iVisaRepository.GetAllVisa(id);
            Visa visa = getdetailsbyId.Select(c => new Visa
            {
                VISA_ID = c.VISA_ID,
                CIVILIAN_NUMBER = c.CIVILIAN_NUMBER,
                VISA_NUMBER = c.VISA_NUMBER,
                PURPOSE = c.PURPOSE,
                PLACE_OF_ENDORSEMENT = c.PLACE_OF_ENDORSEMENT,
                INDIAN_FORMAT_ISSUE_DATE = c.INDIAN_FORMAT_ISSUE_DATE,
                INDIAN_FORMAT_EXPIRY_DATE = c.INDIAN_FORMAT_EXPIRY_DATE,
                ISSUE_DATE = ConvertDateCalendar(c.INDIAN_FORMAT_ISSUE_DATE, "Hijri", "en-GB"),
                EXPIRY_DATE = ConvertDateCalendar(c.INDIAN_FORMAT_EXPIRY_DATE, "Hijri", "en-GB"),
                RECIEVED_DATE = c.RECIEVED_DATE,
                REGISTRATION_NUMBER = c.REGISTRATION_NUMBER,
                CLIENT_NAME = c.CLIENT_NAME,
                FILE_PATH = c.FILE_PATH,
                REMARK = c.REMARK,
                CREATED_BY = c.CREATED_BY,
                CREATED_DATE = c.CREATED_DATE
            }).SingleOrDefault();

            //Visa modifiedVisa = GetHijriDate(visa);
            return View(visa);
        }

        public static string ConvertDateCalendar(DateTime DateConv, string Calendar, string DateLangCulture)
        {
            DateTimeFormatInfo DTFormat;
            DateLangCulture = DateLangCulture.ToLower();
            /// We can't have the hijri date writen in English. We will get a runtime error

            if (Calendar == "Hijri" && DateLangCulture.StartsWith("en-"))
            {
                DateLangCulture = "ar-sa";
            }

            /// Set the date time format to the given culture
            DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;

            /// Set the calendar property of the date time format to the given calendar
            switch (Calendar)
            {
                case "Hijri":
                    DTFormat.Calendar = new System.Globalization.HijriCalendar();
                    break;

                case "Gregorian":
                    DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                    break;

                default:
                    return "";
            }

            /// We format the date structure to whatever we want
            DTFormat.ShortDatePattern = "dd/mm/yyyy";
            string gregDate = (DateConv.Date.ToString("f", DTFormat).Substring(0, 10));
            return gregDate;
        }

        [HttpPost]
        public ActionResult Edit(Visa visa, HttpPostedFileBase visaFile)
        {
            if (ModelState.IsValid)
            {
                if (visaFile != null)
                {
                    string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["VisaUploadedFiles"]));
                    visa.FILE_PATH = Common.UploadFile(visaFile, filepath);
                }
                _iVisaRepository.Edit(visa);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                GetClient();
                return View("Edit", visa);
            }
        }

        private void GetClient(string clientId = null)
        {
            var lstClient = from client in _iVisaRepository.GetClient().AsEnumerable<GetClient>()
                            select new
                            {
                                Value = Convert.ToString(client.REGISTRATION_NO),
                                Text = client.NAME,
                            };

            ViewBag.ClientList = new SelectList(lstClient, "Value", "Text", clientId);
        }

        [HttpPost]
        public JsonResult GetCivilianNo(string client_code)
        {
            return Json(_iVisaRepository.GetCivilianNo(client_code), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iVisaRepository.GetAllVisa(id);
                var visa = getdetailsbyId.Select(c => new Visa
                {
                    VISA_ID = c.VISA_ID,
                    CIVILIAN_NUMBER = c.CIVILIAN_NUMBER,
                    VISA_NUMBER = c.VISA_NUMBER,
                    PURPOSE = c.PURPOSE,
                    PLACE_OF_ENDORSEMENT = c.PLACE_OF_ENDORSEMENT,
                    INDIAN_FORMAT_ISSUE_DATE = c.INDIAN_FORMAT_ISSUE_DATE,
                    INDIAN_FORMAT_EXPIRY_DATE = c.INDIAN_FORMAT_EXPIRY_DATE,
                    RECIEVED_DATE = c.RECIEVED_DATE,
                    REGISTRATION_NUMBER = c.REGISTRATION_NUMBER,
                    CLIENT_NAME = c.CLIENT_NAME,
                    FILE_PATH = c.FILE_PATH,
                    REMARK = c.REMARK,
                    CREATED_BY = c.CREATED_BY,
                    CREATED_DATE = c.CREATED_DATE
                }).SingleOrDefault();
                return View(visa);
            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Visa visa)
        {
            try
            {
                _iVisaRepository.Delete(visa);
                return RedirectToAction("Index", new { success = "Record Deleted Successfully!!!" });
            }
            catch (Exception)
            {
                return View(visa);
            }

        }

        [HttpPost]
        public JsonResult GetIndianDate(string date, string purpose, string isIssueDate)
        {
            CultureInfo arCul;
            CultureInfo enCul;
            HijriCalendar h;
            GregorianCalendar g;
            arCul = new CultureInfo("ar-SA");
            enCul = new CultureInfo("en-GB");

            h = new HijriCalendar();
            g = new GregorianCalendar(GregorianCalendarTypes.USEnglish);

            arCul.DateTimeFormat.Calendar = h;

            try
            {
                DateTime tempDate = DateTime.ParseExact(date, "dd/MM/yyyy",
                   arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                string gregDate = Convert.ToString(tempDate.ToString("dd/MM/yyyy", enCul.DateTimeFormat));



                string expirydate = string.Empty;
                string hijriexpirydate = string.Empty;
                if (isIssueDate.Equals("1"))
                {
                    if (purpose == "Employment" || purpose == "Service")
                    {
                        expirydate = Convert.ToDateTime(gregDate).AddYears(2).ToString("dd/MM/yyyy");
                        hijriexpirydate = Convert.ToDateTime(expirydate).ToString("dd/MM/yyyy", arCul);
                    }
                }

                var data = new { gregDate, expirydate, hijriexpirydate };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }


        }
    }
}