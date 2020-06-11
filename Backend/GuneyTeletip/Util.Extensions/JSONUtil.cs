using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Extensions
{
    public class JSONUtil
    {
        public static string Convert2JSON(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static T ConvertJSON2Object<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
