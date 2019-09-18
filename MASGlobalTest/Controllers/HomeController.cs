using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MASGlobalTest.Controllers
{
    public class HomeController : Controller
    {
        /*public ActionResult Index() 
        { 
            return View(); 
        }*/
        public String Index()
        {
            JArray Employees;
            //Employee Employee;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://masglobaltestapi.azurewebsites.net/api/Employees");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();      
                Employees = JArray.Parse(json);
            }
            return "El Nombre es: " + Employees[0]["name"]+"<br> El Nombre es: "+ Employees[1]["name"];            
        }

    }
    /*
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public string Index()
        {
            return "This is my <b>default</b> action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }*/
}
