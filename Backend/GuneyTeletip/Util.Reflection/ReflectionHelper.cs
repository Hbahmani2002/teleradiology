using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TIF.DTO.Types.Reflection
{
    public static class ReflectionHelper
    {
        private static Expression<Func<T, bool>> FuncToExpression<T>(Func<T, bool> f)
        {
            return x => f(x);
        }
        public static string ToString(object item)
        {
            var _PropertyInfos = item.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(item, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
        //public static List<MethodInfo> GetMethodListInAssemblyFile(string file)
        //{
        //    var assem = Assembly.LoadFrom(file);
        //    var methods = assem.GetTypes();
        //    var endpointMethods = methods.SelectMany(o => o.GetMethods()).Where(o => ReflectionHelper.ExistsAttribute(o.GetCustomAttributes(true), typeof(ServiceEndPointAttribute))).ToList();
        //    return endpointMethods;
        //}
        public static bool ExistsAttribute(object[] attrs, Type attribute)
        {
            var res = attrs.Any(o => o.GetType() == attribute);
            return res;
        }

        public static List<string> PropertyAttributeList(Type tip,Type attribute)
        {
            var t = tip;
            var pi = t.GetProperties();
            return pi.Where(o => Attribute.IsDefined(o, attribute))
                .Select(o => o.Name)
                .ToList();            
        }
        public static object InvokeWithNamedParameters(MethodBase self, object obj, IDictionary<string, object> namedParameters)
        {
            return self.Invoke(obj, MapParameters(self, namedParameters));
        }

        public static object[] MapParameters(MethodBase method, IDictionary<string, object> namedParameters)
        {
            string[] paramNames = method.GetParameters().Select(p => p.Name).ToArray();
            object[] parameters = new object[paramNames.Length];
            for (int i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = Type.Missing;
            }
            foreach (var item in namedParameters)
            {
                var paramName = item.Key;
                var paramIndex = Array.IndexOf(paramNames, paramName);
                parameters[paramIndex] = item.Value;
            }
            return parameters;
        }
        public static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                new Type[] {
            typeof(Enum),
            typeof(String),
            typeof(Decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }

    }
}
