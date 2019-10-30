using SortingCore;
using System;
using System.Collections.Generic;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO:
            //la copia del array no hacerla aca, aunque revisar como se comporta con gran cantidad de datos: uso de memoria
            //implementar un Comparable en el core
            //Una fabrica para distribuir los sorts
            //Incrementar la cantida de datos.


            List<int> list = new List<int>();
            list.Add(10);
            list.Add(50);
            list.Add(5);
            list.Add(2);
            list.Add(1);

            List<int> originalList = new List<int>(list);

            BubbleSort sort = new BubbleSort();
            List<int> orderedList = sort.SortAscending(originalList);

            List<int> original2List = new List<int>(list);
            List<int> orderedDescList = sort.SortDescending(original2List);

            Console.WriteLine("Original list:");
            Print(list);

            Console.WriteLine("Ordered list:");
            Print(orderedList);

            Console.WriteLine("Ordered list:");
            Print(orderedDescList);

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
