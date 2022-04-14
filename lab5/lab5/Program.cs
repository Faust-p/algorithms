using System;
using System.Diagnostics;

namespace lab5
{
    internal class Program
    {

        public static void Main()
        {
            int[] arraysLengths = { 1_000_000, 2_000_000, 3_000_000, 4_000_000, 5_000_000 };
            foreach (int arrayLength in arraysLengths)
            {
                int numberToFind = arrayLength / 2; 
                int[] array; 

                Console.WriteLine($"Average - {arrayLength} элементов, ищем {numberToFind}");
                array = Generator.Average(arrayLength);
                Find(array, numberToFind);

                Console.WriteLine($"Worst - {arrayLength} элементов, ищем {numberToFind}");
                array = Generator.Worst(arrayLength, numberToFind);
                Find(array, numberToFind);

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Find(int[] array, int numberToFind)
        {
            int Index; 
            double workTime; 

            workTime = CustomStopwatch(Finder.Linear, array, numberToFind, out Index);
            Console.WriteLine($"Линейный\tИндекс:\t{Index}\t\tВремя:\t{workTime}");

            int[] arrayWithBarrier = Generator.LinearWithBarrier(array, numberToFind);
            workTime = CustomStopwatch(Finder.WithBarrier, arrayWithBarrier, numberToFind, out Index);
            Console.WriteLine($"C барьером\tИндекс:\t{Index}\t\tВремя:\t{workTime}");

            Array.Sort(array); 
            workTime = CustomStopwatch(Finder.Binary, array, numberToFind, out Index);
            Console.WriteLine($"Бинарный\tИндекс:\t{Index}\t\tВремя:\t{workTime}");

            workTime = CustomStopwatch(Finder.Jump, array, numberToFind, out Index);
            Console.WriteLine($"Прыжковый\tИндекс:\t{Index}\t\tВремя:\t{workTime}\n");
        }

        private static double CustomStopwatch(Func<int[], int, int> method, int[] array, int numberToFind, out int result)
        {
            Stopwatch stopwatch = new Stopwatch();
            double workTime = 0; 
            stopwatch.Start();
            result = method(array, numberToFind);
            stopwatch.Stop();
            workTime += stopwatch.ElapsedMilliseconds;
            return workTime;
        }
    }
}