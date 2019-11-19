using SortingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingCore.Services.Sortables
{
    public class InsertionSort : ISortable
    {
        public override string ToString()
        {
            return "InsertionSort";
        }

        public List<int> SortAscending(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }
            List<int> resultList = new List<int>();

            int size = list.Count;

            for (int pass = 0; pass < size; ++pass)
            {
                int slot = resultList.Count;
                while (slot > 0)
                {
                    if (list[pass] > resultList[slot - 1])
                    {
                        break;
                    }
                    --slot;
                }
                resultList.Insert(slot, list[pass]);
            }

            return resultList;
        }

        public List<int> SortDescending(List<int> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("List can not be null");
            }
            List<int> resultList = new List<int>();

            int size = list.Count;

            for (int pass = 0; pass < size; ++pass)
            {
                int slot = resultList.Count;
                while (slot > 0)
                {
                    if (list[pass] < resultList[slot - 1])
                    {
                        break;
                    }
                    --slot;
                }
                resultList.Insert(slot, list[pass]);
            }

            return resultList;
        }

        public void SetCallBackMethodByOrderedElement(Func<int, int> CallBack)
        {
            throw new NotImplementedException();
        }
    }
}
