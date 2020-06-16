using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Models
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            ExtraData = new Dictionary<string, object>();

        }
        public ServiceResult(T data, string message, ServiceResultType type) : this()
        {
            TypeVal = type;
            Message = message;
            Data = data;
        }
        public string Type => TypeVal.ToString();   
        public ServiceResultType TypeVal { get; set; }

        public string Message { get; set; }
        public Exception Exception { get; set; }

        public T Data { get; set; }

        public Dictionary<string, object> ExtraData { get; private set; }

        public bool HasError => ((int)TypeVal) < 10;
    }
    public enum ServiceResultType
    {
        FAIL = 0,
        NOT_AUTHENTICATED,
        NOT_AUTHORIZED,
        NOT_VALID,

        SUCCESS = 10,
        SUCCESS_WITH_DATA,

    }
}
