using GT.TeletipKos.Model;
using System;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class TeletipKosServiceSettings
    {
        public TeletipKosServiceSettings(MakeKosServiceSettings makeKosSettings, SendKosServiceSettings sendKosSettings)
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
            public SendKosServiceSettings(string appFilePath, string serviceURL)
            {
                AppFilePath = appFilePath;
                ServiceURL = serviceURL;
            }

            public string AppFilePath { get; }
            public string ServiceURL { get; }
        }



    }
}
