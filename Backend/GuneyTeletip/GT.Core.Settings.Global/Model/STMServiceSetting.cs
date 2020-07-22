namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        public class STMServiceSetting
        {
            public string HBYS_PACS_ResourceOwnerClient => "HbPatT!180430";
            //public string userTokenName => "infinitt_pacs@teletip.saglik.gov.tr";
            //public string userTokenPassword => "TGeSNkz7!!7!HpU";

            //public string userTokenName => "protek_hbys@teletip.saglik.gov.tr";
            //public string userTokenPassword => "1234Aasd?";


            public string userTokenName => "protek_pacs@teletip.saglik.gov.tr";
            public string userTokenPassword => "i5Rg71r1H$9RhL";

            public string identityServerBaseUri => "https://sec.teletip.saglik.gov.tr";
            public string BASEADDRESS => "https://api.teletip.saglik.gov.tr/Common.WebApi/api/Integration/";
        }
    }
}
