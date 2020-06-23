using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class EnumTypeJobRepository : AbstractTableRepository<JobEnumtype>
    {
        public EnumTypeJobRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override JobEnumtype GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public JobEnumtype GetByName(string name)
        {
            return Single(o => o.Name == name);
        }
    }
}
