﻿
using TIF.DTO.Types.Reflection;

namespace MEDLIFE.UTILS.GRID
{
    public class FilterPagingBase : FilterBase, IPaging
    {
        public Paging Paging { get; set; }

        //public override string ToString()
        //{
        //   // return ReflectionHelper.ToString(this);
        //}
    }
}
