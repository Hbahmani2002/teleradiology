using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation
{
    public class InfStudyHistoryRepository : AbstractTableRepository<KosStudyHistory>
    {
        public InfStudyHistoryRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override KosStudyHistory GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<KosStudyHistory> GetByKosStudyID(long id)
        {
            return Query(o => o.FkKosStudy== id);
        }
    }
}
