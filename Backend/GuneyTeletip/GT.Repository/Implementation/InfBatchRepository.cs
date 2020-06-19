using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class InfBatchRepository : AbstractTableRepository<InfBatch>
    {
        public InfBatchRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override InfBatch GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
