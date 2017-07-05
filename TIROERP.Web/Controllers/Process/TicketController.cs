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
    public class TicketController : Controller
    {
        private readonly ITicket _iTicketRepository;

        public TicketController(ITicket iTicketRepository)
        {
            _iTicketRepository = iTicketRepository;
        }
        // GET: Ticket
        public ActionResult Ticket()
        {
            GetMasterData();
            return View();
        }


        [HttpPost]
        public ActionResult Ticket(Ticket ticket, HttpPostedFileBase ticketReport)
        {
            if (ModelState.IsValid)
            {
                if (ticketReport != null)
                {
                    ticket.ReportPath = UploadFile(ticketReport); //returns file name
                }
                _iTicketRepository.CreateUpdate(ticket, "INSERT");
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                GetMasterData();
                return View("Ticket", ticket);
            }
        }

        private string UploadFile(HttpPostedFileBase httpPostedFile)
        {
            try
            {
                // Get the complete file path
                string filepath = Path.Combine(HttpContext.Server.MapPath(ConfigurationManager.AppSettings["TicketUploadedFiles"]));
                return Common.UploadFile(httpPostedFile, filepath);
            }
            catch (Exception)
            {
                return "Error";
            }
        }


        private void GetMasterData()
        {
            ViewBag.GetPassportDetails = getPassportNo();
            ViewBag.GetAirlineDetails = getAirlineDetails();

            List<Country> lstCountry = _iTicketRepository.GetCountryData();

            var lstCountryres = (from country in lstCountry
                                 group country by new { country.COUNTRY_CODE, country.COUNTRY_NAME } into c
                                 select c).Select(c => new SelectListItem
                                 {
                                     Value = c.Key.COUNTRY_CODE,
                                     Text = c.Key.COUNTRY_NAME
                                 });

            ViewBag.GetCountry = lstCountryres;
        }
        private IEnumerable<SelectListItem> getPassportNo()
        {
            List<Passport_Details> passportDetailsList = _iTicketRepository.GetPassportDetails();

            IEnumerable<SelectListItem> passportList = passportDetailsList.Select(x => new SelectListItem
            {
                Value = x.USER_REQUIREMENT_ID.ToString(),
                Text = x.PASSPORT_NUMBER
            }).ToList();

            return passportList;
        }

        private IEnumerable<SelectListItem> getAirlineDetails()
        {
            List<Airline> airlineDetails = _iTicketRepository.GetAirlineDetails();

            IEnumerable<SelectListItem> airlinesList = airlineDetails.Select(x => new SelectListItem
            {
                Value = x.AirlinesId.ToString(),
                Text = x.AirlinesName
            }).ToList();

            return airlinesList;
        }

        [HttpPost]
        public JsonResult GetCandidateName(int userRequirementId)
        {
            string candidateName = string.Empty;
            if (userRequirementId > 0)
            {
                candidateName = _iTicketRepository.GetCandidateName(userRequirementId);
            }
            return Json(candidateName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetDestinationCityByCountryCode(string Country_code)
        {
            List<Country> cityNames = _iTicketRepository.GetDestinationCity(Country_code);

            IEnumerable<SelectListItem> cityList = cityNames.Select(x => new SelectListItem
            {
                Value = x.CITY_CODE.ToString(),
                Text = x.CITY_NAME
            });

            return Json(cityList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(int? id, string success = null)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;

            _fromDate = DateTime.Now.AddDays(-60);
            _toDate = DateTime.Now;

            ViewBag.Success = success;
            var result = _iTicketRepository.GetAllProcess(Convert.ToInt16(id), "TICKET", _fromDate, _toDate);
            return View(result);
        }


        [HttpPost]
        public ActionResult Index(string PassportNo, string FromDate, string ToDate)
        {
            try
            {
                DateTime? _fromDate = null;
                DateTime? _toDate = null;
                if (!string.IsNullOrEmpty(FromDate))
                {
                    _fromDate= DateTime.ParseExact(FromDate, @"d/M/yyyy",System.Globalization.CultureInfo.InvariantCulture);
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

                var result = _iTicketRepository.GetAllProcess(0, "TICKET", _fromDate, _toDate, PassportNo);
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Edit(int id)
        {
            GetMasterData();
            var result = _iTicketRepository.GetAllProcess(id, "TICKET");
            var ticket = result.Select(x => new Ticket
            {
                TicketID = x.TicketID,
                USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                AirlinesID = x.AirlinesID,
                AirlinesName = x.AirlinesName,
                IsDirect = x.IsDirect,
                PnrNumber = x.PnrNumber,
                TicketNumber = x.TicketNumber,
                FlightNumber = x.FlightNumber,
                IsBooked = x.IsBooked,
                IsCancelled = x.IsCancelled,
                DepartureCountryCode = x.DepartureCountryCode,
                DepartureCityCode = x.DepartureCityCode,
                DepartureDate = x.DepartureDate,
                DepartureTime = x.DepartureTime,
                DestinationCountryCode = x.DestinationCountryCode,
                DestinationCityCode = x.DestinationCityCode,
                ArivalDate = x.ArivalDate,
                ArrivalTime = x.ArrivalTime,
                ReportPath = x.ReportPath,
                Remark = x.Remark,

                ConnectTicketID = x.ConnectTicketID,
                Conn_PnrNumber = x.Conn_PnrNumber,
                Conn_TicketNumber = x.Conn_TicketNumber,
                Conn_FlightNumber = x.Conn_FlightNumber,
                Conn_IsBooked = x.Conn_IsBooked,
                Conn_IsCancelled = x.Conn_IsCancelled,
                Conn_DestinationCountryCode = x.Conn_DestinationCountryCode,
                Conn_DestinationCityCode = x.Conn_DestinationCityCode,
                Conn_ArivalDate = x.Conn_ArivalDate,
                Conn_ArrivalTime = x.Conn_ArrivalTime,
                Conn_DepartureDate = x.Conn_DepartureDate,
                Conn_DepartureTime = x.Conn_DepartureTime,
                Conn_DepartureCountryCode = x.Conn_DepartureCountryCode,
                Conn_DepartureCityCode = x.Conn_DepartureCityCode,

                TravelStatus = x.TravelStatus,
                DestinationCity = x.DestinationCity,
                DepartureCity = x.DepartureCity,
                CANDIDATE_NAME = x.CANDIDATE_NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                createdBy = x.createdBy,
                CreatedDate = x.CreatedDate
            }).SingleOrDefault();
            return View(ticket);
        }

        [HttpPost]
        public ActionResult Edit(Ticket ticket, HttpPostedFileBase ticketReport)
        {
            if (ModelState.IsValid)
            {
                if (ticketReport != null)
                {
                    ticket.ReportPath = UploadFile(ticketReport); //returns file name
                }
                _iTicketRepository.CreateUpdate(ticket, "UPDATE");
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                GetMasterData();
                return View("Edit", ticket);
            }
        }
    }
}