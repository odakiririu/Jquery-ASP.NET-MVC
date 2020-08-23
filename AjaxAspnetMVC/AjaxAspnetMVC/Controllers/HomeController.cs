using AjaxAspnetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AjaxAspnetMVC.Controllers
{
    public class HomeController : Controller
    {
        List<Employee> listEmployeee = new List<Employee>()
        {
            new Employee()
            {
                ID = 1,
                FullName = "Nguyễn Anh Đức",
               Salary = 1000,
               Status = true
            },
            new Employee()
            {
                ID = 2,
                FullName = "Đỗ Minh Phượng",
               Salary = 2000,
               Status = true
            },
            new Employee()
            {
                ID = 2,
                FullName = "Hoàng Chang",
               Salary = 12000,
               Status = true
            }
        };
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetData()
        {        
            return Json(new { 
            data = listEmployeee,
            status =true
            },JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
       public JsonResult UpdateSalary(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(model);            
            var entity = listEmployeee.Single(x => x.ID == employee.ID);
            entity.Salary = employee.Salary;
            return Json(new
            {
                status = true
            });
        }
    }
}