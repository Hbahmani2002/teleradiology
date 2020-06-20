namespace GT.TeletipKos
{
    public class MakeKosParameter
    {
        public string ID { get; set; }
        public string InstitutionName { get; }
        public string InstitutionSKRS { get; }
        public string InstitutionFirmaKodu { get; }
        public string AccessionNumber { get; }
        public string PatientSex { get; }
        public string PatientId { get; }
        public string InputStudyDirectoryPath { get; }
        public string OutputKosFilePath { get; }
        public MakeKosParameter(string id, string institutionName, string institutionSKRS, string institutionFirmaKodu, string accessionNumber, string patientSex, string patientId, string inputStudyDirectoryPath, string outputKosFilePath)
        {
            ID = id;
            InstitutionName = institutionName;
            InstitutionSKRS = institutionSKRS;
            InstitutionFirmaKodu = institutionFirmaKodu;
            AccessionNumber = accessionNumber;
            PatientSex = patientSex;
            PatientId = patientId;
            InputStudyDirectoryPath = inputStudyDirectoryPath;
            OutputKosFilePath = outputKosFilePath;
        }




    }


}
