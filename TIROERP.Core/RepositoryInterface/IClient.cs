using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IClient
    {
        string Create(Client client);
        List<IEnumerable> GetMasterData();
        List<IndustryDesignation> GetDesignationByIndustry(int[] industry);
    }
}
