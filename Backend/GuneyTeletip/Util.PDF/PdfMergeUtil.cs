using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.PDF
{
    public static class PdfMergeUtil
    {
        public static void Merge(string[] in_filePaths, string out_filePath)
        {
            using (PdfDocument outPdf = new PdfDocument())
            {
                var list = new List<PdfDocument>();
                for (int i = 0; i < in_filePaths.Length; i++)
                {
                    var filePath = in_filePaths[i];
                    var item = PdfReader.Open(filePath, PdfDocumentOpenMode.Import);
                    CopyPages(item, outPdf);
                    list.Add(item);
                }

                outPdf.Save(out_filePath);
                foreach (var item in list)
                {
                    item.Dispose();
                }
            }
          
        }
        private static void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}
