using PerGamer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerGamer.Service.Interface
{
    public interface IExchangeDatastore
    {
        List<ObjectDetail> getObjectDetailByObjectName(ObjectDetail input);
    }
}
