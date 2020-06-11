using System;

namespace Util.Excel
{
    public class Exportable : Attribute
    {

        public Exportable()
        {
            this.FalseVal = "0";
            this.TrueVal = "1";
            this.NullVal = "-";
        }

        public Exportable(string FalseVal, string TrueVal, string NullVal)
        {
            this.FalseVal = FalseVal;
            this.TrueVal = TrueVal;
            this.NullVal = NullVal;
        }

        public string TrueVal { get; set; }
        public string FalseVal { get; set; }
        public string NullVal { get; set; }
        public string DateFormat { get; set; }

    }

}