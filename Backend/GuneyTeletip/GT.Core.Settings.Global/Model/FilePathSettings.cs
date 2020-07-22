using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GT.Core.Settings.Global.Model
{
    public class FilePathSettings
    {
        public FilePathSettings()
        {
            Directory.CreateDirectory(DIR_User);
        }
        private static  string FullPath(string relativePath)
        {
            var path = Path.GetFullPath(relativePath, Environment.CurrentDirectory);
            return path;
        }
        public static string DIR_User => FullPath("upload/_User");
        public static string Seperator = "_GEN_";

        public static string GetFilePathFromFileName(string fileName)
        {
            var outputDirPath = DIR_User+"\\"+ fileName;
            return Path.Combine(outputDirPath);
        }
       
        public static string GetFileIDName(string fileName)
        {
            var trimmedFileName = new string(Path.GetFileNameWithoutExtension(fileName).ToCharArray().Take(400).ToArray());
            var random = Guid.NewGuid().ToString().Replace("-", "").Substring(8);
            return Path.Combine(trimmedFileName + Seperator + random + Path.GetExtension(fileName));
        }
    }
}
