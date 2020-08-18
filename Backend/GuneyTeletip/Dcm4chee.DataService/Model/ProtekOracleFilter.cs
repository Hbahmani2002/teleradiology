using System;
using System.Collections.Generic;
using System.Text;

namespace Dcm4chee.DataService.Model
{
    public class ProtekOracleFilter
    {
        public DateTime BasTar { get; set; }
        public DateTime BitTar { get; set; }
        public string[] ModalityList { get; set; }
        public string Accession_no { get; set; }
        public long? Infstudypklast { get; set; }
        public string SeriesInfo { get; set; }



    }
}
