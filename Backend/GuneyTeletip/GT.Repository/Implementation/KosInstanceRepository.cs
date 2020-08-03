using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class KosInstanceRepository : AbstractTableRepository<KosInstance>
    {
        public KosInstanceRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }


        public KosInstance  QueryOracleKosInstanceKey(decimal key)
        {
            return Single(o => o.InstanceLocKey == key);
        }


        public override KosInstance GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
