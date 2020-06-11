using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEDLIFE.PERSISTANCE
{
    public class LocalSettings
    {
        public static string AppName = "MedlifeDB";

        public static object DocumentPath { get; internal set; }
    }
}
