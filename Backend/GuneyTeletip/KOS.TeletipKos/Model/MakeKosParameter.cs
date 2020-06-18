namespace GT.TeletipKos
{
    public class MakeKosParameter
    {
        public MakeKosParameter(string title, string institutionName, string institutionSKRS, string institutionFirmaKodu, string locationUid, string tempDirectoryPath, string dcmDirectoryPath, string accessionNumber, string patientSex, string patientId, string inputStudyDirectoryPath, string outputKosFilePath)
        {
            Title = title;
            InstitutionName = institutionName;
            InstitutionSKRS = institutionSKRS;
            InstitutionFirmaKodu = institutionFirmaKodu;
            LocationUid = locationUid;
            TempDirectoryPath = tempDirectoryPath;
            DcmDirectoryPath = dcmDirectoryPath;
            AccessionNumber = accessionNumber;
            PatientSex = patientSex;
            PatientId = patientId;
            InputStudyDirectoryPath = inputStudyDirectoryPath;
            OutputKosFilePath = outputKosFilePath;
        }

        public string Title { get; }
        public string InstitutionName { get; }
        public string InstitutionSKRS { get; }
        public string InstitutionFirmaKodu { get; }
        public string LocationUid { get; }
        public string TempDirectoryPath { get; }
        public string DcmDirectoryPath { get; }
        public string AccessionNumber { get; }
        public string PatientSex { get; }
        public string PatientId { get; }
        public string InputStudyDirectoryPath { get; }
        public string OutputKosFilePath { get; }

       
    }


}
