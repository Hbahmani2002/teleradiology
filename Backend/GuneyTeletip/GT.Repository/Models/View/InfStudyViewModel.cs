using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class InfStudyViewModel
    {
        [DataEntityID]
        public long ID { get; set; }
        public string AccessionNumber { get; set; }
        public string HastaNo { get; set; }
        public string PatientName { get; set; }
        public string IstemAdi { get; set; }
        public DateTime IstemTarihi { get; set; }
        public string Modality { get; set; }
        public string KosStateTag { get; set; }
        public int KosState { get; set; }

    }
}
