using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.infinity.Model
{
    public class InfOracleFilter
    {
        public string Accession_no { get; set; }
        public DateTime? Infcreationstartdate { get; set; }
        public DateTime? Infcreationenddate { get; set; }
        public long? Infstudypklast { get; set; }
        public string SeriesInfo { get; set; }

        public string Source_Aetitle { get; set; }

        

        public string[] AccessionNoListte { get; set; }

    }




}
