using System.Linq;
using TIF.DAL.Linq;
using TIF.DTO.Types.Reflection;

namespace GT.UTILS.GRID
{
    public static class Pager
    {
        public static PagingResult<T> GetGridQuery<T, U>(this IQueryable<T> q, Gridable<U> grid) where T : new()
        {
            var skipCount = grid.Paging.GetSkipCount();
            IQueryable<T> qn = q;
            if (grid.Sorting == null || string.IsNullOrEmpty(grid.Sorting.ColName))
            {
                var type = typeof(T);
                var attPropertyList = ReflectionHelper.PropertyAttributeList(type, typeof(DataEntityIDAttribute));
                if (attPropertyList.Count == 0)
                {
                    throw new System.Exception($"Bu class için ({type.Name}) DataEntityIDAttribute column tanımlanmamış");
                }
                else if (attPropertyList.Count > 1)
                {
                    throw new System.Exception($"Bu class için {type.Name} DataEntityIDAttribute birden fazla({string.Join(",", attPropertyList)}) tanımlanmış");
                }

                qn = qn.OrderByDynamic(attPropertyList[0], QueryableExtensions.Order.Desc);
            }
            else
            {
                qn = qn.OrderByDynamic(grid.Sorting.ColName, grid.Sorting.Direction);
            }


            return new PagingResult<T>
            {
                List = qn.Skip(grid.Paging.GetSkipCount())
                 .Take(grid.Paging.Count).ToList(),
                TotalCount = qn.Count()
            };
        }
        public static PagingResult<T> GetPagingQuery<T>(IQueryable<T> ordered, Paging paging) where T : new()
        {
            var skipCount = paging.GetSkipCount();

            var pagingQuery = ordered
                .Skip(skipCount)
                .Take(paging.Count);
            return new PagingResult<T>
            {
                List = pagingQuery.ToList(),
                TotalCount = ordered.Count()
            };
        }


    }
}
