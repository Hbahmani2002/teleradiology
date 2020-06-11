using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class Tenat
    {
        public Tenat()
        {
            TenatSkrs = new HashSet<TenatSkrs>();
        }

        public long Pk { get; set; }
        public string TenatAd { get; set; }
        public string TenatKisaAd { get; set; }
        public short? TenatRecordType { get; set; }
        public string TenatWado { get; set; }
        public string TenatWadoRs { get; set; }
        public string ServerName { get; set; }
        public string AccessionNoOnek { get; set; }
        public string ServerAetitle { get; set; }
        public string ServerHost { get; set; }
        public int? ServerPort { get; set; }
        public int? RecordType { get; set; }
        public int? DaySequence { get; set; }
        public string CallingAetitle { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }

        public virtual ICollection<TenatSkrs> TenatSkrs { get; set; }
    }
}
