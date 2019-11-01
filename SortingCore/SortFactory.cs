namespace SortingCore
{
    public enum Algorithm {
        BubbleSort,
        SelectionSort
    }

    public class SortFactory
    {
        public ISortable GetSortable(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.BubbleSort:
                    return new BubbleSort();
                case Algorithm.SelectionSort:
                    return new SelectionSort();
            }
            return null;
        }

    }
}
