using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Instance
    {
        public Instance()
        {
            ContentItem = new HashSet<ContentItem>();
            Location = new HashSet<Location>();
            VerifyObserver = new HashSet<VerifyObserver>();
        }

        public long Pk { get; set; }
        public int Availability { get; set; }
        public string SrComplete { get; set; }
        public string ContentDate { get; set; }
        public string ContentTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ExtRetrieveAet { get; set; }
        public string InstCustom1 { get; set; }
        public string InstCustom2 { get; set; }
        public string InstCustom3 { get; set; }
        public int? InstNo { get; set; }
        public int? NumFrames { get; set; }
        public string RetrieveAets { get; set; }
        public string SopCuid { get; set; }
        public string SopIuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string SrVerified { get; set; }
        public long? Version { get; set; }
        public long DicomattrsFk { get; set; }
        public long? SrcodeFk { get; set; }
        public long SeriesFk { get; set; }

        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Series SeriesFkNavigation { get; set; }
        public virtual Code SrcodeFkNavigation { get; set; }
        public virtual ICollection<ContentItem> ContentItem { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<VerifyObserver> VerifyObserver { get; set; }
    }
}
