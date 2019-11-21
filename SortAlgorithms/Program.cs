using SortingCore;
using SortingCore.Interfaces;
using SortingCore.Services.GeneratorItems;
using SortingCore.Services.Sortables;
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
            //Incluir el llamado tambn a random y ordenarlo.
            //Incluir Signal R para realizar una grafica en el front (y sea el back el q envia los datos)
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-2.1
            //desacoplar del hub el llamado directo a los sort y demas.
            //para las graficas agregar la del insert y en una sola grafica poder mostrar las 3 comparaciones.

            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.BubbleSort);
            ISortable sortableSelection = factory.GetSortable(Algorithm.SelectionSort);
            ISortable sortableInsertion = factory.GetSortable(Algorithm.InsertionSort);

            IGeneratorItems generatorItems = new AscendingGenerator();

            List<int> iterations = new List<int>();
            iterations.Add(10000);
            iterations.Add(100000);
            //iterations.Add(1000000);
            //iterations.Add(10000000);
            FileService fileService = new FileService();
            fileService.Delete(path);
            foreach (int iteration in iterations)
            {
                Sort(sortable, generatorItems, iteration, fileService);
                Sort(sortableSelection, generatorItems, iteration, fileService);
                Sort(sortableInsertion, generatorItems, iteration, fileService);
            }
            
            Console.ReadKey();
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

        private static void Sort(ISortable sortable, IGeneratorItems generatorItems, int amount, FileService fileService)
        {
            fileService.Save(path, sortable.ToString());

            Console.WriteLine("---- Analyze "+amount+" ----");
            TimeWatch timer = new TimeWatch();
            timer.Start();
            List<int> list = generatorItems.GetData(amount);
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
