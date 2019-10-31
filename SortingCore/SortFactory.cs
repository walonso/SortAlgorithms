namespace SortingCore
{
    public enum Algorithm {
        BubbleSort
    }

    public class SortFactory
    {
        public ISortable GetSortable(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.BubbleSort:
                    return new BubbleSort();
            }
            return null;
        }

    }
}
