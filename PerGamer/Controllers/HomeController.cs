using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerGamer.Data.Models;
using PerGamer.Models;

namespace PerGamer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string tableSelectService(ServiceInput input)
        {
            string[] setServiceId = { "01", "02" };
            string[] setObjectiveIdService01 = { "01", "02", "03", "04", "05" };
            string[] setObjectiveIdService02 = { "06", "07" };
            string[] setMethodIdObjective = { "01", "02" };
            string[] setMethodIdObjectiveMethod01 = { "02" };
            string[] setMethodIdObjectiveMethod02 = { "01", "02" };
            if (string.IsNullOrEmpty(input.ServiceId))
            {
                return "Error";
            }
            else if (setServiceId.Any(input.ServiceId.Contains))
            {
                if (input.ServiceId == "01")
                {
                    if (string.IsNullOrEmpty(input.ObjectId))
                    {
                        return "Error";
                    }
                    else if (setObjectiveIdService01.Any(input.ObjectId.Contains))
                    {
                        if (input.ObjectId == "01")
                        {
                            return "Success";
                        }
                        else if (input.ObjectId == "02")
                        {
                            return "Success";
                        }
                        return "Success";
                    }
                    return "Error";
                }
                else if (input.ServiceId == "02")
                {
                    if (string.IsNullOrEmpty(input.ObjectId))
                    {
                        return "Error";
                    }
                    else if (setObjectiveIdService02.Any(input.ObjectId.Contains))
                    {
                        return "Success";
                    }
                    return "Error";
                }
                return "Error";
            }
            else
            {
                return "Error";
            }

        }
    }
}
