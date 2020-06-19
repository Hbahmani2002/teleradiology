using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Job.Interface
{

    internal interface IInfJobServiceDefinition
    {
        int IntervalMinute { get; set; }
        string Name { get; set; }
        long ID { get; set; }
        long TenantID { get; set; }
        long LastStudyID { get; set; }
        DateTime StartTime { get; set; }
    }
}
