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

namespace GT.Job.Implementation
{
    public class MakeKosOperation
    {
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
                MakeKos(item);
                progressAction.IncreaseProgressError();
                progressAction.IncreaseProgressSuccess();
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
            studyDataService.Save_UpdateMakeKosDurum(item.StudyID, res.IsSuccess, outputPath, res.Message + res.Arguments);
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

    }
}
