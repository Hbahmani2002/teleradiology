using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.Persistance.Domain.infinity.Models;
using GT.Repository.infinity.Conditions;
using GT.Repository.infinity.Model.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Implementation.CompositeView
{
    public class KosInstanceCompositeRepository : AbstractRepository
    {
        public KosInstanceCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public IQueryable<KosInstanceViewModel> Query(InfStudyConditionFilter f, SeriesConditionFilter s)
        {
            var exp1 = InfStudyCondition.Get(f);
            var exp2 = SeriesCondition.Get(s);
            return Query(exp1,exp2);
        }
        public IQueryable<KosInstanceViewModel> Query(Expression<Func<Study, bool>> exp1,
            Expression<Func<Series, bool>> exp2)
        {
            var study = _AbstractWorkspace.Query<Study>(exp1);
            var series = _AbstractWorkspace.Query<Series>(exp2);
            var instance = _AbstractWorkspace.Query<Instance>();
            var instanceLoc = _AbstractWorkspace.Query<Instanceloc>();
            var volume = _AbstractWorkspace.Query<Volume>();
            var image = _AbstractWorkspace.Query<Image>();
            var list = from s in study
                       join se in series on s.StudyKey equals se.StudyKey
                       join i in instance on se.SeriesKey equals i.SeriesKey
                       join il in instanceLoc on i.InstanceKey equals il.InstanceKey
                       join im in image on i.InstanceKey equals im.InstanceKey
                       join v in volume on il.VolumeCode equals v.VolumeCode
                       select new KosInstanceViewModel
                       {
                           PatientID=s.PatientId,
                           PatientName=s.PatientName,
                           StudyKey=s.StudyKey,
                           StudyInstanceUID=s.StudyInstanceUid,
                           SeriesInstanceUID=se.SeriesInstanceUid,
                           SopInstanceUID=i.SopInstanceUid,
                           AccessNo=s.AccessNo,
                           Modalities=s.Modalities,
                           SeriesInfo=se.SeriesInfo,
                           FileName=il.Filename,
                           InstanceLogPathName=il.Pathname,
                           VolumePathName=v.Pathname
                       };
            return list;
        }
    }
}
