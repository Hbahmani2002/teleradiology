using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
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

        public void UpdateExcel(List<Model.Sheet> sheets)
        {
            System.IO.File.Copy(fileSourcePath, fileDestinationPath, true);
            SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(fileDestinationPath, true);
            foreach (Model.Sheet sheet in sheets)
            {
                var sheetName = sheet.SheetName;
                WorkbookPart wbPart = spreadSheet.WorkbookPart;

                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).FirstOrDefault();

                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));


                var cells = sheet.Cells;
                foreach (Model.Cell c in cells)
                {
                    var addr = c.GetCellAddress();
                    wsPart.Worksheet.GetFirstChild<SheetData>();
                    var xyz = wsPart.Worksheet.Descendants<Cell>().Select(o=>o.CellReference).OrderBy(o=>o.Value).ToList();
                    Cell theCell = wsPart.Worksheet.Descendants<Cell>().Where(_c => {
                        var x = _c.CellReference;
                        return _c.CellReference == addr;
                    }).FirstOrDefault();
                    if (theCell !=null)
                    {
                        int number = 0;
                        if (int.TryParse(c.Value, out number))
                        {
                            theCell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(c.Value);
                            theCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                        }
                        else
                        {
                            theCell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(c.Value);
                            theCell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                    }
                }

                // Save the worksheet.
                wsPart.Worksheet.Save();
            }
            spreadSheet.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
            spreadSheet.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
            spreadSheet.Close();
        }

        
    }
}