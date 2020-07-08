using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation
{
    public class TeletipStatusRepository : AbstractTableRepository<StmTeletipStatus>
    {
        public TeletipStatusRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override StmTeletipStatus GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<TeletipStatusViewModel> Query()
        {
            return base.Query().Select(o => new TeletipStatusViewModel
            {
                ID = o.Pk,
                Name = o.Name
            });
        }
    }
}
