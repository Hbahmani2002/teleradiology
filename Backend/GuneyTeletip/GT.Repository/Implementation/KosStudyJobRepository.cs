using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class KosStudyJobRepository : AbstractTableRepository<KosStudyJob>
    {
        public KosStudyJobRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override KosStudyJob GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
