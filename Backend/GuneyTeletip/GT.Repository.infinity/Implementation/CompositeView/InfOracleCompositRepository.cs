using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.Persistance.Domain.infinity.Models;
using GT.Repository.infinity.Model.View;
using GT.REPOSITORY;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Implementation.CompositeView
{
    public class InfOracleCompositeRepository : AbstractRepository
    {
        public InfOracleCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IQueryable<InfOracleViewModel> Query(Expression<Func<Study, bool>> exp, Expression<Func<Series, bool>> exp1)
        {


            var infstudy = _AbstractWorkspace.Query<Study>(exp);
            var infseries = _AbstractWorkspace.Query<Series>(exp1);
            var infinstance = _AbstractWorkspace.Query<Instance>();
            var infinstanceLoc = _AbstractWorkspace.Query<Instanceloc>();
            var infvolume = _AbstractWorkspace.Query<Volume>();
            var infimage = _AbstractWorkspace.Query<Image>();

            var query = from stdy in infstudy

                        from seri in infseries.Where(o => o.StudyKey == stdy.StudyKey)
                                           .Take(1)
                                           .DefaultIfEmpty()
                        from ins in infinstance.Where(o => o.SeriesKey == seri.SeriesKey)
                                          .Take(1)
                                          .DefaultIfEmpty()
                        from insloc in infinstanceLoc.Where(o => o.InstanceKey == ins.InstanceKey)
                                          .Take(1)
                                          .DefaultIfEmpty()
                        from vol in infvolume.Where(o => o.VolumeCode == insloc.VolumeCode)
                                          .Take(1)
                                          .DefaultIfEmpty()

                            //let seri = infseries.Where(o => o.StudyKey == stdy.StudyKey).FirstOrDefault()
                            //let ins =  infinstance.Where(o => o.SeriesKey == seri.SeriesKey).FirstOrDefault()
                            //let insloc =  infinstanceLoc.Where(o => o.InstanceKey == ins.InstanceKey).FirstOrDefault()
                            //let vol =  infvolume.Where(o => o.VolumeCode == insloc.VolumeCode).FirstOrDefault()
                            //let img = infimage.Where(o => o.InstanceKey == insloc.InstanceKey).FirstOrDefault()
                            //join seri in infseries on stdy.StudyKey equals seri.StudyKey into t

                            //join ins in infinstance on seri.SeriesKey equals ins.SeriesKey
                            //join insloc in infinstanceLoc on ins.InstanceKey equals insloc.InstanceKey
                            //join vol in infvolume on insloc.VolumeCode equals vol.VolumeCode
                            //join img in infimage on insloc.InstanceKey equals img.InstanceKey

                        select new InfOracleViewModel
                        {
                            StudyKey = stdy.StudyKey,
                            PatientId = stdy.PatientId,
                            PatientName = stdy.PatientName,
                            PatientSex = stdy.PatientSex,
                            PatientBirthDttm = stdy.PatientBirthDttm.Value,
                            StudyInstanceUid = stdy.StudyInstanceUid,
                            StudyDttm = stdy.StudyDttm,
                            AccessNo = stdy.AccessNo,
                            Institution = stdy.Institution,
                            SeriesCount = stdy.SeriesCount,
                            InstanceCount = stdy.InstanceCount,
                            Modalities = stdy.Modalities,                            
                            Pathname = insloc.Pathname,
                            Filename = insloc.Filename,
                            VolumeCode = vol.VolumeCode,
                            VolumeType = vol.VolumeType,
                            VolumeStat = vol.VolumeStat,
                            VolumePathname = vol.Pathname,
                            ModifyDttm = stdy.ModifyDttm.Value,
                            CreationDttm = stdy.CreationDttm.Value,
                            StudyDesc = stdy.StudyDesc,
                            InfMergeKey = stdy.MergeKey,
                            SeriesInfo = seri.SeriesInfo

                        };

            //var g = query.ToList();

            return query;



        }

        public IQueryable<InfOracleViewModel> Query(InfStudyConditionFilter f, InfSerieConditionFilter s)
        {
            var exp = InfStudyCondition.Get(f);
            var exp1 = InfSeriesCondition.Get(s);
            return Query(exp,exp1);

        }



    }
}
