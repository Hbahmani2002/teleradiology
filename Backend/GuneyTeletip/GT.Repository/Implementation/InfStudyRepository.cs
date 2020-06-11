using GT.Persistance.Domain.Models;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class InfStudyRepository : AbstractTableRepository<InfStudy>
    {
        public InfStudyRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override InfStudy GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
