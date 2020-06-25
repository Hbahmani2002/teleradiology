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

        public void DoSingleBatch(IEnumerable<KosDeleteViewModel> items, System.Threading.CancellationTokenSource cancelToken, Action<JobBussinessServiceProgressItem> progressAction)
        {

            Parallel.ForEach(items, new ParallelOptions() { MaxDegreeOfParallelism = Settings.ParallelTask }, item =>
            {
                if (cancelToken.IsCancellationRequested)
                {
                    return;
                }

                var res = STMService.GetRemoveKos(0, item.AccessionNumber, item.StudyInstanceID);

                var studyDataService = new StudyKosDataService();
               
                throw new NotImplementedException();
                //if (res != null)
                //{

                //}
                studyDataService.Save_UpdateDeleteKos(item.StudyID, "");
                progressAction(new JobBussinessServiceProgressItem(0, 0));
            });
        }

    }
}
