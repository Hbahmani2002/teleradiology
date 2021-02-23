using AppAbc.Data.Service;
using GT.BAL.Infinity.DataSynronizer;
using GT.Core.Settings;
using GT.DataService.Implementation;
using GT.DataService.infinity.Implementation;
using GT.Persistance.Domain.Models;
using GT.Repository.Implementation;
using GT.SERVICE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Util.Job.Interface;
using Util.Logger;


namespace GT.Job.Implementation
{
    public class InfJobManager : JobManager
    {
        private static InfJobManager _InfJobManager;
        private ILogger logger;
        KosStudyParameterDataService _KosStudyParameterDataService;
      
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
            var jobs = new StudyKosDataService(null);
            var paramters = jobs.GetTimerParameters(new InfStudyParameterConditionFilter { RecordState = 1 });
            //var paramters = jobs.GetTimerParameters(new InfStudyParameterConditionFilter { RecordState = 99 });
           
            return paramters;
        }
        public void Start()
        {
            logger.LogInfo("Jobs START");
            try
            {
                var jobs = this.GetJobs();
                //_KosStudyParameterDataService = new KosStudyParameterDataService(null);
                //_KosStudyParameterDataService.Save(jobs);
                logger.LogInfo($"Jobs COUNT:{jobs.Count()}");
                foreach (var item in jobs)
                {

                    RegisterJobs(item);
                    //RegisterJobs(null);
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
                        //ActionFunction(null);
                        ActionFunctionDelete(null);
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


        private static void ActionFunctionDelete(KosStudyParameter item)
        {
            AppLogDataService _AppLogDataService;

            try
            {
               
                string dosya = "";
                string[] paths = null;
          
                string DicomKostemp = "/gt/dicom/temp_kos/";
                paths = System.IO.Directory.GetFiles(DicomKostemp, "*.jpg", System.IO.SearchOption.AllDirectories);

                foreach (string filedcmPhat in paths)
                {

             
                    _AppLogDataService = new AppLogDataService(null);
                    var hata = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                    var message =  "ErrorImg -10026  " + filedcmPhat;
                    _AppLogDataService.Save(hata, message);

                    dosya = filedcmPhat;
                    File.Delete(dosya);
                 
                }

            }
            catch (Exception ex)
            {
       
                _AppLogDataService = new AppLogDataService(null);
                var hata = AppAbc.Data.Service.AppLogDataService.LogType.InfOrclHata;
                var message = ex.Message == null ? "Error -1003" : ex.Message.ToString();
                _AppLogDataService.Save(hata, message);

            }
        }





            private static void ActionFunction(KosStudyParameter item)
        {

            


            var dt = new InfinityDataSyncronizer(null);
            var dt1 = new InfinityDataSyncronizer(null);

            var jobs = new StudyKosDataService(null);
            var paramtersjobs = jobs.GetTimerParameters(new InfStudyParameterConditionFilter { RecordState = 1 });

            //if (paramtersjobs.ToList().Count==1)
            //{

            //    DateTime Otosaat = DateTime.Now;
            //    var bassaat =  DateTime.Now.ToString("dd.MM.yyyy 18:00:00");
            //    var bitsaat = DateTime.Now.ToString("dd.MM.yyyy 22:00:00");
            //    var saat = Otosaat.ToString("dd.MM.yyyy HH:mm:ss");

            //    dt1.ParameterRepositoryUpdate(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop)


            //    if ( Convert.ToDateTime(bassaat) > Convert.ToDateTime(saat)  &&  Convert.ToDateTime(saat) < Convert.ToDateTime(bitsaat) )
            //    {
            //        dt.SyncronizeInfinityStudyList(item.FkTenant.Value, 0, item.TimeStart, item.TimeStop);
            //    }
            //    else
            //    {
            //        dt.SyncronizeInfinityStudyList(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);
            //    }

            //    foreach (var items in paramtersjobs)
            //    {
            //    }

            //}
            //else
            //{

                dt.SyncronizeInfinityStudyList(item.FkTenant.Value, item.OracleStudyKeyLast.Value, item.TimeStart, item.TimeStop);


            //}

            


           




        }

        private void StartJobs()
        {
            JobItems.ToList().ForEach(o => o.Value.Start());
        }

    }
}
