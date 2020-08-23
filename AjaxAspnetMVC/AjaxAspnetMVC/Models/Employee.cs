using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxAspnetMVC.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Salary { get; set; }
        public bool Status { get; set; }
    }
}