using GT.Persistance.Domain.infinity.Models;
using GT.Repository.infinity.Conditions;
using GT.Repository.infinity.Model.Filter;
using GT.Repository.infinity.Model.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation
{
    public class StudyRepository : AbstractTableRepository<Study>
    {
        public StudyRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public override Study GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<StudyViewModel> Query(StudyConditionFilter s)
        {
            var res = StudyCondition.Get(s);

            return Query(res);
        }
        private IQueryable<StudyViewModel> Query(Expression<Func<Study, bool>> exp)
        {
            var study = _AbstractWorkspace.Query<Study>(exp);
            var list = from s in study
                       select new StudyViewModel
                       {
                           AccessNo=s.AccessNo,
                           InstanceCount=s.InstanceCount,
                           Modalities=s.Modalities,
                           PatientID=s.PatientId,
                           PatientName=s.PatientName,
                           PatientSex=s.PatientSex,
                           StudyInstanceUID=s.StudyInstanceUid
                       };
            return list;
        }
    }
}
