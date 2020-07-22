using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class AppFilePathRepository : AbstractTableRepository<AppFilePath>
    {
        public AppFilePathRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override AppFilePath GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }
    }
}
