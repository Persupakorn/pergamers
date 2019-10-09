using PerGamer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerGamer.Service.Interface
{
    public interface ICustomerDatastore
    {
        List<CustomerResult> Get(string location);
        void InsertData(CustomerInput input);
    }
}
