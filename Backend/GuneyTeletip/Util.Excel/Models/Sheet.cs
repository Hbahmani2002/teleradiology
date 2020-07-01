using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Excel.Model
{
    public class Sheet
    {
        public string SheetName { get; set; }
        public List<Cell> Cells { get; set; }
        public Sheet(string sheetName)
        {
            SheetName = sheetName;
            Cells = new List<Cell>();
        }
    }
}
