using GT.TeletipKos.Model;
using System;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class TeletipKosService
    {
        public TeletipKosServiceSettings Settings { get; }
        public TeletipKosService(TeletipKosServiceSettings settings)
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

        public ProcessResult SendKos(SendKosParameter par)
        {
            var settings = Settings.SendKosSettings;

            var processParameter = $"-jar {settings.AppFilePath} {par.PatientId} {par.KosFilePath} \"{settings.ServiceURL}\"";
            var processResult = ProcessUtil.Start("java", processParameter);
            return processResult;
        }

        public ProcessResult MakeKos(MakeKosParameter par)
        {
            var makeKosSettings = Settings.MakeKosSettings;

            var output = par.OutputKosFilePath;
            var input = par.InputStudyDirectoryPath;

            var res = $@"--title {makeKosSettings.Title} --location-uid  {makeKosSettings.LocationUID} --temp-tlocation {makeKosSettings.TempDirectory} --dcm-dcmlocation {makeKosSettings.DCM4CheeDirectory}";
            var processParameter = $"-jar {makeKosSettings.AppFilePath} {res} -o {output} {input}";

            var processResult = ProcessUtil.Start("java", processParameter);
            return processResult;
        }
        private ProcessResult MakeKosOld(MakeKosParameter par)
        {
            //var res = $@"--title {par.Title} --institution-insname {par.InstitutionName}^^^SKRS{par.InstitutionSKRS}^^^{par.InstitutionFirmaKodu} --location-uid {par.LocationUid} --temp-tlocation {par.TempDirectoryPath.Replace('\\', '/')} --dcm-dcmlocation {par.DcmDirectoryPath.Replace('\\', '/')} --number-accession {par.AccessionNumber} --patient-sex {par.PatientSex} --patient-pid {par.PatientId} -o {par.OutputKosFilePath.Replace('\\', '/')} {par.InputStudyDirectoryPath.Replace('\\', '/')}";

            //var processStr = string.Format("-jar {1} {0}", res, "jar file name");
            //Console.WriteLine(processStr);
            //var ret = ProcessUtil.Start("java", processStr);
            //return ret;
            return null;
        }

        private string GetTESTInfo()
        {

            var makeKosJarName = "MakeKOS_v21";
            var makeKosAppLocation = $"/gt/app/teletip_kos/{makeKosJarName}.jar";

            var output = $"/gt/dicom/kos/test_{Guid.NewGuid().ToString().Replace("-", "")}.dcm";
            var input = "/gt/dicom/study/YKCK01/20200519/E0071610";

            var tempTLocation = "/gt/dicom/temp_kos";
            var dcmLocation = "/gt/app/teletip_kos/dcm4che-5.22.2/bin";
            var res = $@" --title DCM-113030 --location-uid  1.3.6.1.4.1.21367.2017.10.26.111 --temp-tlocation {tempTLocation} --dcm-dcmlocation {dcmLocation} -o {output} {input}";
            //java -jar /app/dicom/MakeKOS_v21.jar --title DCM-113030 --location-uid  1.3.6.1.4.1.21367.2017.10.26.111 --temp-tlocation /app/dicom/temp --dcm-dcmlocation /app/dicom/dcm4che-5.22.2/bin -o /app/dicom/output/test.dcm /app/dicom/dicom-input-files
            var processStr = $"-jar {makeKosAppLocation} {res}";
            return processStr;

        }
    }
}
