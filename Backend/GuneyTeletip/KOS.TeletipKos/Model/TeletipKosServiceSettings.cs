using GT.Core.Settings;
using GT.TeletipKos.Model;
using System;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class TeletipKosServiceSetting
    {
        private static TeletipKosServiceSetting _TeletipKosServiceSetting;
        public static TeletipKosServiceSetting GetCurrent()
        {
            if (_TeletipKosServiceSetting == null)
            {

                var settings = AppSettings.GetCurrent();
                var makeKosSettings = settings.Kos.Make;
                var sendKosSettings = settings.Kos.Send;

                var var = new TeletipKosServiceSetting(
                   new TeletipKosServiceSetting.MakeKosServiceSettings(makeKosSettings.AppFilePath, makeKosSettings.App_Ver_JSON_FilePath, makeKosSettings.LocationUID, makeKosSettings.Title, makeKosSettings.TempDirectoryPath + "/", makeKosSettings.DCM4CheeDirectoryPath, makeKosSettings.InstitutionFirmaKodu),
                   new TeletipKosServiceSetting.SendKosServiceSettings(sendKosSettings.AppFilePath, sendKosSettings.ServiceAddressURL, sendKosSettings.AxisRepoDirectoryPath, sendKosSettings.AxisXmlFilePath)
               );
                _TeletipKosServiceSetting = var;
            }
            return _TeletipKosServiceSetting;
        }
        public TeletipKosServiceSetting(MakeKosServiceSettings makeKosSettings, SendKosServiceSettings sendKosSettings)
        {
            MakeKosSettings = makeKosSettings;
            SendKosSettings = sendKosSettings;
        }

        public MakeKosServiceSettings MakeKosSettings { get; }
        public SendKosServiceSettings SendKosSettings { get; }
        public class MakeKosServiceSettings
        {
            public MakeKosServiceSettings(string appFilePath, string app_Ver_JSON_FilePath, string locationUID, string title, string tempDirectory, string dCM4CheeDirectory, string institutionFirmaKodu)
            {
                AppFilePath = appFilePath;
                App_Ver_JSON_FilePath = app_Ver_JSON_FilePath;
                LocationUID = locationUID;
                Title = title;
                TempDirectory = tempDirectory;
                DCM4CheeDirectory = dCM4CheeDirectory;
                InstitutionFirmaKodu = institutionFirmaKodu;
            }
            public string App_Ver_JSON_FilePath { get; }
            public string AppFilePath { get; }
            public string LocationUID { get; }
            public string Title { get; }
            public string TempDirectory { get; }
            public string DCM4CheeDirectory { get; }
            public object InstitutionFirmaKodu { get; set; }
        }

        public class SendKosServiceSettings
        {
            public SendKosServiceSettings(string appFilePath, string serviceURL, string axisRepoDirectoryPath, string axisXmlFilePath)
            {
                AppFilePath = appFilePath;
                ServiceURL = serviceURL;
                AxisRepoDirectoryPath = axisRepoDirectoryPath;
                AxisXmlFilePath = axisXmlFilePath;
            }

            public string AppFilePath { get; }
            public string ServiceURL { get; }

            public string AxisRepoDirectoryPath { get; set; }
            public string AxisXmlFilePath { get; set; }

        }



    }




}
