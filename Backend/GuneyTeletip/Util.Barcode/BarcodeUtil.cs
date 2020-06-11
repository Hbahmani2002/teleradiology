using IronBarCode;
using System.Drawing;

namespace Util.Barcode
{
    public class BarcodeUtil
    {
        public static Bitmap CreateBarcode(string code, int maxWidth, int maxHeight)
        {
            var coded = BarcodeWriter.CreateBarcode(code, BarcodeWriterEncoding.Code39, maxWidth, maxHeight);
            var bitmap = coded.ToBitmap();
            return bitmap;
        }
        public static void CreateBarcode(string code, int maxWidth, int maxHeight,string outFilePath)
        {
            var coded = BarcodeWriter.CreateBarcode(code, BarcodeWriterEncoding.Code39, maxWidth, maxHeight);
            var bitmap = coded.SaveAsPdf(outFilePath);            
        }
    }
}
