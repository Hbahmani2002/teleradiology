using GT.TeletipKos.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public partial class TeletipMakeKosService
    {
        public TeletipKosServiceSetting.MakeKosServiceSettings Settings { get; }
        public TeletipMakeKosService(TeletipKosServiceSetting.MakeKosServiceSettings settings)
        {
            Settings = settings;
        }
        public ProcessResult MakeKos(string inputStudyDirectoryPath, string outputKosFilePath, string institutionName, string institutionSKRS)
        {
            var makeKosSettings = Settings;

            var output = outputKosFilePath;
            var input = inputStudyDirectoryPath;

            var res = $@"--title {makeKosSettings.Title} --institution-insname {institutionName}^^^SKRS{institutionSKRS}^^^{makeKosSettings.InstitutionFirmaKodu} --location-uid  {makeKosSettings.LocationUID} --temp-tlocation {makeKosSettings.TempDirectory} --dcm-dcmlocation {makeKosSettings.DCM4CheeDirectory}";
            var processParameter = $"-jar {makeKosSettings.AppFilePath} {res} -o {output} {input}";

            var processResult = ProcessUtil.Start("java", processParameter);

            return processResult;
        }
        public ProcessResult MakeKosJSON(MakeKosInstanceItem[] dicomFilePathList, string outputKosFilePath, string institutionName, string institutionSKRS, string override_gender = null, string override_age = null, string override_accNo = null, string override_patientID = null)
        {
            var Title = Settings.Title;
            var locationuid = Settings.LocationUID;
            var tempLocation = Settings.TempDirectory;
            var dcmLocation = Settings.DCM4CheeDirectory;

            var javaMakekos = Settings.App_Ver_JSON_FilePath;

            var uniqeName = Guid.NewGuid().ToString().Replace("-", "");
            var dcmJson = Path.Combine(Settings.TempDirectory, "make_kos_json", $"MakeKosParametter_{uniqeName}.json");
            var jsonParameters = CreateDCMJSON(dicomFilePathList, override_accNo, override_patientID);
            File.WriteAllText(dcmJson, jsonParameters);


            var res = $@"--title {Title} --location-uid {locationuid} --temp-tlocation {tempLocation} --dcm-dcmlocation {dcmLocation} --dcmjson {dcmJson}";
            var processParameter = $"-jar \"{javaMakekos}\" {res} -o {outputKosFilePath}";
            //var processParameter = $" -jar \"{javaMakekos}\" ";

            var processResult = ProcessUtil.Start("java", processParameter);
            if (File.Exists(dcmJson))
            {
                File.Delete(dcmJson);
            }

            return processResult;
        }
        public ProcessResult MakeKosJSON_Test()
        {
            //var makeKosSettings = Settings;

            //var output = outputKosFilePath;
            //var input = inputStudyDirectoryPath;

            //java - jar / gt / app / teletip_kos / MakeKOS_protekV2.jar
            //--title DCM-113030
            //--location - uid 1.3.6.1.4.1.21367.2017.10.26.111
            //--temp - tlocation / gt / dicom / temp_kos / 
            //--dcm - dcmlocation / gt / app / teletip_kos / dcm4che - 5.22.2 / bin
            //--dcmjson / gt / test_java / MakeKosParametter.json 
            //- o / gt / test_java / test.dcm / gt / app / teletip_kos / E37678675
            var makeKosSettings = Settings;
            var uniqeName = Guid.NewGuid().ToString().Replace("-", "");
            //var dcmJson = $"/gt/test_java/MakeKosParametter_{uniqeName}.json";
            var dcmJson = $"/gt/test_java/MakeKosParametter.json";
            //var items = new InstanceItem[] {
            //new InstanceItem(""),
            //};
            //var jsonString = CreateDCMJSON(items,);
            //File.WriteAllText(dcmJson, jsonString);
            var Title = "DCM-113030";
            var locationuid = "1.3.6.1.4.1.21367.2017.10.26.111";
            var tempLocation = "/gt/dicom/temp_kos/";
            var dcmLocation = "/gt/app/teletip_kos/dcm4che-5.22.2/bin";

            var outputKosFilePath = "/gt/test_java/test.dcm";
            var studyFolderPath = "/gt/app/teletip_kos/E37678675";
            var javaMakekos = "/gt/app/teletip_kos/MakeKOS_protekV2.jar";
            var res = $@"--title {Title} --location-uid {locationuid} --temp-tlocation {tempLocation} --dcm-dcmlocation {dcmLocation} --dcmjson {dcmJson}";
            var processParameter = $"-jar \"{javaMakekos}\" {res} -o {outputKosFilePath} {studyFolderPath}";
            //var processParameter = $" -jar \"{javaMakekos}\" ";

            var processResult = ProcessUtil.Start("java", processParameter);
            if (File.Exists(dcmJson))
            {
                File.Delete(dcmJson);
            }

            return processResult;
        }

        private string CreateDCMJSON(MakeKosInstanceItem[] items, string accNo, string patientID)
        {
            var jsonFormat = new
            {
                AccsNumber = accNo,
                PatientId = patientID,
                DcmList = items.Select(o => o.InstancePath).ToList()
            };
            var str = JsonConvert.SerializeObject(jsonFormat);
            return str;
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
