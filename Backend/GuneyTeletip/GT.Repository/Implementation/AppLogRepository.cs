using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class AppLogRepository : AbstractTableRepository<AppLog>
    {
        public AppLogRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override AppLog GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
