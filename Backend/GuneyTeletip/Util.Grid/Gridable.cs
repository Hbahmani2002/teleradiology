
namespace GT.UTILS.GRID
{
    public class Gridable<T>
    {
        public T Filter { get; set; }
        public Paging Paging { get; set; }
        public Sorting Sorting { get; set; }

        public void Validate()
        {
            if (Filter == null)
            {
                throw new System.Exception("Gridable Filter property null olamaz");
            }
        }
        public Gridable()
        {
            Paging = new Paging();
        }
    }
}
