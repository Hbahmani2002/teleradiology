﻿
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Models.View;
using GT.SERVICE;
using System;
using System.Collections.Generic;


namespace GT.BAL.Infinity.DataSynronizer
{
    public class InfinityDataSyncronizer : BaseService
    {
        InfOracleDataService _InfOracleDataService;
        StudyKosDataService _InfStudyDataService;
        public InfinityDataSyncronizer(IBussinessContext context) : base(context)
        {            
            _InfOracleDataService = new InfOracleDataService(null);
            _InfStudyDataService = new StudyKosDataService(null);

        }
        public void SyncronizeInfinityStudyList(long tenantID, long lastID, System.DateTime? startTime, System.DateTime? endTime)
        {
            var filter = new DataService.infinity.Model.InfOracleFilter();
            filter.Infcreationstartdate = startTime;


            filter.Infcreationstartdate = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day);


            filter.Infstudypklast = lastID;
            filter.Accession_no = _InfStudyDataService.GetAccessionOnekNoByTenantID(tenantID);
            var items=_InfOracleDataService.GetInfOracleList(filter);
            var list = new List<InfOraclePostgreStudyViewModel>();

        

            foreach (var item in items)
            {
                
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
                model.DateBirth = DateTime.Now; // item.PatientBirthDttm.Value == null ? DateTime.Now : item.PatientBirthDttm.Value;
                model.StudyDate = DateTime.Now;
                model.StoragePath = item.Pathname;
                model.PatinetNameSurname = item.PatientName;
                model.CihazDeviceSerialNumber = null;
                model.Desc1 = null;
                model.Desc2 = null;
                model.Desc3 = null;
                model.TimeCreated = DateTime.Now;
                model.TimeModified =null;
                model.Institution =item.Institution;
                model.SeriesCount = 0;
                model.SeriesKey = 0;
                model.InstanceKey = "";
                model.FileName = item.Filename;
                model.ValumeCode = item.VolumeCode;
                model.ValumeType = item.VolumeType;
                model.ValumeStat = item.VolumeStat;
                model.ValumePathname = item.VolumePathname;
                model.CreationDttm = DateTime.Now;
                model.OracleStudyKey =item.StudyKey;
                model.FkKosEnumType = 2;
                model.InfMergeKey = item.InfMergeKey;
                model.SeriesInfo = item.SeriesInfo;
                model.DicomPhat = item.VolumePathname + "\\" + item.Pathname;

                string OrcleZeroImages = AppSettings.GetCurrent().InfinityOracleSettings.ZeroImageGeneratorName.ToString();
             


                if ( item.SeriesInfo == OrcleZeroImages)
                {
                    
                    model.ZeroImg = 1;
                }
                else
                {
                    model.ZeroImg = 0;
                }

          

                list.Add(model);
               // throw new NotImplementedException();
                
            }
            _InfStudyDataService.Save(list);

        }
    }
}
