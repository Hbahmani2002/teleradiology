using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class AppParameterRepository : AbstractTableRepository<AppParameter>
    {
        public AppParameterRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override AppParameter GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
