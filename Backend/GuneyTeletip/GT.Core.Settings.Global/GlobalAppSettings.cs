using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace GT.Core.Settings.Global
{
    public class GlobalAppSettings
    {
        private const string Path = "appsettings.json";
        private static GlobalAppSettings globalSettings;
        public static GlobalAppSettings GetCurrent()
        {
            if (globalSettings == null)
            {

                lock (Path)
                {
                    if (globalSettings == null)
                    {
                        var file = File.ReadAllText(Path, Encoding.UTF8);
                        try
                        {
                            globalSettings = JsonConvert.DeserializeObject<GlobalAppSettings>(file);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"{Path} dosaysından global ayarlar çekilmedi", ex);
                        }
                    }
                }
            }
            return globalSettings;
        }
        public class WebAppSetting
        {
            public string TokenMasterKey { get; set; }
        }
        public WebAppSetting WebAppSettings { get; set; }
        public DatabaseSettings ConnectionStrings { get; set; }
        public class DatabaseSettings
        {
            public string StudyPostgre { get; set; }
            public string InfinityOracle { get; set; }
        }

       

    }
}
