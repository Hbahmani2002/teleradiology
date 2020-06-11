using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Util.Excel.Models
{
    public class ExcelUpdateManager
    {
        public string fileSourcePath { get; set; }
        public string fileDestinationPath { get; set; }
        public ExcelUpdateManager(string fileSourcePath, string fileDestinationPath)
        {
            this.fileSourcePath = fileSourcePath;
            this.fileDestinationPath = fileDestinationPath;
        }
        public void Change(List<SheetValues> values)
        {
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(fileSourcePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
                file.Close();
            }
            foreach (var item in values)
            {
                var sheet = hssfwb.GetSheet(item.SheetName);
                foreach (var cellValue in item.Values)
                {
                    IRow row = sheet.GetRow(cellValue.Row);
                    ICell cell = row.CreateCell(cellValue.Column);
                    cell.SetCellValue(cellValue.Value);
                }
            }
            using (FileStream file = new FileStream(fileDestinationPath, FileMode.Create))
            {
                hssfwb.Write(file);
                file.Close();
            }
        }
    }
}