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
        [InlineData("01", "01", "Success")]
        [InlineData("01", "02", "Success")]
        [InlineData("01", "03", "Success")]
        [InlineData("01", "04", "Success")]
        [InlineData("01", "05", "Success")]
        [InlineData("02", "06", "Success")]
        [InlineData("02", "07", "Success")]
        [InlineData("", "", "Error")]
        [InlineData("", "01", "Error")]
        [InlineData("", "02", "Error")]
        [InlineData("", "03", "Error")]
        [InlineData("", "04", "Error")]
        [InlineData("", "05", "Error")]
        [InlineData("", "06", "Error")]
        [InlineData("", "07", "Error")]
        [InlineData("01", "", "Error")]
        [InlineData(null, "", "Error")]
        [InlineData(null, "01", "Error")]
        [InlineData(null, "02", "Error")]
        [InlineData(null, "03", "Error")]
        [InlineData(null, "04", "Error")]
        [InlineData(null, "05", "Error")]
        [InlineData(null, "06", "Error")]
        [InlineData(null, "07", "Error")]
        [InlineData("01", null, "Error")]
        [InlineData("02", null, "Error")]
        [InlineData(null, null, "Error")]
        [InlineData("12341234", null, "Error")]
        [InlineData("12341234", "12341324", "Error")]
        public void SelectService(string serviceid, string objectId, string message)
        {
            var input = new ServiceInput()
            {
                ServiceId = serviceid,
                ObjectId = objectId
            };
            var result = data.tableSelectService(input);
            Assert.Equal(result, message);
        }

    }
}
