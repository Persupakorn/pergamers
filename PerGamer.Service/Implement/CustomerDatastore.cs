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
    public class CustomerDatastore : ICustomerDatastore
    {
        private readonly string connectionString;
        public CustomerDatastore(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<CustomerResult> Get(string location)
        {
            var customers = new List<CustomerResult>();
            using (var connection = new SqlConnection(connectionString))
            {
                customers = connection.Query<CustomerResult>(@"
                SELECT CustomerID,CustomerName,CustomerLastName,Location 
                FROM Customer (nolock) WHERE @location IS NULL OR Location = @location", new { location = location }).ToList();
            }
            return customers;
        }
        public void InsertData(CustomerInput input)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"INSERT INTO Customer(CustomerID,CustomerName,CustomerLastName,Location)
                VALUES(@CustomerID,@CustomerName,@CustomerLastName,@Location)";
                try
                {
                    connection.Execute(query, input);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public CustomerResult SearchCustomer(CustomerInput input)
        {
            var customers = new CustomerResult();
            using (var connection = new SqlConnection(connectionString))
            {
                customers = connection.QueryFirstOrDefault<CustomerResult>(@"
                SELECT CustomerID,CustomerName,CustomerLastName,Location 
                FROM Customer (nolock) WHERE  CustomerID = @CustomerID", new { CustomerID = input.CustomerID });
            }
            return customers;
        }
    }
}
