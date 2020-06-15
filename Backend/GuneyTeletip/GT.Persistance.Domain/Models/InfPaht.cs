﻿using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class InfPaht
    {
        public long Pk { get; set; }
        public string PahtCode { get; set; }
        public char PahtType { get; set; }
        public char PahtStat { get; set; }
        public string Pathname { get; set; }
        public string Hostname { get; set; }
        public string Sharename { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string KurumKodu { get; set; }
        public string Modality { get; set; }
        public string FilePath { get; set; }
        public short RecordType { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFk { get; set; }
        public long UserFkLastModfiead { get; set; }
    }
}
