using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XinfValume
    {
        public string VolumeCode { get; set; }
        public char VolumeType { get; set; }
        public char VolumeStat { get; set; }
        public string Pathname { get; set; }
        public string Hostname { get; set; }
        public string Rhostname { get; set; }
        public string Sharename { get; set; }
        public char? Protocol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rusername { get; set; }
        public string Rpassword { get; set; }
        public double Ordinal { get; set; }
        public double Threshold { get; set; }
        public string InstitutionCode { get; set; }
        public string Modality { get; set; }
        public string Iishost { get; set; }
        public string Aetitle { get; set; }
        public double? Capacity { get; set; }
        public double? UsedSpace { get; set; }
        public DateTime? UsedSpaceUpdateDttm { get; set; }
    }
}
