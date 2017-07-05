using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.DBModel;
using EntityFrameworkExtras.EF6;
using TIROERP.Infrastructure.Utilities;
using System.Web;
using System.Data.SqlClient;

namespace TIROERP.Infrastructure.Repository
{

    public class TicketRepository : ITicket
    {
        ArbabTravelsERPEntities _entities;
        CommonRepository common = new CommonRepository();
        
        public void CreateUpdate(Ticket ticket, string Condition_Operator)
        {
            _entities = new ArbabTravelsERPEntities();
            try
            {
                List<UDT_TICKET_DETAILS> udt_ticketObj_list = common.GetProcessTicket(ticket);

                var procedure = new proc_Insert_Ticket_Details()
                {
                    UDT_TICKET_DETAILS = udt_ticketObj_list,
                    CONDITION_OPERATOR = Condition_Operator
                };
                _entities.Database.ExecuteStoredProcedure(procedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Passport_Details> GetPassportDetails()
        {
            string status = "17";
            return common.GetPassportNumbers(status);
        }

        public List<Airline> GetAirlineDetails()
        {
            _entities = new ArbabTravelsERPEntities();
            List<Airline> airline_Details_List = new List<Airline>();
            try
            {
                airline_Details_List = _entities.TBL_AIRLINES_MASTER
                    .Where(x => x.IsActive.Value && x.AirlinesName != null)
                    .Select(x => new Airline
                    {
                        AirlinesId = x.AirlinesId,
                        AirlinesName = x.AirlinesName
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return airline_Details_List;

        }

        public List<Country> GetCountryData()
        {
            _entities = new ArbabTravelsERPEntities();
            List<Country> countryData = new List<Country>();

            try
            {
                countryData = _entities.GET_COUNTRY_STATE_CITY().Select(x => new Country
                {
                    COUNTRY_CODE = x.COUNTRY_CODE,
                    COUNTRY_NAME = x.COUNTRY_NAME,
                    CITY_CODE = x.CITY_CODE,
                    CITY_NAME = x.CITY_NAME
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return countryData;

        }

        public string GetCandidateName(int userRequirementId)
        {
            return common.GetCandidateName(userRequirementId);
        }

        public List<Country> GetDestinationCity(string country_code)
        {
            _entities = new ArbabTravelsERPEntities();
            List<Country> countryCityList = new List<Country>();
            try
            {
                countryCityList = _entities.GET_COUNTRY_STATE_CITY().Where(x => x.COUNTRY_CODE.Trim().ToLower() == country_code.Trim().ToLower()).Select(x => new Country
                {
                    CITY_CODE = x.CITY_CODE,
                    CITY_NAME = x.CITY_NAME
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return countryCityList;
        }

        public List<Ticket> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null)
        {
            var ID = new SqlParameter { ParameterName = "ID", Value = id };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var CONDITION_OPERATOR = new SqlParameter { ParameterName = "CONDITION_OPERATOR", Value = condition_operator };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var PASSPORT_NUMBER = new SqlParameter { ParameterName = "PASSPORT_NUMBER", Value = passportNo };

            var result = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_GET_ALL_PROCESS]")
                .With<Ticket>()
                .Execute(ID, CREATED_BY, CONDITION_OPERATOR, FROMDATE, TODATE, PASSPORT_NUMBER);

            var lstticket = ((List<Ticket>)result[0])
                .Select(x => new Ticket
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
                    CreatedDate = x.CreatedDate,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER

                }).ToList();
            return lstticket;
        }
    }
}
