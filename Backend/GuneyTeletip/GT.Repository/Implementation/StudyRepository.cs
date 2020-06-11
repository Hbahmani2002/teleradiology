using GT.Persistance.Domain.infinity.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class StudyRepository : AbstractTableRepository<Study>
    {
        public StudyRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public override Study GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
