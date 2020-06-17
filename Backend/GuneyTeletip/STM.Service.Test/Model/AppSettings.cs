using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STM.Service.Test
{
    public class AppSettings
    {
        //private static IConfiguration Configuration;
        //public static JWT JWT;

        //public static IConfigurationSection Init(IConfiguration conf)
        //{
        //    Configuration = conf;

        //    var appSettingsSection = Configuration.GetSection("AppSettings");
        //    JWT = appSettingsSection.Get<JWT>();

        //    return appSettingsSection;
        //}
        public static GlobalCls GetCredentials()
        {

            var gelen_app_setting = File.ReadAllText("appsettings.json");

            var item = JsonConvert.DeserializeObject<GlobalCls>(gelen_app_setting);
            return item;
        }




    }


}
