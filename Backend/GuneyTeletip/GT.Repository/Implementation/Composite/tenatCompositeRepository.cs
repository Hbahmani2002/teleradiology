using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
   
    public class tenatCompositeRepository : AbstractRepository
    {

        public tenatCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {



           


        }



        public string Query(long fktenat)
        {
            var tenantdata = _AbstractWorkspace.Query<Tenant>();
            var tenantskrsdata = _AbstractWorkspace.Query<TenantSkrs>();
       
            var list = from t in tenantdata
                       join s in tenantskrsdata on t.Pk  equals s.FkTenat
                      
                        select new TenantViewModel
                       {
                           TenantAd = t.TenantAd,
                           TenantKisaAd = t.TenantKisaAd,
                           DaySequence = t.DaySequence,
                           Pk  = t.Pk
                        };

            

            return null ;
        }







    }


}
