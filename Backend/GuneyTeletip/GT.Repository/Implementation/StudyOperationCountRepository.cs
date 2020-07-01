using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class StudyOperationCountRepository : AbstractTableRepository<StudyOperationCount>
    {
        public StudyOperationCountRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override StudyOperationCount GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public StudyOperationCount GetByStudyID(long id)
        {
            return Single(o => o.FkStudy==id);
        }
    }
}
