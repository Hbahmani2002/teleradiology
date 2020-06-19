using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Util.Extensions
{
    public class RandomDataGenerator
    {
        public static IEnumerable<T> CreateRandom<T>(int count)
        {

            return Enumerable.Range(0, count).Select(o => GetRandomItem<T>()).ToList();
            //var item=GetRandomItem(tip);
        }

        private static T GetRandomItem<T>()
        {
            var r = new Random();
            var type = typeof(T);
            var propertyInfo = type.GetProperties();
            var o = Activator.CreateInstance(type);
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                var info = propertyInfo[i];
                var fieldName = info.Name;

                Type t = info.PropertyType;
                try
                {
                    object value = null;

                    if (t == typeof(string) || t == typeof(String))
                    {
                        value = (Int16)r.Next(999);
                        value = fieldName + "_" + value;
                        info.SetValue(o, value,null);
                    }
                    else if (t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64))
                    {
                        value = (Int16)r.Next(999);
                        info.SetValue(o, value, null);
                    }
                    else if (t == typeof(Int16?))
                    {
                        Int16? v = (Int16)r.Next(999);
                        info.SetValue(o, v, null);
                    }
                    else if (t == typeof(Int32?))
                    {
                        Int32? v = (Int32)r.Next(999);
                        info.SetValue(o, v, null);
                    }
                    else if (t == typeof(Int64?))
                    {
                        Int64? v = (Int64)r.Next(999);
                        info.SetValue(o, v, null);
                    }
                    else if (t == typeof(DateTime) || t == typeof(DateTime?))
                    {
                        value = DateTime.Now;
                        info.SetValue(o, value, null);
                    }
                    else if (t == typeof(double) || t == typeof(float) || t == typeof(Double))
                    {
                        value = 17.2;
                        info.SetValue(o, value, null);
                    }
                    else if (t == typeof(char) || t == typeof(Char))
                    {
                        value = 'a';
                        info.SetValue(o, value, null);
                    }
                    else
                    {

                        //object temp = info.GetValue(o);
                        //if (temp == null)
                        //{
                        //    temp = Activator.CreateInstance(t);
                        //    info.SetValue(o, temp);
                        //}

                    }
                }
                catch (Exception ex)
                {

                }
            }
            return (T)o;
        }
    }
}
