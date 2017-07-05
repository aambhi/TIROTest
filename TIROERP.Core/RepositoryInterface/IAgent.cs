using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IAgent
    {
        string Create(Agent agent);
        List<IEnumerable> GetMasterData();
        List<IndustryDesignation> GetDesignationByIndustry(int[] industry);
    }
}
