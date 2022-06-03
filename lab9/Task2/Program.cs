using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Collections.Extensions;


namespace Task2
{
    class Program
    {
        // Подсчёт количества путей
        private static long Search(MultiValueDictionary<int, int> Lecture, int count)
        {
            var min = Lecture.Min(s => s.Key);
            foreach (KeyValuePair<int, IReadOnlyCollection<int>> first in Lecture.OrderBy(first => first.Key))
            {
                if (min >= first.Key)
                {
                    foreach (int value in first.Value)
                    {
                        min = value;
                        count++;
                    }
                }
                else
                    break;
            }
            return count;
        }
        static void Main(string[] args)
        {
            // Задача 2.3
            Console.WriteLine("Введите количество лекций");
            int N;
            N = Convert.ToInt32(Console.ReadLine());
            MultiValueDictionary<int, int> Lecture = new MultiValueDictionary<int, int>(N);
            for (int i = 0; i < N; i++)
            {
                string temp = Console.ReadLine();
                Lecture.Add(int.Parse(temp.Split(" ")[0]), int.Parse(temp.Split(" ")[1]));
            }
            int count = 0;
            int tempCount = 1;
            // Ищем наибольше количество путей
            for (int i = 0; i < N; i++)
            {
                if (count > tempCount)
                {
                    tempCount = count;
                }
                count++;
                Search(Lecture, count);
            }
            Console.WriteLine("Максимальное количество заявок, которые можно выполнить: {0}", tempCount);
            Console.WriteLine();
        }
    }
}
