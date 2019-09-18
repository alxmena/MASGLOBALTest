using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MASGlobalTest.Models;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MASGlobalTest.Controllers
{
    public class EmployeesController : Controller
    {
        private JArray GetData()
        {
            JArray Employees;            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://masglobaltestapi.azurewebsites.net/api/Employees");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                Employees = JArray.Parse(json);
            }
            foreach (JObject item in Employees)
            {
                string Contract = item.GetValue("contractTypeName").ToString();
                double HourlySalary = Convert.ToDouble(item.GetValue("hourlySalary"));
                double MonthlySalary = Convert.ToDouble(item.GetValue("monthlySalary"));
                if (Contract.ToString() == "HourlySalaryEmployee")
                    item.Add(new JProperty("AnnualSalary", 120 * HourlySalary * 12));
                if (Contract == "MonthlySalaryEmployee")
                    item.Add(new JProperty("AnnualSalary", 12 * MonthlySalary));
            }
            return Employees;
        }

        // GET: Employees
        public ActionResult Index()
        {            
            List<Employee> lst;
            JArray Employees = GetData();
            lst = Employees.ToObject<List<Employee>>();
            return View(lst);
        }
        public ActionResult GetEmployees(string searchString)
        {
            List<Employee> lst;
            JArray Employees = GetData();
            lst = Employees.ToObject<List<Employee>>();            
            var result = from i in lst
                         where i.Id == Convert.ToInt32(searchString)
                         select i;
            if (searchString != "")
            {
               return View(result.ToList());

            }
            else
            return View(lst);
             
        }
        // GET: Employees
        public ActionResult API()
        {
            return View();

        }
    }
}