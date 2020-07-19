using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Code
    {
        public Code()
        {
            ContentItemCodeFkNavigation = new HashSet<ContentItem>();
            ContentItemNameFkNavigation = new HashSet<ContentItem>();
            Instance = new HashSet<Instance>();
            Mpps = new HashSet<Mpps>();
            MwlItemDeptCodeFkNavigation = new HashSet<MwlItem>();
            MwlItemInstCodeFkNavigation = new HashSet<MwlItem>();
            RejectedInstance = new HashSet<RejectedInstance>();
            SeriesDeptCodeFkNavigation = new HashSet<Series>();
            SeriesInstCodeFkNavigation = new HashSet<Series>();
            UpsStationClassFkNavigation = new HashSet<Ups>();
            UpsStationLocationFkNavigation = new HashSet<Ups>();
            UpsStationNameFkNavigation = new HashSet<Ups>();
            UpsUpsCodeFkNavigation = new HashSet<Ups>();
        }

        public long Pk { get; set; }
        public string CodeMeaning { get; set; }
        public string CodeValue { get; set; }
        public string CodeDesignator { get; set; }
        public string CodeVersion { get; set; }

        public virtual ICollection<ContentItem> ContentItemCodeFkNavigation { get; set; }
        public virtual ICollection<ContentItem> ContentItemNameFkNavigation { get; set; }
        public virtual ICollection<Instance> Instance { get; set; }
        public virtual ICollection<Mpps> Mpps { get; set; }
        public virtual ICollection<MwlItem> MwlItemDeptCodeFkNavigation { get; set; }
        public virtual ICollection<MwlItem> MwlItemInstCodeFkNavigation { get; set; }
        public virtual ICollection<RejectedInstance> RejectedInstance { get; set; }
        public virtual ICollection<Series> SeriesDeptCodeFkNavigation { get; set; }
        public virtual ICollection<Series> SeriesInstCodeFkNavigation { get; set; }
        public virtual ICollection<Ups> UpsStationClassFkNavigation { get; set; }
        public virtual ICollection<Ups> UpsStationLocationFkNavigation { get; set; }
        public virtual ICollection<Ups> UpsStationNameFkNavigation { get; set; }
        public virtual ICollection<Ups> UpsUpsCodeFkNavigation { get; set; }
    }
}
