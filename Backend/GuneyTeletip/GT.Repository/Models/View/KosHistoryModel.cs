using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Models.View
{
    public class KosHistoryModel
    {
        public long ID { get; set; }
        public long KosStudyID { get; set; }
        public String Result { get; set; }
        public int? EnumType { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public long? UserIDCreated { get; set; }
        public long? UserIDModified { get; set; }
    }
}
