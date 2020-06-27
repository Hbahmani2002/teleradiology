using System;
using System.Diagnostics;
using System.Text;
using Util.ProcessUtil;

namespace Util.ProcessUtil
{
    public class ProcessUtil
    {
        public static ProcessResult Start(string command, string args, string workingDirectory = null)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            var res = new ProcessResult();
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {

                res.Message = ex.ToString();
                return res;
            }

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();


            res.Arguments = args;
            if (string.IsNullOrEmpty(error))
            {
                res.IsSuccess = true;
                res.Message = output;
            }
            else
            {
                res.IsSuccess = false;
                res.Message = error;
            }
            return res;
        }
        // static string WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
        private static ProcessResult Start2(string fileName, string args, string workingDirectory)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,

                //ErrorDialog = false,
                UseShellExecute = false,
                CreateNoWindow = true,
                //WorkingDirectory = workingDirectory

                //StandardOutputEncoding = Encoding.UTF8,
                RedirectStandardOutput = true,
                RedirectStandardError = true,

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
