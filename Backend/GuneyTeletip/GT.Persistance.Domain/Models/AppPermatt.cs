using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class AppPermatt
    {
        public long Pk { get; set; }
        public int Valuse { get; set; }
        public string AppLog { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFkCreated { get; set; }
        public long UserFkLastModfiead { get; set; }
    }
}
