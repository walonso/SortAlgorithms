using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSortAlgorithms
{
    public interface ISortHubClient
    {
        Task ReceiveProgressAscSortBubble(long time, int value);

        Task ReceiveProgressAscSortSelection(long time, int value);

        Task ReceiveProgressAscSortInsertion(long time, int value);
    }
}
