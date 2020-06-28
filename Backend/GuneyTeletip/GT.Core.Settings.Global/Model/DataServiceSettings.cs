namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        public class DataServiceSettings
        {
            public class OracleSetting
            {
                public int InfinityOracleTakeTop => 200;
                public string ZeroImageGeneratorName => "INFINITT::DCMCREATOR::::::";
            }

            public OracleSetting OracleSettings { get; }
            public DataServiceSettings()
            {
                OracleSettings = new OracleSetting();
            }


            public int MakeKosServiceItemPerBatch => 50;

            public int OrderServiceItemPerBatch => 50;
            public int KosWaitHour => 2;
        }



    }
}
