namespace FODICOM.Service
{
    public class DICOMStoreParameter
    {
        public DICOMStoreParameter(string storeServerHost, int storeServerPort, string storeServerAET, string clientAET)
        {
            StoreServerHost = storeServerHost;
            StoreServerPort = storeServerPort;
            StoreServerAET = storeServerAET;
            ClientAET = clientAET;
        }

        public string StoreServerHost { get; }
        public int StoreServerPort { get; }
        public string StoreServerAET { get; }
        public string ClientAET { get; }
    }
}
