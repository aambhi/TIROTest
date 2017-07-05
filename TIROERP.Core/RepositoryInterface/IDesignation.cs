using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IDesignation
    {
        void Create(Designation designation);
        List<Designation> GetAllDesignation();
        Designation GetDetailById(int designationId);
        void Edit(Designation designation);
        void Delete(Designation designation);
        bool CheckDuplicate(string designation, int industryId, int? id);
        List<Industry> GetAllIndustry();
        List<Designation> GetDesignationByIndustry(int[] industryIds);
    }
}
