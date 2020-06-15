using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teletip.SorgulamaServis
{
    public class PatientResult
    {
        public string AccessionNumber { get; set; }
        public string Modality { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string SutCode { get; set; }
        public string SutDescription { get; set; }
        public string PatientHbysId { get; set; }
        public string PatientHistory { get; set; }
        public string PatientComplaints { get; set; }
        public string PatientICD1O { get; set; }

    }

    


}
