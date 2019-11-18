using SortingCore.Interfaces;
using System;
using System.Collections.Generic;

namespace SortingCore.Services.GeneratorItems
{
    public class RandomGenerator : IGeneratorItems
    {
        public List<int> GetData(int amount)
        {
            List<int> list = GetOrderedData(amount);
            Random rnd = new Random();
            for (int i = 0; i < amount / 2; i++)
            {
                int randomFirstPosition = rnd.Next(amount);
                int randomSecondPosition = rnd.Next(amount);
                int aux = list[randomFirstPosition];
                list[randomFirstPosition] = list[randomSecondPosition];
                list[randomSecondPosition] = aux;
            }
            return list;
        }

        public List<int> GetOrderedData(int amount)
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
