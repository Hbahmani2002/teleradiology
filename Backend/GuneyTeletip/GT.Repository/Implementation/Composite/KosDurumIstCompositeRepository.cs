using Gt.PERSISTANCE;
using GT.Persistance.Domain.Models;
using GT.Repository.Models.View;
using GT.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.Repository.Implementation.Composite
{
    public class KosDurumIstCompositeRepository : AbstractRepository
    {
        public KosDurumIstCompositeRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public IEnumerable<KosDurumIstModel> Query()
        {
            var study = _AbstractWorkspace.Query<KosStudy>();
            var kosEnumType = _AbstractWorkspace.Query<KosEnumtype>();

            var query = from s in study
                        join k in kosEnumType on s.FkKosEnumType equals k.Pk
                        select new 
                        {
                            KosEnumTypeID=k.Pk,
                            KosEnumTypeName=k.Name
                        };
            var groupList = query.GroupBy(o => new 
            {
                ID=o.KosEnumTypeID,
                Name=o.KosEnumTypeName
            }).Select(o => new KosDurumIstModel { 
                ID=o.Key.ID,
                Name=o.Key.Name,
                TotalCount=o.Count()
            });

            return groupList;
        }
    }
}
