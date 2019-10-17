using Dapper;
using Newtonsoft.Json;
using PerGamer.Data.Models;
using PerGamer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
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
                select * from ObjectDetail 
                where @ObjectName is null or ObjectName = @ObjectName", 
                new { ObjectName = input.ObjectName }).ToList();
            }
            return objectDetail;
        }
        public void insertDataFirebase(string name ,string value)
        {
            var jsoninput = JsonConvert.SerializeObject(new
            {
                Name = name,
                Value = value
            });
            //per.supakorn@gmail.com
            var request = WebRequest.CreateHttp("https://pergamer-b6b14.firebaseio.com/.json");
            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(jsoninput);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            jsoninput = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        }
    }
}
