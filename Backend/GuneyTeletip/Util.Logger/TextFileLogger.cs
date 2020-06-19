using System;
using System.IO;
using System.Text;

namespace Util.Logger
{
    public class TextFileLogger : ILogger
    {
        public StreamWriter StreamWriter { get; set; }

        public TextFileLogger(string filePath)
        {
            StreamWriter = new StreamWriter(filePath, true)
            {
                AutoFlush = true
            };
        }
        public void LogDebug(string subject, string message)
        {
            var sb = LogBegin();
            sb.AppendFormat("##D##{0}", subject ?? "Subject");
            sb.AppendLine();
            sb.AppendFormat("{0}", message ?? "message");
            sb.AppendLine();
            LogEnd(sb);
        }



        public void LogError(Exception ex, string message)
        {
            var sb = LogBegin();
            sb.AppendFormat("##E##{0}", ex.ToString());
            sb.AppendLine();
            sb.AppendFormat("{0}", message ?? "message");
            sb.AppendLine();
            LogEnd(sb);
        }

        public void LogInfo(string message)
        {
            var sb = LogBegin();
            sb.AppendFormat("##Info##");
            sb.AppendLine();
            sb.AppendFormat("{0}", message ?? "message");
            sb.AppendLine();
            LogEnd(sb);
        }

        private StringBuilder LogBegin()
        {
            var sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString("yyyyMMdd HH:MM:ss:ffff"));

            return sb;
        }
        private void LogEnd(StringBuilder sb)
        {
            StreamWriter.Write(sb);
        }
    }
}
