using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerGamer.Data.Models;
using PerGamer.Service.Interface;

namespace PerGamer.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly IExchangeDatastore exchangeDatastore;
        public ExchangeController(IExchangeDatastore exchangeDatastore)
        {
            this.exchangeDatastore = exchangeDatastore;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ObjectDetail getObjectDetail(string name)
        {
            var objectDetails = exchangeDatastore.getObjectDetailByObjectName(new ObjectDetail
            {
                ObjectName = name
            }).FirstOrDefault();

            if (objectDetails == null)
            {
                objectDetails = new ObjectDetail();
            }
            return objectDetails;
        }
    }
}