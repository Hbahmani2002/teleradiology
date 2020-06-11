using IzcilikSistemi.BAL.Web.Ajax;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Web;

namespace Util.File
{
    public class FileOps
    {
        public static void ZipFiles(string zipFilePath, IEnumerable<string> filepathList)
        {

            using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
            {
                using (var zipArchive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (var file in filepathList)
                    {
                        var fileName = Path.GetFileName(file);
                        var entry = zipArchive.CreateEntry(fileName, CompressionLevel.Optimal);
                        using (var entryStream = entry.Open())
                        {
                            using (var fs = new FileStream(file, FileMode.Open))
                            {
                                fs.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }
        }

        public static string ExtractToFile(string zipFilePath, string destination)
        {
            var fullName="";
            using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
            {
                if (archive.Entries.Count == 1)
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        
                        entry.ExtractToFile(Path.Combine(destination, entry.FullName));
                        fullName = entry.FullName;
                    }
                }
            }
            return fullName;
        }

        private static string BaseDir => HttpRuntime.AppDomainAppId == null ? Environment.CurrentDirectory : HttpContext.Current.Server.MapPath("~/App_Data");
        public static readonly string MainDir = HttpRuntime.AppDomainAppId == null ? Path.Combine(Environment.CurrentDirectory, "TempFiles") : HttpContext.Current.Server.MapPath("~/App_Data/TempFiles/");
        /// <summary>
        /// Convert abc.pdf to unique MainDir+ abc20180101001212123.pdf
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GenerateTempSavePath(string fileName)
        {
            var fileNameNew = Path.GetFileNameWithoutExtension(fileName) + "-" + DateTime.Now.ToString("yyyyMMddhhmmssffff") + Path.GetExtension(fileName);
            var filePath = Path.Combine(MainDir, DateTime.Now.ToString("yyyyMMdd"), fileNameNew);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            return filePath;
        }
        public static FileResultData GenerateTempSaveResult(string fileName)
        {
            var fn = GenerateTempSavePath(fileName);
            return new FileResultData(fn);
        }
        public static string GetFilePath(string fileName)
        {
            var filePath = Path.Combine(BaseDir, "Config", fileName);
            //Path.Combine(HttpRuntime.AppDomainAppId == null ? "Config" : HttpContext.Current.Server.MapPath("~/App_Data/Config/"), fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            return filePath;
        }
        public static string GetRelativeFileName(string filePath)
        {
            if (!filePath.ToLowerInvariant().Contains(MainDir.ToLowerInvariant()))
            {
                throw new Exception($"Dosya ana temp dizininde değil {filePath}");
            }

            var relativeFileName = filePath.ToLowerInvariant().Replace(MainDir.ToLowerInvariant(), "");
            return relativeFileName;
        }
        public static string GetFullFilePath(string relativeFileName)
        {
            var filePath = Path.Combine(MainDir, relativeFileName);
            return filePath;
        }

        public static byte[] GetUrl2Bytes(string input)
        {
            var regex = new Regex(@"data:(?<mime>[\w/\-\.]+);(?<encoding>\w+),(?<data>.*)", RegexOptions.Compiled);

            var match = regex.Match(input);

            //var mime = match.Groups["mime"].Value;
            //var encoding = match.Groups["encoding"].Value;
            var data = match.Groups["data"].Value;
            return Convert.FromBase64String(data);
        }
    }
}
