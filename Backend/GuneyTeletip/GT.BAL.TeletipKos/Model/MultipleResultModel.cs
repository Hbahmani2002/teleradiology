using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GT.BAL.TeletipKos.Model
{
    public class OperationResultModel
    {
        public int Status { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
    }
    public class MultipleOperationResultModel
    {
        public long TotalSuccess { get; }
        public long TotalFail { get; }

        public OperationResultModel[] Items { get; }
        public MultipleOperationResultModel(OperationResultModel[] items)
        {
            Items = items;
            TotalSuccess = items.Count(o => o.Status == 1);
            TotalFail = items.Count(o => o.Status == 0);
        }
    }
}
