﻿using SortingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingCore.Services.Sortables
{
    public class BubbleSort : ISortable
    {
        Func<int, int> CallBackByOrderedElement;

        public override string ToString()
        {
            return "BubbleSort";
        }

        public List<int> SortAscending(List<int> list)
        {            
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            int size = list.Count;

            for (int pass = 1; pass < size; ++pass)
            {
                CallBackByOrderedElement?.Invoke(pass);
                // outer loop
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

        public List<int> SortDescending(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            int size = list.Count;

            for (int pass = 1; pass < size; ++pass)
            {
                CallBackByOrderedElement?.Invoke(pass);
                // outer loop
                for (int left = 0; left < (size - pass); ++left)
                { // inner loop
                    int right = left + 1;
                    if (list[left] < list[right])
                    {
                        int temp = list[left];
                        list[left] = list[right];
                        list[right] = temp;
                    }
                }
            }

            return list;
        }

        public void SetCallBackMethodByOrderedElement(Func<int, int> CallBack)
        {
            CallBackByOrderedElement = CallBack;
        }
    }
}
