using System.Collections.Generic;

namespace GT.UTILS.GRID
{
    public class SelectedItemListUI<T>
    {
        public bool IsIncluded { get; set; }
        public List<T> ItemList { get; set; }
        public SelectedItemListUI()
        {
            ItemList = new List<T>();
        }
    }
}
