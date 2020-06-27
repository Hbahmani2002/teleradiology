using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using KOS.TeletipKos;

namespace KOS.TeletipKos.Test
{
    public partial class Tests
    {

        string dataHeader = "patientId: 123^^^&amp;1.3.6.1.4.1.21367.13.20.3000&amp;ISO" + "\r\n" +
                "KOS: /gt/dicom/kos/kos_00401bdc7f4940c6894163a17af32fbd.dcm" + "\r\n" +
                "RepositoryUrl: https://xdarep.teletip.saglik.gov.tr/axis2/services/xdsrepositoryb \n" +
                "Result:\n";
        string SENDKOS_successResult = "<rs:RegistryResponse xmlns:rs=\"urn:oasis:names:tc:ebxml-regrep:xsd:rs:3.0\" status=\"urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Success\">\n" +
            "<rs:RegistryErrorList>\n" +
            "<rs:RegistryError codeContext=\"{ &quot;result&quot;: true, &quot;institutionId&quot;: 111111, &quot;citizenId&quot;:\r\n&quot;11111111111&quot;, &quot;accessionNumberList&quot;:\r\n&quot;[\\&quot;123456789\\&quot;]&quot;, &quot;error&quot;: &quot;&quot;}\"\r\nerrorCode=\"MatchStatus\"\r\nlocation=\"ProvideAndRegister.java\"\r\nseverity=\"urn:oasis:names:tc:ebxmlregrep:ErrorSeverityType:Warning\" />\n" +
            "</rs:RegistryErrorList>\n" +
            "</rs:RegistryResponse>\n";
        string SENDKOS_partialSuccessResult = "<rs:RegistryResponse xmlns:rs=\"urn:oasis:names:tc:ebxml-regrep:xsd:rs:3.0\"\r\nstatus=\"urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:PartialSuccess\">\n" +
            "<rs:RegistryErrorList>\n" +
            "<rs:RegistryError codeContext=\"{ &quot;result&quot;:true, &quot;institutionId&quot;: -1, &quot;citizenId&quot;: &quot;&quot;,\r\n&quot;accessionNumberList&quot;: &quot;\r\n[]&quot;, &quot;error&quot;: &quot;&quot;}\"\r\nerrorCode=\"MatchStatus\"\r\nlocation=\"ProvideAndRegister.java\"\r\nseverity=\"urn:oasis:names:tc:ebxmlregrep:ErrorSeverityType:Error\" />\n" +
            "</rs:RegistryErrorList>\n" +
            "</rs:RegistryResponse>\n";
        string SENDKOS_errorResult = "<rs:RegistryResponse xmlns:rs=\"urn:oasis:names:tc:ebxml-regrep:xsd:rs:3.0\"\r\nstatus=\"urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Failure\">\r\n<rs:RegistryErrorList>\r\n<rs:RegistryError\r\ncodeContext=\"{&quot;validationDate&quot;:&quot;Jun 13, 2018 5:40:57PM&quot;,&quot;state&quot;:{&quot;id&quot;:2},&quot;validationSectionList&quot;:[{&quot;state&quot;:{&quot;id&quot;:2},\r\n&quot;validationCommentList&quot;:[{&quot;state&quot;:{&quot;id\r\n&quot;:3},&quot;description&quot;:&quot;Hastaya ait bilgilerden Hasta Ad\u0131, PatientID/OtherPatientIDs, Cinsiyeti, \u00C7ekim Tarihi bo\u015F olamaz.&quot;}]},{&quot;state&quot;:\r\n{&quot;id&quot;:1},&quot;validationCommentList&quot;:[]}],&quot;name&quot;:\r\n&quot;KOS Validasyon&quot;,&quot;description&quot;:&quot;KOS\r\nValidasyon&quot;}\"\r\nerrorCode=\"XDSRepositoryError\"\r\nlocation=\"ProvideAndRegistryDocumentSet.java\"\r\nseverity=\"urn:oasis:names:tc:ebxmlregrep:ErrorSeverityType:Error\" />\r\n</rs:RegistryErrorList>\r\n</rs:RegistryResponse>";

        string sampleData = "patientId: 123^^^&amp;1.3.6.1.4.1.21367.13.20.3000&amp;ISO" + "\r\n" +
                "KOS: /gt/dicom/kos/kos_00401bdc7f4940c6894163a17af32fbd.dcm" + "\r\n" +
                "RepositoryUrl: https://xdarep.teletip.saglik.gov.tr/axis2/services/xdsrepositoryb \n" +
                "Result:\n" +
                "<rs:RegistryResponse xmlns:rs=\"urn:oasis:names:tc:ebxml-regrep:xsd:rs:3.0\" status=\"urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Failure\">\n" +
                "<rs:RegistryErrorList>\n" +
                "<rs:RegistryError codeContext=\"{&quot;validationDate&quot;:&quot;Jun 25, 2020 9:55:38 PM&quot;,&quot;state&quot;:{&quot;id&quot;:2},&quot;validationSectionList&quot;:[{&quot;state&quot;:{&quot;id&quot;:1},&quot;validationCommentList&quot;:[]},{&quot;state&quot;:{&quot;id&quot;:2},&quot;validationCommentList&quot;:[{&quot;state&quot;:{&quot;id&quot;:3},&quot;name&quot;:&quot;InstitutionName de?er kontrol?&quot;,&quot;description&quot;:&quot;Institution Name alan? \\u003cKurum Ad?\\u003e^^^SKRS\\u003cKurum SKRS kodu\\u003e^^^FK\\u003cFirma Kodu\\u003e formunda olmal?d?r.&quot;}]}]}\" errorCode=\"XDSRepositoryError\" location=\"ProvideAndRegistryDocumentSet.java\" severity=\"urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Error\">\n" +
                "</rs:RegistryError>\n" +
                "</rs:RegistryErrorList>\n" +
                "</rs:RegistryResponse>\n";
        [SetUp]
        public void Setup()
        {
            Debug.WriteLine(SENDKOS_successResult);
            Debug.WriteLine("");
            Debug.WriteLine(SENDKOS_partialSuccessResult);
            Debug.WriteLine("");
            Debug.WriteLine(SENDKOS_errorResult);
            Debug.WriteLine("");

        }
        public void TestXML()
        {

            var xmlString = SENDKOS_errorResult;
            var ns2 = XNamespace.Get(SendKosProcessResult.nameSpace);
            var registryResponse = XElement.Parse(xmlString);
            var elementError = registryResponse.Descendants(ns2 + "RegistryErrorList").FirstOrDefault();


            {
                var tt = registryResponse.Name.LocalName;
                var elResponse = registryResponse.Descendants(ns2 + "RegistryResponse").ToList();

                registryResponse.Descendants(ns2 + "RegistryErrorList").ToList();
                var t = registryResponse.Descendants().ToList();
                foreach (var item in t)
                {
                    Debug.WriteLine("Name:" + item.Name);
                }
            }
        }
        [Test]
        public void TestParse()
        {
            var type = SendKosDataResult.SendKosResultType.PartialSuccess;
            var data = "";
            switch (type)
            {
                case SendKosDataResult.SendKosResultType.Failure:
                    data = dataHeader + SENDKOS_errorResult;
                    break;
                case SendKosDataResult.SendKosResultType.Success:
                    data = dataHeader + SENDKOS_successResult;
                    break;
                case SendKosDataResult.SendKosResultType.PartialSuccess:
                    data = dataHeader + SENDKOS_partialSuccessResult;
                    break;
                default:
                    break;
            }


            Debug.WriteLine("Data:");
            Debug.WriteLine(data);

            var result = SendKosProcessResult.Process(data);

            Debug.Write(result);
            Assert.AreEqual(result.Type, type);
        }
    }
}