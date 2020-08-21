using GT.UTILS.GRID;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dcm4chee.Repository.Models
{
    public class DcmViewModel
    {
        [DataEntityID]
        public long LocationID { get; set; }
        public int TotalCount { get; set; }
        public long InstanseID { get; set; }
        public string Sopiuid { get; set; }
        public long SeriesID { get; set; }
        public string SeriesCuid { get; set; }
        public long StudyID { get; set; }
        public string StudyCuid { get; set; }
        public long? InstanceID { get; set; }
        public long PatientID { get; set; }
        public long StudyPatientID { get; set; }
        public long PersonNameID { get; set; }
        public string Accessionno { get; set; }
        public string FamilyName { get; set; }
        public string StoragePath { get; set; }
        public long? PatID { get; set; }
        public string Modality { get; set; }
        public long? TeletipDurum { get; set; }
        public string TeletipMesaj { get; set; }
        public string PatientSex { get; set; }
        public string StudyDescription { get; set; }
        public string StudyDate { get; set; }
        public string PatBirthdate { get; set; }
        public string Institution { get; set; }
        public int SeriesCount { get; set; }
        public int InstanceCount { get; set; }
        public string Filename { get; set; }
        public string VolumeCode { get; set; }
        public string VolumeType { get; set; }
        public string VolumeStat { get; set; }
        public string VolumePathname { get; set; }
        public DateTime ModifyDttm { get; set; }
        public DateTime CreationDttm { get; set; }
        public string StudyDesc { get; set; }
        public int InfMergeKey { get; set; }
        public string SeriesInfo { get; set; }
        public int ZeroImg { get; set; }
        public string DicomDirPhat { get; set; }
        public string PersonName { get; set; }
        public string StudyDttm { get; set; }
    }


    public class DcmViewModelNew
    {
        [DataEntityID]
        public decimal? StudyKey { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSex { get; set; }
        public string PatientBirthDttm { get; set; }
        public string StudyInstanceUid { get; set; }
        public string StudyDttm { get; set; }
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

        public string DicomDirPhat { get; set; }

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
