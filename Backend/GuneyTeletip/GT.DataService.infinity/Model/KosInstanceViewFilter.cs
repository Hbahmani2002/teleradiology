using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.infinity.Model
{
    public class KosInstanceViewFilter
    {
        public string PatientID { get; set; }
        public string SeriesInfo { get; set; }

        public string StudyUID { get; set; }

        public long? StudyKey { get; set; }



    }
}
