using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace IzcilikSistemi.Kutuphane
{
    public static class PhotoUtils
    {
        public static Image Inscribe(Image image, int size)
        {
            return PhotoUtils.Inscribe(image, size, size);
        }

        public static Image Inscribe(Image image, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                double num = 1.0 * (double)width / (double)image.Width;
                if ((double)image.Height * num < (double)height)
                {
                    num = 1.0 * (double)height / (double)image.Height;
                }
                Size size = new Size((int)((double)width / num), (int)((double)height / num));
                Point location = new Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2);
                PhotoUtils.SmoothGraphics(graphics);
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(location, size), GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        public static byte[] Resize(byte[] img, int width, int height)
        {
            if (img == null)
                throw new ArgumentNullException("img is null");
            var msInput = new MemoryStream(img);
            var ms = new MemoryStream();
            PhotoUtils.ResizeImage( width, height, msInput,ms);                        
            var bytes = ms.ToArray();
            msInput.Dispose();
            ms.Dispose();
            return bytes;

        }

        public static void ResizeImage(int newWidth, int newHeight, Stream fromStream, Stream toStream)
        {
            using (Image image = Image.FromStream(fromStream))
            {
                using (Bitmap bitmap = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Rectangle rect = new Rectangle(0, 0, newWidth, newHeight);
                        graphics.DrawImage(image, rect);
                        bitmap.Save(toStream, image.RawFormat);
                    }
                }
            }
        }

        private static void SmoothGraphics(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }

        public static void SaveToJpeg(Image image, Stream output)
        {
            image.Save(output, ImageFormat.Jpeg);
        }

        public static void SaveToJpeg(Image image, string fileName)
        {
            image.Save(fileName, ImageFormat.Jpeg);
        }
    }
}
