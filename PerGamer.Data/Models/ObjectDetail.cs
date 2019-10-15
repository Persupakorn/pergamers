using System;
using System.Collections.Generic;
using System.Text;

namespace PerGamer.Data.Models
{
    public class ObjectDetail
    {
        public Guid? ObjectId { get; set; }
        public string ObjectName { get; set; }
        public decimal ObjectPrice { get; set; }
        public string ObjectStatus { get; set; }
    }
}
