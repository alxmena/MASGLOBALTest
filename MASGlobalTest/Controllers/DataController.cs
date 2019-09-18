using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MASGlobalTest.Models;
using System.IO;

namespace MASGlobalTest.Controllers
{
    public class DataController : ApiController
    {

        /*public JArray GetData()
        {
            JArray Employees;
            List<Employee> lst;
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
        */
        // GET api/data
        public JArray Get()
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
                if(Contract.ToString()== "HourlySalaryEmployee")
                    item.Add(new JProperty("AnnualSalary", 120*HourlySalary*12));
                if (Contract == "MonthlySalaryEmployee")
                    item.Add(new JProperty("AnnualSalary", 12*MonthlySalary));                
            }    
            return Employees;           
        }

        // GET api/values/5
        public JArray Get(int id)
        {
            JArray Employees;
            List<Employee> lst;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://masglobaltestapi.azurewebsites.net/api/Employees");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                Employees = JArray.Parse(json);
            }            
            lst = Employees.ToObject<List<Employee>>();
            var EmployeeLst = Employees.Where(n => n["id"].Value<int>() == id);
            return new JArray(EmployeeLst);

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
