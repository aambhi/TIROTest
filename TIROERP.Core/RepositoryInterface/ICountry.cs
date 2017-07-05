using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.Interface
{
    public interface ICountry
    {
        void Create(Country country);
        List<Country> GetAllCountry();
        Country GetDetailById(int country_Code);
        void Edit(Country countrydetails);
        void Delete(Country countrydetails);
        bool CheckDuplicate(string country_name, int? id);
    }
}
