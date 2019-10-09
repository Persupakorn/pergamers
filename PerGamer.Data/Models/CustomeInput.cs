using System;
using System.Collections.Generic;
using System.Text;

namespace PerGamer.Data.Models
{
    public class CustomerInput
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string Location { get; set; }
    }
}
