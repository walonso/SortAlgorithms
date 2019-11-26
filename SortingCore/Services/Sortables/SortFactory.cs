using SortingCore.Interfaces;

namespace SortingCore.Services.Sortables
{
    public enum Algorithm {
        BubbleSort,
        SelectionSort,
        InsertionSort,
        ShellSort,
        QuickSort,
        MergeSort
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
                case Algorithm.ShellSort:
                    return new ShellSort();
                case Algorithm.QuickSort:
                    return new QuickSort();
                case Algorithm.MergeSort:
                    return new MergeSort();
            }
            return null;
        }

    }
    
}
