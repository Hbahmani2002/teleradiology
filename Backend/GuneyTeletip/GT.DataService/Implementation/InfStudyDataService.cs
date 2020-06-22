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
        InfStudyHistoryRepository infStudyHistoryRepository;
        KosEnumTypeRepository kosEnumTypeRepository;
        ModalityRepository modalityRepository;
        KosDurumIstCompositeRepository kosDurumIstCompositeRepository;
        public InfStudyDataService(IBussinessContext context) : base(context)
        {
            _Workspace = GTWorkspaceFactory.Create(true);
            _InfStudyRepository = new InfStudyRepository(_Workspace);
            tenatCompositeRepository = new TenantCompositeRepository(_Workspace);
            _InfStudyParameterRepository = new InfStudyParameterRepository(_Workspace);
            _InfBatchRepository = new InfBatchRepository(_Workspace);
            infStudyHistoryRepository = new InfStudyHistoryRepository(_Workspace);
            kosEnumTypeRepository = new KosEnumTypeRepository(_Workspace);
            modalityRepository = new ModalityRepository(_Workspace);
            kosDurumIstCompositeRepository = new KosDurumIstCompositeRepository(_Workspace);
        }

        public void Save(IEnumerable<InfOraclePostgreStudyViewModel> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KosStudyParameter> GetTimerParameters(InfStudyParameterConditionFilter filter)
        {
            return _InfStudyParameterRepository
                .Query(filter)
                .ToArray();
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
                HastaneIDList=parms.Filter.HastaneIDList,
                AccessionNumberList=parms.Filter.AccessionNumberList,
                BasTarih=parms.Filter.BasTarih,
                BitTarih=parms.Filter.BitTarih,
                Modality=parms.Filter.Modalite,
                TcList=parms.Filter.TCList
            };
            return _InfStudyRepository.Query(s)
                .GetGridQuery(parms);
        }

        public void Save(IEnumerable<KosStudy> studies)
        {

            var item = new KosBatch();
            item.TimeCreated = DateTime.Now;

            foreach (var study in studies)
            {
                item.KosStudy.Add(study);
            }
            _InfBatchRepository.Add(item);
            _Workspace.CommitChanges();

        }

        public string GetAccessionOnekNoByTenantID(long tenantID)
        {
            var item = tenatCompositeRepository.Single(tenantID);
            return item.AccessionNoOnek;
        }

        public InfStudyViewModel GetByID(int id)
        {
            var infStudy = _InfStudyRepository.GetByID(id);
            var item = new InfStudyViewModel
            {
                AccessionNumber= infStudy.AccessionNo,
                Desc1= infStudy.Desc1,
                Desc2= infStudy.Desc2,
                Desc3= infStudy.Desc3,
                Gender=infStudy.Gender,
                InstitutionName= infStudy.InstitutionName,
                ID= infStudy.Pk,
                PatientID= infStudy.PatientId,
                FileName= infStudy.FileName,
                CreationDttm= infStudy.CreationDttm,
                InstanceKey= infStudy.InstanceKey,
                DateBirth= infStudy.DateBirth,
                Institution= infStudy.Institution,
                CihazDeviceSerialNumber= infStudy.CihazDeviceSerialNumber,
                Modality= infStudy.Modality,
                OracleStudyKey= infStudy.OracleStudyKey,
                InfBatchID= infStudy.FkInfBatch,
                InstanceCount= infStudy.InstanceCount,
                SeriesCount= infStudy.SeriesCount,
                SeriesKey= infStudy.SeriesKey,
                StudyDate= infStudy.StudyDate,
                StudyInstanceuid= infStudy.StudyInstanceuid,
                ValumeCode= infStudy.ValumeCode,
                StudyDescription= infStudy.StudyDescription,
                UserIDCreated= infStudy.FkUserCreated,
                TimeCreated= infStudy.TimeCreated,
                PatientName= infStudy.PatinetNameSurname,
                TimeModified= infStudy.TimeModified,
                ValumePathname= infStudy.ValumePathname,
                ValumeStat= infStudy.ValumeStat,
                UserIDModfiead= infStudy.FkUserModfiead,
                ValumeType= infStudy.ValumeType,
                TenantID= infStudy.FkTenant,
                StoragePath= infStudy.StoragePath,
                HastaNo= infStudy.PatientId,
            };
            return item;
        }

        public PagingResult<KosHistoryModel> GetKosHistoryByStudyID(Gridable<KosHistoryFilter> parms)
        {
            return infStudyHistoryRepository.GetByKosStudyID(parms.Filter.StudyID)
                .Select(o => new KosHistoryModel { 
                    EnumType=o.EnumType,
                    ID=o.Pk,
                    KosStudyID=o.FkKosStudy,
                    Result=o.Result,
                    TimeCreated=o.TimeCreated,
                    TimeModified=o.TimeModified,
                    UserIDCreated=o.FkUserCreated,
                    UserIDModified=o.FkUserModified
                }).GetGridQuery(parms);
        }

        public List<KosEnumTypeViewModel> GetEnumTypeList()
        {
            return kosEnumTypeRepository.Query().Select(o => new KosEnumTypeViewModel{
                ID=o.Pk,
                Name=o.Name
            }).ToList();
        }

        public List<KosEnumTypeViewModel> GetModalityList()
        {
            return modalityRepository.Query().Select(o => new KosEnumTypeViewModel
            {
                ID = o.Pk,
                Name = o.Name
            }).ToList();
        }

        public List<KosDurumIstModel> GetKosDurumIst()
        {
            return kosDurumIstCompositeRepository.Query().ToList();
        }

        public long UpdateKosDurum(int kosStudyID, int kosEnumID)
        {
            var kosStudyHistory = new KosStudyHistory();
            kosStudyHistory.EnumType = kosEnumID;
            kosStudyHistory.FkKosStudy = kosStudyID;
            kosStudyHistory.FkUserCreated = Context.UserInfo.UserIDCurrent;
            kosStudyHistory.TimeCreated = DateTime.Now;
            //result ?

            var kosStudy = _InfStudyRepository.GetByID(kosStudyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID"+ kosStudyID);
            }
            kosStudy.FkKosEnumType = kosEnumID;
            _InfStudyRepository.Update(kosStudy);

            _Workspace.CommitChanges();
            return kosStudy.Pk;
        }
    }
}