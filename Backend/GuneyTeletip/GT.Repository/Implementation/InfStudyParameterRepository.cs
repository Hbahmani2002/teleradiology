using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation
{
    public class InfStudyParameterRepository : AbstractTableRepository<KosStudyParameter>
    {
        public InfStudyParameterRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override KosStudyParameter GetByID(int id)
        {
            throw new NotImplementedException();
        }





        public  KosStudyParameter GetByTenatID(long tenatID)
        {
            return Single(o => o.FkTenant == tenatID && o.RecordStatus == 1);
        }


        public IEnumerable<KosStudyParameter> Query(InfStudyParameterConditionFilter filter)
        {
            var exp = InfStudyParameterCondition.Get(filter);
            return Query(exp);
        }
    }
}
