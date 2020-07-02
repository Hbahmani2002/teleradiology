using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.infinity.Model.View
{
    public class InfOracleViewModel
    {
        [DataEntityID]
        public decimal? StudyKey { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSex { get; set; }
        public DateTime? PatientBirthDttm { get; set; }
        public string StudyInstanceUid { get; set; }
        public DateTime? StudyDttm { get; set; }
        public string AccessNo { get; set; }
        public string Institution { get; set; }
        public decimal? SeriesCount { get; set; }
        public decimal? InstanceCount { get; set; }
        public string Modalities { get; set; }
        public string Pathname { get; set; }
        public string Filename { get; set; }
        public string VolumeCode { get; set; }
        public string VolumeType { get; set; }
        public string VolumeStat { get; set; }
        public string VolumePathname { get; set; }
        public DateTime? ModifyDttm { get; set; }
        public DateTime? CreationDttm { get; set; }
        public string StudyDesc { get; set; }
        public decimal? InfMergeKey { get; set; }
        public string SeriesInfo { get; set; }
        public int? ZeroImg { get; set; }

        public override string ToString()
        {
            var
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }

    }
}
