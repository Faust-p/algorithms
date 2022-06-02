using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab8
{
    public static class Sort
    {
        // Сортировка подсчетом
        public static int[] Counting(int[] arr)
        {
            return Counting(arr, arr.Min(), arr.Max());
        }

        private static int[] Counting(int[] arr, int min, int max)
        {
            int[] count = new int[max - min + 1];
            int k = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }
            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    arr[k++] = i;
                }
            }
            return arr;
        }

        // Голубиная сортировка
        public static int[] Pigeonhole(int[] arr)
        {
            int k = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsKey(arr[i]))
                {
                    dictionary[arr[i]]++;
                }
                else
                {
                    dictionary.Add(arr[i], 1);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsKey(i))
                {
                    for (int j = 0; j < dictionary[i]; j++)
                    {
                        arr[k++] = i;
                    }
                }
            }
            return arr;
        }

        // Блочная сортировка
        public static int[] Bucket(int[] arr)
        {
            int min = arr.Min(), max = arr.Max(), count = 0;
            List<int>[] bucket = new List<int>[max - min + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - min].Add(arr[i]);
            }

            for (int i = 0; i < bucket.Length; i++)
            {
                for (int j = 0; j < bucket[i].Count; j++)
                {
                    arr[count++] = bucket[i][j];

                }
            }
            return arr;
        }

        // Поразрядная сортировка
        public static int[] Radix(int[] arr)
        {
            return Radix(arr, 10, (int)Math.Log10(arr.Max()) + 1);
        }

        private static int[] Radix(int[] arr, int range, int lengthNumber)
        {
            List<int>[] bucket = new List<int>[range];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < lengthNumber; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    bucket[(arr[j] % (int)Math.Pow(range, i + 1)) / (int)Math.Pow(range, i)].Add(arr[j]);

                }
                int count = 0;
                for (int j = 0; j < bucket.Length; j++)
                {
                    for (int k = 0; k < bucket[j].Count; k++)
                    {
                        arr[count++] = bucket[j][k];

                    }
                }
                for (int k = 0; k < bucket.Length; k++)
                {
                    bucket[k].Clear();

                }
            }
            return arr;
        }
    }
}
