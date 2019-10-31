using System;
using System.Collections.Generic;
using System.Text;

namespace SortingCore
{
    public interface ISortable
    {
        List<int> SortAscending(List<int> list);

        List<int> SortDescending(List<int> list);
    }
}
