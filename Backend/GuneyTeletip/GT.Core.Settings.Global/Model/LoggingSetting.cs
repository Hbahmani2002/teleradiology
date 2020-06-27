using System;
using System.IO;

namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        public class LoggingSetting
        {
            private string FullPath(string relativePath)
            {
                var path = Path.GetFullPath(relativePath, Environment.CurrentDirectory);
                return path;
            }
            public string DIR_JobsLog => FullPath("/upload/_jobs");
            public string DIR_BackgroundProcess => FullPath("../upload/_background");
            public string DIR_JobsLogMakeKos => Path.Combine(DIR_JobsLog, "MakeKos");
            public string DIR_JobsLogManuel => Path.Combine(DIR_JobsLog, "ManuelJobs");
            public string DIR_JobsLogSendKos => Path.Combine(DIR_JobsLog, "SendKos");
            public string DIR_JobsLogSTM => Path.Combine(DIR_JobsLog, "STM");
            public string PATH_JobInfinity => Path.Combine(DIR_JobsLog, "infinity_job_log.txt");
            
        }
    }
}
