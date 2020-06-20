using System;
using System.Collections.Generic;
using System.Text;

namespace GT.TeletipKos.Model
{
    public class SendKosParameter
    {
        public string ID { get; set; }
        public SendKosParameter(string id, string patientId, string kosFilePath)
        {
            ID = id;
            PatientId = patientId;
            KosFilePath = kosFilePath;            
        }

        public string PatientId { get; }
        //RepositoryPath
        public string KosFilePath { get; }      


    }
}
