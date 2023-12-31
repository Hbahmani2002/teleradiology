﻿using Gt.PERSISTANCE;
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
using GT.Core.Settings;
using GT.DataService.infinity.Implementation;
using System.Collections;
using AppAbc.Data.Service;
using static GT.Repository.Conditions.InfStudyConditionFilter;
using static GT.Repository.Conditions.StudyOperationCountCondition;
using GT.Repository.infinity.Model.View;
using GT.TeletipKos;

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
        StudyOperationCountRepository studyOperationCount;
        GetorderStatusRepository getorderStatusRepository;
        KosDurumOrderCompositeRepository KosDurumOrderCompositeRepository;
        AppFilePathRepository appFilePathRepository;
        InfOracleDataService _InfOracleDataService;
        StudyKosDataService _InfStudyDataService;
        KosPahtDataService KosPahtDataService;
        AppLogDataService _AppLogDataService;
        KosInstanceRepository _kosInstanceRepository;
        ReprocessRepository reprocessRepository;

        KosInstanceDataService _KosInstanceDataService;
   


        string hataMesajInstance = "";
        string hataMesajInfStundy = "";

        string CekimBilgi = "";
        string CekimInstanseBilgi = "";
        public StudyKosDataService() : this(null, true)
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
            studyOperationCount = new StudyOperationCountRepository(_Workspace);
            getorderStatusRepository = new GetorderStatusRepository(_Workspace);
            KosDurumOrderCompositeRepository = new KosDurumOrderCompositeRepository(_Workspace);
            appFilePathRepository = new AppFilePathRepository(_Workspace);
            _kosInstanceRepository = new KosInstanceRepository(_Workspace);
            reprocessRepository = new ReprocessRepository(_Workspace);
            _AppLogDataService = new AppLogDataService();
            _KosInstanceDataService = new KosInstanceDataService(null);
        }



        public List<InfStudyViewModel> ExcelExport(Gridable<KosStudyFilter> parms)
        {
            var s = ConvertConditionFilter(parms);
            return _InfStudyRepository.Query(s)
                .ToList();
        }



        public void Save(IEnumerable<InfOraclePostgreStudyViewModel> items, int otomatik)
        {


           
            try
            {
                var KosBatch = new KosBatch();
                KosBatch.TimeCreated = DateTime.Now;
                KosBatch.FkUserCreated = 1;
                _InfBatchRepository.Add(KosBatch);
                _Workspace.CommitChanges();
                long tenatID = 0;
                decimal Last_OracleStudyKey = 0;



                var list = new List<InfOraclePostgreStudyViewModel>();
                int x = 0;
                foreach (InfOraclePostgreStudyViewModel item in items)
                {
                   
                

                        CekimBilgi = "PatientId : " + item.PatientId + " StudyKey : " + item.OracleStudyKey + " AccessionNo : " + item.AccessionNo;


                    var gelenKey = _InfStudyRepository.QueryOracleStudyKey(item.OracleStudyKey.Value);
                    var KosStudy = new KosStudy();

                    if (gelenKey == null)
                    {

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
                        KosStudy.DateBirth = item.DateBirth;
                        KosStudy.StudyDate = item.StudyDate;
                        KosStudy.StoragePath = item.StoragePath;
                        KosStudy.ZeroImg = item.ZeroImg;
                        KosStudy.PatinetNameSurname = item.PatinetNameSurname;
                        KosStudy.CihazDeviceSerialNumber = "0";
                        KosStudy.Desc1 = "";
                        KosStudy.Desc2 = item.Desc2;
                        KosStudy.Desc3 = item.Desc3;
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
                        KosStudy.CreationDttm = item.CreationDttm; ;
                        KosStudy.OracleStudyKey = item.OracleStudyKey.Value;
                        KosStudy.FkKosEnumType = item.FkKosEnumType;
                        KosStudy.DicomDirPath = item.DicomPhat;
                        Last_OracleStudyKey = item.OracleStudyKey.Value;
                        _InfStudyRepository.Add(KosStudy);
                        _Workspace.CommitChanges();

                        if (otomatik == 1)
                        {
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
                    else
                    {
                        //var KosStudyUpdate = _InfStudyRepository.QueryOracleStudyKey(item.OracleStudyKey.Value);
                        //tenatID = item.FkTenant.Value;
                        //KosStudyUpdate.FkTenant = item.FkTenant.Value;
                        //KosStudyUpdate.FkInfBatch = KosBatch.Pk;
                        //KosStudyUpdate.FkUserCreated = null;
                        //KosStudyUpdate.FkUserModified = null;
                        //KosStudyUpdate.PatientId = item.PatientId;
                        //KosStudyUpdate.Gender = item.Gender;
                        //KosStudyUpdate.StudyDescription = item.StudyDescription;
                        //KosStudyUpdate.InstitutionName = item.InstitutionName;
                        //KosStudyUpdate.Modality = item.Modality;
                        //KosStudyUpdate.AccessionNo = item.AccessionNo;
                        //KosStudyUpdate.StudyInstanceuid = item.StudyInstanceuid;
                        //KosStudyUpdate.InstanceCount = 0;
                        //KosStudyUpdate.DateBirth = item.DateBirth;
                        //KosStudyUpdate.StudyDate = item.StudyDate;
                        //KosStudyUpdate.StoragePath = item.StoragePath;
                        //KosStudyUpdate.ZeroImg = item.ZeroImg;
                        //KosStudyUpdate.PatinetNameSurname = item.PatinetNameSurname;
                        //KosStudyUpdate.CihazDeviceSerialNumber = "0";
                        //KosStudyUpdate.Desc1 = "";
                        //KosStudyUpdate.Desc2 = item.Desc2;
                        //KosStudyUpdate.Desc3 = item.Desc3;
                        //KosStudyUpdate.TimeCreated = DateTime.Now;
                        //KosStudyUpdate.TimeModified = DateTime.Now;
                        //KosStudyUpdate.Institution = "";
                        //KosStudyUpdate.SeriesCount = 0;
                        //KosStudyUpdate.SeriesKey = 0;
                        //KosStudyUpdate.InstanceKey = 0;
                        //KosStudyUpdate.FileName = item.FileName;
                        //KosStudyUpdate.VolumeCode = item.ValumeCode;
                        //KosStudyUpdate.VolumeType = item.ValumeType;
                        //KosStudyUpdate.VolumeStat = item.ValumeStat;
                        //KosStudyUpdate.VolumePathname = item.ValumePathname;
                        //KosStudyUpdate.CreationDttm = item.CreationDttm; ;
                        //KosStudyUpdate.OracleStudyKey = item.OracleStudyKey.Value;
                        //KosStudyUpdate.FkKosEnumType = item.FkKosEnumType;
                        //KosStudyUpdate.DicomDirPath = item.DicomPhat;
                        //Last_OracleStudyKey = item.OracleStudyKey.Value;
                        //_InfStudyRepository.Update(KosStudyUpdate);
                        //_Workspace.CommitChanges();


                        var ParamterTimertenatID = _InfStudyParameterRepository.GetByTenatID(item.FkTenant.Value);
                        if (ParamterTimertenatID == null)
                        {
                            throw new Exception("User bulunamadı. tenatID:" + tenatID);
                        }
                        else
                        {
                            ParamterTimertenatID.OracleStudyKeyLast = Convert.ToInt64(item.OracleStudyKey);
                            _InfStudyParameterRepository.Update(ParamterTimertenatID);
                        }
                        _Workspace.CommitChanges();
                    }


                    x += 1;
                }
            }
            catch (Exception ex)
            {
                var hata = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                var message = ex.InnerException==null?"Error":ex.InnerException.Message.ToString();
                _AppLogDataService.Save(hata, "Hata-1004 CekimBilgi : " + CekimBilgi + " - " +  message);
                //throw new Exception("InfOrc Save. Hata-1004:" + " " + ex.Message.ToString());
            }

        }




        public int Delete(long StudyKey)
        {
            var InfStudy = _InfStudyRepository.GetByID(StudyKey);
           
            if (InfStudy == null)
            {
                throw new Exception("Kullanıcı veya kullanıcı Rolü bulunamadı");
            }

            _InfStudyRepository.Delete(InfStudy);
           
            _Workspace.CommitChanges();
            return 0;
        }



        public int DeleteInstanse(long StudyKey)
        {
            var InfInstanceList = _kosInstanceRepository.GetByStudyID(StudyKey);

            if (InfInstanceList == null)
            {
                throw new Exception("Kullanıcı veya kullanıcı Rolü bulunamadı");
            }

            foreach (var item in InfInstanceList)
            {
                _kosInstanceRepository.Delete(item);

            }


            _Workspace.CommitChanges();
            return 0;
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



        public PagingResult<InfStudyViewModel> GetInfStudyList(Gridable<KosStudyFilter> parms)
        {



            ArrayList myAL = new ArrayList();

           
            var s = ConvertConditionFilter(parms);
           
            if (parms.Filter.AccessionNumberList != null && parms.Filter.AccessionNumberList.Length > 0 )
            {
                parms.Paging.Count = parms.Filter.AccessionNumberList.Length;

            }

            if (parms.Filter.AccessionNumberList.Length <= 0)
            {
  
            }
            else
            {


               
                string[] accesnumbur = new string[parms.Filter.AccessionNumberList.Length];
                accesnumbur = parms.Filter.AccessionNumberList;
                ArrayList AccessionDizi = new ArrayList();
                ArrayList Acces = new ArrayList();

                AccessionDizi.AddRange(parms.Filter.AccessionNumberList);
                string[] Accession2 = new string[1];



                int x = 0;
                
                foreach (object Accession in accesnumbur)
                {

                    ArrayList lists = new ArrayList();
                    x = x + 1;


                    lists.Add(Accession);

                    string[] array = lists.ToArray(typeof(string)) as string[];
                    //if (x == 10)
                    //{
                        parms.Filter.AccessionNumberList = array;



                        var sorgu = new InfStudyConditionFilter
                        {
                            AccessionNumberList = array,

                        };


                        var list = _InfStudyRepository.Query(sorgu)
                        .GetGridQuery(parms);
                        var oracleList = list.List;
                        var accList = parms.Filter.AccessionNumberList;


                        if (accList != null)
                        {
                            var onlyOracle = accList.Where(o => !oracleList.Select(t => t.AccessionNumber).Contains(o)).ToList();
                            if (onlyOracle != null && onlyOracle.Count > 0 && parms.Filter.AccessionNumberList != null)
                            {
                                try
                                {
                                    //string [] fff = onlyOracle.ToArray();
                                    foreach (string acceno in parms.Filter.AccessionNumberList)
                                    {
                                    //SyncronizeInfinityStudyListSend(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
                                    //SyncronizeInfinityStudyListSend2(fff);
                                    SyncronizeInfinityStudyListSend(acceno);


                                    //x = 0;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    return list;
                                    throw new Exception("Inf Study List bulunamadı. Hata-1001:" + ex.Message.ToString());
                                }
                            }
                            //var list_Update = _InfStudyRepository.Query(s)
                            //      .GetGridQuery(parms);
                            //return list_Update;
                        }
                        else
                        {
                            if (list != null && list.List.Count > 0)
                            {
                                return list;
                            }
                            else
                            {
                                return list;
                                throw new Exception("List bulunamadı. Hata-1002:" + " " + list.List.Count.ToString());
                            }

                        }

                        
                    //}
                  


                }
                


            }





            return null;

        }


        public PagingResult<InfStudyViewModel> GetInfStudyListTwo(Gridable<KosStudyFilter> parms)
        {

            

            //if (parms.Filter.AccessionNumberList != null && parms.Filter.AccessionNumberList.Length > 1000)
            //{
               
            //    foreach (string acceno in parms.Filter.AccessionNumberList)
            //    {
            //        //SyncronizeInfinityStudyListSend(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
            //        SyncronizeInfinityStudyListSend(acceno);
            //    }
            //    //throw new Exception(parms.Filter.AccessionNumberList.Length.ToString()  +  " Kayıtın işlemi yapıldı. ");

            //    var s = ConvertConditionFilter(parms);
            //    var list_Update = _InfStudyRepository.Query(s)
            //           .GetGridQuery(parms);
            //    return list_Update;

            //}
            //else
            //{
                ArrayList myAL = new ArrayList();
                var s = ConvertConditionFilter(parms);

                if (parms.Filter.AccessionNumberList != null && parms.Filter.AccessionNumberList.Length > 0)
                {
                    parms.Paging.Count = parms.Filter.AccessionNumberList.Length;

                }

                var list = _InfStudyRepository.Query(s)
               .GetGridQuery(parms);
                var oracleList = list.List;
                var accList = parms.Filter.AccessionNumberList;

                if (accList != null)
                {

                    var onlyOracle = accList.Where(o => !oracleList.Select(t => t.AccessionNumber).Contains(o)).ToList();


                    if (onlyOracle != null && onlyOracle.Count > 0 && parms.Filter.AccessionNumberList != null)
                    {


                        try
                        {

                            foreach (string acceno in parms.Filter.AccessionNumberList)
                            {
                                //SyncronizeInfinityStudyListSend(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
                                SyncronizeInfinityStudyListSend(acceno);
                            }

                        }
                        catch (Exception ex)
                        {
                            return list;
                            throw new Exception("Inf Study List bulunamadı. Hata-1001:" + ex.Message.ToString());

                        }



                    }
                    var list_Update = _InfStudyRepository.Query(s)
                          .GetGridQuery(parms);
                    return list_Update;
                }
                else
                {

                    if (list != null && list.List.Count > 0)
                    {

                        return list;


                    }
                    else
                    {
                        return list;
                        throw new Exception("List bulunamadı. Hata-1002:" + " " + list.List.Count.ToString());
                    }

                }

            //}


           

        }

        public PagingResult<InfStudyViewModel> GetInfStudyHastaIstanceCek(Gridable<KosStudyFilter> parms)
        {


            ArrayList myAL = new ArrayList();
            var s = ConvertConditionFilter(parms);

            if (parms.Filter.StudyIDList != null && parms.Filter.StudyIDList.Length > 0)
            {
                parms.Paging.Count = parms.Filter.StudyIDList.Length;

            }

            var list = _InfStudyRepository.Query(s)
           .GetGridQuery(parms);
            var oracleList = list.List;
            var accList = parms.Filter.AccessionNumberList;

            if (accList != null)
            {

                var onlyOracle = accList.Where(o => !oracleList.Select(t => t.AccessionNumber).Contains(o)).ToList();


                if (onlyOracle != null && onlyOracle.Count > 0 && parms.Filter.AccessionNumberList != null)
                {


                    try
                    {

                        foreach (string acceno in parms.Filter.AccessionNumberList)
                        {
                            //SyncronizeInfinityStudyListSend(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
                            SyncronizeInfinityStudyListCek(acceno);
                        }

                    }
                    catch (Exception ex)
                    {
                        return list;
                        throw new Exception("Inf Study List bulunamadı. Hata-1001:" + ex.Message.ToString());

                    }



                }
                else
                {

                    foreach (string acceno in parms.Filter.AccessionNumberList)
                    {
                        //SyncronizeInfinityStudyListSend(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
                        SyncronizeInfinityStudyListCek(acceno);
                    }

                }
                var list_Update = _InfStudyRepository.Query(s)
                      .GetGridQuery(parms);
                return list_Update;
            }
            else
            {

                if (list != null && list.List.Count > 0)
                {

                    return list;


                }
                else
                {
                    return list;
                    throw new Exception("List bulunamadı. Hata-1002:" + " " + list.List.Count.ToString());
                }

            }

        }


        public PagingResult<InfStudyViewModel> GetStudyDataDeleteList(Gridable<KosStudyFilter> parms)
        {


            ArrayList myAL = new ArrayList();
            var s = ConvertConditionFilter(parms);

       

            var list = _InfStudyRepository.Query(s)
           .GetGridQuery(parms);
            var oracleList = list.List;


            foreach (var item in oracleList)
            {

                Delete(item.ID);
                DeleteInstanse( Convert.ToInt32( item.OracleStudyKey) );

            }
            var list_Update = _InfStudyRepository.Query(s)
               .GetGridQuery(parms);
            return list_Update;
            throw new Exception("List bulunamadı. Hata-1002:" + " " + list.List.Count.ToString());



        }







        //public void SyncronizeInfinityStudyListSend(long tenantID, long lastID, System.DateTime? startTime, System.DateTime? endTime)
        public void SyncronizeInfinityStudyListSend(string Accession)
        {
            _InfOracleDataService = new InfOracleDataService(null);
            _InfStudyDataService = new StudyKosDataService(null);
            KosPahtDataService = new KosPahtDataService(null);
            string mesaj = "";
            var filter = new DataService.infinity.Model.InfOracleFilter();
            //filter.Infcreationstartdate = startTime;
            //filter.Infcreationenddate = endTime;

            //filter.Infcreationstartdate = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day);
            string AC = Accession.Substring(0, 1).ToString();
            long qtenantID = _InfStudyDataService.GetTenatIDOnekNoByAccession(AC);

            //filter.Infstudypklast = lastID;

            filter.Accession_no = Accession;
            filter.Source_Aetitle = "DICOM CREATOR";
            filter.SeriesInfo = "DCMCREATOR";
            var items = _InfOracleDataService.ManuelGetInfOracleList(filter);
           
            
            var volumMap = "";

            foreach (var item in items)
            {
                var list = new List<InfOraclePostgreStudyViewModel>();
                Console.WriteLine(item.AccessNo);
                mesaj = item.AccessNo + " numarasının " + item.VolumePathname + " dicom paht yolu bulunmadı...";
                if (item.VolumePathname != null)
                {              
                    var model = new InfOraclePostgreStudyViewModel();
                    model.AccessionNo = item.AccessNo;
                    model.TimeCreated = item.CreationDttm;
                    model.FkTenant = qtenantID;
                    model.FkUserCreated = 2; //Context.UserInfo.UserIDCurrent;
                    model.PatientId = item.PatientId;
                    model.Gender = item.PatientSex;
                    model.StudyDescription = item.StudyDesc;
                    model.InstitutionName = item.Institution;
                    model.Modality = item.Modalities;
                    model.AccessionNo = item.AccessNo;
                    model.StudyInstanceuid = item.StudyInstanceUid;
                    model.InstanceCount = 0;
                    model.DateBirth = item.PatientBirthDttm.HasValue ? item.PatientBirthDttm.Value : DateTime.Now;
                    model.StudyDate = item.StudyDttm.HasValue ? item.StudyDttm.Value : DateTime.Now;
                    model.StoragePath = item.Pathname;
                    model.PatinetNameSurname = item.PatientName;
                    model.CihazDeviceSerialNumber = null;
                    model.Desc1 = null;
                    model.Desc2 = null;
                    model.Desc3 = null;
                    model.TimeCreated = DateTime.Now;
                    model.TimeModified = null;
                    model.Institution = item.Institution;
                    model.SeriesCount = 0;
                    model.SeriesKey = 0;
                    model.InstanceKey = "";
                    model.FileName = item.Filename;
                    model.ValumeCode = item.VolumeCode;
                    model.ValumeType = item.VolumeType;
                    model.ValumeStat = item.VolumeStat;
                    model.ValumePathname = item.VolumePathname;
                    model.CreationDttm = item.CreationDttm.HasValue ? item.CreationDttm : DateTime.Now;
                    model.OracleStudyKey = item.StudyKey;
                    //model.FkKosEnumType = 2;
                    model.InfMergeKey = item.InfMergeKey;
                    model.SeriesInfo = item.SeriesInfo;

                    if (item.VolumePathname != null)
                    {

                        if (item.VolumeCode != null)
                        {
                            try
                            {
                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);
                                model.DicomPhat = item.VolumePathname.Replace(item.VolumePathname, volumMap) + "/" + item.Pathname;
                            }
                            catch (Exception ex)
                            {
                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);

                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            model.DicomPhat = item.VolumePathname + "\\" + item.Pathname.Replace("/", "\\");

                        }

                    }
                    else
                    {
                        model.DicomPhat = "";

                    }


                

                    string OrcleZeroImages = AppSettings.GetCurrent().DataServiceSettings.OracleSettings.ZeroImageGeneratorName.ToString();

                    //if (item.SeriesInfo.Contains(OrcleZeroImages))
                    //{
                    //    model.ZeroImg = 1;
                    //    model.FkKosEnumType = 999;
                    //}
                    //else
                    //{
                    //    model.ZeroImg = 0;
                    //    model.FkKosEnumType = 10;
                    //}
                    if (item.SeriesInfo.Contains(OrcleZeroImages))
                    {
                        model.Desc3 = OrcleZeroImages +" Manuel Oracle Liste Cek";
                        model.ZeroImg = 1;
                        model.FkKosEnumType = 999;
                    }
                    else
                    {
                        model.ZeroImg = 0;
                        model.FkKosEnumType = 10;
                    }

                    

                  

                    list.Add(model);
                }
                else
                {
                    var hata2 = AppAbc.Data.Service.AppLogDataService.LogType.DoSingleBatchPahtIsNull;
                    var message2 = mesaj + "Study veya Series de Kayıt Bulunamadı...";
                    _AppLogDataService.Save(hata2, message2 + " - " + item.StudyKey + " 9 ");
                    mesaj = "";


               
                }
                if (list.Count > 0)
                {
                    Save(list, 0);
                    list = null;
                }
               
                mesaj = "";


            }

           


        }
        public void SyncronizeInfinityStudyListSend2(string[] Accession)
        {
            _InfOracleDataService = new InfOracleDataService(null);
            _InfStudyDataService = new StudyKosDataService(null);
            KosPahtDataService = new KosPahtDataService(null);
            string mesaj = "";
            var filter = new DataService.infinity.Model.InfOracleFilter();
            //filter.Infcreationstartdate = startTime;
            //filter.Infcreationenddate = endTime;

            //filter.Infcreationstartdate = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day);
            string AC = Accession[0].Substring(0, 1).ToString();
            long qtenantID = _InfStudyDataService.GetTenatIDOnekNoByAccession(AC);

            //filter.Infstudypklast = lastID;

            filter.AccessionNoListte = Accession;
            var items = _InfOracleDataService.ManuelGetInfOracleList(filter);
            var list = new List<InfOraclePostgreStudyViewModel>();

            var volumMap = "";

            foreach (var item in items)
            {
                Console.WriteLine(item.AccessNo);
                mesaj = item.AccessNo + " numarasının " + item.VolumePathname + " dicom paht yolu bulunmadı...";
                if (item.VolumePathname != null)
                {
                    var model = new InfOraclePostgreStudyViewModel();
                    model.AccessionNo = item.AccessNo;
                    model.TimeCreated = item.CreationDttm;
                    model.FkTenant = qtenantID;
                    model.FkUserCreated = 2; //Context.UserInfo.UserIDCurrent;
                    model.PatientId = item.PatientId;
                    model.Gender = item.PatientSex;
                    model.StudyDescription = item.StudyDesc;
                    model.InstitutionName = item.Institution;
                    model.Modality = item.Modalities;
                    model.AccessionNo = item.AccessNo;
                    model.StudyInstanceuid = item.StudyInstanceUid;
                    model.InstanceCount = 0;
                    model.DateBirth = item.PatientBirthDttm.HasValue ? item.PatientBirthDttm.Value : DateTime.Now;
                    model.StudyDate = item.StudyDttm.HasValue ? item.StudyDttm.Value : DateTime.Now;
                    model.StoragePath = item.Pathname;
                    model.PatinetNameSurname = item.PatientName;
                    model.CihazDeviceSerialNumber = null;
                    model.Desc1 = null;
                    model.Desc2 = null;
                    model.Desc3 = null;
                    model.TimeCreated = DateTime.Now;
                    model.TimeModified = null;
                    model.Institution = item.Institution;
                    model.SeriesCount = 0;
                    model.SeriesKey = 0;
                    model.InstanceKey = "";
                    model.FileName = item.Filename;
                    model.ValumeCode = item.VolumeCode;
                    model.ValumeType = item.VolumeType;
                    model.ValumeStat = item.VolumeStat;
                    model.ValumePathname = item.VolumePathname;
                    model.CreationDttm = item.CreationDttm.HasValue ? item.CreationDttm : DateTime.Now;
                    model.OracleStudyKey = item.StudyKey;
                    //model.FkKosEnumType = 2;
                    model.InfMergeKey = item.InfMergeKey;
                    model.SeriesInfo = item.SeriesInfo;

                    if (item.VolumePathname != null)
                    {

                        if (item.VolumeCode != null)
                        {
                            try
                            {
                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);
                                model.DicomPhat = item.VolumePathname.Replace(item.VolumePathname, volumMap) + "/" + item.Pathname;
                            }
                            catch (Exception ex)
                            {
                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);

                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            model.DicomPhat = item.VolumePathname + "\\" + item.Pathname.Replace("/", "\\");

                        }

                    }
                    else
                    {
                        model.DicomPhat = "";

                    }




                    string OrcleZeroImages = AppSettings.GetCurrent().DataServiceSettings.OracleSettings.ZeroImageGeneratorName.ToString();

                    if (item.SeriesInfo.Contains(OrcleZeroImages))
                    {
                        model.ZeroImg = 1;
                        model.FkKosEnumType = 999;
                    }
                    else
                    {
                        model.ZeroImg = 0;
                        model.FkKosEnumType = 10;
                    }
                    list.Add(model);
                }
                else
                {
                    var hata2 = AppAbc.Data.Service.AppLogDataService.LogType.DoSingleBatchPahtIsNull;
                    var message2 = mesaj;
                    _AppLogDataService.Save(hata2, message2 + " - " + item.StudyKey + " 9 ");
                    mesaj = "";


                }
                if (list.Count > 0)
                {
                    Save(list, 0);
                }
                mesaj = "";


            }




        }
        public void SyncronizeInfinityStudyListCek(string AccessionNo)
        {
            _InfOracleDataService = new InfOracleDataService(null);
            _InfStudyDataService = new StudyKosDataService(null);
            KosPahtDataService = new KosPahtDataService(null);

            var filter = new DataService.infinity.Model.InfOracleFilter();
            //filter.Infcreationstartdate = startTime;
            //filter.Infcreationenddate = endTime;

            //filter.Infcreationstartdate = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day);
            string AC = AccessionNo.Substring(0, 1).ToString();
            long qtenantID = _InfStudyDataService.GetTenatIDOnekNoByAccession(AC);

            //filter.Infstudypklast = lastID;

            filter.Accession_no = AccessionNo;
            var items = _InfOracleDataService.ManuelGetInfOracleList(filter);
            var list = new List<InfOraclePostgreStudyViewModel>();

            var volumMap = "";

            foreach (var item in items)
            {

                if (item.VolumePathname != null)
                {

                    var model = new InfOraclePostgreStudyViewModel();
                    model.AccessionNo = item.AccessNo;
                    model.TimeCreated = item.CreationDttm;
                    model.FkTenant = qtenantID;
                    model.FkUserCreated = 2; //Context.UserInfo.UserIDCurrent;
                    model.PatientId = item.PatientId;
                    model.Gender = item.PatientSex;
                    model.StudyDescription = item.StudyDesc;
                    model.InstitutionName = item.Institution;
                    model.Modality = item.Modalities;
                    model.AccessionNo = item.AccessNo;
                    model.StudyInstanceuid = item.StudyInstanceUid;
                    model.InstanceCount = 0;
                    model.DateBirth = item.PatientBirthDttm.HasValue ? item.PatientBirthDttm.Value : DateTime.Now;
                    model.StudyDate = item.StudyDttm.HasValue ? item.StudyDttm.Value : DateTime.Now;
                    model.StoragePath = item.Pathname;
                    model.PatinetNameSurname = item.PatientName;
                    model.CihazDeviceSerialNumber = null;
                    model.Desc1 = null;
                    model.Desc2 = null;
                    model.Desc3 = null;
                    model.TimeCreated = DateTime.Now;
                    model.TimeModified = null;
                    model.Institution = item.Institution;
                    model.SeriesCount = 0;
                    model.SeriesKey = 0;
                    model.InstanceKey = "";
                    model.FileName = item.Filename;
                    model.ValumeCode = item.VolumeCode;
                    model.ValumeType = item.VolumeType;
                    model.ValumeStat = item.VolumeStat;
                    model.ValumePathname = item.VolumePathname;
                    model.CreationDttm = item.CreationDttm.HasValue ? item.CreationDttm : DateTime.Now;
                    model.OracleStudyKey = item.StudyKey;
                    //model.FkKosEnumType = 2;
                    model.InfMergeKey = item.InfMergeKey;
                    model.SeriesInfo = item.SeriesInfo;

                    if (item.VolumePathname != null)
                    {

                        if (item.VolumeCode != null)
                        {
                            try
                            {
                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);
                                model.DicomPhat = item.VolumePathname.Replace(item.VolumePathname, volumMap) + "/" + item.Pathname;
                            }
                            catch (Exception ex)
                            {
                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);

                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            model.DicomPhat = item.VolumePathname + "\\" + item.Pathname.Replace("/", "\\");

                        }

                    }
                    else
                    {
                        model.DicomPhat = "";

                    }


                    if (SyncronizeInfinityInstanceList(item, qtenantID, volumMap) == false)
                        continue;

                    string OrcleZeroImages = AppSettings.GetCurrent().DataServiceSettings.OracleSettings.ZeroImageGeneratorName.ToString();

                    if (item.SeriesInfo.Contains(OrcleZeroImages))
                    {
                        model.ZeroImg = 1;
                        model.FkKosEnumType = 999;
                    }
                    else
                    {
                        model.ZeroImg = 0;
                        model.FkKosEnumType = 10;
                    }
                    list.Add(model);
                }


            }
            Save(list, 0);


        }

        public bool SyncronizeInfinityInstanceList(InfOracleViewModel item, long tenantID, string volumMap)
        {
            try
            {
                var kosfilter = new DataService.infinity.Model.KosInstanceViewFilter();
                hataMesajInstance = tenantID + "" + item.StudyKey + "" + item.PatientId;

                if (item.StudyKey != null)
                {
                    kosfilter.StudyKey = Convert.ToInt32(item.StudyKey);
                    kosfilter.SeriesInfo = "DCMCREATOR";
                    var kositems = _KosInstanceDataService.KosInstanceOracleList(kosfilter);
                    var klist = new List<KosInstanceViewModel>();
                    foreach (var kitem in kositems)
                    {
                        var kmodel = new KosInstanceViewModel();
                        kmodel.PatientID = kitem.PatientID;
                        kmodel.PatientName = kitem.PatientName;
                        kmodel.StudyKey = kitem.StudyKey;
                        kmodel.StudyInstanceUID = kitem.StudyInstanceUID;
                        kmodel.SeriesInstanceUID = kitem.SeriesInstanceUID;
                        kmodel.SopInstanceUID = kitem.SopInstanceUID;
                        kmodel.Modalities = kitem.Modalities;
                        kmodel.AccessNo = kitem.AccessNo;
                        kmodel.SeriesInfo = kitem.SeriesInfo;
                        kmodel.InstanceLocPathName = kitem.InstanceLocPathName;
                        kmodel.VolumePathName = kitem.VolumePathName;
                        kmodel.FileName = kitem.FileName;
                        kmodel.InstanceLocKey = kitem.InstanceLocKey;
                        kmodel.Instance_dcmdir_path = kitem.VolumePathName.Replace(kitem.VolumePathName, volumMap) + "/" + kitem.InstanceLocPathName + "/" + kitem.FileName;

                        klist.Add(kmodel);
                    }
                    _InfStudyDataService.SaveKosInstance(klist, 1);
                }
                return true;
            }
            catch (Exception es)
            {
                var hata2 = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                var message2 = es.Message == null ? "Error Instance -1009" : es.Message.ToString();
                _AppLogDataService.Save(hata2, message2 + " - " + hataMesajInstance);
                hataMesajInstance = "";
                return false;
            }
        }


        public IEnumerable<MakeKosViewModel> GetMakeKosList(Gridable<KosStudyFilter> parms)
        {


            //if (parms.Filter.StudyIDList != null && parms.Filter.StudyIDList.Length > 0)
            //{

            //    int i = 0;
            //    foreach (var StudyPk in parms.Filter.StudyIDList)
            //    {
            //        var ParamterKosStudy = _InfStudyRepository.GetByPkID(StudyPk);


            //        if (ParamterKosStudy == null)
            //        {
            //            throw new Exception("Study Key  Bulunamadı : " + StudyPk);
            //        }
            //        else
            //        {
            //            ParamterKosStudy.FkKosEnumType = Convert.ToInt64(KosEnumType.KosOlusturulamamisOlanlar);
            //            _InfStudyRepository.Update(ParamterKosStudy);
            //        }



            //        _Workspace.CommitChanges();
            //        i = +1;
            //    }


            //}



            var s = ConvertConditionFilter(parms);
            
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            return makeKosCompositeRepository.Query(s, sc)
                .OrderBy(o => o.StudyID).Take(parms.Paging.Count).ToArray();
        }
        public List<MakeKosViewModel> GetMakeKosList(int count)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosOlusturulamamisOlanlar,
                KosWaitHour = true
            };
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            return makeKosCompositeRepository.Query(s, sc).OrderBy(o => o.StudyID).Take(count).ToList();
        }

        public List<MakeKosViewModel> GetMakeKosWithIntanceList(Gridable<KosStudyFilter>? parms,int count)
        {
            var s = new InfStudyConditionFilter
            {
                //KosEnum = KosEnumType.KosOlusturulamamisOlanlar,
                KosWaitHour = true,
                AccessionNumberList=parms.Filter.AccessionNumberList,
                BasTarih=parms.Filter.BasTarih,
                BitTarih=parms.Filter.BitTarih,
                EslesmeDurumuList=parms.Filter.EslesmeDurumuList,
                HastaneIDList=parms.Filter.HastaneIDList,
                ModalityList=parms.Filter.ModaliteList,
                PkList=parms.Filter.StudyIDList,
                TcList=parms.Filter.TCList,
                StudyInstanceUID=parms.Filter.StudyInstanceUID
            };
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            var list=makeKosCompositeRepository.Query(s, sc).ToList();
           
            foreach (var item in list)
            {
                var filter = new { kosStudyID = item.StudyID };
                var pathList = _kosInstanceRepository.GetByKosStudyInstanceID(item.oracle_study_key.Value).OrderBy(o => o.OracleStudyKey)
                    .ToList().Select(o=>o.Instance_dcmdir_path).ToArray();

                item.DicomInstanceList = pathList;
            }
            return list;
        }

        public List<SentKosViewModel> GetSentKosList(int count)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosOlusmusOlanlar,
                KosWaitHour = true
            };
            var sc = new StudyOperationCountConditionFilter
            {
                SentKosCount = true
            };
            return kosStudyJobRepository.Query(s, sc).OrderBy(o => o.StudyID).Take(count).ToList();
        }


        public List<SentKosViewModel> GetSentKosOrderList(int count)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosGonderilipEslesenler,
                KosWaitHour = true
            };
            var sc = new StudyOperationCountConditionFilter
            {
                SentKosCount = true
            };
            return kosStudyJobRepository.Query(s, sc).OrderBy(o => o.StudyID).Take(count).ToList();
        }


        public List<MakeKosViewModel> GetDozList(int count)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosGonderilipEslesenler,
                Modality = "SR",
                KosWaitHour = true
            };
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            return makeKosCompositeRepository.Query(s, sc).OrderBy(o => o.StudyID).Take(count).ToList();
        }


        public IEnumerable<SentKosViewModel> GetSentKosList(Gridable<KosStudyFilter> parms)
        {
            InfStudyConditionFilter s = ConvertConditionFilter(parms);
            s.KosEnum = KosEnumType.KosOlusmusOlanlar;
            s.KosWaitHour = true;
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            return kosStudyJobRepository.Query(s, sc)
                .OrderBy(o => o.StudyID).Take(parms.Paging.Count).ToArray();
        }

        private InfStudyConditionFilter ConvertConditionFilter(Gridable<KosStudyFilter> parms)
        {
            if (parms == null)
            {
                parms = new Gridable<KosStudyFilter>()
                {
                    Filter = new KosStudyFilter(),
                };
            }
            var filter = parms.Filter;
            if (filter == null)
                filter = new KosStudyFilter();
            return new InfStudyConditionFilter
            {
                AccessionNumberList = filter.AccessionNumberList,
                EslesmeDurumuList = filter.EslesmeDurumuList,
                HastaneIDList = filter.HastaneIDList,
                ModalityList = filter.ModaliteList,
                BasTarih = filter.BasTarih,
                BitTarih = filter.BitTarih,
                Modality = filter.Modalite,
                PatientID = filter.PatientID,
                StudyInstanceUID = filter.StudyInstanceUID,
                PkList = filter.StudyIDList,
                TcList = filter.TCList,
                KosEnum = filter.KosEnum,
                KosWaitHour = filter.KosWaitHour

            };
        }


        //public List<Repository.Models.View.OrderStatusForAccessionNumberViewModel> GetSTMInfoList(int count, string accessionNumberList)
        //{
        //    var g = new GetorderStatusConditionFilter
        //    {
        //        //AccessionNumberList= accessionNumberList
        //    };
        //    return getorderStatusCompositeRepository.Query(g).OrderBy(o => o.ID).Take(count).ToList();
        //}

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


        public long GetTenatIDOnekNoByAccession(string acc)
        {
            var item = tenatCompositeRepository.SingleDb(acc);
            return item.ID;
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
            return infStudyHistoryRepository.GetByKosStudyID(parms.Filter.id)
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

        public List<KosDurumIstModel> GetKosDurumIst(KosStudyFilter filter)
        {
            var s = new InfStudyConditionFilter
            {
                AccessionNumberList = filter.AccessionNumberList,
                BasTarih = filter.BasTarih,
                BitTarih = filter.BitTarih,
                EslesmeDurumuList = filter.EslesmeDurumuList,
                HastaneIDList = filter.HastaneIDList,
                ModalityList = filter.ModaliteList,
                TcList = filter.TCList
            };
            return kosDurumIstCompositeRepository.Query(s).ToList();
        }

        public IEnumerable<MakeKosViewModel> GetKosDurum(Gridable<KosStudyFilter> parms)
        {



            var s = new InfStudyConditionFilter
            {
                KosEnum = KosEnumType.KosOlusturulamamisOlanlar,
                KosWaitHour = true,
                AccessionNumberList = parms.Filter.AccessionNumberList,
                EslesmeDurumuList = parms.Filter.EslesmeDurumuList,
                HastaneIDList = parms.Filter.HastaneIDList,
                ModalityList = parms.Filter.ModaliteList,
                BasTarih = parms.Filter.BasTarih,
                BitTarih = parms.Filter.BitTarih,
                Modality = parms.Filter.Modalite,
                PatientID = parms.Filter.PatientID,
                StudyInstanceUID = parms.Filter.StudyInstanceUID
            };
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            return makeKosCompositeRepository.Query(s, sc)
                .OrderBy(o => o.StudyID).Take(parms.Paging.Count).ToArray();


        }

        public IEnumerable<KosDeleteViewModel> GetKosDeleteList(KosStudyFilter filter)
        {
            if (filter == null)
                filter = new KosStudyFilter();
            var s = new InfStudyConditionFilter
            {
                HastaneIDList = filter.HastaneIDList,
                AccessionNumberList = filter.AccessionNumberList,
                BasTarih = filter.BasTarih,
                BitTarih = filter.BitTarih,
                Modality = filter.Modalite,
                TcList = filter.TCList,
                KosEnum = KosEnumType.ZeroImg,
                StudyInstanceUID = filter.StudyInstanceUID,
                PatientID = filter.PatientID
            };
            return kosDeleteCompositeRepository.Query(s).ToArray();
        }

        public IEnumerable<KosDurumViewModel> GetKosDurumOrderList(KosStudyFilter filter)
        {
            if (filter == null)
                filter = new KosStudyFilter();
            var s = new InfStudyConditionFilter
            {



                HastaneIDList = filter.HastaneIDList,
                AccessionNumberList = filter.AccessionNumberList,
                BasTarih = filter.BasTarih,
                BitTarih = filter.BitTarih,
                Modality = filter.Modalite,
                TcList = filter.TCList,
                KosEnum = KosEnumType.KosGonderilipEslesenler,
                StudyInstanceUID = filter.StudyInstanceUID,
                PatientID = filter.PatientID
            };
            return KosDurumOrderCompositeRepository.Query(s).ToArray();






        }



        public IEnumerable<KosDeleteViewModel> GetKosDeleteListGrid(Gridable<KosStudyFilter> parms)
        {
            InfStudyConditionFilter s = ConvertConditionFilter(parms);



            //string EslesmeDurumuList = Convert.ToInt32( parms.Filter.EslesmeDurumuList[0]).ToString();

            //if (EslesmeDurumuList != null)
            //{
            //    switch (EslesmeDurumuList)
            //    {
            //        case "999":
            //            s.KosEnum = KosEnumType.ZeroImg;
            //            break;
            //        case "60":
            //            s.KosEnum = KosEnumType.KosGonderilipEslesenler;
            //            break;

            //    }
            //}
            //else
            //{
            //    s.KosEnum = KosEnumType.KosGonderilipEslesenler;

            //}

            s.KosWaitHour = true;
            var sc = new StudyOperationCountConditionFilter
            {
                MakeKosCount = true,
            };
            return kosDeleteCompositeRepository.Query(s).ToArray();
        }


        public long Save_UpdateMakeKosDurum(long kosStudyID, bool isSuccess, string kosPath, string statusMessage)
        {
            var newKosState = (int)(isSuccess ? KosEnumType.KosOlusmusOlanlar : KosEnumType.KosOlusumuHataliOlanlar);



            try
            {


                var kosStudyHistory = new KosStudyHistory();
                kosStudyHistory.EnumType = newKosState;
                kosStudyHistory.FkKosStudy = kosStudyID;
                kosStudyHistory.FkUserCreated = 0;
                //kosStudyHistory.FkUserCreated = Context==null?(long?):Context.UserInfo.UserIDCurrent;
                kosStudyHistory.TimeCreated = DateTime.Now;
                kosStudyHistory.Result = statusMessage;
                infStudyHistoryRepository.Add(kosStudyHistory);
                _Workspace.CommitChanges();
            }
            catch
            {

            }


            var kosStudy = _InfStudyRepository.GetByID(kosStudyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID" + kosStudyID);
            }
            if (isSuccess)
            {
                kosStudy.FkKosEnumType = newKosState;
                kosStudy.DicomKosPath = kosPath;
            }
            else
            {
                kosStudy.FkKosEnumType = newKosState;
                kosStudy.DicomKosPath = null;
            }
            _InfStudyRepository.Update(kosStudy);

            var failCount = studyOperationCount.GetByStudyID(kosStudyID);
            if (failCount == null)
            {
                failCount = new StudyOperationCount();
                failCount.MakekosErrorTryCount = 1;
                failCount.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                failCount.TimeCreated = DateTime.Now;
                studyOperationCount.Add(failCount);
            }
            else
            {
                failCount.MakekosErrorTryCount = failCount.MakekosErrorTryCount + 1;
                failCount.FkUserModified = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                failCount.TimeModified = DateTime.Now;
                studyOperationCount.Update(failCount);
            }

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

            try
            {

                var kosStudyHistory = new KosStudyHistory();
                kosStudyHistory.EnumType = newKosState;
                kosStudyHistory.FkKosStudy = kosStudyID;
                kosStudyHistory.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                kosStudyHistory.TimeCreated = DateTime.Now;
                kosStudyHistory.Result = statusMessage;
                infStudyHistoryRepository.Add(kosStudyHistory);
                _Workspace.CommitChanges();
            }
            catch
            {

            }



            var kosStudy = _InfStudyRepository.GetByID(kosStudyID);
            if (kosStudy == null)
            {
                throw new Exception("kosStudy bulunmadı. kosStudyID" + kosStudyID);
            }
            kosStudy.FkKosEnumType = newKosState;
            _InfStudyRepository.Update(kosStudy);

            var failCount = studyOperationCount.GetByStudyID(kosStudyID);
            if (failCount == null)
            {
                failCount = new StudyOperationCount();
                failCount.SentkosErrorTryCount = 1;
                failCount.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                failCount.TimeCreated = DateTime.Now;
                studyOperationCount.Add(failCount);
            }
            else
            {
                failCount.SentkosErrorTryCount = failCount.SentkosErrorTryCount + 1;
                failCount.FkUserModified = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                failCount.TimeModified = DateTime.Now;
                studyOperationCount.Update(failCount);
            }

            _Workspace.CommitChanges();
            return kosStudy.Pk;
        }

        public long Save_UpdateSTMInfo(long kosStudyID, Repository.Models.View.GetorderStatusViewModel model)
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
            kosStudyHistory.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
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

            try
            {

                var kosStudyHistory = new KosStudyHistory();
                kosStudyHistory.EnumType = (int)KosEnumType.KosSilinenler;
                kosStudyHistory.FkKosStudy = studyID;
                kosStudyHistory.FkUserCreated = Context == null ? (long?)null : Context.UserInfo.UserIDCurrent;
                kosStudyHistory.TimeCreated = DateTime.Now;
                kosStudyHistory.Result = message;
                infStudyHistoryRepository.Add(kosStudyHistory);
                _Workspace.CommitChanges();
            }
            catch 
            { }



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
        
        public void SaveKosInstance(IEnumerable<KosInstanceViewModel> items, int otomatik)
        {



            try
            {




                var list = new List<KosInstanceViewModel>();
                foreach (KosInstanceViewModel item in items)
                {

                    CekimInstanseBilgi = "InstanceLocKey : " + item.InstanceLocKey.Value + " StudyKey : " + item.StudyKey + " PatientID :" + item.PatientID + " StudyInstanceUID :" + item.StudyInstanceUID;
                    var gelenKey = _kosInstanceRepository.QueryOracleKosInstanceKey(item.InstanceLocKey.Value);
                    var KosInstance = new KosInstance();

                    if (gelenKey == null)
                    {
                        KosInstance.PatientId = item.PatientID;
                        KosInstance.PatinetName = item.PatientName;
                        KosInstance.OracleStudyKey = Convert.ToInt32(item.StudyKey);
                        KosInstance.StudyInstanceuid = item.StudyInstanceUID;
                        KosInstance.SeriInstanceuid = item.SeriesInstanceUID;
                        KosInstance.SopInstanceuid = item.SopInstanceUID;
                        KosInstance.Modality = item.Modalities;
                        KosInstance.AccessionNo = item.AccessNo;
                        KosInstance.SeriInfo = item.SeriesInfo;
                        KosInstance.VolumePath = item.VolumePathName;
                        KosInstance.InstitutionFilename = item.FileName;
                        KosInstance.InstitutionPathname = item.InstanceLocPathName;
                        KosInstance.UserFk = 1;
                        KosInstance.UserFkLastModfiead = 1;
                        KosInstance.TimeCreated = DateTime.Now;
                        KosInstance.TimeDelete = DateTime.Now;
                        KosInstance.InstanceLocKey = item.InstanceLocKey;
                        KosInstance.Instance_dcmdir_path = item.Instance_dcmdir_path;

                        _kosInstanceRepository.Add(KosInstance);
                        _Workspace.CommitChanges();
                    }
              
                  

                }
          
            }
            catch (Exception ex)
            {
                var hata = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                var message = ex.InnerException == null ? "Error 10 " : ex.InnerException.Message.ToString();
                _AppLogDataService.Save(hata, message +" - "+ CekimInstanseBilgi);
                //throw new Exception("InfOrc Save. Hata-1010:" + " " + ex.Message.ToString());
            }

        }

        public ReprocessViewModel[] GetReprocessList(Gridable<KosStudyFilter> parms,int count=10)
        {
            var s = new InfStudyConditionFilter
            {
                KosEnum=parms.Filter.KosEnum,
                AccessionNumberList=parms.Filter.AccessionNumberList,
                BasTarih=parms.Filter.BasTarih,
                BitTarih=parms.Filter.BitTarih,
                EslesmeDurumuList=parms.Filter.EslesmeDurumuList,
                PkList=parms.Filter.StudyIDList,
                HastaneIDList=parms.Filter.HastaneIDList,
                ModalityList=parms.Filter.ModaliteList,
                TcList=parms.Filter.TCList
            };
            return reprocessRepository.Query(s).OrderBy(o => o.AccessionNumber).Take(count).ToArray();
        }

    }
}