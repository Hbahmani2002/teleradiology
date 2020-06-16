using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XinfInstanceloc
    {
        public double InstanceKey { get; set; }
        public char InstanceType { get; set; }
        public double? InstanceSize { get; set; }
        public double? CompressSize { get; set; }
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
