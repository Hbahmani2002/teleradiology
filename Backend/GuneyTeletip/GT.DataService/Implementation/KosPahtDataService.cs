using Gt.PERSISTANCE;
using GT.DataService.Model;
using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Implementation;
using GT.Repository.Implementation.Composite;
using GT.Repository.Models.View;
using GT.Repository.Models.View.Composite;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static GT.Repository.Conditions.InfStudyConditionFilter;
using static GT.Repository.Conditions.StudyOperationCountCondition;

namespace GT.DataService.Implementation
{


    public class KosPahtDataService : BaseService
    {

        InfStudyRepository _InfStudyRepository;
        TenantCompositeRepository tenatCompositeRepository;
        InfStudyParameterRepository _InfStudyParameterRepository;
        InfBatchRepository _InfBatchRepository;
        InfStudyHistoryRepository infStudyHistoryRepository;
        KosEnumTypeRepository kosEnumTypeRepository;
        ModalityRepository modalityRepository;
        KosDurumIstCompositeRepository kosDurumIstCompositeRepository;
        MakeKosCompositeRepository makeKosCompositeRepository;
        KosStudyJobRepository kosStudyJobRepository;
        KosDeleteCompositeRepository kosDeleteCompositeRepository;
        GetorderStatusCompositeRepository getorderStatusCompositeRepository;
        GetorderStatusRepository getorderStatusRepository;
        StudyOperationCountRepository studyOperationCount;
        KosPahtDataRepository KosPahtDataRepository;

        public KosPahtDataService() : this(null, false)
        {

        }
        public KosPahtDataService(IBussinessContext context, bool sqlLogging = false) : this(context, GTWorkspaceFactory.Create(sqlLogging))
        {

        }
        public KosPahtDataService(IBussinessContext context, AbstractWorkspace Workspace) : base(context, Workspace)
        {
            _InfStudyRepository = new InfStudyRepository(_Workspace);
            tenatCompositeRepository = new TenantCompositeRepository(_Workspace);
            _InfStudyParameterRepository = new InfStudyParameterRepository(_Workspace);
            _InfBatchRepository = new InfBatchRepository(_Workspace);
            infStudyHistoryRepository = new InfStudyHistoryRepository(_Workspace);
            kosEnumTypeRepository = new KosEnumTypeRepository(_Workspace);
            modalityRepository = new ModalityRepository(_Workspace);
            kosDurumIstCompositeRepository = new KosDurumIstCompositeRepository(_Workspace);
            makeKosCompositeRepository = new MakeKosCompositeRepository(_Workspace);
            kosStudyJobRepository = new KosStudyJobRepository(_Workspace);
            kosDeleteCompositeRepository = new KosDeleteCompositeRepository(_Workspace);
            getorderStatusCompositeRepository = new GetorderStatusCompositeRepository(_Workspace);
            getorderStatusRepository = new GetorderStatusRepository(_Workspace);
            studyOperationCount = new StudyOperationCountRepository(_Workspace);
            KosPahtDataRepository = new KosPahtDataRepository(_Workspace);
        

        }

        public void Save(IEnumerable<InfOraclePostgreStudyViewModel> items)
        {

        }

        public string GetTenantKosPaht(string tenantID)
        {
            var item = KosPahtDataRepository.GetByPhatCode(tenantID);
            return item.ReplacePath;
        }


        public int Save_Update(string tenatID)
        {
         
            return 1;
        }

        public IEnumerable<KosStudyParameter> GetTimerParameters(InfStudyParameterConditionFilter filter)
        {
            return _InfStudyParameterRepository
                .Query(filter)
                .ToArray();
        }
        public PagingResult<InfStudyViewModel> GetInfStudyList(Gridable<KosStudyFilter> parms)
        {
            return null;
        }
        public IEnumerable<MakeKosViewModel> GetMakeKosList(Gridable<KosStudyFilter> parms)
        {
            return null;
        }
        public List<MakeKosViewModel> GetMakeKosList(int count)
        {
            return null;
        }

        public List<SentKosViewModel> GetSentKosList(int count)
        {
            return null;
        }



        public string GetAccessionOnekNoByTenantID(long tenantID)
        {
            var item = tenatCompositeRepository.Single(tenantID);
            return item.AccessionNoOnek;
        }

        public InfStudyViewModel GetByID(int id)
        {
            return null;
        }

 
    }
}