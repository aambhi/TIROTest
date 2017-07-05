using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.Interface
{
    public interface IEducation
    {
        void Create(EducationType education);
        List<EducationType> GetAllEducationList();
        void Edit(EducationType education);
        void Delete(EducationType edu);
        bool CheckDuplicate(string education_type, int? id);

        EducationType GetEducationById(int education_type_id);
    }
}
