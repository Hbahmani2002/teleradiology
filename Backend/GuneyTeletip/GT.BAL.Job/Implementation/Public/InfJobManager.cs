using GT.BAL.Job.Interface;
using System;
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
            JobDataService = new InfJobDataService();
        }
        public void Load()
        {
            var jobs = JobDataService.GetInfinityJobParameterList();

            foreach (var item in jobs)
            {
                JobManager.Register(item.Name, item.IntervalMinute, () =>
                {
                    var getStudyList = JobDataService.GetInfinityStudyList(item.TenantID, item.LastStudyID, item.StartTime);
                });
            }
            StartJobs();
        }

        private void StartJobs()
        {
            JobManager.JobItems.ToList().ForEach(o => o.Value.Start());
        }

        public JobManager JobManager { get; set; }
        private IInfJobDataService JobDataService { get; set; }
    }
}
