using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IInterview
    {
        void Create(Interview interview);
        List<Advertisement_Requirements> GetAllRequirements();
        List<Interview_Mode_Master> GetModeOfInterview();
    }
}
