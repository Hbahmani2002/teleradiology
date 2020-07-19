using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gt.PERSISTANCE
{
    public class LocalSettings
    {
        public static string AppName = "pacsdb";

        public static object DocumentPath { get; internal set; }
    }
}
