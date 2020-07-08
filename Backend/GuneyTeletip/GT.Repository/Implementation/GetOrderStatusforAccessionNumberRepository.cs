using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation
{


  public class GetOrderStatusforAccessionNumberRepository : AbstractTableRepository<StmGetorderStatusforAccessionnumberlist>
    {
        public GetOrderStatusforAccessionNumberRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override StmGetorderStatusforAccessionnumberlist GetByID(long id)
        {
            throw new NotImplementedException();
        }


    }


}
