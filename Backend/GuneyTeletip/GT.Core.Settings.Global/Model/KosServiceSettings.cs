namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        public class KosServiceSetting
        {
            public MakeKos Make { get; }
            public SendKos Send { get; }

            public KosServiceSetting()
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
                public string App_Ver_JSON_FilePath => "/gt/app/teletip_kos/MakeKOS_protekV2.jar";
                public string LocationUID => "1.3.6.1.4.1.21367.2017.10.26.111";
                public string Title => "DCM-113030";
                public string TempDirectoryPath => "/gt/dicom/temp_kos";
                public string DCM4CheeDirectoryPath => "/gt/app/teletip_kos/dcm4che-5.22.2/bin";
                //public string InstitutionFirmaKodu => "FKad6e6d67-7607-473f-83eb-6dbe516f91b3";

                public string InstitutionFirmaKodu => "FK6527c5ff-b301-45ec-b4df-2d09700dd61c";
            }
            public class SendKos
            {
                public string AppFilePath => "/gt/app/teletip_kos/SendKOS_vProtek.jar";
                public string ServiceAddressURL => "https://xdarep.teletip.saglik.gov.tr/axis2/services/xdsrepositoryb";
                public string ServiceAddress_BETA_URL => "http://betaxdsrepository.teletip.saglik.gov.tr/axis2/services/xdsrepositoryb";

                public string AxisRepoDirectoryPath => "/gt/app/teletip_kos/axis2Repo/axis2repository";
                public string AxisXmlFilePath => "/gt/app/teletip_kos/axis2Repo/axis2_test.xml";

            }
        }
    }
}
