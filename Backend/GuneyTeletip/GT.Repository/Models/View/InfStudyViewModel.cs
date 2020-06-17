using MEDLIFE.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class InfStudyViewModel
    {

        [DataEntityID]
        public string Modality { get; set; }

        public string Patine_name { get; set; }

        public string Accession_no { get; set; }

        public string Patinet_id { get; set; }
        public long? Pk { get; set; }

    }
}
