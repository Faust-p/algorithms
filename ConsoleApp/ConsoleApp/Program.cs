using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp
{
    public static class Program
    {
        private static HashSet<int> listsLengths = new HashSet<int> { 10000000, 20000000, 50000000, 100000000 };
        private static Stopwatch stopwatch = new Stopwatch(); // Секундомер
        private static double workTime;

        public static void Main()
        {
            int[] numbersArray;

            Generator generator = new Generator(1000000);
            generator.Best(); // Холостой 

            foreach (int length in listsLengths)
            {
                generator = new Generator(length);

                numbersArray = generator.Worst(); // Худший случай
                Stopwatch(numbersArray);
                Console.WriteLine($"Элементов: {length}");
                Console.WriteLine($"Худший случай - время: {workTime}");

                numbersArray = generator.Average(); // Средний случай
                Stopwatch(numbersArray);
                Console.WriteLine($"Средний случай -  время: {workTime}");

                numbersArray = generator.Best(); // Лучший случай
                Stopwatch(numbersArray);
                Console.WriteLine($"Лучший случай -  время: {workTime}\n");
            }
        }

        //Проверка на возрастание
        private static bool AscendingTest(int[] numbersArray)
        {
            int number = numbersArray[0];
            for (int i = 1; i < numbersArray.Length; i++)
            {
                if (number > numbersArray[i])
                {
                    return false;
                }
                else
                {
                    number = numbersArray[i];
                }              
            }
            return true;
        }

        // Секундомер
        private static void Stopwatch(int[] numbersArray)
        {
            workTime = 0; // Секундомер
            stopwatch.Reset();
            stopwatch.Start();
            AscendingTest(numbersArray);
            stopwatch.Stop();
            workTime = workTime + stopwatch.ElapsedMilliseconds;
        }
    }
}