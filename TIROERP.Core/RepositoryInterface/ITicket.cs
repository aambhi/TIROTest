using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface ITicket
    {
        void CreateUpdate(Ticket ticket, string Condition_Operator);
        List<Passport_Details> GetPassportDetails();
        List<Airline> GetAirlineDetails();
        List<Country> GetCountryData();
        string GetCandidateName(int userRequirementId);
        List<Country> GetDestinationCity(string country_code);
        List<Ticket> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null);
    }
}
