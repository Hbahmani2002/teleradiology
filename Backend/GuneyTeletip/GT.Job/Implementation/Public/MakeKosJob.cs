using GT.BAL.Infinity.DataSynronizer;
using GT.BAL.TeletipKos.Model;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.SERVICE;
using GT.TeletipKos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Job.Interface;
using Util.Logger;

namespace GT.Job.Implementation
{
    public class MakeKosJob
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
        JobDataService JobDataService { get; }
        InfStudyDataService StudyDataService { get; }
        TeletipMakeKosService TeletipMakeKosService { get; set; }

        public MakeKosJob()
        {
            var globalSettings = AppSettings.GetCurrent();
            Settings = new MakeKosJobSetting(globalSettings.DataServiceSettings.MakeKosServiceItemPerBatch, globalSettings.Kos.Make.JOB_MaxParallelTask);
            var makeKosSetting = TeletipKosServiceSetting.GetCurrent().MakeKosSettings;

            JobDataService = new JobDataService(null);
            StudyDataService = new InfStudyDataService(null);
            TeletipMakeKosService = new TeletipMakeKosService(makeKosSetting);
        }

        public void DoSingleBatch(System.Threading.CancellationTokenSource cancelToken)
        {
            var jobId = JobDataService.Save(DateTime.Now, JobDataService.JopEnumType.MakeKos);
            var items = StudyDataService.GetMakeKosList(Settings.ItemPerJob);

            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, o =>
            {
                if (cancelToken.IsCancellationRequested)
                {
                    return;
                }
                var outputPath = KosOutFileNameGenerator.GetFilePath(o.StudyID);
                TeletipMakeKosService.MakeKos(o.InputStudyDirectoryPath, outputPath);
                StudyDataService.UpdateKosDurum(o.StudyID, 20);
            });

            JobDataService.UpdateAndClose(jobId, DateTime.Now);

        }

    }
}
