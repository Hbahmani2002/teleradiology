using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Util.Excel
{
    public class Reflection
    {
        public static List<string> PropertyAttributeList(Type tip, Type attribute)
        {
            var t = tip;
            var pi = t.GetProperties();
            return pi.Where(o => Attribute.IsDefined(o, attribute))
                .Select(o => o.Name)
                .ToList();
        }

        public static T GetPropertyAttribute<T>(PropertyInfo prop)
        {
            var item = prop.GetCustomAttributes(true)
            .SingleOrDefault(o => o.GetType() == typeof(T));
            if (item == null)
                return default(T);
            return (T)item;


        }
    }
}
