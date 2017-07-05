using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IAirline
    {
        void Create(Airline airline);
        List<Airline> GetAllAirline();
        Airline GetDetailById(int airlineId);
        void Edit(Airline airline);
        void Delete(Airline airline);
        bool CheckDuplicate(string airline, int? id);
    }
}
