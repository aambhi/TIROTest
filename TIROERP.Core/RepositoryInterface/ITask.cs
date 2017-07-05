using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface ITask
    {
        void Create(TaskMaster task);
        void Update(TaskMaster task);
        List<IEnumerable> GetEmployee(string conditional_operator);
        List<IEnumerable> GetAllTask(string condition_operator, int? taskId = 0);
    }
}
