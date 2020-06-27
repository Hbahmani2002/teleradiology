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

namespace GT.DataService.Implementation
{


    public class StudyKosDataService : BaseService
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
        public StudyKosDataService() : this(null, false)
        {

        }
        public StudyKosDataService(IBussinessContext context, bool sqlLogging = false) : this(context, GTWorkspaceFactory.Create(sqlLogging))
        {

        }
        public StudyKosDataService(IBussinessContext context, AbstractWorkspace Workspace) : base(context, Workspace)
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
        }

        public void Save(IEnumerable<InfOraclePostgreStudyViewModel> items)
        {




            var KosBatch = new KosBatch();
            KosBatch.TimeCreated = DateTime.Now;
            KosBatch.FkUserCreated = 1;
            _InfBatchRepository.Add(KosBatch);
            _Workspace.CommitChanges();
            long tenatID = 0;
            decimal Last_OracleStudyKey = 0;



            var list = new List<InfOraclePostgreStudyViewModel>();
            foreach (InfOraclePostgreStudyViewModel item in items)
            {
                var KosStudy = new KosStudy();
                tenatID = item.FkTenant.Value;
                KosStudy.FkTenant = item.FkTenant.Value;
                KosStudy.FkInfBatch = KosBatch.Pk;
                KosStudy.FkUserCreated = null;
                KosStudy.FkUserModified = null;
                KosStudy.PatientId = item.PatientId;
                KosStudy.Gender = item.Gender;
                KosStudy.StudyDescription = item.StudyDescription;
                KosStudy.InstitutionName = item.InstitutionName;
                KosStudy.Modality = item.Modality;
                KosStudy.AccessionNo = item.AccessionNo;
                KosStudy.StudyInstanceuid = item.StudyInstanceuid;
                KosStudy.InstanceCount = 0;
                KosStudy.DateBirth = DateTime.Now;
                KosStudy.StudyDate = DateTime.Now;
                KosStudy.StoragePath = item.StoragePath;
                KosStudy.PatinetNameSurname = item.PatinetNameSurname;
                KosStudy.CihazDeviceSerialNumber = "0";
                KosStudy.Desc1 = "";
                KosStudy.Desc2 = "";
                KosStudy.Desc3 = "";
                KosStudy.TimeCreated = DateTime.Now;
                KosStudy.TimeModified = DateTime.Now;
                KosStudy.Institution = "";
                KosStudy.SeriesCount = 0;
                KosStudy.SeriesKey = 0;
                KosStudy.InstanceKey = 0;
                KosStudy.FileName = item.FileName;
                KosStudy.VolumeCode = item.ValumeCode;
                KosStudy.VolumeType = item.ValumeType;
                KosStudy.VolumeStat = item.ValumeStat;
                KosStudy.VolumePathname = item.ValumePathname;
                KosStudy.CreationDttm = DateTime.Now;
                KosStudy.OracleStudyKey = item.OracleStudyKey.Value;
                KosStudy.FkKosEnumType = 10;
                KosStudy.DicomDirPath = item.DicomPhat;
                Last_OracleStudyKey = item.OracleStudyKey.Value;
                _InfStudyRepository.Add(KosStudy);

                _Workspace.CommitChanges();


                var ParamterTimertenatID = _InfStudyParameterRepository.GetByTenatID(tenatID);

                if (ParamterTimertenatID == null)
                {
                    throw new Exception("User bulunamadı. tenatID:" + tenatID);

                }
                else
                {
                    ParamterTimertenatID.OracleStudyKeyLast = Convert.ToInt64(Last_OracleStudyKey);
                    _InfStudyParameterRepository.Update(ParamterTimertenatID);
                }
                _Workspace.CommitChanges();

            }






        }




        public int Save_Update(string tenatID)
        {
            //var InfStudyParameter = new InfStudyParameterRepository();
            //if (tenatID == null)
            //{


            //    userLogin = userLoginRepository.GetByID(model.ID.Value);
            //    if (model.ID == null)
            //    {
            //        throw new Exception("User bulunamadı. UserID:" + model.ID);
            //    }
            //    userLogin.TimeModified = DateTime.Now;
            //    userLogin.FkUserModified = Context.UserInfo.UserIDCurrent;
            //    userLoginRepository.Update(userLogin);
            //}
            //userLogin.EmailAdress = model.EmailAdress;
            //userLogin.Name = model.Name;
            //userLogin.Password = model.Password;
            //userLogin.Surname = model.Surname;
            //userLogin.UserName = model.UserName;
            //userLogin.RecordStatus = model.RecordState;
            //_Workspace.CommitChanges();
            return 1;
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
                HastaneIDList = parms.Filter.HastaneIDList,
                AccessionNumberList = parms.Filter.AccessionNumberList,
                BasTarih = parms.Filter.BasTarih,
                BitTarih = parms.Filter.BitTarih,
                Modality = parms.Filter.Modalite,
                TcList = parms.Filter.TCList,
                KosEnum = parms.Filter.KosEnum
            };
            return _InfStudyRepository.Query(s)
                .GetGridQuery(parms);
        }
        public List<MakeKosViewModel> GetMakeKosList(int count)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosOlusturulamamisOlanlar,
                KosWaitHour = true
            };
            return makeKosCompositeRepository.Query(s).OrderBy(o => o.StudyID).Take(count).ToList();
        }
        public List<SentKosViewModel> GetSentKosList(int count)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosOlusmusOlanlar,
                KosWaitHour = true
            };
            return kosStudyJobRepository.Query(s).OrderBy(o => o.StudyID).Take(count).ToList();
        }
        public List<GetorderStatusViewModel> GetSTMInfoList(int count, string[] accessionNumberList)
        {
            var g = new GetorderStatusConditionFilter
            {
                AccessionNumberList= accessionNumberList
            };
            return getorderStatusCompositeRepository.Query(g).OrderBy(o => o.ID).Take(count).ToList();
        }

        public void Save(IEnumerable<KosStudy> studies)
        {

            var item = new KosBatch();
            item.TimeCreated = DateTime.Now;

            foreach (var study in studies)
            {
                //item.KosStudy.Add(study);
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
                AccessionNumber = infStudy.AccessionNo,
                Desc1 = infStudy.Desc1,
                Desc2 = infStudy.Desc2,
                Desc3 = infStudy.Desc3,
                Gender = infStudy.Gender,
                InstitutionName = infStudy.InstitutionName,
                ID = infStudy.Pk,
                PatientID = infStudy.PatientId,
                FileName = infStudy.FileName,
                CreationDttm = infStudy.CreationDttm,
                InstanceKey = infStudy.InstanceKey,
                DateBirth = infStudy.DateBirth,
                Institution = infStudy.Institution,
                CihazDeviceSerialNumber = infStudy.CihazDeviceSerialNumber,
                Modality = infStudy.Modality,
                OracleStudyKey = infStudy.OracleStudyKey,
                InfBatchID = infStudy.FkInfBatch,
                InstanceCount = infStudy.InstanceCount,
                SeriesCount = infStudy.SeriesCount,
                SeriesKey = infStudy.SeriesKey,
                StudyDate = infStudy.StudyDate,
                StudyInstanceuid = infStudy.StudyInstanceuid,
                ValumeCode = infStudy.VolumeCode,
                StudyDescription = infStudy.StudyDescription,
                UserIDCreated = infStudy.FkUserCreated,
                TimeCreated = infStudy.TimeCreated,
                PatientName = infStudy.PatinetNameSurname,
                TimeModified = infStudy.TimeModified,
                ValumePathname = infStudy.VolumePathname,
                ValumeStat = infStudy.VolumeStat,
                UserIDModfiead = infStudy.FkUserModified,
                ValumeType = infStudy.VolumeType,
                TenantID = infStudy.FkTenant,
                StoragePath = infStudy.StoragePath,
                HastaNo = infStudy.PatientId,
            };
            return item;
        }

        public PagingResult<KosHistoryModel> GetKosHistoryByStudyID(Gridable<KosHistoryFilter> parms)
        {
            return infStudyHistoryRepository.GetByKosStudyID(parms.Filter.StudyID)
                .Select(o => new KosHistoryModel
                {
                    EnumType = o.EnumType,
                    ID = o.Pk,
                    KosStudyID = o.FkKosStudy,
                    Result = o.Result,
                    TimeCreated = o.TimeCreated,
                    TimeModified = o.TimeModified,
                    UserIDCreated = o.FkUserCreated,
                    UserIDModified = o.FkUserModified
                }).GetGridQuery(parms);
        }

        public List<KosEnumTypeViewModel> GetEnumTypeList()
        {
            return kosEnumTypeRepository.Query().Select(o => new KosEnumTypeViewModel
            {
                ID = o.Pk,
                Name = o.Name
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
        public IEnumerable<KosDeleteViewModel> GetKosDeleteList(InfStudyFilter filter)
        {
            if (filter == null)
                filter = new InfStudyFilter();
            var s = new InfStudyConditionFilter
            {
                HastaneIDList = filter.HastaneIDList,
                AccessionNumberList = filter.AccessionNumberList,
                BasTarih = filter.BasTarih,
                BitTarih = filter.BitTarih,
                Modality = filter.Modalite,
                TcList = filter.TCList,
                KosEnum = filter.KosEnum,
                StudyInstanceUID = filter.StudyInstanceUID,
                PatientID = filter.PatientID
            };
            return kosDeleteCompositeRepository.Query(s).ToArray();
        }
        public long Save_UpdateMakeKosDurum(long kosStudyID, bool isSuccess, string kosPath, string statusMessage)
        {
            var newKosState = (int)(isSuccess ? KosEnumType.KosOlusmusOlanlar : KosEnumType.KosOlusturulamamisOlanlar);
            var kosStudyHistory = new KosStudyHistory();
            kosStudyHistory.EnumType = newKosState;
            kosStudyHistory.FkKosStudy = kosStudyID;
            kosStudyHistory.FkUserCreated = Context.UserInfo.UserIDCurrent;
            kosStudyHistory.TimeCreated = DateTime.Now;
            kosStudyHistory.Result = statusMessage;

            var kosStudy = _InfStudyRepository.GetByID(kosStudyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID" + kosStudyID);
            }
            kosStudy.FkKosEnumType = newKosState;
            if (isSuccess)
                kosStudy.DicomKosPath = kosPath;
            _InfStudyRepository.Update(kosStudy);

            _Workspace.CommitChanges();
            return kosStudy.Pk;
        }

        public enum SentKosResult
        {
            Success = 1,
            Fail = 2,
            PartialSuccess
        }
        public long Save_UpdateSentKosDurum(long kosStudyID, SentKosResult result, string statusMessage)
        {
            var newKosState = 0;
            if (result == SentKosResult.Success)
                newKosState = (int)KosEnumType.KosGonderilipEslesenler;
            else if (result == SentKosResult.Fail)
                newKosState = (int)KosEnumType.KosHataliGonderileneler;
            else if (result == SentKosResult.PartialSuccess)
                newKosState = (int)KosEnumType.KosGonderilipEslesmeyenler;

            var kosStudyHistory = new KosStudyHistory();
            kosStudyHistory.EnumType = newKosState;
            kosStudyHistory.FkKosStudy = kosStudyID;
            kosStudyHistory.FkUserCreated = Context.UserInfo.UserIDCurrent;
            kosStudyHistory.TimeCreated = DateTime.Now;
            kosStudyHistory.Result = statusMessage;

            var kosStudy = _InfStudyRepository.GetByID(kosStudyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID" + kosStudyID);
            }
            kosStudy.FkKosEnumType = newKosState;
            _InfStudyRepository.Update(kosStudy);

            _Workspace.CommitChanges();
            return kosStudy.Pk;
        }

        public long Save_UpdateSTMInfo(long kosStudyID, GetorderStatusViewModel model)
        {
            var accessionNumberList = new StmGetorderStatusforAccessionnumberlist();
            accessionNumberList.Medulainstitutionid = model.Medulainstitutionid;
            accessionNumberList.Accessionnumber = model.Accessionnumber;
            accessionNumberList.Citizenid = model.Citizenid;
            accessionNumberList.Dosestatus = model.Dosestatus;
            accessionNumberList.Dosestatusid = model.Dosestatusid;
            accessionNumberList.Error = model.Error;
            accessionNumberList.FkInfBatch = model.FkInfBatch;
            accessionNumberList.FkKosStudy = model.FkKosStudy;
            accessionNumberList.FkTenant = model.FkTenant;
            accessionNumberList.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
            accessionNumberList.Lastmedulasenddate = model.Lastmedulasenddate;
            accessionNumberList.Medulainstitutionid = model.Medulainstitutionid;
            accessionNumberList.Medularesponsecode = model.Medularesponsecode;
            accessionNumberList.Medularesponsemessage = model.Medularesponsemessage;
            accessionNumberList.Medulastatus = model.Medulastatus;
            accessionNumberList.Medulastatusid = model.Medulastatusid;
            accessionNumberList.Patienthistorysearchstatus = model.Patienthistorysearchstatus;
            accessionNumberList.Patienthistorysearchstatusid = model.Patienthistorysearchstatusid;
            accessionNumberList.Performeddate = model.Performeddate;
            accessionNumberList.Reportstatus = model.Reportstatus;
            accessionNumberList.Reportstatusid = model.Reportstatusid;
            accessionNumberList.Scheduledate = model.Scheduledate;
            accessionNumberList.Sutcode = model.Sutcode;
            accessionNumberList.Teletipstatus = model.Teletipstatus;
            accessionNumberList.Teletipstatusid = model.Teletipstatusid;
            accessionNumberList.TimeCreated = DateTime.Now;
            accessionNumberList.Wadostatus = model.Wadostatus;
            accessionNumberList.Wadostatusid = model.Wadostatusid;
            getorderStatusRepository.Add(accessionNumberList);

             var kosStudyHistory = new KosStudyHistory();
            kosStudyHistory.EnumType = (int)KosEnumType.KosGonderilipEslesenler;
            kosStudyHistory.FkKosStudy = kosStudyID;
            kosStudyHistory.FkUserCreated = Context.UserInfo.UserIDCurrent;
            kosStudyHistory.TimeCreated = DateTime.Now;
            kosStudyHistory.Result = "";

            var kosStudy = _InfStudyRepository.GetByID(kosStudyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID" + kosStudyID);
            }
            kosStudy.FkKosEnumType = (int)KosEnumType.KosGonderilipEslesenler;
            _InfStudyRepository.Update(kosStudy);

            _Workspace.CommitChanges();
            return kosStudy.Pk;
        }
        public long Save_UpdateDeleteKos(long studyID, string message)
        {
            var kosStudyHistory = new KosStudyHistory();
            kosStudyHistory.EnumType = (int)KosEnumType.KosSilinenler;
            kosStudyHistory.FkKosStudy = studyID;
            kosStudyHistory.FkUserCreated = Context.UserInfo.UserIDCurrent;
            kosStudyHistory.TimeCreated = DateTime.Now;
            kosStudyHistory.Result = message;

            var kosStudy = _InfStudyRepository.GetByID(studyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID" + studyID);
            }
            kosStudy.FkKosEnumType = (int)KosEnumType.KosSilinenler;
            _InfStudyRepository.Update(kosStudy);

            _Workspace.CommitChanges();
            return kosStudy.Pk;
        }
    }
}