using System;
using System.Collections.Generic;

namespace Dcm4chee.Persistance.Domain.Models
{
    public partial class Ups
    {
        public Ups()
        {
            Subscription = new HashSet<Subscription>();
            UpsReq = new HashSet<UpsReq>();
        }

        public long Pk { get; set; }
        public string AdmissionId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ExpectedEndDateTime { get; set; }
        public int InputReadinessState { get; set; }
        public string PerformerAet { get; set; }
        public int UpsState { get; set; }
        public string ReplacedIuid { get; set; }
        public string ExpirationDateTime { get; set; }
        public string StartDateTime { get; set; }
        public string TransactionIuid { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string UpsIuid { get; set; }
        public string UpsLabel { get; set; }
        public int UpsPriority { get; set; }
        public long? Version { get; set; }
        public string WorklistLabel { get; set; }
        public long DicomattrsFk { get; set; }
        public long? AdmissionIssuerFk { get; set; }
        public long PatientFk { get; set; }
        public long? StationClassFk { get; set; }
        public long? StationLocationFk { get; set; }
        public long? StationNameFk { get; set; }
        public long? UpsCodeFk { get; set; }

        public virtual Issuer AdmissionIssuerFkNavigation { get; set; }
        public virtual Dicomattrs DicomattrsFkNavigation { get; set; }
        public virtual Patient PatientFkNavigation { get; set; }
        public virtual Code StationClassFkNavigation { get; set; }
        public virtual Code StationLocationFkNavigation { get; set; }
        public virtual Code StationNameFkNavigation { get; set; }
        public virtual Code UpsCodeFkNavigation { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }
        public virtual ICollection<UpsReq> UpsReq { get; set; }
    }
}
