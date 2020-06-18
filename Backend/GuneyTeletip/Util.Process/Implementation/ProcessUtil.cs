using System;
using System.Diagnostics;
using System.Text;
using Util.ProcessUtil;

namespace Util.ProcessUtil
{
    public class ProcessUtil
    {
        
        // static string WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
        public static ProcessResult Start(string fileName, string args, string workingDirectory)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,
                ErrorDialog = false,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding.UTF8,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            };
            var res = new ProcessResult();
            var stringBuilder = new StringBuilder();

            try
            {                
                using (var process = Process.Start(startInfo))
                using (var output = process.StandardOutput)
                using (var error = process.StandardError)
                {
                    stringBuilder.Append(output.ReadToEnd());
                    res.IsSuccess = true;
                    if (stringBuilder.Length == 0)
                    {
                        res.IsSuccess = false;
                        stringBuilder.Append(error.ReadToEnd());
                    }
                    process.WaitForExit();
                }
                res.Message = stringBuilder.ToString();
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.ToString();
                return res;
            }
        }
    }
}
