using AjaxAspnetMVC.Models;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Employee = Data.Models.Employee;

namespace AjaxAspnetMVC.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext _context;
        public HomeController()
        {
            _context = new EmployeeDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetData(int page, int pageSize =4)
        {
            var model = _context.Employees.OrderByDescending(x=>x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
            int totalaRecord = _context.Employees.Count();
            return Json(new {
                data = model,
                total = totalaRecord,
                status = true
            }, JsonRequestBehavior.AllowGet); ;
        }

       [HttpPost]
       public JsonResult UpdateSalary(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(model);            
            var entity = _context.Employees.Find(employee.ID);
            var result = entity.Salary = employee.Salary;
            _context.SaveChanges();
            return Json(new
            {
                status = true
            });
        }
    }
}