using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Util.ProcessUtil;

namespace KOS.TeletipKos
{

    public class SendKosProcessResult
    {
        public const string nameSpace = "urn:oasis:names:tc:ebxml-regrep:xsd:rs:3.0";
        public const string responseErrorTypeSplitText = "urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:";

        public SendKosDataResult SendKosResult { get; set; }
        public ProcessResult ProcessResult { get; set; }

        public bool IsSuccess => ProcessResult.IsSuccess;
        public string Arguments => ProcessResult.Arguments;
        public string Message => ProcessResult.Message;
        public SendKosProcessResult(ProcessResult pc)
        {
            ProcessResult = pc;
            if (pc.IsSuccess)
            {
                SendKosResult = Process(pc.Message);
            }
        }
        public static SendKosDataResult Process(string data)
        {

            var lines = data.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                Debug.WriteLine("Line:" + line);
            }
            const int n = 4;
            var xmlString = string.Join("\r\n", lines.Skip(n));
            if (string.IsNullOrEmpty(xmlString))
            {
                throw new Exception($"Send Kos sonucu {n}.satırda xml verisi bulunamadı Sonuç:{data}");
            }
            //var ns = XNamespace.Get("rs");

            try
            {
                return ParseXML(xmlString);
            }
            catch (Exception ex)
            {

                throw new Exception($"Send Kos xml parse edilemedi XML:{xmlString}", ex);
            }

        }

        private static SendKosDataResult ParseXML(string xmlString)
        {
            var result = new SendKosDataResult();
            var registryResponse = XElement.Parse(xmlString);
            var status = registryResponse.Attributes("status").SingleOrDefault();
            if (status == null || string.IsNullOrEmpty(status.Value))
            {
                throw new Exception("XML Parse " + "status attaribute boş:" + registryResponse);
            }
            var statusValueSplit = status.Value.Split(new[] { responseErrorTypeSplitText }, StringSplitOptions.RemoveEmptyEntries);
            var statusValue = statusValueSplit[0];

            if (statusValue == "Failure")
            {
                result.Type = SendKosDataResult.SendKosResultType.Failure;
            }
            else if (statusValue == "Success")
            {
                result.Type = SendKosDataResult.SendKosResultType.Success;
            }
            else if (statusValue == "PartialSuccess")
            {
                result.Type = SendKosDataResult.SendKosResultType.PartialSuccess;
            }
            var xmlNS = XNamespace.Get(nameSpace);
            var elementError = registryResponse.Descendants(xmlNS + "RegistryErrorList").FirstOrDefault();
            var errList = new List<string>();
            foreach (var item in elementError.Descendants().ToList())
            {
                var codeContext = item.Attributes("codeContext").FirstOrDefault();
                if (codeContext == null)
                    continue;
                var codeContextValue = codeContext.Value;
                errList.Add(codeContextValue);
            }
            result.CodeContext = string.Join("\r\n", errList);

            return result;
        }
    }
}