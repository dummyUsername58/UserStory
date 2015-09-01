using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public class DataRequest
    {
        public int StartPosition { get; set; }
        public int Count { get; set; }
    }
    public class RequestWrapper
    {
        public DataRequest request{get;set;}
        public int Id{get;set;}
    }
}
