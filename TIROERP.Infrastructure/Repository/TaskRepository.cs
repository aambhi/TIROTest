using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class TaskRepository : ITask
    {
        ArbabTravelsERPEntities _entities;
        
        public void Create(TaskMaster task)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_TASK_MASTER tbltask = new TBL_TASK_MASTER();
            tbltask.TASK_NAME = task.TASK_NAME;
            tbltask.TASK_ASSIGNED_TO = task.TASK_ASSIGNED_TO;
            tbltask.PERC_COMPLETED = 0;
            tbltask.TASK_COMMENT = task.TASK_COMMENT;
            tbltask.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tbltask.CREATED_DATE = DateTime.Now;
            _entities.TBL_TASK_MASTER.Add(tbltask);
            _entities.SaveChanges();

            TBL_TASK_FOLLOWUP objFollowup = new TBL_TASK_FOLLOWUP();
            objFollowup.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            objFollowup.CREATED_DATE = DateTime.Now;
            objFollowup.PERC_COMPLETED = 0;
            objFollowup.TASK_COMMENT = task.TASK_COMMENT;
            objFollowup.TASK_ID = tbltask.TASK_ID;
            _entities.TBL_TASK_FOLLOWUP.Add(objFollowup);
            _entities.SaveChanges();

            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = "OPENTASK" };
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };

            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_TASK_MASTER]")
                .With<int>()
                .Execute(CONDITIONAL_OPERATOR, REGISTRATION_NO);

            var taskcount = (List<int>)results[0];
            var logindetails = ((UserLoginResult)HttpContext.Current.Session["UserDetails"]);
            logindetails.OPEN_TASK = taskcount[0];
        }

        public void Update(TaskMaster task)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_TASK_MASTER tbltask = new TBL_TASK_MASTER();
            tbltask.TASK_ID = task.TASK_ID;
            tbltask.TASK_NAME = task.TASK_NAME;
            tbltask.TASK_ASSIGNED_TO = task.TASK_ASSIGNED_TO;
            tbltask.PERC_COMPLETED = task.PERC_COMPLETED;
            tbltask.TASK_COMMENT = task.TASK_COMMENT;
            tbltask.CREATED_BY = task.CREATED_BY;
            tbltask.CREATED_DATE = task.CREATED_DATE;
            tbltask.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tbltask.MODIFIED_DATE = DateTime.Now;
            _entities.Entry(tbltask).State = System.Data.Entity.EntityState.Modified;
            _entities.SaveChanges();

            TBL_TASK_FOLLOWUP objFollowup = new TBL_TASK_FOLLOWUP();
            objFollowup.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            objFollowup.CREATED_DATE = DateTime.Now;
            objFollowup.PERC_COMPLETED = task.PERC_COMPLETED;
            objFollowup.TASK_COMMENT = task.TASK_COMMENT;
            objFollowup.TASK_ID = tbltask.TASK_ID;
            _entities.TBL_TASK_FOLLOWUP.Add(objFollowup);
            _entities.SaveChanges();

            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = "OPENTASK" };
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };

            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_TASK_MASTER]")
                .With<int>()
                .Execute(CONDITIONAL_OPERATOR, REGISTRATION_NO);

            var taskcount = (List<int>)results[0];
            var logindetails = ((UserLoginResult)HttpContext.Current.Session["UserDetails"]);
            logindetails.OPEN_TASK = taskcount[0];

        }

        public List<IEnumerable> GetEmployee(string condition_operator)
        {
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = condition_operator };

            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_TASK_MASTER]")
                .With<EmployeeList>()
                .Execute(CONDITIONAL_OPERATOR);

            return results;
        }

        public List<IEnumerable> GetAllTask(string condition_operator, int? taskId = 0)
        {
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = condition_operator };
            var REGISTRATION_NO = new SqlParameter { ParameterName = "REGISTRATION_NO", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var TASK_ID = new SqlParameter { ParameterName = "TASK_ID", Value = taskId };

            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_TASK_MASTER]")
                .With<TaskMaster>()
                .With<TaskFollowup>()
                .Execute(CONDITIONAL_OPERATOR, REGISTRATION_NO, TASK_ID);

            return results;
        }

    }
}
