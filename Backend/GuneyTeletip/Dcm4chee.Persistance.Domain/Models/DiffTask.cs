using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class DiffTask
    {
        public long Pk { get; set; }
        public bool CheckDifferent { get; set; }
        public bool CheckMissing { get; set; }
        public string CompareFields { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Different { get; set; }
        public string LocalAet { get; set; }
        public int Matches { get; set; }
        public int Missing { get; set; }
        public string PrimaryAet { get; set; }
        public string QueryStr { get; set; }
        public string SecondaryAet { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long QueueMsgFk { get; set; }

        public virtual QueueMsg QueueMsgFkNavigation { get; set; }
    }
}
