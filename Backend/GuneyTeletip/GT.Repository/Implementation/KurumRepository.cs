using Gt.PERSISTANCE;
using GT.Persistance.Domain;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation
{
    public class KurumRepository : AbstractTableRepository<KosKurumlar>
    {
        public KurumRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }


        public override KosKurumlar GetByID(long id)
        {
            return Single(o => o.KurumOnEk == Convert.ToString(id)) ;
        }

        //public IEnumerable<KurumViewModel> Query(KurumlarConditionFilter t)
        //{
        //    var res = KurumCondition.Get(t);

        //    return Query(res);
        //}

        //private IEnumerable<KurumViewModel> Query(Expression<Func<Persistance.Domain.Models.UsrTenant, bool>> res)
        //{
        //    throw new NotImplementedException();
        //}

        private IEnumerable<KurumViewModel> Query(Expression<Func<KosKurumlar, bool>> exp)
        {
            var kurum = _AbstractWorkspace.Query<KosKurumlar>(exp);
            var list = from t in kurum
                       select new KurumViewModel
                       {
                           KurumAd=t.KurumAd,
                           KurumOnEk=t.KurumOnEk
                       };
            return list;
        }
    }
}
