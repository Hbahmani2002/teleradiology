using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Excel.Model
{
    public class Cell
    {
        public int Row { get; set; }
        public string Column { get; set; }
        public string Value { get; set; }
        public string GetCellAddress()
        {
            return Column + Row;
        }
    }
}
