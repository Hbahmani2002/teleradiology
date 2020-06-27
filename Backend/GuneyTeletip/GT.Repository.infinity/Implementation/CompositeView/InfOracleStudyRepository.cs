using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.Persistance.Domain.infinity.Models;
using GT.Repository.infinity.Model.View;
using GT.REPOSITORY;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.infinity.Implementation.CompositeView
{
    public class InfOracleStudyRepository : AbstractTableRepository<Study>
    {
        public InfOracleStudyRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override Study GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Study> Query(InfStudyConditionFilter f)
        {
            var exp = InfStudyCondition.Get(f);
            return Query(exp);

        }
    }
}
