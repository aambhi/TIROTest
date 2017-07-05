using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface ICompany
    {
        void Create(CompanyMaster company);
        List<CompanyMaster> GetAllCompanies();
        CompanyMaster GetDetailById(int companyId);
        void Edit(CompanyMaster company);
        void Delete(CompanyMaster company);
        bool CheckDuplicate(string company_name, int? id);
    }
}
