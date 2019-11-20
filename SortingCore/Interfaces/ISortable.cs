using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SortingCore.Interfaces
{
    public interface ISortable
    {
        List<int> SortAscending(List<int> list);
        List<int> SortDescending(List<int> list);
        void SetCallBackMethodByOrderedElement(IProgress<int> callBackByOrderedElement);
    }
}
