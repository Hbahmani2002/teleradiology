using System.Collections.Generic;

namespace GT.UTILS.GRID
{
    public interface IDeselectable
    {
        List<long> ExcludedIdList { get; set; }
    }
}