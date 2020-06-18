using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class InfStudyViewModel
    {

        [DataEntityID]
        public string AccessionNumber { get; set; }
        public string Modalite { get; set; }
        public string Patinetıd { get; set; }
        public string Patinename { get; set; }
        public string Pk { get; set; }

    }
}
