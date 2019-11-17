using SortingCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace SortAlgorithms
{
    class Program
    {
        static string path = Directory.GetCurrentDirectory()+"/statistics.txt";
        static void Main(string[] args)
        {
            //TODO:
            //la copia del array no hacerla aca, aunque revisar como se comporta con gran cantidad de datos: uso de memoria
            //implementar un Comparable en el core
            //No hacerlo secuencial, hacer un randmon, pero se podra de numeros unicos?
            //meter los tipos de algorimos en una carpeta aparte.
            //crear interfaz y tres diferentes clases que provean las listas con los numeros a ordenar (una clase de ascendingNumbers, otra de descendingNumbers y otra de RandomNumbers)

            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.BubbleSort);
            ISortable sortableSelection = factory.GetSortable(Algorithm.SelectionSort);
            ISortable sortableInsertion = factory.GetSortable(Algorithm.InsertionSort);

            List<int> iterations = new List<int>();
            iterations.Add(10000);
            iterations.Add(100000);
            //iterations.Add(1000000);
            //iterations.Add(10000000);
            FileService fileService = new FileService();
            fileService.Delete(path);
            foreach (int iteration in iterations)
            {
                Sort(sortable, iteration, fileService);
                Sort(sortableSelection, iteration, fileService);
                Sort(sortableInsertion, iteration, fileService);
            }
            

            
            //Console.WriteLine("Original list:");
            //Print(list);

            //Console.WriteLine("Ordered Asc list:");
            //Print(orderedList);

            //Console.WriteLine("Ordered Desc list:");
            //Print(orderedDescList);

            Console.ReadKey();
        }

        //TODO:
        private static List<int> GetListToOrder(int amount)
        {
            List<int> list = new List<int>();
            for(int i = 0; i <= amount; i++)
            {
                list.Add(i);
            }

            return list;
        }

        //TODO:
        private static List<int> GetListInDisorderToOrder(int amount)
        {
            List<int> list = GetListToOrder(amount);
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

        private static List<int> OrderAsc(ISortable sortable, List<int> list)
        {
            return sortable.SortAscending(list);
        }

        private static List<int> OrderDesc(ISortable sortable, List<int> list)
        {
            return sortable.SortDescending(list);
        }

        private static void Print(List<int> list)
        {
            foreach(int value in list)
            {
                Console.WriteLine(value);
            }
        }

        private static void Sort(ISortable sortable, int amount, FileService fileService)
        {
            fileService.Save(path, sortable.ToString());

            Console.WriteLine("---- Analyze "+amount+" ----");
            TimeWatch timer = new TimeWatch();
            timer.Start();
            List<int> list = GetListToOrder(amount);
            Console.WriteLine("Time Loading List: " + timer.GetEllapsedMilliSeconds());

            timer.Restart();
            List<int> listOrderAsc = new List<int>(list);
            List<int> listOrderDesc = new List<int>(list);
            Console.WriteLine("Time Loading List to Order Asc or Desc:" + timer.GetEllapsedMilliSeconds());

            timer.Restart();
            List<int> orderedList = OrderAsc(sortable, listOrderAsc);
            long timeAsc = timer.GetEllapsedMilliSeconds();
            Console.WriteLine("Time Ordering Asc:" + timer.GetEllapsedMilliSeconds());
            
            timer.Restart();
            List<int> orderedDescList = OrderDesc(sortable, listOrderDesc);
            long timeDesc = timer.GetEllapsedMilliSeconds();
            Console.WriteLine("Time Ordering Desc:" + timer.GetEllapsedMilliSeconds());

            fileService.Save(path, Environment.NewLine + $"Amount:{amount},TimeAsc:{timeAsc}, TimeDesc:{timeDesc}");

        }
    }
}
