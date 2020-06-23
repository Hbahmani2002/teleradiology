using System;
using System.IO;

namespace GT.Core.Settings
{
    public class AppSettings
    {
        private static AppSettings _AppSettings;
        public static AppSettings GetCurrent()
        {
            if (_AppSettings == null)
            {
                _AppSettings = new AppSettings();
            }
            return _AppSettings;
        }
        private AppSettings()
        {
            Log = new Logging();
            STM = new STMService();
            Kos = new KosService();
            DatabaseConnection = new Database();
        }

        public Logging Log { get; }
        public STMService STM { get; }
        public KosService Kos { get; }

        public Database DatabaseConnection { get; }


        public class Database
        {
            public string StudyPostgreConnectionString => "​UserID=test_protek;Password=test123;Server=85.95.238.211;Port=9002;Database=guney_teletip_db;Integrated Security=true;Pooling=true;";
          // "Host=85.95.238.211;Database=guney_teletip_db;Username=test_protek;Password=test123;Port=9002"
            public string InfinityOracleConnectionString => "User Id=test_user;Password=protek_oracle_2020;Data Source=85.95.238.211:9003/xe;";
        }
        public class Logging
        {
            private string FullPath(string relativePath)
            {
                var path = Path.GetFullPath(relativePath, Environment.CurrentDirectory);
                return path;
            }
            public string DIR_JobsLog => FullPath("../upload/_jobs");
            public string PATH_JobInfinity => Path.Combine(DIR_JobsLog, "infinity_job_log.txt");
            public string DIR_BackgroundProcess => FullPath("../upload/_background");
        }
        public class STMService
        {
            public string HBYS_PACS_ResourceOwnerClient => "HbPatT!180430";
            public string userTokenName => "infinitt_pacs@teletip.saglik.gov.tr";
            public string userTokenPassword => "TGeSNkz7!!7!HpU";
            public string identityServerBaseUri => "https://sec.teletip.saglik.gov.tr";
            public string BASEADDRESS => "https://api.teletip.saglik.gov.tr/Common.WebApi/api/Integration/";
        }

        public class KosService
        {
            public MakeKos Make { get; }
            public SendKos Send { get; }

            public KosService()
            {
                Make = new MakeKos();
                Send = new SendKos();
            }
            public class MakeKos
            {
                public int JOB_MaxParallelTask => 10;
                public string DIR_StudyPath => "/gt/dicom/study";
                public string DIR_KosPath => "/gt/dicom/kos";
                public string AppFilePath => "/gt/app/teletip_kos/MakeKOS_v21.jar";
                public string LocationUID => "1.3.6.1.4.1.21367.2017.10.26.111";
                public string Title => "DCM-113030";
                public string TempDirectoryPath => "/gt/dicom/temp_kos";
                public string DCM4CheeDirectoryPath => "/gt/app/teletip_kos/dcm4che-5.22.2/bin";
            }
            public class SendKos
            {
                public string AppFilePath => "/gt/app/teletip_kos/SendKOS_vProtek.jar";
                public string ServiceAddressURL => "https://xdarep.teletip.saglik.gov.tr/axis2/services/xdsrepositoryb";
                public string ServiceAddress_BETA_URL => "http://betaxdsrepository.teletip.saglik.gov.tr/axis2/services/xdsrepositoryb";

                public string AxisRepoDirectoryPath => "/gt/app/teletip_kos/axis2Repo";
                public string AxisXmlFilePath => "/gt/app/teletip_kos/axis2Repo/axis2_test.xml";

            }

        }
        private void GetCredentials()
        {

            var gelen_app_setting = File.ReadAllText("appsettings.json");

            //var item = JsonConvert.DeserializeObject<GlobalCls>(gelen_app_setting);
            //return item;
        }
    }
}
