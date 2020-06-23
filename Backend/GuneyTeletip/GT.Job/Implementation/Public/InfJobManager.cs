using GT.BAL.Infinity.DataSynronizer;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.SERVICE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Util.Job.Interface;
using Util.Logger;

namespace GT.Job.Implementation
{
    public class InfJobManager : JobManager
    {
        private static InfJobManager _InfJobManager;
        private ILogger logger;

        public static InfJobManager Create(ILogger logger)
        {
            if (_InfJobManager != null)
            {
                throw new Exception("Infinity Job zaten başlamış");
            }
            _InfJobManager = new InfJobManager(logger);
            return _InfJobManager;
        }


        private InfJobManager(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentException("Joıg logger boşi olamaz");
            this.logger = logger;
        }

        private IEnumerable<KosStudyParameter> GetJobs()
        {
            var jobs = new InfStudyDataService(null);
            var paramters = jobs.GetTimerParameters(new InfStudyParameterConditionFilter { RecordState = 1 });
            return paramters;
        }
        public void Start()
        {
            logger.LogInfo("Jobs START");
            try
            {
                var jobs = this.GetJobs();
                logger.LogInfo($"Jobs COUNT:{jobs.Count()}");
                foreach (var item in jobs)
                {
                    RegisterJobs(item);
                }
                StartJobs();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Jobs FAIL");
                throw ex;
            }
            logger.LogInfo("Jobs OK");
        }


        public void Stop()
        {
            JobItems.ToList().ForEach(o => o.Value.Stop());


        }
            private void RegisterJobs(KosStudyParameter item)
        {
            Register(item.Name, item.IntervalMinute.Value * 60 * 1000, () =>
                {
                    logger.LogInfo(item.Name + " başladı");
                    Exception ex = null;
                    try
                    {
                        ActionFunction(item);
                      

                    }
                    catch (Exception ex2)
                    {
                        ex = ex2;

                    }
                    if (ex == null)
                    {
                        logger.LogInfo(item.Name + " bitti");

                    }
                    else
                    {
                        logger.LogError(ex, item.Name);
                    }

                });
        }

        private static void ActionFunction(KosStudyParameter item)
        {


            var dt = new InfinityDataSyncronizer(null);
            dt.SyncronizeInfinityStudyList(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);


        }

        private void StartJobs()
        {
            JobItems.ToList().ForEach(o => o.Value.Start());
        }

    }
}
