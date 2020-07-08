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
using Teletip.SorgulamaServis;
using Util.Job.Interface;
using Util.Logger;
using Util.ProcessUtil;

namespace GT.Job.Implementation
{
    public class STMKosDeleteOperation
    {
        public class STMKosDeleteSetting
        {
            public int ItemPerJob { get; set; }
            public int ParallelTask { get; set; }

            public STMKosDeleteSetting(int itemPerJob, int parallelTask)
            {
                ItemPerJob = itemPerJob;
                ParallelTask = parallelTask;

            }
        }
        STMService STMService { get; set; }
        public STMKosDeleteSetting Settings { get; set; }

        public STMKosDeleteOperation()
        {
            var globalSettings = AppSettings.GetCurrent();
            Settings = new STMKosDeleteSetting(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch, globalSettings.Kos.Make.JOB_MaxParallelTask);

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

                var res = STMService.GetRemoveKos(int.Parse(item.KurumSkrsKodu), item.AccessionNumber, item.StudyInstanceID);

                var studyDataService = new StudyKosDataService();

                //throw new NotImplementedException();
                //if (res != null)
                //{


                //}
                //studyDataService.Save_UpdateDeleteKos(item.StudyID, "");
                progressAction.IncreaseProgressError();
                progressAction.IncreaseProgressSuccess();
            });
        }

        private ProcessResult MakeKos(KosDeleteViewModel item)
        {

            var res = STMService.GetRemoveKos(int.Parse(item.KurumSkrsKodu), item.AccessionNumber, item.StudyInstanceID);

            var studyDataService = new StudyKosDataService();


            var sb = new StringBuilder();
         
            studyDataService.Save_UpdateDeleteKos(item.StudyID, "");
            return null;
        }

        public IEnumerable<ProcessResult> DoSingleBatch(IEnumerable<KosDeleteViewModel> items)
        {
            var resultCollection = new ConcurrentBag<ProcessResult>();
            ParallelLoopResult result = Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                var outputPath = KosOutFileNameGenerator.GetFilePath(item.StudyID);
                var res = MakeKos(item);
                resultCollection.Add(res);
            });
            return resultCollection.ToArray();
        }


    }
}
