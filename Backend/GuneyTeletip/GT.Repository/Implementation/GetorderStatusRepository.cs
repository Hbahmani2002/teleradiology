using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class GetorderStatusRepository : AbstractTableRepository<StmGetorderStatusforAccessionnumberlist>
    {
        public GetorderStatusRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override StmGetorderStatusforAccessionnumberlist GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
