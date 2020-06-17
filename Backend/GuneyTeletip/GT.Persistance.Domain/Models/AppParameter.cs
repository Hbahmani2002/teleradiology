using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class AppParameter
    {
        public long Pk { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long UserFkCreated { get; set; }
        public long UserFkLastModfiead { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
    }
}
