using System;
using System.IO;

namespace GT.Core.Settings
{
    public class AppSettings
    {
        public class Logging
        {
            private static string FullPath(string relativePath)
            {
                var path = Path.GetFullPath(relativePath, Environment.CurrentDirectory);
                return path;
            }
            public static string DIR_JobsLog => FullPath("../upload/_jobs");
            public static string PATH_JobInfinity => Path.Combine(DIR_JobsLog, "infinity_job_log.txt");
            public static string DIR_BackgroundProcess => FullPath("../upload/_background");
        }
        public class STMService
        {
            public static string HBYS_PACS_ResourceOwnerClient => "HbPatT!180430";
            public static string userTokenName => "infinitt_pacs@teletip.saglik.gov.tr";
            public static string userTokenPassword => "TGeSNkz7!!7!HpU";            
            public static string identityServerBaseUri => "https://sec.teletip.saglik.gov.tr";
            public static string BASEADDRESS => "https://api.teletip.saglik.gov.tr/Common.WebApi/api/Integration/";
        }

        private static void GetCredentials()
        {

            var gelen_app_setting = File.ReadAllText("appsettings.json");

            //var item = JsonConvert.DeserializeObject<GlobalCls>(gelen_app_setting);
            //return item;
        }
    }
}
