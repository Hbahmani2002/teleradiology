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
        public IQueryable<SentKosViewModel> Query(InfStudyConditionFilter filter)
        {
            var exp = InfStudyCondition.Get(filter);
            return Query(exp);
        }
        public IQueryable<SentKosViewModel> Query(Expression<Func<KosStudy, bool>> exp)
        {
            var kosStudy = _AbstractWorkspace.Query<KosStudy>(exp);
            var list = from k in kosStudy
                       select new SentKosViewModel
                       {
                           PatientId=k.PatientId,
                           DicomPath=k.DicomDirPath,
                           StudyID=k.Pk
                       };
            return list;
        }
    }
}
