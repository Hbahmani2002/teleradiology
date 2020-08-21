using Dcm4chee.Persistance.Domain.Models;
using Dcm4chee.Repository.Conditions;
using Dcm4chee.Repository.Models;
using Gt.PERSISTANCE;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dcm4chee.Repository.Implementation.Composite
{
    public class DcmCompositeRepository : AbstractRepository
    {
        public DcmCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<DcmViewModelNew> Query(StudyConditionFilter s, SeriesConditionFilter se)
        {
            var exp1 = StudyCondition.Get(s);
            var exp2 = SeriesCondition.Get(se);
            return Query(exp1,exp2);
        }

        public IQueryable<DcmViewModelNew> Query(Expression<Func<Study, bool>> exp1, Expression<Func<Series, bool>> exp2)
        {
            var location = _AbstractWorkspace.Query<Location>();
            var instance = _AbstractWorkspace.Query<Instance>();
            var series = _AbstractWorkspace.Query<Series>(exp2);
            var study = _AbstractWorkspace.Query<Study>(exp1);
            var patient = _AbstractWorkspace.Query<Patient>();
            var patientID = _AbstractWorkspace.Query<PatientId>();
            var personName = _AbstractWorkspace.Query<PersonName>();
            var list = from l in location
                       join i in instance on l.InstanceFk equals i.Pk
                       join s in series on i.SeriesFk equals s.Pk
                       join stdy in study on s.StudyFk equals stdy.Pk
                       join pa in patient on stdy.PatientFk equals pa.Pk
                       join pi in patientID on pa.PatientIdFk equals pi.Pk
                       join pe in personName on pa.PatNameFk equals pe.Pk
                       //select new DcmViewModel
                       //{
                       //    LocationID = l.Pk,
                       //    InstanseID = i.Pk,
                       //    Sopiuid = i.SopCuid,
                       //    SeriesID = s.Pk,
                       //    SeriesCuid = s.SopCuid,
                       //    StudyID = s.StudyFk,
                       //    StudyCuid = stdy.StudyIuid,
                       //    InstanceID = l.InstanceFk,
                       //    PatientID = pa.Pk,
                       //    StudyPatientID = stdy.PatientFk,
                       //    PersonNameID = pe.Pk,
                       //    StoragePath = l.StoragePath,
                       //    PatID = pa.PatNameFk,
                       //    Modality = s.Modality,
                       //    TeletipDurum = l.TeletipDurum,
                       //    TeletipMesaj = l.TeletipMesaj,
                       //    Accessionno = stdy.AccessionNo,
                       //    FamilyName = pe.FamilyName,
                       //    PatientSex = pa.PatSex,
                       //    StudyDescription = stdy.StudyDesc,
                       //    StudyDate = stdy.StudyDate,
                       //    PatBirthdate = pa.PatBirthdate,
                       //    Institution = s.Institution,
                       //    SeriesCount = 0,
                       //    InstanceCount = 0,
                       //    Filename = "dcm",
                       //    VolumeCode = "fs1",
                       //    VolumeType = "fs1",
                       //    VolumeStat = "fs1",
                       //    VolumePathname = "fs1",
                       //    ModifyDttm = stdy.CreatedTime,
                       //    CreationDttm = stdy.AccessTime,
                       //    StudyDesc = "fs1",
                       //    InfMergeKey = 0,
                       //    SeriesInfo = "SeriesInfo",
                       //    ZeroImg = 0,
                       //    DicomDirPhat = l.StoragePath.Substring(0, 22) + "/" + stdy.StudyIuid,
                       //    StudyDttm = stdy.StudyDate
                       //};




            select new DcmViewModelNew
            {
                StudyKey = stdy.Pk,
                PatientId = pi.PatId,
                PatientName = pe.FamilyName +" "+ pe.GivenName,
                PatientSex = pa.PatSex ,
                PatientBirthDttm =  pa.PatBirthdate ,
                StudyInstanceUid = stdy.StudyIuid,
                StudyDttm = stdy.StudyDate,
                AccessNo = stdy.AccessionNo ,
                Institution = s.Institution,
                SeriesCount = 0,
                InstanceCount = 0,
                Modalities = s.Modality,
                Pathname = l.StoragePath,
                Filename = "",
                VolumeCode = "fs1",
                VolumeType = "fs1",
                VolumeStat ="fs1",
                VolumePathname = "/mnt/",
                ModifyDttm = DateTime.Now ,
                CreationDttm = stdy.CreatedTime,
                StudyDesc = stdy.StudyDesc,
                InfMergeKey = 0,
                SeriesInfo = "",
                DicomDirPhat = l.StoragePath.Substring(0, 22) + "/" + stdy.StudyIuid

            };
            var groupList = list.GroupBy(g => new
            {
                g.StudyKey,
                g.PatientId,
                g.PatientName,
                g.PatientSex,
                g.PatientBirthDttm,
                g.StudyInstanceUid,
                g.StudyDttm,
                g.AccessNo,
                g.Institution,
                g.Modalities,
                g.ModifyDttm,
                g.CreationDttm,
                g.DicomDirPhat,
                g.VolumeCode,
                g.VolumePathname
         
            }).Select(o => new DcmViewModelNew
            {


                StudyKey = o.Key.StudyKey,
                PatientId=o.Key.PatientId,
                PatientName = o.Key.PatientName,
                PatientSex = o.Key.PatientSex,
                PatientBirthDttm=o.Key.PatientBirthDttm,
                StudyInstanceUid=o.Key.StudyInstanceUid,
                StudyDttm=o.Key.StudyDttm,
                AccessNo=o.Key.AccessNo,
                Institution=o.Key.Institution,
                Modalities=o.Key.Modalities,
                ModifyDttm=o.Key.ModifyDttm,
                CreationDttm=o.Key.CreationDttm,
                DicomDirPhat=o.Key.DicomDirPhat,
                VolumeCode=o.Key.VolumeCode,
                VolumePathname=o.Key.VolumePathname
             
            







                //  StudyKey = stdy.StudyKey,
                //PatientId = stdy.PatientId,
                //PatientName = stdy.PatientName,
                //PatientSex = stdy.PatientSex,
                //PatientBirthDttm = stdy.PatientBirthDttm.Value,
                //StudyInstanceUid = stdy.StudyInstanceUid,
                //StudyDttm = stdy.StudyDttm,
                //AccessNo = stdy.AccessNo,
                //Institution = stdy.Institution,
                //SeriesCount = stdy.SeriesCount,
                //InstanceCount = stdy.InstanceCount,
                //Modalities = stdy.Modalities,
                //Pathname = insloc.Pathname,
                //Filename = insloc.Filename,
                //VolumeCode = vol.VolumeCode,
                //VolumeType = vol.VolumeType,
                //VolumeStat = vol.VolumeStat,
                //VolumePathname = vol.Pathname,
                //ModifyDttm = stdy.ModifyDttm.Value,
                //CreationDttm = stdy.CreationDttm.Value,
                //StudyDesc = stdy.StudyDesc,
                //InfMergeKey = stdy.MergeKey,
                //SeriesInfo = seri.SeriesInfo











            });
            return groupList;
        }
    }
}
