using Rollbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollbarDotnetExample.Controllers
{
    public class CreateErrorController : Controller
    {
        // GET: CreateError
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateError()
        {
            //RollbarLocator.RollbarInstance.Info("ConsoleApp sample: Basic info log example.");
            string value = null;
            try
            {
               
            
            if (value.Length == 0) // <-- Causes exception
            {
                Console.WriteLine(value); // <-- Never reached
            }
            }catch (Exception e)
            {
                RollbarLocator.RollbarInstance.Error(e);
            }

            //throw new Exception("This is test exception");
            return null;
        }

        [HttpPost]
        public ActionResult GenerateUncoughtError()
        {
            //RollbarLocator.RollbarInstance.Info("ConsoleApp sample: Basic info log example.");
            string value = null;
            

                if (value.Length == 0) // <-- Causes exception
                {
                    Console.WriteLine(value); // <-- Never reached
                }
            return null;
        }

    }
}