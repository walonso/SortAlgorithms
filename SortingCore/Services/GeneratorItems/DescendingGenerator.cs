using SortingCore.Interfaces;
using System.Collections.Generic;

namespace SortingCore.Services.GeneratorItems
{
    public class DescendingGenerator : IGeneratorItems
    {
        public List<int> GetData(int amount)
        {
            List<int> list = new List<int>();
            for (int i = amount; i > 0; i--)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
