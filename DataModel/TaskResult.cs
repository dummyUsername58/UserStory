using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public enum StatusState
    {
        UnknownStat,
        DoneState,
        CancelState,
    }
    public class TaskResult
    {
        public StatusState state { get; set; }
        public string StatusMessage { get; set; }
        public short StatusCode { get; set; }
    }
    public class TaskResult<T>:TaskResult
    {  
        public T Data { get; set; }
    }
}
