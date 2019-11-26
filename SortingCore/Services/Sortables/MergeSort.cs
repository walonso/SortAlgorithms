using SortingCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingCore.Services.Sortables
{
    public class MergeSort : ISortable
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

            return mergesortAsc(list, 0, list.Count - 1);
        }

        public List<int> SortDescending(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }

            return mergesortDesc(list, 0, list.Count - 1);
        }

        private List<int> mergesortAsc(List<int> list, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                List<int> result = new List<int>();
                result.Add(list[startIndex]);
                return result;
            }
            int splitIndex = startIndex + (endIndex - startIndex) / 2;
            List<int> left = mergesortAsc(list, startIndex, splitIndex);
            List<int> right = mergesortAsc(list, splitIndex + 1, endIndex);
            Progress?.Report(startIndex);
            return mergeAsc(left, right);
        }

        private List<int> mergesortDesc(List<int> list, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                List<int> result = new List<int>();
                result.Add(list[startIndex]);
                return result;
            }
            int splitIndex = startIndex + (endIndex - startIndex) / 2;
            List<int> left = mergesortDesc(list, startIndex, splitIndex);
            List<int> right = mergesortDesc(list, splitIndex + 1, endIndex);
            Progress?.Report(startIndex);
            return mergeDesc(left, right);
        }


        private List<int> mergeAsc(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftSize = left.Count;
            int rightSize = right.Count;

            int leftIterator = 0;
            int rightIterator = 0;
            while (!(leftIterator == leftSize && rightIterator == rightSize))
            {
                if (leftIterator == leftSize)
                {
                    result.Add(right[rightIterator]);
                    rightIterator++;
                }
                else if (rightIterator == rightSize)
                {
                    result.Add(left[leftIterator]);
                    leftIterator++;
                }
                else if (left[leftIterator] <= right[rightIterator])
                {
                    result.Add(left[leftIterator]);
                    leftIterator++;
                }
                else
                {
                    result.Add(right[rightIterator]);
                    rightIterator++;
                }
            }
            return result;
        }

        private List<int> mergeDesc(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftSize = left.Count;
            int rightSize = right.Count;

            int leftIterator = 0;
            int rightIterator = 0;
            while (!(leftIterator == leftSize && rightIterator == rightSize))
            {
                if (leftIterator == leftSize)
                {
                    result.Add(right[rightIterator]);
                    rightIterator++;
                }
                else if (rightIterator == rightSize)
                {
                    result.Add(left[leftIterator]);
                    leftIterator++;
                }
                else if (left[leftIterator] >= right[rightIterator])
                {
                    result.Add(left[leftIterator]);
                    leftIterator++;
                }
                else
                {
                    result.Add(right[rightIterator]);
                    rightIterator++;
                }
            }
            return result;
        }

        public override string ToString()
        {
            return "MergeSort";
        }
    }
}
