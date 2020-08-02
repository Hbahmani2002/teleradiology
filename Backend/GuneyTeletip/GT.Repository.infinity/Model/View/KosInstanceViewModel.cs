using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.infinity.Model.View
{
    public class KosInstanceViewModel
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public decimal? StudyKey { get; set; }
        public string StudyInstanceUID { get; set; }
        public string SeriesInstanceUID { get; set; }
        public string SopInstanceUID { get; set; }
        public string AccessNo { get; set; }
        public string Modalities { get; set; }
        public string SeriesInfo { get; set; }
        public string FileName { get; set; }
        public string InstanceLogPathName { get; set; }
        public string VolumePathName { get; set; }
    }
}
