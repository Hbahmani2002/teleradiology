using System.Collections.Generic;

namespace MEDLIFE.UTILS.GRID
{
    public interface IDeselectable
    {
        List<long> ExcludedIdList { get; set; }
    }
}