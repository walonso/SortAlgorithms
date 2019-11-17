namespace SortingCore
{
    public enum Algorithm {
        BubbleSort,
        SelectionSort,
        InsertionSort
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
                case Algorithm.InsertionSort:
                    return new InsertionSort();

            }
            return null;
        }

    }
}
