using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IIndustry
    {
        void Create(Industry industry);
        List<Industry> GetAllIndustry();
        Industry GetDetailById(int industryId);
        void Edit(Industry industry);
        void Delete(Industry industry);
        bool CheckDuplicate(string industry, int? id);
    }
}
