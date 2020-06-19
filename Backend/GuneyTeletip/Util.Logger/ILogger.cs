using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Logger
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(Exception ex, string message);
        void LogDebug(string subject, string message);
    }
}
