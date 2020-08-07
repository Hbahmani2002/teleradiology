
using App.Data.Service;
using AppAbc.Data.Service;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.Repository.infinity.Model.View;
using GT.Repository.Models.View;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.IO;
using Util.Logger;


namespace GT.BAL.Infinity.DataSynronizer
{
    public class InfinityDataSyncronizer : BaseService
    {
        InfOracleDataService _InfOracleDataService;
        StudyKosDataService _InfStudyDataService;
        KosPahtDataService KosPahtDataService;
        AppLogDataService _AppLogDataService;

        KosInstanceDataService _KosInstanceDataService;
        InfStudyParameterRepository _InfStudyParameterRepository;


        string hataMesajInstance = "";
        string hataMesajInfStundy = "";

        public InfinityDataSyncronizer(IBussinessContext context) : base(context)
        {            
            _InfOracleDataService = new InfOracleDataService(null);
            _InfStudyDataService = new StudyKosDataService(null);
             KosPahtDataService = new KosPahtDataService(null);
            _AppLogDataService = new AppLogDataService(null);
            _KosInstanceDataService = new KosInstanceDataService(null);

            _InfStudyParameterRepository = new InfStudyParameterRepository(null);
        }
        public void SyncronizeInfinityStudyList(long tenantID, long lastID, System.DateTime? startTime, System.DateTime? endTime)
        {
            string Mesaj = "";
            string InstancePhat = "";
            try
            {




                var filter = new DataService.infinity.Model.InfOracleFilter();
                filter.Infcreationstartdate = startTime;
                filter.Infcreationenddate = endTime;

                filter.Infcreationstartdate = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day);


                filter.Infstudypklast = lastID;
                filter.SeriesInfo = "DCMCREATOR";

                filter.Accession_no = _InfStudyDataService.GetAccessionOnekNoByTenantID(tenantID);
                var items = _InfOracleDataService.GetInfOracleList(filter);
                if (items != null && items.Count > 0 )
                {
                  
              

                            var list = new List<InfOraclePostgreStudyViewModel>();
               
                            var volumMap = "";

                            foreach (var item in items)
                            {



                                Mesaj = "Tenat ID : " + tenantID + " Oracle StudyKey " + item.StudyKey;

                                if (item.VolumePathname != null)
                                {

                                     hataMesajInfStundy =  " tenantID : " + tenantID + " StudyKey :" + item.StudyKey + "PatientId : " + item.PatientId;

                                    var model = new InfOraclePostgreStudyViewModel();
                                    model.AccessionNo = item.AccessNo;
                                    model.TimeCreated = item.CreationDttm;
                                    model.FkTenant = tenantID;
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
                                            InstancePhat =  item.VolumePathname.Replace(item.VolumePathname, volumMap) + "/" + item.Pathname;
                                            }
                                            catch(Exception ex)
                                            {
                                                volumMap = KosPahtDataService.GetTenantKosPaht(item.VolumeCode);

                                                throw new NotImplementedException();
                                            }
                                        }
                                        else
                                        {
                                            model.DicomPhat = item.VolumePathname + "\\" + item.Pathname.Replace("/", "\\");
                                            InstancePhat = item.VolumePathname + "\\" + item.Pathname.Replace("/", "\\");
                                        }




                                    }
                                    else
                                    {
                                        model.DicomPhat = "";
                                        InstancePhat = "";
                                    }



                            ////Instance çeken yer.
                            ///
                                        //try
                                        //{
                                        //            var kosfilter = new DataService.infinity.Model.KosInstanceViewFilter();
                                        //            hataMesajInstance = tenantID + "" + item.StudyKey + "" + item.PatientId;

                                        //            if (item.StudyKey != null)
                                        //            {
                                        //                kosfilter.StudyKey = Convert.ToInt32(item.StudyKey);
                                        //                kosfilter.SeriesInfo = "DCMCREATOR";
                                        //                var kositems = _KosInstanceDataService.KosInstanceOracleList(kosfilter);
                                        //                var klist = new List<KosInstanceViewModel>();
                                        //                foreach (var kitem in kositems)
                                        //                {
                                        //                    var kmodel = new KosInstanceViewModel();
                                        //                    kmodel.PatientID = kitem.PatientID;
                                        //                    kmodel.PatientName = kitem.PatientName;
                                        //                    kmodel.StudyKey = kitem.StudyKey;
                                        //                    kmodel.StudyInstanceUID = kitem.StudyInstanceUID;
                                        //                    kmodel.SeriesInstanceUID = kitem.SeriesInstanceUID;
                                        //                    kmodel.SopInstanceUID = kitem.SopInstanceUID;
                                        //                    kmodel.Modalities = kitem.Modalities;
                                        //                    kmodel.AccessNo = kitem.AccessNo;
                                        //                    kmodel.SeriesInfo = kitem.SeriesInfo;
                                        //                    kmodel.InstanceLocPathName = kitem.InstanceLocPathName;
                                        //                    kmodel.VolumePathName = kitem.VolumePathName;
                                        //                    kmodel.FileName = kitem.FileName;
                                        //                    kmodel.InstanceLocKey = kitem.InstanceLocKey;
                                        //                    kmodel.Instance_dcmdir_path = kitem.VolumePathName.Replace(kitem.VolumePathName, volumMap) + "/" + kitem.InstanceLocPathName + "/" + kitem.FileName;

                                        //                    klist.Add(kmodel);
                                        //                }
                                        //                _InfStudyDataService.SaveKosInstance(klist, 1);

                                        //            }
                                        //} catch (Exception es)
                                        //{

                                
                                        //        var hata2 = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                                        //        var message2 = es.Message == null ? "Error Instance -1009" : es.Message.ToString();
                                        //        _AppLogDataService.Save(hata2, message2 + " - "+ hataMesajInstance);
                                        //        hataMesajInstance = "";

                                        //}


                            //Instance çeken yer. bitti



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
                                    // throw new NotImplementedException();
                                }


                            }
           
                           _InfStudyDataService.Save(list, 1);
                }
            }
            catch(Exception ex)
            {
              

                var hata = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                var message = ex.Message == null ? "Error -1003" : ex.Message.ToString();
                _AppLogDataService.Save(hata, message + " tenantID :" + tenantID);
                //throw new Exception("InfOrc SyncronizeInfinityStudyList. Hata-1003:" + " " + ex.Message.ToString());
 
            }
            Mesaj = "";
            hataMesajInstance = "";
        }
    }
}
