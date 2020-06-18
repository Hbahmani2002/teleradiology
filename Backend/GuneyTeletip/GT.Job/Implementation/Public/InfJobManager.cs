using GT.BAL.Infinity.DataSynronizer;
using GT.BAL.Job.Interface;
using GT.DataService.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Util.Job.Interface;

namespace GT.BAL.Job.Implementation
{
    public class InfJobManager : IInfJobManager
    {
        private static InfJobManager _InfJobManager;
        public static InfJobManager Create()
        {
            if (_InfJobManager != null)
            {
                throw new Exception("Infinity Job zaten başlamış");
            }
            _InfJobManager = new InfJobManager();
            return _InfJobManager;
        }
        private InfJobManager()
        {
            JobManager = new JobManager();

        }


        private IEnumerable<InfStudyParameter> GetJobs()
        {
            var jobs = new InfStudyDataService(null);
            var paramters = jobs.GetTimerParameters(new InfStudyParameterConditionFilter { RecordState = 1 });
            return paramters;
        }
        public void Load()
        {
            var jobs = this.GetJobs();

            foreach (var item in jobs)
            {
                JobManager.Register(item.Name, item.IntervalMinute.Value, () =>
                {
                    try
                    {

                        var dt = new InfinityDataSyncronizer();
                        dt.SyncronizeInfinityStudyList(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                });
            }
            StartJobs();
        }

        private void StartJobs()
        {
            JobManager.JobItems.ToList().ForEach(o => o.Value.Start());
        }

        public JobManager JobManager { get; set; }
    }
}
