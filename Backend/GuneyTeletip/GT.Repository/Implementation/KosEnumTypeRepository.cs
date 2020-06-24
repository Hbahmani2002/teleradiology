using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class KosEnumTypeRepository : AbstractTableRepository<KosEnumtype>
    {
        public KosEnumTypeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override KosEnumtype GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
