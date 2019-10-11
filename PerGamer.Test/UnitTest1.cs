using PerGamer.Controllers;
using PerGamer.Data.Models;
using System;
using Xunit;

namespace PerGamer.Test
{
    public class UnitTest1
    {
        HomeController data = new HomeController();
        
        [Theory(DisplayName = "service 01 เลือกได้แค่ 01 หรือ 02")]
        [InlineData("01",true)]
        [InlineData("02", true)]
        public void Service(string serviceid,bool issuccess)
        {
            var input = new ServiceInput()
            {
                ServiceId = serviceid
            };
            var test = data.tableSelectService(input);
        }
    }
}
