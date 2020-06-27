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
            Settings = new SendKosJobSetting(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch, globalSettings.Kos.Make.JOB_MaxParallelTask);
            var makeKosSetting = TeletipKosServiceSetting.GetCurrent().SendKosSettings;
            TeletipSendKosService = new TeletipSendKosService(makeKosSetting);
        }

        public void DoSingleBatch(IEnumerable<SentKosViewModel> items, System.Threading.CancellationTokenSource cancelToken, JobBussinessServiceProgressItem progressAction)
        {

            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                if (cancelToken.IsCancellationRequested)
                {
                    return;
                }
               
                var res = TeletipSendKosService.SendKos(item.PatientId,item.DicomPath);
                var studyDataService = new StudyKosDataService();
                var sb = new StringBuilder();
                sb.AppendLine(res.Message);
                sb.AppendLine("");
                sb.AppendLine("");
                sb.Append(res.Arguments);
                if(res.IsSuccess)
                {
                    //if(res.Message)
                    {
                        throw new NotImplementedException();
                    }
                }
                studyDataService.Save_UpdateSentKosDurum(item.StudyID,StudyKosDataService.SentKosResult.Success , res.Message + res.Arguments);
                progressAction.IncreaseProgressError();
                progressAction.IncreaseProgressSuccess();
            });
        }

    }
}
