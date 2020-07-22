using NUnit.Framework;
using System.Diagnostics;

namespace FODICOM.Service.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SendSRFiles()
        {
            var storeServerHost = "dicom.teletip.saglik.gov.tr";
            var storeServerPort = 443;
            var storeServerAET = "TELETIP_MGA";
            var aET = "ProtekTest";
            //ÖZEL HAYAT HASTANESİ ^^^ SKRS500059 ^^^ FK10163006
            var par = new DICOMStoreParameter(storeServerHost, storeServerPort, storeServerAET, aET);
            var sender = new TeletipDosSender();



            var SRFiles = new[]{
                @"C:\DCM_DOSE\321.dcm"
            };
            foreach (var dicomFilePath in SRFiles)
            {
                var res = sender.Send(par, dicomFilePath);
                if (res == null)
                {
                    return;
                }
                {
                    Debug.WriteLine(res);
                }
            }
        }

    }
}