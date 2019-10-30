using SortingCore;
using System;
using System.Collections.Generic;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(50);
            list.Add(5);
            list.Add(2);
            list.Add(1);

            List<int> originalList = new List<int>(list);

            BubbleSort sort = new BubbleSort();
            List<int> orderedList = sort.SortDescending(originalList);

            Console.WriteLine("Original list:");
            Print(list);

            Console.WriteLine("Ordered list:");
            Print(orderedList);

            Console.ReadKey();
        }

        private static void Print(List<int> list)
        {
            foreach(int value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
}
