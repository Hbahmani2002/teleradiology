using System;
using System.Collections.Generic;
using System.Text;

namespace GT.BAL.Job.Interface
{
    interface IGTJobDataService
    {
        IEnumerable<IJobParamterModel> GetInfinityJobParamterList(long lastId);
    }

    public interface IJobParamterModel
    {
        int Interval { get; set; }
        string name { get; set; }
        long tenat_fk { get; set; }
     




    }
}
