﻿using AppAbc.Data.Service;
using GT.BAL.Infinity.DataSynronizer;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
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
using Util.Job.Interface;
using Util.Logger;
using Util.ProcessUtil;
using AppAbc.Data.Service;
using System.IO;

namespace GT.Job.Implementation
{
    public class MakeKosOperation
    {

        AppLogDataService _AppLogDataService;

      
        public class MakeKosJobSetting
        {
            public int ItemPerJob { get; set; }
            public int ParallelTask { get; set; }

            public MakeKosJobSetting(int itemPerJob, int parallelTask)
            {
                ItemPerJob = itemPerJob;
                ParallelTask = parallelTask;

            }
        }
        public MakeKosJobSetting Settings { get; }
        TeletipMakeKosService TeletipMakeKosService { get; set; }

        public MakeKosOperation()
        {
            var globalSettings = AppSettings.GetCurrent();
            Settings = new MakeKosJobSetting(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch, globalSettings.Kos.Make.JOB_MaxParallelTask);
            var makeKosSetting = TeletipKosServiceSetting.GetCurrent().MakeKosSettings;
            TeletipMakeKosService = new TeletipMakeKosService(makeKosSetting);
        }

        public void DoSingleBatch(IEnumerable<MakeKosViewModel> items, System.Threading.CancellationTokenSource cancelToken, JobBussinessServiceProgressItem progressAction)
        {
            var resultCollection = new ConcurrentBag<int>();
            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                if (cancelToken.IsCancellationRequested)
                {
                    return;
                }
                ProcessResult Result = MakeKos(item);


                if (Result.IsSuccess == true)
                {
                     progressAction.IncreaseProgressSuccess();
                     
                    _AppLogDataService = new AppLogDataService();
                    var hata = AppAbc.Data.Service.AppLogDataService.LogType.DoSingleBatchMakeKosBackroud;
                    _AppLogDataService.Save(hata, Result.Arguments);


                }
                else
                {
                    progressAction.IncreaseProgressError();
                    _AppLogDataService = new AppLogDataService();
                    var hata = AppAbc.Data.Service.AppLogDataService.LogType.DoSingleBatchMakeKosBackroud;
                    _AppLogDataService.Save(hata, Result.Arguments);
                }



                //progressAction.IncreaseProgressSuccess();
                //progressAction.IncreaseProgressError();


            });
        }

        private ProcessResult MakeKos(MakeKosViewModel item)
        {
            var outputPath = KosOutFileNameGenerator.GetFilePath(item.StudyID);
            var res = TeletipMakeKosService.MakeKos(item.InputStudyDirectoryPath, outputPath, item.InstitutionName, item.InstitutionSKRS);
            var studyDataService = new StudyKosDataService();
            var sb = new StringBuilder();
            sb.AppendLine(res.Message);
            sb.AppendLine("");
            sb.AppendLine("");
            sb.Append(res.Arguments);

            if (res.IsSuccess == true)
            {
                studyDataService.Save_UpdateMakeKosDurum(item.StudyID, res.IsSuccess, outputPath, res.Message + res.Arguments);
              
            }
            else
            {
                studyDataService.Save_UpdateMakeKosDurum(item.StudyID, res.IsSuccess, outputPath, res.Message + res.Arguments);

            }


            //////string MakeKosTempSil =  "/gt/dicom/temp_kos";
            //////CAGDAS SİLME
            //////if (File.Exists(MakeKosTempSil))
            //////{
            //////    File.Delete(dcmJson);
            //////}



            return res;
        }

        public IEnumerable<ProcessResult> DoSingleBatch(IEnumerable<MakeKosViewModel> items)
        {
            var resultCollection = new ConcurrentBag<ProcessResult>();
            ParallelLoopResult result = Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                var res = MakeKos(item);
                resultCollection.Add(res);
            });
            return resultCollection.ToArray();
        }

        public IEnumerable<ProcessResult> DoSingleBatchJSON(IEnumerable<MakeKosViewModel> items)
        {

            var resultCollection = new ConcurrentBag<ProcessResult>();
            var studyDataService = new StudyKosDataService();
            long qStudyID;
            string outputPathTry;
            try
            {
               
                foreach (var item in items)
                {
                    var outputPath = KosOutFileNameGenerator.GetFilePath(item.StudyID);
                    
                    var dicomFilePathList = new List<MakeKosInstanceItem>();
                    if (item.DicomInstanceList == null || item.DicomInstanceList.Count() <= 0)
                        continue;
                    foreach (var dicomInstance in item.DicomInstanceList)
                    {
                        dicomFilePathList.Add(new MakeKosInstanceItem(dicomInstance));
                    }
                    var res = TeletipMakeKosService.MakeKosJSON(dicomFilePathList.ToArray(), outputPath, item.InstitutionName, item.InstitutionSKRS, null, null, item.AccessionNumber, item.PatientId);
                    resultCollection.Add(res);
                    qStudyID = item.StudyID;


                    _AppLogDataService = new AppLogDataService();
                    var hata = AppAbc.Data.Service.AppLogDataService.LogType.KosInstanceHata;

                    _AppLogDataService.Save(hata, res.Message.ToString());

                    studyDataService.Save_UpdateMakeKosDurum(item.StudyID, res.IsSuccess, outputPath, res.Message + res.Arguments);
                
                }
            }
            catch(Exception ex )
            {

                foreach (var item in items)
                {

                    outputPathTry = KosOutFileNameGenerator.GetFilePath(item.StudyID);
                    studyDataService.Save_UpdateMakeKosDurum(item.StudyID, true, outputPathTry, ex.InnerException.Message + " " + ex.Message.ToString());
                }

                _AppLogDataService = new AppLogDataService();
                var hata = AppAbc.Data.Service.AppLogDataService.LogType.KosInstanceHata;
                var message = ex.InnerException.Message == null ? "Error -20021" : ex.InnerException.Message.ToString();
                _AppLogDataService.Save(hata, message);
               
              
            }


            return resultCollection.ToArray();
        }

    }
}
