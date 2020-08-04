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
using static GT.Repository.Conditions.StudyOperationCountCondition;

namespace GT.Repository.Implementation.Composite
{
    public class MakeKosCompositeRepository : AbstractRepository
    {
        public MakeKosCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public IEnumerable<MakeKosViewModel> Query(InfStudyConditionFilter i, StudyOperationCountConditionFilter s)
        {
            var exp1 = InfStudyCondition.Get(i,1);
            var exp2 = StudyOperationCountCondition.Get(s);
            return Query(exp1, exp2);

         



        }

        public IEnumerable<MakeKosViewModel> Query(Expression<Func<KosStudy, bool>> exp1, Expression<Func<StudyOperationCount, bool>> exp2)
        {
            var kosStudy = _AbstractWorkspace.Query<KosStudy>(exp1);
            var skrs = _AbstractWorkspace.Query<ConstSkrs>();
            var userSkrs = _AbstractWorkspace.Query<UsrTenantSkrs>();
            var failCount = _AbstractWorkspace.Query<StudyOperationCount>(exp2);
            var kosTenat = _AbstractWorkspace.Query<UsrTenant>();

            var list = from k in kosStudy
                       join us in userSkrs on k.FkTenant equals us.FkTenant
                       join t in kosTenat on us.FkTenant equals t.Pk
                       join s in skrs on us.FkSkrs equals s.Pk
                       join fc in failCount on k.Pk equals fc.FkStudy
         
                       into ps3 from fc in ps3.DefaultIfEmpty()
                       select new MakeKosViewModel
                       {
                          AccessionNumber=k.AccessionNo,
                          InputStudyDirectoryPath=k.DicomDirPath,
                          PatientId=k.PatientId,
                          PatientSex=k.Gender,
                          InstitutionName=t.TenantShortName,
                          InstitutionSKRS=s.KurumSkrsKodu,
                          StudyID=k.Pk,
                       };

            return list;
        }
    }
}
