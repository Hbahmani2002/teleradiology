using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Series
    {
        public Series()
        {
            Instance = new HashSet<Instance>();
            SeriesQueryAttrs = new HashSet<SeriesQueryAttrs>();
            SeriesReq = new HashSet<SeriesReq>();
        }

        public long Pk { get; set; }
        public string BodyPart { get; set; }
        public int Completeness { get; set; }
        public int CompressFailures { get; set; }
        public string CompressParams { get; set; }
        public DateTime? CompressTime { get; set; }
        public string CompressTsuid { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ExpirationDate { get; set; }
        public string ExpirationExporterId { get; set; }
        public int ExpirationState { get; set; }
        public string ExtRetrieveAet { get; set; }
        public int FailedRetrieves { get; set; }
        public int StgverFailures { get; set; }
        public int InstPurgeState { get; set; }
        public DateTime? InstPurgeTime { get; set; }
        public string Institution { get; set; }
        public string Department { get; set; }
        public string Laterality { get; set; }
        public DateTime? MetadataUpdateTime { get; set; }
        public int MetadataUpdateFailures { get; set; }
        public string Modality { get; set; }
        public string PpsCuid { get; set; }
        public string PpsIuid { get; set; }
        public string PpsStartDate { get; set; }
        public string PpsStartTime { get; set; }
        public int RejectionState { get; set; }
        public string SeriesCustom1 { get; set; }
        public string SeriesCustom2 { get; set; }
        public string SeriesCustom3 { get; set; }
        public string SeriesDesc { get; set; }
        public string SeriesIuid { get; set; }
        public int? SeriesNo { get; set; }
        public long SeriesSize { get; set; }
        public string SopCuid { get; set; }
        public string SrcAet { get; set; }
        public string StationName { get; set; }
        public DateTime? StgverTime { get; set; }
        public string Tsuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public long? Version { get; set; }
        public long DicomattrsFk { get; set; }
        public long? InstCodeFk { get; set; }
        public long? DeptCodeFk { get; set; }
        public long? MetadataFk { get; set; }
        public long? PerfPhysNameFk { get; set; }
        public long StudyFk { get; set; }

        public virtual Code DeptCodeFkNavigation { get; set; }
        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Code InstCodeFkNavigation { get; set; }
        public virtual Metadata MetadataFkNavigation { get; set; }
        public virtual PersonName PerfPhysNameFkNavigation { get; set; }
        public virtual Study StudyFkNavigation { get; set; }
        public virtual ICollection<Instance> Instance { get; set; }
        public virtual ICollection<SeriesQueryAttrs> SeriesQueryAttrs { get; set; }
        public virtual ICollection<SeriesReq> SeriesReq { get; set; }
    }
}
