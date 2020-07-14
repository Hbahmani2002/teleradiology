using Dcm4chee.Persistance.Domain.Models;
using Dcm4chee.Repository.Models;
using Gt.PERSISTANCE;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dcm4chee.Repository.Implementation
{
    public class InstanceRepository : AbstractTableRepository<Instance>
    {
        public InstanceRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override Instance GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InstanceViewModel> InstanceList()
        {
            return Query().Select(o =>  new InstanceViewModel { 
                InstNo=o.InstNo
            });
        }
    }
}
