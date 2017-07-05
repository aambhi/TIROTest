using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{
    
    [Authenticate]
    [ErrorFilter]
    public class TaskController : Controller
    {
        private readonly ITask _iTask;

        public TaskController(ITask iTask)
        {
            _iTask = iTask;
        }

        // GET: Task
        public ActionResult Index(string success = null)
        {
            ViewBag.Success = success;
            var result = _iTask.GetAllTask("SELECT_ALLTASK");
            var alltask = (List<TaskMaster>)result[0];
            return View(alltask);
        }

        public ActionResult Create()
        {
            GetEmployee();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskMaster task)
        {
            if (ModelState.IsValid)
            {
                _iTask.Create(task);
                return RedirectToAction("Index", new { success = "Record Created Successfully!!!" });
            }
            else
            {
                GetEmployee();
                return View(task);
            }
        }

        public ActionResult Edit(int taskId)
        {
            GetEmployee();
            var result = _iTask.GetAllTask("GET_TASK_BY_ID", taskId);
            var alltask = (List<TaskMaster>)result[0];
            ViewBag.TaskFollowUp = (List<TaskFollowup>)result[1];

            var task = alltask.Select(x => new TaskMaster
            {
                TASK_ID = x.TASK_ID,
                TASK_NAME=x.TASK_NAME,
                TASK_ASSIGNED_TO=x.TASK_ASSIGNED_TO,
                TASK_COMMENT = x.TASK_COMMENT,
                PERC_COMPLETED = x.PERC_COMPLETED,
                CREATED_BY = x.CREATED_BY,
                CREATED_DATE = x.CREATED_DATE,
            }).SingleOrDefault();

            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(TaskMaster task)
        {
            if (ModelState.IsValid)
            {
                _iTask.Update(task);
                return RedirectToAction("Index", new { success = "Record Updated Successfully!!!" });
            }
            else
            {
                GetEmployee();
                return View(task);
            }
        }

        private void GetEmployee()
        {
            var result = _iTask.GetEmployee("SELECT_EMPLOYEE");
            var emplist = (List<EmployeeList>)result[0];
            var lstEmployee = from emp in emplist.AsEnumerable()
                              select new
                              {
                                  Value = Convert.ToString(emp.REGISTRATION_NO),
                                  Text = emp.EMPLOYEE_NAME,
                              };

            ViewData["EmployeeList"] = new SelectList(lstEmployee, "Value", "Text");
        }
    }
}