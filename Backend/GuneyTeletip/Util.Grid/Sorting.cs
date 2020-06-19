using static TIF.DAL.Linq.QueryableExtensions;

namespace GT.UTILS.GRID
{
    public class Sorting
    {
        public string ColName { get; set; }
        /// <summary>
        /// true:desc
        /// false:asc
        /// </summary>
        public Order Direction { get; set; }
    }
}