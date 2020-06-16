using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Volume
    {
        public string VolumeCode { get; set; }
        public string VolumeType { get; set; }
        public string VolumeStat { get; set; }
        public string Pathname { get; set; }
        public string Hostname { get; set; }
        public string Rhostname { get; set; }
        public string Sharename { get; set; }
        public string Protocol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rusername { get; set; }
        public string Rpassword { get; set; }
        public decimal Ordinal { get; set; }
        public decimal Threshold { get; set; }
        public string InstitutionCode { get; set; }
        public string Modality { get; set; }
        public string Iishost { get; set; }
        public string Aetitle { get; set; }
        public decimal? Capacity { get; set; }
        public decimal? UsedSpace { get; set; }
        public DateTime? UsedSpaceUpdateDttm { get; set; }
    }
}
