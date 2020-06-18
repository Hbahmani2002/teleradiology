using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GT.DataService.Implementation
{


    public class InfStudyDataService : BaseService
    {
        AbstractWorkspace _Workspace;
        InfStudyRepository _InfStudyRepository;
        TenantCompositeRepository tenatCompositeRepository;

        InfStudyParameterRepository _InfStudyParameterRepository;
        InfBatchRepository _InfBatchRepository;
        public InfStudyDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            _InfStudyRepository = new InfStudyRepository(_Workspace);
            tenatCompositeRepository = new TenantCompositeRepository(_Workspace);
            _InfStudyParameterRepository = new InfStudyParameterRepository(_Workspace);
            _InfBatchRepository = new InfBatchRepository(_Workspace);
        }

        public void Save(IEnumerable<InfOraclePostgreStudyViewModel> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InfStudyParameter> GetTimerParameters(InfStudyParameterConditionFilter filter)
        {
            return _InfStudyParameterRepository.Query(filter);
        }
        public PagingResult<InfStudyViewModel> GetInfStudyList(Gridable<InfStudyFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<InfStudyFilter>();
            }
            if (parms.Filter == null)
            {
                parms.Filter = new InfStudyFilter();
            }

            var s = new InfStudyConditionFilter
            {

                //Accession_no = parms.Filter.Accession_no,
                //Modality = parms.Filter.Modality,
                //Patinet_id = parms.Filter.Patinet_id,
                //Patine_name = parms.Filter.Patine_name,
                //Pk = parms.Filter.Pk,
            };
            return _InfStudyRepository.QueryGrid(s)
                .GetGridQuery(parms);
        }

        public void Save(IEnumerable<InfStudy> studies)
        {

            var item = new InfBatch();
            item.TimeCreated = DateTime.Now;

            foreach (var study in studies)
            {
                item.InfStudy.Add(study);
            }
            _InfBatchRepository.Add(item);
            _Workspace.CommitChanges();

        }

        public string GetAccessionOnekNoByTenantID(long tenantID)
        {
            var item = tenatCompositeRepository.Single(tenantID);
            return item.AccessionNoOnek;
        }
    }
}