using Dicom.Network;
using System.Diagnostics;

namespace FODICOM.Service
{
    public class TeletipDosSender
    {
        public DicomStatus Send(DICOMStoreParameter param, string dicomFilePath)
        {
            var client = new Dicom.Network.Client.DicomClient(param.StoreServerHost, param.StoreServerPort, true, param.ClientAET, param.StoreServerAET);
            client.NegotiateAsyncOps();

            var request = new DicomCStoreRequest(dicomFilePath);
            DicomStatus res = null;
            request.OnResponseReceived += (req, response) =>
            {
                res = response.Status;
            };
            request.OnTimeout += (a, b) =>
            {

            };

            client.AddRequestAsync(request).Wait();
            client.SendAsync().Wait();
            return res;
        }
    }
}
