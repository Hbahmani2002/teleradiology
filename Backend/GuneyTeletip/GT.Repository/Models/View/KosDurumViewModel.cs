using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class KosDurumViewModel
    {
        public string KurumSkrsKodu { get; set; }
        public long StudyID { get; set; }
        public string StudyInstanceID { get; set; }
        public string AccessionNumber { get; set; }
        public string KurumMedulaTesisKodu { get; set; }
    }
}
