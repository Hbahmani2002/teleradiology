using System;

namespace GT.UTILS.GRID
{
    public class Paging
    {
        public const int DefaultCount = 25;
        public Paging()
        {
            Count = DefaultCount;
            PageNumber = 1;
        }
        public int PageNumber { get; set; }
        public int Count { get; set; }

        public int GetSkipCount()
        {
            return (PageNumber - 1) * Count;
        }

    }
}
