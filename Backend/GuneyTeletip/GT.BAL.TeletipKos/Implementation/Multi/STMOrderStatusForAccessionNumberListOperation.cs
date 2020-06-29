﻿using GT.BAL.Infinity.DataSynronizer;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.Repository.Models.View;
using GT.Repository.Models.View.Composite;
using GT.SERVICE;
using GT.TeletipKos;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teletip.SorgulamaServis;
using Util.Job.Interface;
using Util.Logger;

namespace GT.Job.Implementation
{
    

    public class STMOrderStatusForAccessionNumberListOperation
    {

        OrderStatusForAccessionNumberDataService _OrderStatusForAccessionNumberDataService;

        public class STMOrderStatusForAccessionNumberListSetting
        {
            public int ItemPerJob { get; set; }
            public int ParallelTask { get; set; }

            public STMOrderStatusForAccessionNumberListSetting(int itemPerJob, int parallelTask)
            {
                ItemPerJob = itemPerJob;
                ParallelTask = parallelTask;

            }
        }
        STMService STMService { get; set; }
        public STMOrderStatusForAccessionNumberListSetting Settings { get; set; }

        public STMOrderStatusForAccessionNumberListOperation()
        {
            var globalSettings = AppSettings.GetCurrent();
            Settings = new STMOrderStatusForAccessionNumberListSetting(globalSettings.DataServiceSettings.OrderServiceItemPerBatch, globalSettings.Kos.Make.JOB_MaxParallelTask);

            var stmSettings = globalSettings.STM;
            var token = new STMTokenProvider(stmSettings.BASEADDRESS, stmSettings.userTokenName, stmSettings.userTokenPassword, stmSettings.HBYS_PACS_ResourceOwnerClient, stmSettings.identityServerBaseUri).GetToken();
            STMService = new STMService(token, stmSettings.BASEADDRESS);
        }

        public void DoSingleBatch(IEnumerable<KosDeleteViewModel> items, System.Threading.CancellationTokenSource cancelToken, JobBussinessServiceProgressItem progressAction)
        {

            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                if (cancelToken.IsCancellationRequested)
                {
                    return;
                }


                List<string> AccessionNumber = new List<string>();
                AccessionNumber.Add(item.AccessionNumber);

                var studyDataService = new StudyKosDataService();
              



                var res = STMService.GetOrderStatusForAccessionNumberList(int.Parse(item.AccessionNumber), AccessionNumber);
                var list = new List<OrderStatusForAccessionNumberViewModel>();
                var items = studyDataService.GetByID(Convert.ToInt32(item.StudyID));
                _OrderStatusForAccessionNumberDataService = new OrderStatusForAccessionNumberDataService(null);

                if (res != null)
                {
                    foreach (var Gelenitem in res)
                    {
                       
                        var model = new OrderStatusForAccessionNumberViewModel();

                        model.FkTenant = items.TenantID;
                        model.FkInfBatch = items.InfBatchID;
                        model.FkKosStudy = items.ID;
                        model.FkUserCreated = 0;
                        model.FkUserModified = 0;
                        model.Accessionnumber = item.AccessionNumber;
                        model.Citizenid = Gelenitem.CitizenId;
                        model.Teletipstatus = Gelenitem.TeletipStatus;
                        model.Teletipstatusid = Gelenitem.TeletipStatusId;
                        model.Medulastatus = Gelenitem.MedulaStatus;
                        model.Medulastatusid = Gelenitem.MedulaStatusId;
                        model.Wadostatus = Gelenitem.WadoStatus;
                        model.Wadostatusid = Gelenitem.WadoStatusId;
                        model.Reportstatus = Gelenitem.ReportStatus;
                        model.Reportstatusid = Gelenitem.ReportStatusId;
                        model.Dosestatus = "";
                        model.Dosestatusid = 0;
                        model.Medulainstitutionid = Gelenitem.MedulaInstitutionId;
                        model.Sutcode = Gelenitem.SutCode;
                        model.Lastmedulasenddate = DateTime.Now;
                        model.Medularesponsecode = Gelenitem.MedulaResponseCode;
                        model.Medularesponsemessage = Gelenitem.MedulaResponseMessage;
                        model.Scheduledate = Gelenitem.ScheduleDate;
                        model.Performeddate = Gelenitem.PerformedDate;
                        model.Error = Gelenitem.Error;
                        model.Patienthistorysearchstatus = "";
                        model.Patienthistorysearchstatusid = 0;
                        model.TimeCreated = DateTime.Now;
                        model.TimeModified = null;

                        list.Add(model);
                    }

                   

                    _OrderStatusForAccessionNumberDataService.Save(list);


                }



                //throw new NotImplementedException();
                //if (res != null)
                //{


                //}
                //studyDataService.Save_UpdateDeleteKos(item.StudyID, "");



                progressAction.IncreaseProgressError();
                progressAction.IncreaseProgressSuccess();
            });
        }

    }
}