using Util.Job.Interface;

namespace GT.BAL.Job.Interface
{
    public interface IInfJobManager
    {
        JobManager JobManager { get; set; }
        void Load();
    }
}
