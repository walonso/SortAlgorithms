using System.Collections.Generic;

namespace SortingCore.Interfaces
{
    public interface ISortable
    {
        List<int> SortAscending(List<int> list);

        List<int> SortDescending(List<int> list);
    }
}
