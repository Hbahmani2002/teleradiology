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
            var infStudiesLogin = _AbstractWorkspace.Query<KosStudy>(exp);
            var skrs = _AbstractWorkspace.Query<ConstSkrs>();
            var userSkrs = _AbstractWorkspace.Query<UsrTenantSkrs>();
            var list = from i in infStudiesLogin
                       join us in userSkrs on i.FkTenant equals us.FkTenant
                       join s in skrs on us.FkSkrs equals s.Pk
                       select new MakeKosViewModel
                       {
                          AccessionNumber=i.AccessionNo,
                          InputStudyDirectoryPath=i.DicomDirPath,
                          PatientId=i.PatientId,
                          PatientSex=i.Gender,
                          InstitutionName=s.InstitutionName,
                          InstitutionSKRS=s.KurumSkrsAdi
                       };

            return list;
        }
    }
}
