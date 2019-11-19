using System;
using System.Collections.Generic;

namespace SortingCore.Interfaces
{
    public interface ISortable
    {
        void SetCallBackMethodByOrderedElement(Func<int, int> CallBack);

        List<int> SortAscending(List<int> list);

        List<int> SortDescending(List<int> list);
    }
}
