using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation
{
    public class InfStudyParameterRepository : AbstractTableRepository<InfStudyParameter>
    {
        public InfStudyParameterRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override InfStudyParameter GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InfStudyParameter> Query(InfStudyParameterConditionFilter filter)
        {
            var exp = InfStudyParameterCondition.Get(filter);
            return Query(exp);
        }
    }
}
