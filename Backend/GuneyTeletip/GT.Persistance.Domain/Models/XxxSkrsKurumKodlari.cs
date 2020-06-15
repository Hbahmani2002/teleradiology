using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XxxSkrsKurumKodlari
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string KurumIsmi { get; set; }
        public string SkrsKodu { get; set; }
        public int TenantId { get; set; }
        public string InstitutionName { get; set; }
        public int MedulaTesisKodu { get; set; }
        public int QrSettingId { get; set; }
    }
}
