using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        private static GlobalAppSettings globalSettings;
        public static GlobalAppSettings GetCurrent()
        {
            if (globalSettings == null)
            {
                globalSettings = new GlobalAppSettings();
            }
            return globalSettings;
        }
        //CONSTANT
        public WebAppSetting WebAppSettings { get; set; }
        public DataServiceSettings DataService { get; set; }
        public STMServiceSetting STMSettings { get; set; }
        public LoggingSetting LogSettings { get; set; }
        public KosServiceSetting KosServiceSettings { get; set; }

        private GlobalAppSettings()
        {
            DataService = new DataServiceSettings();
            STMSettings = new STMServiceSetting();
            LogSettings = new LoggingSetting();
            KosServiceSettings = new KosServiceSetting();

        }
    }
}
