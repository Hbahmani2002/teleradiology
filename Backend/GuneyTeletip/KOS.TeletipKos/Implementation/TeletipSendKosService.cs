using GT.TeletipKos.Model;
using KOS.TeletipKos;
using System;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class TeletipSendKosService
    {
        public TeletipKosServiceSetting.SendKosServiceSettings Settings { get; }
        public TeletipSendKosService(TeletipKosServiceSetting.SendKosServiceSettings settings)
        {
            Settings = settings;
        }
        private ProcessResult SendKosOLD(SendKosParameter par)
        {
            /*
            var res = string.Format(" {0} {1} \"{2}\"", par.PatientId, par.KosFilePath.Replace('\\', '/'), Settings.SendKosServiceURL.Replace('\\', '/'));
            var processStr = string.Format("-jar -Duser.language=en {1} {0}", res, Settings.SendKosJarName);
            var ret = ProcessUtil.Start("java", processStr);
            return ret;
            */
            return null;
        }

        public SendKosProcessResult SendKos(string patientId, string kosFilePath)
        {
            var settings = Settings;
            var processParameter = $"-jar \"{settings.AppFilePath}\" \"{patientId}\" \"{kosFilePath}\" \"{settings.ServiceURL}\" \"{settings.AxisRepoDirectoryPath}\" \"{settings.AxisXmlFilePath}\" ";
            var processResult = ProcessUtil.Start("java", processParameter);
            var sc = new SendKosProcessResult(processResult);            
            return sc;
        }

        public ProcessResult SendKosCa(string patientId, string kosFilePath)
        {
          

            var settings = Settings;
            var processParameter = $"-jar \"{settings.AppFilePath}\" \"{patientId}\" \"{kosFilePath}\" \"{settings.ServiceURL}\" \"{settings.AxisRepoDirectoryPath}\" \"{settings.AxisXmlFilePath}\" ";
            var processResult = ProcessUtil.Start("java", processParameter);
            //var sc = new SendKosProcessResult(processResult);
            return processResult;






        }



    }
}
