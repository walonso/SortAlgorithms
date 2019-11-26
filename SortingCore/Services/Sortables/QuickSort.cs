using SortingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingCore.Services.Sortables
{
    class QuickSort : ISortable
    {
        IProgress<int> Progress;

        public void SetCallBackMethodByOrderedElement(IProgress<int> CallBack)
        {
            Progress = CallBack;
        }

        public List<int> SortAscending(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            quicksortAsc(list, 0, list.Count - 1);
            return list;
        }
        public List<int> SortDescending(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            quicksortDesc(list, 0, list.Count - 1);
            return list;
        }

        private void quicksortAsc(List<int> list, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= list.Count)
            {
                return;
            }
            if (endIndex <= startIndex)
            {
                return;
            }
            int value = list[endIndex];
            int partition = partitionListAsc(list, value, startIndex, endIndex - 1);
            if (list[partition] < value) //aca debe cambiar
            {
                ++partition;
            }
            swap(list, partition, endIndex);
            Progress?.Report(startIndex);
            quicksortAsc(list, startIndex, partition - 1);
            quicksortAsc(list, partition + 1, endIndex);
        }

        private int partitionListAsc(List<int> list, int value, int leftIndex, int rightIndex)
        {
            int left = leftIndex;
            int right = rightIndex;
            while (left < right)
            {
                if (list[left] < value) //aca debe cambiar
                {
                    ++left;
                    continue;
                }
                if (list[right] >= value)  //aca debe cambiar
                {
                    --right;
                    continue;
                }
                swap(list, left, right);
                ++left;
            }
            return left;
        }

        private void quicksortDesc(List<int> list, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= list.Count)
            {
                return;
            }
            if (endIndex <= startIndex)
            {
                return;
            }
            int value = list[endIndex];
            int partition = partitionListDesc(list, value, startIndex, endIndex - 1);
            if (list[partition] > value) //aca debe cambiar
            {
                ++partition;
            }
            swap(list, partition, endIndex);
            Progress?.Report(startIndex);
            quicksortDesc(list, startIndex, partition - 1);
            quicksortDesc(list, partition + 1, endIndex);
        }

        private int partitionListDesc(List<int> list, int value, int leftIndex, int rightIndex)
        {
            int left = leftIndex;
            int right = rightIndex;
            while (left < right)
            {
                if (list[left] >= value) //aca debe cambiar
                {
                    ++left;
                    continue;
                }
                if (list[right] < value)  //aca debe cambiar
                {
                    --right;
                    continue;
                }
                swap(list, left, right);
                ++left;
            }
            return left;
        }

        private void swap(List<int> list, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            int temp = list[left];
            list[left] = list[right];//.set(left, list.get(right));
            list[right] = temp;
        }
    }
}
