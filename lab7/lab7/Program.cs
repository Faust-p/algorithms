using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab7
{
    public class Program
    {
        private static List<int> numbersCountList = new List<int> { 1000, 2000, 3000, 4000, 5000 };
        private delegate int[] Sorting(int[] arr);
        private static Random rand = new Random();
        private static int[] UnsortedArr(int length)
        {
            int[] arr = new int[length];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(1, length);

            return arr;
        }

        private static void Idle()
        {
            int[] arr = new int[10000];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(1, 1000);

            Sort.Quick(arr);
        }
        private static double Stopwatch(int[] arr, Sorting sort)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            sort(arr);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }
        static void Main(string[] args)
        {
            Idle();

            foreach (var length in numbersCountList)
            {
                int[] unsortedMas = UnsortedArr(length);
                int[] arr = new int[length];

                Console.WriteLine($"- - - {length} ЭЛЕМЕНТОВ - - -");

                Array.Copy(unsortedMas, arr, length);
                double timeWork = Stopwatch(arr, Sort.Quick);
                Console.WriteLine("{0,-16}{1,-8}", "Быстрая: ", timeWork);

                Array.Copy(unsortedMas, arr, length);
                timeWork = Stopwatch(arr, Sort.Merge);
                Console.WriteLine("{0,-16}{1,-8}", "Слиянием: ", timeWork);

                Array.Copy(unsortedMas, arr, length);
                timeWork = Stopwatch(arr, Sort.Heap);
                Console.WriteLine("{0,-16}{1,-8}", "Пирамидальная: ", timeWork);

                Console.WriteLine();
            }

        }
    }
}
