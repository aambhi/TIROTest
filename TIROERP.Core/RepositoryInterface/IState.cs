using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IState
    {
        void Create(State state);
        List<Country> GetAllCountry();
        State GetDetailById(int? stateId);
        void Edit(State stateDetails);
        void Delete(State stateDetails);
        bool CheckDuplicate(string state_name, int? id);
        List<State> GetAllState();
    }
}
