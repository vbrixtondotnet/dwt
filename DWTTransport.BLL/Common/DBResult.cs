using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWTTransport.BLL.Common
{
    public class DBResult
    {
        public ReturnCode ReturnCode { get; set; }
        public string Message {get;set;} 
        public object Data { get; set; }
    }

    public enum ReturnCode
    {
        Failed = 0,
        Success = 1
    }
}
