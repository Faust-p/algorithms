using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab8
{
    class Program
    {
        private static List<int> numbersCountList = new List<int> { 1000, 2000, 3000, 4000, 5000 };
        private static Random rand = new Random();
        private delegate int[] sort(int[] arr);

        private static void Idle()
        {
            int[] arr = new int[10000];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(1, 1000);

            Sort.Counting(arr);
        }

        private static double Stopwatch(int[] arr, sort sort)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            sort(arr);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private static int[] UnsortedMas(int length)
        {
            int[] arr = new int[length];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(100, 1000);

            return arr;
        }

        static void Main(string[] args)
        {
            Idle();
            foreach (var length in numbersCountList)
            {
                int[] unsortedMas = UnsortedMas(length);
                int[] arr = new int[length];

                Console.WriteLine($"- - - {length} ЭЛЕМЕНТОВ - - -");

                Array.Copy(unsortedMas, arr, length);
                double timeWork = Stopwatch(arr, Sort.Counting);
                Console.WriteLine("{0,-16}{1,-8}", "Подсчетом: ", timeWork);

                Array.Copy(unsortedMas, arr, length);
                timeWork = Stopwatch(arr, Sort.Pigeonhole);
                Console.WriteLine("{0,-16}{1,-8}", "Голубиная: ", timeWork);

                Array.Copy(unsortedMas, arr, length);
                timeWork = Stopwatch(arr, Sort.Bucket);
                Console.WriteLine("{0,-16}{1,-8}", "Блочная: ", timeWork);

                Array.Copy(unsortedMas, arr, length);
                timeWork = Stopwatch(arr, Sort.Radix);
                Console.WriteLine("{0,-16}{1,-8}", "Поразрядная: ", timeWork);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
