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
                   new TeletipKosServiceSetting.MakeKosServiceSettings(makeKosSettings.AppFilePath, makeKosSettings.LocationUID, makeKosSettings.Title, makeKosSettings.TempDirectoryPath + "/", makeKosSettings.DCM4CheeDirectoryPath),
                   new TeletipKosServiceSetting.SendKosServiceSettings(sendKosSettings.AppFilePath, sendKosSettings.ServiceAddress_BETA_URL, sendKosSettings.AxisRepoDirectoryPath, sendKosSettings.AxisXmlFilePath)
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
            public MakeKosServiceSettings(string appFilePath, string locationUID, string title, string tempDirectory, string dCM4CheeDirectory)
            {
                AppFilePath = appFilePath;
                LocationUID = locationUID;
                Title = title;
                TempDirectory = tempDirectory;
                DCM4CheeDirectory = dCM4CheeDirectory;
            }

            public string AppFilePath { get; }
            public string LocationUID { get; }
            public string Title { get; }
            public string TempDirectory { get; }
            public string DCM4CheeDirectory { get; }
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
