using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models
{
    public class BaseTableViewModel
    {
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? UserIDCreated { get; set; }
        public long? UserIDModified { get; set; }
        public long? RecordStatus { get; set; }
    }
}
