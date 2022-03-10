using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    internal class Generator
    {
        private readonly Random random = new Random();
        private readonly int Count;
        private int[] numbersArray;

        public Generator(int count)
        {
            Count = count;
            numbersArray = new int[count];
        }

        // Худший вариант, массив отсортирован по возрастанию
        internal int[] Worst()
        {
            int k = 0;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = k;
                k++;
            }
            return numbersArray;
        }

        // Средний случай, половина по возрастанию, а остальные случайные элементы (т.к. при полностью случайных значениях всегда выдаёт 0)
        internal int[] Average()
        {
            for (int i = 0; i < numbersArray.Length / 2; i++)
            {
                int k = 0;
                numbersArray[i] = k;
                k++;
            }
            for (int i = numbersArray.Length / 2; i < numbersArray.Length; i++)
            {
                numbersArray[i] = random.Next(0, Count);
            }
            return numbersArray;
        }

        // Лучший вариант, первый элемент больше второго
        internal int[] Best()
        {
            numbersArray[0] = 1; 
            numbersArray[1] = 0;
            for (int i = 2; i < numbersArray.Length; i++) // Далее заполнение случайными числами
            {
                numbersArray[i] = random.Next(1, Count);
            }
            return numbersArray;
        }
    }
}