using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain
{
    public partial class XxxQueryRetrieveSettings
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string ServerName { get; set; }
        public string AccessionNoOnek { get; set; }
        public string ServerAetitle { get; set; }
        public string ServerHost { get; set; }
        public int ServerPort { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaySequence { get; set; }
        public string Aktif { get; set; }
        public int TenantId { get; set; }
        public string CallingAetitle { get; set; }
    }
}
