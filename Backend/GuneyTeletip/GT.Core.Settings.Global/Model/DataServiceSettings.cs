﻿namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        public class DataServiceSettings
        {
            public class OracleSetting
            {
                public int InfinityOracleTakeTop => 500;
                public string ZeroImageGeneratorName => "INFINITT::DCMCREATOR::::::";
            }

            public OracleSetting OracleSettings { get; }
            public DataServiceSettings()
            {
                OracleSettings = new OracleSetting();
            }


            public int MakeKosServiceItemPerBatch => 100;

            public int SendKosServiceItemPerBatch => 500;

            public int OrderServiceItemPerBatch => 100;

            public int OrderStatusForAccessionNumberPerBatch => 10;

            public int KosWaitHour => 2;
        }



    }
}
