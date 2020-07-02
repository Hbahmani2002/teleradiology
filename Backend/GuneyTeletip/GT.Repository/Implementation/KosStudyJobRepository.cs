using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using static GT.Repository.Conditions.StudyOperationCountCondition;

namespace GT.Repository.Implementation
{
    public class KosStudyJobRepository : AbstractTableRepository<KosStudyJob>
    {
        public KosStudyJobRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override KosStudyJob GetByID(long id)
        {
            return Single(o => o.Pk==id);
        }
        public IQueryable<SentKosViewModel> Query(InfStudyConditionFilter i, StudyOperationCountConditionFilter s)
        {
            var exp1 = InfStudyCondition.Get(i);
            var exp2 = StudyOperationCountCondition.Get(s);
            return Query(exp1, exp2);
        }
        public IQueryable<SentKosViewModel> Query(Expression<Func<KosStudy, bool>> exp1, Expression<Func<StudyOperationCount, bool>> exp2)
        {
            var kosStudy = _AbstractWorkspace.Query<KosStudy>(exp1);
            var failCount = _AbstractWorkspace.Query<StudyOperationCount>(exp2);
            var list = from k in kosStudy
                       join fc in failCount on k.Pk equals fc.FkStudy
                        into ps3  from fc in ps3.DefaultIfEmpty()
                       select new SentKosViewModel
                       {
                           PatientId=k.PatientId,
                           DicomPath=k.DicomDirPath,
                           StudyID=k.Pk,
                           SendDicomPath =k.DicomKosPath

                       };
            return list;
        }
    }
}
