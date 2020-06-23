﻿using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{
    public class ModalityRepository : AbstractTableRepository<ConstModality>
    {
        public ModalityRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override ConstModality GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
