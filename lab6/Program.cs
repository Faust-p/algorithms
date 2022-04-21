using System;
using System.Diagnostics;

namespace lab6
{
    static class Program
    {
        private static readonly int[] lengthsArray = { 100, 1_000, 2_500, 5_000, 10_000 }; // Длины генерируемых массивов
        private static readonly Random random = new Random();
        private delegate int[] SortMethod(int[] array);

        static void Main(string[] args)
        {
            foreach (var length in lengthsArray)
            {
                int[] array = new int[length];

                for (var i = 0; i < length; i++) // Заполнение массива
                    array[i] = random.Next(1, length); // Случайное число от 1 до количества элементов массива

                Console.WriteLine($"- - - {length} ЭЛЕМЕНТОВ - - -");

                double ticks = CustomStopwatch(array, sort.Bubble);
                Console.WriteLine("{0,-16}{1,-8}", "Пузырьковая: ", ticks);

                ticks = CustomStopwatch(array, sort.Shaker);
                Console.WriteLine("{0,-16}{1,-8}", "Шейкерная: ", ticks);


                ticks = CustomStopwatch(array, sort.Comb);
                Console.WriteLine("{0,-16}{1,-8}", "Расчёской: ", ticks);

                ticks = CustomStopwatch(array, sort.Choice);
                Console.WriteLine("{0,-16}{1,-8}", "Выбором: ", ticks);

                ticks = CustomStopwatch(array, sort.Inserts);
                Console.WriteLine("{0,-16}{1,-8}", "Вставками: ", ticks);

                ticks = CustomStopwatch(array, sort.Shell);
                Console.WriteLine("{0,-16}{1,-8}", "Шелла: ", ticks);

                ticks = CustomStopwatch(array, sort.Dwarf);
                Console.WriteLine("{0,-16}{1,-8}", "Гномья: ", ticks);

                Console.WriteLine();
            }
        }
        private static double CustomStopwatch(int[] array, SortMethod sortMethod)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            sortMethod(array); // Сортировка
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
    }
}
