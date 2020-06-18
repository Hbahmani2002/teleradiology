using GT.TeletipKos.Model;
using System;
using Util.ProcessUtil;

namespace GT.TeletipKos
{
    public class TeletipKosService
    {
        public static TeletipKosService Create()
        {
            return new TeletipKosService(
            "SendKOS_v15.jar",
            "MakeKOSProtek.jar",
            "C:/_Teletip/Programs/Archive"
            );


        }
        public string SendKosJarName { get; }
        public string MakeKosJarName { get; }
        public string WorkingDirectory { get; }



        public TeletipKosService(string sendKosJarName, string makeKosJarName, string workingDirectory)
        {
            SendKosJarName = sendKosJarName;
            MakeKosJarName = makeKosJarName;
            WorkingDirectory = workingDirectory;
        }

        public ProcessResult SendKos(SendKosParameter par)
        {
            var res = string.Format(" {0} {1} \"{2}\"", par.PatientId, par.KosFilePath.Replace('\\', '/'), par.ServiceUrl.Replace('\\', '/'));
            var processStr = string.Format("-jar -Duser.language=en {1} {0}", res, SendKosJarName);
            var ret = ProcessUtil.Start("java", processStr, WorkingDirectory);
            return ret;
        }

        public ProcessResult MakeKos(MakeKosParameter par)
        {
            var res = string.Format(@"--title {0} --institution-insname {1}^^^SKRS{2}^^^{3} --location-uid {4} --temp-tlocation {5} --dcm-dcmlocation {6} --number-accession {7} --patient-sex {8} --patient-pid {9} -o {10} {11}",
              par.Title, par.InstitutionName, par.InstitutionSKRS, par.InstitutionFirmaKodu, par.LocationUid,
              par.TempDirectoryPath.Replace('\\', '/'), par.DcmDirectoryPath.Replace('\\', '/'),
              par.AccessionNumber, par.PatientSex, par.PatientId, par.OutputKosFilePath.Replace('\\', '/'),
              par.InputStudyDirectoryPath.Replace('\\', '/'));

            var processStr = string.Format("-jar {1} {0}", res, MakeKosJarName);
            Console.WriteLine(processStr);
            var ret = ProcessUtil.Start("java", processStr, WorkingDirectory);
            return ret;
        }
    }
}
