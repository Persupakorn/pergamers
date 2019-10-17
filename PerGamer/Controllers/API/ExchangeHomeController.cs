using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public void insertDataToFireBase(string name,string value)
        {
           exchangeDatastore.insertDataFirebase(name, value);
        }
    }
}