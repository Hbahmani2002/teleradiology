using System;

namespace GT.BAL.Job.Interface
{
    internal interface IJobServiceAction
    {
        Action GetInfinityJobParamterList(IInfJobServiceDefinition serviceDefiniton);
    }
}
