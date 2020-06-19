using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.Persistance.Domain.infinity.Models;
using GT.Repository.infinity.Model.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Implementation.CompositeView
{
    public class InfOracleCompositRepository : AbstractRepository
    {
        public InfOracleCompositRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public List<InfOracleViewModel> Query(Expression<Func<Study, bool>> exp)
        {


            var infstudy = _AbstractWorkspace.Query<Study>(exp);
            var infseries = _AbstractWorkspace.Query<Series>();
            var infinstance = _AbstractWorkspace.Query<Instance>();
            var infinstanceLoc = _AbstractWorkspace.Query<Instanceloc>();
            var infvolume = _AbstractWorkspace.Query<Volume>();
            var infimage = _AbstractWorkspace.Query<Image>();

            var list = from stdy in infstudy
                       join seri in infseries on stdy.StudyKey equals seri.StudyKey
                       join ins in infinstance on seri.SeriesKey equals ins.SeriesKey
                       join insloc in infinstanceLoc on ins.InstanceKey equals insloc.InstanceKey
                       join vol in infvolume on insloc.VolumeCode equals vol.VolumeCode
                       join img in infimage on insloc.InstanceKey equals img.InstanceKey

                       select new InfOracleViewModel
                       {

                           
                           StudyKey = stdy.StudyKey,
                           PatientId = stdy.PatientId,
                           PatientName = stdy.PatientName,
                           PatientSex = stdy.PatientSex,
                           PatientBirthDttm= stdy.PatientBirthDttm,
                           StudyInstanceUid= stdy.StudyInstanceUid,
                           StudyDttm = stdy.StudyDttm,
                           AccessNo = stdy.AccessNo,
                           Institution= stdy.Institution,
                           SeriesCount= stdy.SeriesCount,
                           InstanceCount = stdy.InstanceCount,
                           Modalities = stdy.Modalities,
                           Pathname = insloc.Pathname,
                           Filename = insloc.Filename,
                           VolumeCode=vol.VolumeCode,
                           VolumeType=vol.VolumeType ,
                           VolumeStat = vol.VolumeStat,
                           VolumePathname =vol.Pathname,
                           ModifyDttm = stdy.ModifyDttm,
                           CreationDttm = stdy.CreationDttm





                       };



            return list.ToList();
        }



                public List<InfOracleViewModel> Query(InfStudyConditionFilter filter)
                {

                    var exp = InfStudyCondition.Get(filter);
                    return Query(exp);

                }


            //public IQueryable<InfOracleViewModel> QueryGrid()
            //{


            //    var infstudy = _AbstractWorkspace.Query<Study>();
            //    var infseries = _AbstractWorkspace.Query<Series>();
            //    var infinstance = _AbstractWorkspace.Query<Instance>();
            //    var infinstanceLoc = _AbstractWorkspace.Query<Instanceloc>();
            //    var infvolume = _AbstractWorkspace.Query<Volume>();
            //    var infimage = _AbstractWorkspace.Query<Image>();

            //    var list = from stdy in infstudy
            //               join seri in infseries on stdy.StudyKey equals seri.StudyKey
            //               join ins in infinstance on seri.SeriesKey equals ins.SeriesKey
            //               join insloc in infinstanceLoc on ins.InstanceKey equals insloc.InstanceKey
            //               join vol in infvolume on insloc.VolumeCode equals vol.VolumeCode
            //               join img in infimage on insloc.InstanceKey equals img.InstanceKey

            //               select new InfOracleViewModel
            //               {


            //                   StudyKey = stdy.StudyKey,
            //                   PatientId = stdy.PatientId,
            //                   PatientName = stdy.PatientName,
            //                   PatientSex = stdy.PatientSex,
            //                   PatientBirthDttm = stdy.PatientBirthDttm,
            //                   StudyInstanceUid = stdy.StudyInstanceUid,
            //                   StudyDttm = stdy.StudyDttm,
            //                   AccessNo = stdy.AccessNo,
            //                   Institution = stdy.Institution,
            //                   SeriesCount = stdy.SeriesCount,
            //                   InstanceCount = stdy.InstanceCount,
            //                   Modalities = stdy.Modalities,
            //                   Pathname = insloc.Pathname,
            //                   Filename = insloc.Filename,
            //                   VolumeCode = vol.VolumeCode,
            //                   VolumeType = vol.VolumeType,
            //                   VolumeStat = vol.VolumeStat,
            //                   VolumePathname = vol.Pathname,
            //                   ModifyDttm = stdy.ModifyDttm,
            //                   CreationDttm = stdy.CreationDttm





            //               };



            //    return list;
            //}

        }
}
