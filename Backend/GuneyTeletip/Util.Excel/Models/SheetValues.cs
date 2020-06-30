using System.Collections.Generic;

namespace Util.Excel.Models
{
    public class SheetValues
    {
        public string SheetName { get; set; }
        public List<CellValue> Values { get; set; }
        public SheetValues(string sheetName)
        {
            SheetName = sheetName;
            Values = new List<CellValue>();
        }
    }
}
