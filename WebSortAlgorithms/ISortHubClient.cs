using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSortAlgorithms
{
    public interface ISortHubClient
    {
        Task ReceiveProgressSortBubble(long time, int value);
    }
}
