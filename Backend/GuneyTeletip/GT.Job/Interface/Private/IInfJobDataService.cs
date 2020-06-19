using GT.BAL.Job.Interface;
using GT.Repository.Models.View;
using System.Collections.Generic;

namespace GT.BAL.Job.Interface
{

    internal interface IInfJobDataService
    {
        IEnumerable<IInfJobServiceDefinition> GetJobParameterList();

        void SyncronizeData(long tenantID, long lastID, System.DateTime startTime);
       
    }
}
