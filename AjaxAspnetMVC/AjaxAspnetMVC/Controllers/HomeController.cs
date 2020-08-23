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
                ID = 3,
                FullName = "Hoàng Chang",
               Salary = 12000,
               Status = true
            },
            new Employee()
            {
                ID = 4,
                FullName = "Thu Uyên",
               Salary = 4000,
               Status = true
            },
            new Employee()
            {
                ID = 5,
                FullName = "Văn Lọk",
               Salary = 1900,
               Status = false
            },
            new Employee()
            {
                ID = 6,
                FullName = "Kiều Kiên",
               Salary = 400,
               Status = true
            }
        };
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetData(int page, int pageSize =3)
        {
            var model = listEmployeee.Skip((page - 1) * pageSize).Take(pageSize);
            int totalaRecord = listEmployeee.Count();
            return Json(new { 
            data = model,
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