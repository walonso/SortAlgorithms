using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingCore
{
    public class BubbleSort
    {
        public List<int> SortDescending(List<int> list)
        {            
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            int size = list.Count;

            for (int pass = 1; pass < size; ++pass)
            { // outer loop
                for (int left = 0; left < (size - pass); ++left)
                { // inner loop
                    int right = left + 1;
                    if (list[left] > list[right])
                    {
                        int temp = list[left];
                        list[left] = list[right];
                        list[right] = temp;                        
                    }
                }
            }

            return list;
        }

        public List<int> SortAscending(List<int> list)
        {
            if (list == null || list.Any())
            {
                throw new Exception("List can not be null");
            }

            

            return list;
        }
    }
}
