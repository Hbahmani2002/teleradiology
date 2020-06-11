using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FastReport;
using FastReport.Export.PdfSimple;

namespace Util.Reporting
{
    public class Reporting
    {

        public void Export(string reportTemplateFilePath, Dictionary<string, DataTable> data, string pdfFilePath)
        {
            var report = new Report();
            report.Load(reportTemplateFilePath);
            foreach (var item in data)
            {
                report.RegisterData(item.Value, item.Key);
            }
            report.Prepare();
            var pdfExport = new PDFSimpleExport();
            report.Export(pdfExport, pdfFilePath);
            report.Dispose();
        }
    }
}