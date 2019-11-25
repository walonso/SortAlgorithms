using SortingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingCore.Services.Sortables
{
    public class ShellSort : ISortable
    {
        IProgress<int> Progress;

        public void SetCallBackMethodByOrderedElement(IProgress<int> CallBack)
        {
            Progress = CallBack;
        }

        private void hSortAsc(List<int> list, int increment)
        {
            if (list.Count < (increment * 2))
            {
                return;
            }
            for (int i = 0; i < increment; ++i)
            {
                sortSublistAsc(list, i, increment);
            }
        }

        private void sortSublistAsc(List<int> list, int startIndex, int increment)
        {
            for (int i = startIndex + increment; i < list.Count; i += increment)
            {
                int value = list[i];
                int j;
                for (j = i; j > startIndex; j -= increment)
                {
                    int previousValue = list[j - increment];
                    if (value > previousValue)
                    {
                        break;
                    }
                    list[j] = previousValue;
                }
                list[j] = value;
                Progress?.Report(i);
            }
        }

        public List<int> SortAscending(List<int> list)
        {
            int[] increments = { 121, 40, 13, 4, 1 };

            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            for (int i = 0; i < increments.Length; i++)
            {
                int increment = increments[i];
                hSortAsc(list, increment);
            }

            return list;
        }

        public List<int> SortDescending(List<int> list)
        {
            int[] increments = { 121, 40, 13, 4, 1 };

            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            for (int i = 0; i < increments.Length; i++)
            {
                int increment = increments[i];
                hSortDesc(list, increment);
            }

            return list;
        }

        private void hSortDesc(List<int> list, int increment)
        {
            if (list.Count < (increment * 2))
            {
                return;
            }
            for (int i = 0; i < increment; ++i)
            {
                sortSublistDesc(list, i, increment);
            }
        }

        private void sortSublistDesc(List<int> list, int startIndex, int increment)
        {
            for (int i = startIndex + increment; i < list.Count; i += increment)
            {
                int value = list[i];
                int j;
                for (j = i; j > startIndex; j -= increment)
                {
                    int previousValue = list[j - increment];
                    if (value < previousValue)
                    {
                        break;
                    }
                    list[j] = previousValue;
                }                
                list[j] = value;
                Progress?.Report(i);
            }
        }

        public override string ToString()
        {
            return "ShellSort";
        }
    }
}
