using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.PDF
{
    public class PdfTextUtil
    {
        public static void AddText2Pdf(string oldFile, string newFile, string text)
        {


            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(bf, 8);
            if (true)
            {
                cb.BeginText();
                cb.SetTextMatrix(1, 1);
                cb.ShowText(text);
                cb.EndText();
            }
            if (false)
            {
                // write the text in the pdf content
                cb.BeginText();
                //string text = "Some random blablablabla...";
                // put the alignment and coordinates here
                cb.ShowTextAligned(99999, text, 1, 1, 0);
                cb.EndText();


                cb.BeginText();
                text = "Other random blabla...";
                // put the alignment and coordinates here
                cb.ShowTextAligned(2, text, 100, 200, 0);
                cb.EndText();
            }
            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }
        public static void AddTextToPdf(string inputPdfPath, string outputPdfPath, string textToAdd, System.Drawing.Point point,float fontSize=8)
        {
            //https://stackoverflow.com/questions/3992617/itextsharp-insert-text-to-an-existing-pdf
            //variables
            string pathin = inputPdfPath;
            string pathout = outputPdfPath;

            //create PdfReader object to read from the existing document
            using (PdfReader reader = new PdfReader(pathin))
            //create PdfStamper object to write to get the pages from reader 
            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.Create)))
            {
                //select two pages from the original document
                reader.SelectPages("1-2");

                //gettins the page size in order to substract from the iTextSharp coordinates
                var pageSize = reader.GetPageSize(1);

                // PdfContentByte from stamper to add content to the pages over the original content
                PdfContentByte pbover = stamper.GetOverContent(1);

                //add content to the page using ColumnText
                Font font = new Font();
                font.Size = fontSize;

                //setting up the X and Y coordinates of the document
                int x = point.X;
                int y = point.Y;

                y = (int)(pageSize.Height - y);

                ColumnText.ShowTextAligned(pbover, Element.ALIGN_CENTER, new Phrase(textToAdd, font), x, y, 0);
            }
        }
    }
}
