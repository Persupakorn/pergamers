using System;
using System.Collections.Generic;
using System.Text;

namespace PerGamer.Data.Models
{
    public class ReturnData
    {
        public bool IsSuccess { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }
}
