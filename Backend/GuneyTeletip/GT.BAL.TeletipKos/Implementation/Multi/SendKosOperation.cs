using App.Data.Service;
using AppAbc.Data.Service;
using GT.BAL.Infinity.DataSynronizer;
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
using Util.Job.Interface;
using Util.Logger;
using Util.ProcessUtil;

namespace GT.Job.Implementation
{
    public class SendKosOperation
    {
        public class SendKosJobSetting
        {
            public int ItemPerJob { get; set; }
            public int ParallelTask { get; set; }

            public SendKosJobSetting(int itemPerJob, int parallelTask)
            {
                ItemPerJob = itemPerJob;
                ParallelTask = parallelTask;

            }
        }
        public SendKosJobSetting Settings { get; }
        TeletipSendKosService TeletipSendKosService { get; set; }
        public SendKosOperation()
        {
            var globalSettings = AppSettings.GetCurrent();
            Settings = new SendKosJobSetting(globalSettings.DataServiceSettings.SendKosServiceItemPerBatch, globalSettings.Kos.Make.JOB_MaxParallelTask);
            var makeKosSetting = TeletipKosServiceSetting.GetCurrent().SendKosSettings;
            TeletipSendKosService = new TeletipSendKosService(makeKosSetting);
        }

        public void DoSingleBatch(IEnumerable<SentKosViewModel> items, System.Threading.CancellationTokenSource cancelToken, JobBussinessServiceProgressItem progressAction)
        {
            try
            {
                Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
                {
                     var log = new AppLogDataService(null);
                        try
                        {
                           
                            if (cancelToken.IsCancellationRequested)
                            {
                                return;
                            }

                            var res = TeletipSendKosService.SendKos(item.PatientId, item.SendDicomPath);
                            var studyDataService = new StudyKosDataService();
                            var sb = new StringBuilder();
                            sb.AppendLine(res.Message);
                            sb.AppendLine("");
                            sb.AppendLine("");
                            sb.Append(res.Arguments);
                            if (res.IsSuccess)
                            {
                                studyDataService.Save_UpdateSentKosDurum(item.StudyID, StudyKosDataService.SentKosResult.Success, res.Message + res.Arguments);
                            }
                            else
                            {
                                studyDataService.Save_UpdateSentKosDurum(item.StudyID, StudyKosDataService.SentKosResult.Fail, res.Message + res.Arguments);
                            }



                            progressAction.IncreaseProgressError();
                            progressAction.IncreaseProgressSuccess();

                        }
                        catch (Exception ex)
                        {
                            log.Save(AppLogDataService.LogType.OtomatikMakeKos, "Log File Path DoSingleBatch :" + ex.Message.ToString().Substring(0, 500));                
                        }



                 });

            }
            catch 
            {

            }


        }



        public IEnumerable<ProcessResult> DoSingleBatch(IEnumerable<SentKosViewModel> items)
        {
            var resultCollection = new ConcurrentBag<ProcessResult>();
            ParallelLoopResult result = Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {

                var outputPath = KosOutFileNameGenerator.GetFilePath(item.StudyID);
                var res = TeletipSendKosService.SendKosCa(item.PatientId, item.SendDicomPath);
                var studyDataService = new StudyKosDataService();
                var sb = new StringBuilder();


           


                sb.AppendLine(res.Message);
                sb.AppendLine("");
                sb.AppendLine("");
                sb.Append(res.Arguments);
                var sonuc =  studyDataService.Save_UpdateSentKosDurum(item.StudyID, StudyKosDataService.SentKosResult.Success, res.Message + res.Arguments);
                resultCollection.Add(res);




            });
            return resultCollection.ToArray();
        }









    }
}
