using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface ICertification
    {
        void Create(Certification certification);
        List<Certification> GetAllCertification();
        Certification GetDetailById(int certificationId);
        void Edit(Certification certification);
        void Delete(Certification certification);
        bool CheckDuplicate(string certification, int? id);
    }
}
