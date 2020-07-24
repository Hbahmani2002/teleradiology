using GT.TeletipKos.Model;
using System;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class TeletipMakeKosService
    {
        public TeletipKosServiceSetting.MakeKosServiceSettings Settings { get; }
        public TeletipMakeKosService(TeletipKosServiceSetting.MakeKosServiceSettings settings)
        {
            Settings = settings;
        }
        public ProcessResult MakeKos(string inputStudyDirectoryPath,string outputKosFilePath,string institutionName,string institutionSKRS)
        {
            var makeKosSettings = Settings;

            var output = outputKosFilePath;
            var input = inputStudyDirectoryPath;

            var res = $@"--title {makeKosSettings.Title} --institution-insname {institutionName}^^^SKRS{institutionSKRS}^^^{makeKosSettings.InstitutionFirmaKodu} --location-uid  {makeKosSettings.LocationUID} --temp-tlocation {makeKosSettings.TempDirectory} --dcm-dcmlocation {makeKosSettings.DCM4CheeDirectory}";
            var processParameter = $"-jar {makeKosSettings.AppFilePath} {res} -o {output} {input}";

            var processResult = ProcessUtil.Start("java", processParameter);
            
            return processResult;
        }
        
        public ProcessResult MakeKosJSON()
        {
            //var makeKosSettings = Settings;

            //var output = outputKosFilePath;
            //var input = inputStudyDirectoryPath;

            //java - jar / mnt / DB / gt - server - volume / app / teletip_kos / MakeKOS_protekV2.jar--title "DCM-113030"
            //    --location - uid "1.3.6.1.4.1.21367.2017.10.26.111"
            //    --temp - tlocation "./"
            //    --dcm - dcmlocation / mnt / DB / gt - server - volume / app / teletip_kos / dcm4che - 5.22.2 / bin
            //    --dcmjson "/mnt/DB/gt-server-volume/test_java/MakeKosParametter.json" 
            //    - o cikti.dcm / mnt / DB / gt - server - volume / app / teletip_kos / E37678675
            var Title = "DCM-113030";
            var locationuid = "1.3.6.1.4.1.21367.2017.10.26.111";
            var tempLocation = "./";
            var dcmLocation = "/mnt/DB/gt-server-volume/app/teletip_kos/dcm4che-5.22.2/bin";
            var dcmJson = "/mnt/DB/gt-server-volume/test_java/MakeKosParametter.json";
            var fileName = "test.dcm";
            var filePath = "/mnt/DB/gt-server-volume/app/teletip_kos/E37678675";
            var javaMakekos = "/mnt/DB/gt-server-volume/app/teletip_kos/MakeKOS_protekV2.jar";
            var res = $@"--title {Title} --location -uid {locationuid} --temp{tempLocation} --dcm -dcmlocation{dcmLocation} --dcmjson{dcmJson}";
            var processParameter = $"-jar {javaMakekos} {res} -o {fileName} {filePath}";

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
