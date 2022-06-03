using System;
using System.Collections.Generic;
using System.Linq;


namespace lab9
{
    class Program
    {
        // Задача 1.2
        // Нахождение максимальной суммы для данного числа
        private static long Numb(int s, int k)
        {
            long a;
            if (s < 10)
            {
                return s;
            }
            else
            {
                if (Sum(k) == s)
                {
                    return k;
                }
                else
                {
                    if (k % 10 == 9)
                    {
                        k = k * 10;
                    }
                    k++;
                    a = Numb(s, k);
                    return a;
                }
            }         
        }

        // Сумма всех цифр числа
        private static long Sum(int s)
        {
            long sum = 0;
            while (s > 0)
            {

                sum = sum + s % 10;
                s = s / 10;
            }
            return sum;
        }

        // Переворачивает число
        private static long Reverse(long n)
        {
            string s = n.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            s = new String(arr);
            n = Convert.ToInt32(s);
            return n;
        }

        // Количество цифр в числе
        private static int Count(long n)
        {
            int digitCount = (int)Math.Log10(n) + 1;
            return digitCount;
        }

        // Поиск максимального
        private static long Max(int s, int n)
        {            
            int k = 91, count;
            long a;
            a = Numb(s, k);
            count = Count(a);
            if (count > n)
            {
                return 0;
            }
            else
            {
                count = n - count;
                a = a * (long)Math.Pow(10, count);
            }
            return a;
        }

        // Поиск минимального
        private static long Min(int s, int n)
        {
            long min;
            int r;
            min = Reverse(Max(s, n));
            r = n - Count(min);
            if (r == 0)
            {
                return min;
            }
            else
            {
                if (Count(min) == 1)
                    min = min - 1 + (int)Math.Pow(10, n - 1);
                else
                    min = min - (int)Math.Pow(10, Count(min) - 1) + (int)Math.Pow(10, n - 1);
            }
            return min;
        }

        static void Main(string[] args)
        {
            // Задача 1
            // Нахожу максимально возможное число, сумма цифр которого равна нашей вводимой сумме и подгоняем под нужное количество цифр n. 
            // Затем, для поиска минимального, это число переворачиваю, после чего делаю из него число нужного количества цифр.
            int s, n;
            Console.WriteLine("Введите сумму цифр: ");
            s = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Количество цифр: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (Max(s, n) == 0)
                Console.WriteLine("Нет таких чисел");
            else
                Console.WriteLine("{0} {1}", Max(s, n), Min(s, n));

            Console.WriteLine();
        }
    }
}
