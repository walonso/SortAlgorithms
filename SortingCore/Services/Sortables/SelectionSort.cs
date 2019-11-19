using SortingCore.Interfaces;
using System;
using System.Collections.Generic;

namespace SortingCore.Services.Sortables
{
    public class SelectionSort : ISortable
    {
        public void SetCallBackMethodByOrderedElement(Func<int, int> CallBack)
        {
            throw new NotImplementedException();
        }

        public List<int> SortAscending(List<int> list)
        {
            int size = list.Count;

            for (int slot = 0; slot < size - 1; ++slot)
            { // outer loop
                int smallest = slot;
                for (int check = slot + 1; check < size; ++check)
                { // inner loop
                    if (list[check] < list[smallest])
                    {
                        smallest = check;
                    }
                }
                swap(list, smallest, slot);
            }
            return list;
        }
        public List<int> SortDescending(List<int> list)
        {
            int size = list.Count;

            for (int slot = 0; slot < size - 1; ++slot)
            { // outer loop
                int tallest = slot;
                for (int check = slot + 1; check < size; ++check)
                { // inner loop
                    if (list[check] > list[tallest])
                    {
                        tallest = check;
                    }
                }
                swap(list, tallest, slot);
            }
            return list;
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
