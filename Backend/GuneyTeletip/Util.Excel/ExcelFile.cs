using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Util.Excel
{
    public class ExcelUtil
    {
        public DataTable GetExcelData(string excelFilePath, int sheetIndex)
        {
            var ds = LoadDataSet(excelFilePath);
            if (ds.Tables.Count <= sheetIndex)
            {
                throw new Exception($"Excelde sadece {ds.Tables.Count } sheet var");
            }
            var dt = ds.Tables[sheetIndex];

            if (dt == null)
            {
                throw new Exception($"Excelde '{sheetIndex + 1}' nolu  ile bir sayfa bulunamadı");
            }
            return dt;
        }
      
        public DataTable GetExcelData(string excelFilePath, string sheet)
        {
            if (string.IsNullOrEmpty(sheet))
            {
                throw new Exception("Sheet adı boş olamaz");
            }
            var ds = LoadDataSet(excelFilePath);
            var table = ds.Tables[sheet];
            if (table == null)
            {
                throw new Exception($"Excelde '{sheet}' adı ile bir sayfa bulunamadı");
            }
            return table;
        }

        private DataSet LoadDataSet(string excelFilePath)
        {
            var ds = ExcelFile.Read(excelFilePath);
            if (ds == null)
            {
                throw new Exception("Excel okunamadı");
            }
            if (ds.Tables.Count == 0)
            {
                throw new Exception("Excelde sayfa bulunamaıdı");
            }
            return ds;
        }
    }
    public class ExcelFile
    {
        public static DataSet Read(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1251);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    return result;
                    // The result of each spreadsheet is in result.Tables
                }
            }
        }
        public static void Write(DataTable dataTable, string fileName)
        {
            using (var workbook = SpreadsheetDocument.Create(fileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                uint sheetId = 1;

                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                {
                    sheetId =
                        sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = dataTable.TableName };
                sheets.Append(sheet);

                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                List<String> columns = new List<string>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in dataTable.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (String col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }
            }
        }

        public static void Write(IList dataList, string fileName)
        {
            IWorkbook workbook;

            switch (Path.GetExtension(fileName))
            {
                case ".xlsx":
                    workbook = new XSSFWorkbook();
                    break;
                case ".xls":
                    workbook = new HSSFWorkbook();
                    break;
                default:
                    throw new Exception("This format is not supported");
            }

            var sheet1 = workbook.CreateSheet("Sheet 1");
            //make a header row
            var row1 = sheet1.CreateRow(0);
            // Style dict such as Datetime etc.
            var styleDict = GetStyleList(workbook);



            var dict = dataList[0] as Dictionary<string, string>;
            if (dict == null)
            {
                var itemType = dataList[0].GetType();
                IList<PropertyInfo> propertyInfos = itemType.GetProperties();

                for (var j = 0; j < propertyInfos.Count; j++)
                {
                    var cell = row1.CreateCell(j);
                    var columnName = propertyInfos[j].Name;
                    cell.SetCellValue(columnName);
                }

                var rowHeight = (short)1200;
                var rowWidth = 3750;

                //loops through data
                for (var i = 0; i < dataList.Count; i++)
                {
                    var row = sheet1.CreateRow(i + 1);

                    for (var j = 0; j < propertyInfos.Count; j++)
                    {
                        var cell = row.CreateCell(j);

                        var pro = propertyInfos[j];
                        var val = pro.GetValue(dataList[i], null);
                        var t = Reflection.GetPropertyAttribute<Exportable>(pro);
                        var imgAtt = Reflection.GetPropertyAttribute<ExportImage>(pro);
                        if (val is byte[] && imgAtt != null)
                        {
                            try
                            {
                                {
                                    row.Height = rowHeight;
                                    sheet1.SetColumnWidth(j, rowWidth);
                                }
                                InsertImage(workbook, sheet1, (byte[])val, i + 1, j);
                            }
                            catch
                            {
                            }
                            continue;
                        }

                        RenderCell(workbook, cell, val, t, styleDict);
                    }
                }
            }
            //else
            //{
            //    for (var j = 0; j < dict.Keys.Count; j++)
            //    {
            //        var cell = row1.CreateCell(j);
            //        var columnName = dict.Keys.ElementAt(j);
            //        cell.SetCellValue(columnName);
            //    }

            //    //loops through data
            //    for (var i = 0; i < dataList.Count; i++)
            //    {
            //        var row = sheet1.CreateRow(i + 1);
            //        for (var j = 0; j < dict.Keys.Count; j++)
            //        {
            //            var cell = row.CreateCell(j);
            //            var val = (dataList[i] as Dictionary<string, string>)[dict.Keys.ElementAt(j)];
            //            RenderCell(workbook, cell, val, styleDict);
            //        }
            //    }
            //}

            using (FileStream file = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
            //using (var exportData = new MemoryStream())
            {
                // workbook.Write(exportData);
                workbook.Write(file);
                {
                    //exportData.WriteTo(file);
                    file.Close();
                    //exportData.Close();
                }
            }
        }



        private static void InsertImage(IWorkbook workbook, ISheet _sheet, byte[] img, int rowIndex, int colIndex)
        {
            //https://stackoverflow.com/questions/41138848/add-image-to-excel-xlsx-using-npoi-c-sharp
            if (img == null)
                throw new NullReferenceException("img is null");
            int pictureIndex = workbook.AddPicture(img, PictureType.PNG);
            ICreationHelper helper = workbook.GetCreationHelper();
            IDrawing drawing = _sheet.CreateDrawingPatriarch();
            IClientAnchor anchor = helper.CreateClientAnchor();
            anchor.Col1 = colIndex;//0 index based column
            anchor.Row1 = rowIndex;//0 index based row
            IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
            picture.Resize();
        }

        private static void RenderCell(IWorkbook workbook, ICell cell, object val, Exportable format,
            IDictionary<string, ICellStyle> styleDict)
        {
            if (val == null)
            {
                cell.SetCellValue("");
                return;
            }


            var type = val.GetType();
            if (!IsSimpleType(type))
            {
                cell.SetCellValue("");
                return;
            }
            if (val is DateTime)
            {
                if ((DateTime)val != default(DateTime))
                {
                    var v = (DateTime)val;
                    if (format != null && !string.IsNullOrEmpty(format.DateFormat))
                        cell.SetCellValue(v.ToString(format.DateFormat));
                    else
                    {
                        cell.SetCellValue((DateTime)val);
                        cell.CellStyle = styleDict["Datetime"];
                    }
                }
            }
            else if (val is bool)
            {
                var v = (bool)val;
                if (format != null && !string.IsNullOrEmpty(format.TrueVal))
                    cell.SetCellValue(v ? format.TrueVal : format.FalseVal);
                else
                {
                    cell.SetCellValue(v ? "1" : "0");
                }
            }
            else
            {
                cell.SetCellValue(val.ToString());
            }

        }

        private static Dictionary<string, ICellStyle> GetStyleList(IWorkbook workbook)
        {
            var styleDict = new Dictionary<string, ICellStyle>();
            // Datetime
            var newDataFormat = workbook.CreateDataFormat();
            var style = workbook.CreateCellStyle();
            style.DataFormat = newDataFormat.GetFormat("dd.MM.yyyy HH:mm:ss");
            styleDict["Datetime"] = style;

            return styleDict;
        }

        public static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                new Type[] {
            typeof(Enum),
            typeof(string),
            typeof(decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }
    }
}
