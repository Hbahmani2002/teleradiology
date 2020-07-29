using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
    public class KosDurumOrderCompositeRepository : AbstractRepository
    {
        public KosDurumOrderCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public IQueryable<KosDurumViewModel> Query(InfStudyConditionFilter filter)
        {
            var exp = InfStudyCondition.Get(filter,0);
            return Query(exp);
        }
        public IQueryable<KosDurumViewModel> Query(Expression<Func<KosStudy, bool>> exp)
        {
             var tenantSkrs = _AbstractWorkspace.Query<UsrTenantSkrs>();
            var skrs = _AbstractWorkspace.Query<ConstSkrs>();
            var study= _AbstractWorkspace.Query<KosStudy>(exp);
            var stmorder = _AbstractWorkspace.Query<StmGetorderStatusforAccessionnumberlist>();




            var list = from s in study 
                       join stmo in stmorder on s.AccessionNo equals  stmo.Accessionnumber into ps2 from stmo in ps2.DefaultIfEmpty()


                       join t in tenantSkrs on s.FkTenant equals t.FkTenant
                       join sk in skrs on t.FkSkrs equals sk.Pk
                       where stmo.Accessionnumber == null







            select new KosDurumViewModel
                       {
                           AccessionNumber=s.AccessionNo,
                           KurumSkrsKodu=sk.KurumSkrsKodu,
                           StudyID=s.Pk,
                           StudyInstanceID=s.StudyInstanceuid,
                           KurumMedulaTesisKodu = sk.KurumMedulaTesisKodu
                           
                       };






            return list;
        }
    }
}
