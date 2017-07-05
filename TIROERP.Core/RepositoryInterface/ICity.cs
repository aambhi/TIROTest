using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface ICity
    {
        void Create(City city);
        List<State> GetAllStates();
        City GetDetailById(int? cityId);
        void Edit(City cityDetails);
        void Delete(City cityDetails);
        bool CheckDuplicate(string city_name, int? id);
        List<City> GetAllCities();
    }
}
