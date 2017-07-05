using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IAdvertisement
    {
        void Create(Advertisement advertisement);
        List<Advertisement> GetAllAdvertisements(int adv_Id);
        void Edit(Advertisement advertisement);
        void Delete(Advertisement advertisement);
        List<Advertisement_Requirements> GetAllRequirements();

    }
}
