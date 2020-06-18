using System.Collections;
using System.Collections.Generic;

namespace GT.UTILS.GRID
{

    public class PagingResult
    {
        public IList List { get; set; }
        public long TotalCount { get; set; }
    }
    public class PagingResult<T>
    {
        public List<T> List { get; set; }
        public long TotalCount { get; set; }

    }
}
