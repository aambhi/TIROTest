using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IEmigration
    {
        void Create(Emigration emigrationObj);
        List<Passport_Details> GetPassportNumbers();
        string GetCandidateName(int userRequirementId);
        void Update(Emigration emigrationObj);
        List<Emigration> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null);
    }
}
