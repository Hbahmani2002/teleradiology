using GT.Core.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GT.BAL.TeletipKos.Model
{
    public class KosOutFileNameGenerator
    {
        public static string GetFilePath(long studyID)
        {
            var set=AppSettings.GetCurrent().Kos.Make;
            //var outputKosFilePath = Path.Combine(set.DIR_KosPath, $"kos_{Guid.NewGuid().ToString().Replace("-", "")}.dcm");
            var outputKosFilePath = Path.Combine(set.DIR_KosPath, $"{studyID}.dcm");
            return outputKosFilePath;
        }
    }
}
