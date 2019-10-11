using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerGamer.Data.Models;
using PerGamer.Service.Interface;

namespace PerGamer.Controllers.API
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDatastore customerDatastore;
        public CustomerController(ICustomerDatastore customerDatastore)
        {
            this.customerDatastore = customerDatastore;
        }

        [Route("api/customer/getdata")]
        [HttpGet]
        public List<CustomerResult> GetData(string location)
        {
            return customerDatastore.Get(location);
        }
        [Route("api/customer/insertData")]
        [HttpPost]
        public ReturnData InsertData(CustomerInput input)
        {
            //var result = new ReturnData();
            customerDatastore.InsertData(input);
            return new ReturnData
            {
                IsSuccess = true,
                ReturnCode = 200,
                ReturnMessage = "Success"
            };
        }
        //public CustomerResult searchCustomer(CustomerInput input)

        //    => customerDatastore.SearchCustomer(input);
    }
}