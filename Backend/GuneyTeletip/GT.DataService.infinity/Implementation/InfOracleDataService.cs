using Gt.PERSISTANCE;
using GT.DataService.infinity.Conditions;
using GT.DataService.infinity.Model;
using GT.PERSISTANCE;
using GT.Repository.infinity.Implementation.CompositeView;
using GT.Repository.infinity.Model.View;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.DataService.infinity.Implementation
{
  

    public class InfOracleDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        InfOracleCompositRepository _InfOracleCompositRepository;



        public InfOracleDataService(IBussinessContext context) : base(context)
        {
            _Workspace = InfWorkspaceFactory.Create(true);

            _InfOracleCompositRepository = new InfOracleCompositRepository(_Workspace);


        }


        public List<InfOracleViewModel> GetInfOracleList(InfOracleFilter filter)
        {
            var f = new InfStudyConditionFilter
            {
                AccessionNo= filter.Accession_no,
                InfStudyPkLast = filter.Infstudypklast,
                CreationStartDate = filter.Infcreationstartdate,
                
            };
            return _InfOracleCompositRepository.Query(f);
        }

    }
}
