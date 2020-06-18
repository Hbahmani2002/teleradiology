using System;
using System.Collections.Generic;
using System.Text;

namespace GT.TeletipKos.Model
{
    public class SendKosParameter
    {
        public SendKosParameter(string patientId, string kosFilePath, string serviceUrl)
        {
            PatientId = patientId;
            KosFilePath = kosFilePath;
            ServiceUrl = serviceUrl;
        }

        public string PatientId { get; }
        //RepositoryPath
        public string KosFilePath { get; }
        public string ServiceUrl { get; }


    }
}
