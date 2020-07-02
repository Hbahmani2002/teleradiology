using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Repository.Implementation
{



    public class KosPahtDataRepository : AbstractTableRepository<KosPaht>
    {

        public KosPahtDataRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public  KosPaht GetByPhatCode(string PahtCode)
        {
            return Single(o => o.PahtCode == PahtCode);
        }

        public override KosPaht GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }



}
