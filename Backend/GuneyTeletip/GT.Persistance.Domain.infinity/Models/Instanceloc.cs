using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Instanceloc
    {
        public decimal InstanceKey { get; set; }
        public string InstanceType { get; set; }
        public decimal? InstanceSize { get; set; }
        public decimal? CompressSize { get; set; }
        public string Pathname { get; set; }
        public string Pathext { get; set; }
        public string Filename { get; set; }
        public string VolumeCode { get; set; }
        public string B0VolCode { get; set; }
        public string B0VolStat { get; set; }
        public string B0Filepath { get; set; }
        public string B1VolCode { get; set; }
        public string B1VolStat { get; set; }
        public string B1BakStat { get; set; }
        public string B1Filepath { get; set; }
        public string B2VolCode { get; set; }
        public string B2VolStat { get; set; }
        public string B2BakStat { get; set; }
        public string B2Filepath { get; set; }
        public string B3VolCode { get; set; }
        public string B3VolStat { get; set; }
        public string B3BakStat { get; set; }
        public string B3Filepath { get; set; }
    }
}
