using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT.UI.WebApi.Implementation
{
    public class AppSettings
    {
        private static IConfiguration Configuration;
        public static JWT JWT;

        public static IConfigurationSection Init(IConfiguration conf)
        {
            Configuration = conf;

            var appSettingsSection = Configuration.GetSection("AppSettings");
            JWT = appSettingsSection.Get<JWT>();

            return appSettingsSection;
        }

    }
    public class JWT
    {
        public string Secret { get; set; }
    }

}
