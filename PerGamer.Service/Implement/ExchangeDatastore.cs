using Dapper;
using PerGamer.Data.Models;
using PerGamer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PerGamer.Service.Implement
{
    public class ExchangeDatastore : IExchangeDatastore
    {
        private readonly string connectionString;
        public ExchangeDatastore(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<ObjectDetail> getObjectDetailByObjectName(ObjectDetail input)
        {
            var objectDetail = new List<ObjectDetail>();
            using (var connection = new SqlConnection(connectionString))
            {
                objectDetail = connection.Query<ObjectDetail>(@"
                select * from ObjectDetail where @ObjectName IS NULL OR ObjectName = @ObjectName", new { ObjectName = input.ObjectName }).ToList();
            }
            return objectDetail;
        }
    }
}
