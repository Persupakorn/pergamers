using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using PerGamer.Data.Models;
using PerGamer.Service.Interface;

namespace PerGamer.Controllers.API
{
    [ApiController]
    public class ExchangeHomeController : ControllerBase
    {
        private readonly IExchangeDatastore exchangeDatastore;
        public ExchangeHomeController(IExchangeDatastore exchangeDatastore)
        {
            this.exchangeDatastore = exchangeDatastore;
        }

        [Route("api/exchangehome/getobjectdetail")]
        [HttpGet]
        public ObjectDetail getObjectDetail(string name)
        {
            var objectDetails = exchangeDatastore.getObjectDetailByObjectName(new ObjectDetail
            {
                ObjectName = name
            }).FirstOrDefault();

            if (objectDetails == null)
            {
                objectDetails = new ObjectDetail();
                return objectDetails;
            }
            else
            {
                return objectDetails;
            }
        }
        [Route("api/exchangehome/insertdatatofirebase")]
        [HttpGet]
        public void insertDataToFireBase(string name, string value)
        {
            exchangeDatastore.insertDataFirebase(name, value);
        }

        [Route("api/exchangehome/testNlog")]
        [HttpGet]
        public string testNlog()
        {
            throw new Exception();
        }

        [Route("api/exchangehome/test")]
        [HttpGet]
        public string test()
        {
            var t4 = string.Empty;
            var a4 = "";
            string tt = null;
            var w4 = " ";
            var test = (string.IsNullOrWhiteSpace(tt)) ? "a" : w4;
            return test;

        }
    }
}