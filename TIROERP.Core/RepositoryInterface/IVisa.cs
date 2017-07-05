using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IVisa
    {
        void Create(Visa visa);
        List<Visa> GetAllVisa(int visaId, DateTime? fromDate = null, DateTime? toDate = null, string visaNo = null, string conditionOperator = null);
        void Edit(Visa designation);
        void Delete(Visa designation);
        List<GetClient> GetClient();
        string GetCivilianNo(string registration_no);
    }
}
