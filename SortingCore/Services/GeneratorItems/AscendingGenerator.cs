using SortingCore.Interfaces;
using System.Collections.Generic;

namespace SortingCore.Services.GeneratorItems
{
    public class AscendingGenerator : IGeneratorItems
    {
        public List<int> GetData(int amount)
        {
            List<int> list = new List<int>();
            for (int i = 0; i <= amount; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
