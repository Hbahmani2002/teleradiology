using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View.Composite;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
    public class MakeKosCompositeRepository : AbstractRepository
    {
        public MakeKosCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public IEnumerable<MakeKosViewModel> Query(InfStudyConditionFilter filter)
        {
            var exp = InfStudyCondition.Get(filter);
            return Query(exp);
        }

        public IEnumerable<MakeKosViewModel> Query(Expression<Func<KosStudy, bool>> exp)
        {
            var kosStudy = _AbstractWorkspace.Query<KosStudy>(exp);
            var skrs = _AbstractWorkspace.Query<ConstSkrs>();
            var userSkrs = _AbstractWorkspace.Query<UsrTenantSkrs>();
            var list = from k in kosStudy
                       join us in userSkrs on k.FkTenant equals us.FkTenant
                       join s in skrs on us.FkSkrs equals s.Pk
                       select new MakeKosViewModel
                       {
                          AccessionNumber=k.AccessionNo,
                          InputStudyDirectoryPath=k.DicomDirPath,
                          PatientId=k.PatientId,
                          PatientSex=k.Gender,
                          InstitutionName=s.InstitutionName,
                          InstitutionSKRS=s.KurumSkrsAdi,
                          StudyID=k.Pk
                       };

            return list;
        }
    }
}
