using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.Interface
{
    public interface ISpecialization
    {
        void Create(Specialization specialization);
        List<Specialization> GetAllSpecialization();
        List<EducationType> GetAllEducationList();
        void Edit(Specialization specialization);
        void Delete(Specialization specialization);
        bool CheckDuplicate(string specialization_type, int education_type_id, int? id);
        Specialization GetSpecializationById(int specialization_type_id);
    }
}
