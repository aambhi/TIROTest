using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class TaskMaster
    {
        public int TASK_ID { get; set; }
        public string TASK_NAME { get; set; }
        public string TASK_ASSIGNED_TO { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public Decimal? PERC_COMPLETED { get; set; }
        public string MODIFIED_BY { get; set; }
        public string TASK_COMMENT { get; set; }
        public TaskFollowup TaskFollowUp { get; set; }
    }

    public class TaskFollowup
    {
        public int TASK_FOLLOWUP_ID { get; set; }
        public int TASK_ID { get; set; }
        public string TASK_COMMENT { get; set; }
        public decimal? PERC_COMPLETED { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
    }

    public class EmployeeList
    {
        public string EMPLOYEE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
    }
}
