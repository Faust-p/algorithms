using System;
using System.Diagnostics.CodeAnalysis;

namespace lab5
{
    internal static class Generator
    {
        private static Random random = new Random();

        public static int[] Average(int numbersCount)
        {
            int[] array = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                int randomNumber = random.Next(0, numbersCount);
                array[i] = randomNumber;
            }
            return array;
        }

        public static int[] Worst(int Count, int numberFind)
        {
            int[] array = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = numberFind + 1;
            }
            return array;
        }

        public static int[] LinearWithBarrier(int[] array, int numberFind)
        {
            int[] arrayBarrier = new int[array.Length + 1];
            array.CopyTo(arrayBarrier, 0);
            arrayBarrier[arrayBarrier.Length - 1] = numberFind; 
            return arrayBarrier;
        }
    }
}