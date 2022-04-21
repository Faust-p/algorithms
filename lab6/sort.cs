using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    public static class sort
    {
        // Пузырьковая сортировка
        public static int[] Bubble(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); // Взаимная замена переменных
                }
            }
            return arr;
        }

        public static int[] Shaker(int[] arr)
        {
            for (var i = 0; i < arr.Length / 2; i++)
            {
                var swapFlag = false;

                for (var j = i; j < arr.Length - i - 1; j++) // Проход слева направо
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapFlag = true;
                    }
                }

                for (var j = arr.Length - 2 - i; j > i; j--) // Проход справа налево
                {
                    if (arr[j - 1] > arr[j])
                    {
                        (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag) // Выход, если обменов не было
                    break;
            }

            return arr;
        }

        // Сортировка расчёской
        public static int[] Comb(int[] arr)
        {
            var arrLength = arr.Length;
            var currentStep = arrLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < arr.Length; i++)
                {
                    if (arr[i] > arr[i + currentStep])
                        (arr[i], arr[i + currentStep]) = (arr[i + currentStep], arr[i]);
                }

                currentStep = GetNextStep(currentStep);
            }

            return Bubble(arr); // Пузырьковая сортировка

            int GetNextStep(int step) // Метод для генерации следующего шага
            {
                step = step * 1000 / 1247;
                return step > 1 ? step : 1;
            }
        }

        // Сортировка выбором
        public static int[] Choice(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Поиск минимального числа
                var min = i;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                (arr[i], arr[min]) = (arr[min], arr[i]);
            }

            return arr;
        }

        // Сортировка Шелла
        public static int[] Shell(int[] arr)
        {
            int step = arr.Length / 2;

            while (step > 0)
            {
                for (int i = step; i < arr.Length; i++)
                {
                    int value = arr[i];
                    int j;
                    for (j = i - step; (j >= 0) && (arr[j] > value); j -= step)
                        arr[j + step] = arr[j];

                    arr[j + step] = value;
                }
                step /= 2;
            }

            return arr;
        }

        // Гномья сортировка
        public static int[] Dwarf(int[] arr)
        {
            int i = 1;
            int j = 2;

            while (i < arr.Length)
            {
                if (arr[i - 1] < arr[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    (arr[i - 1], arr[i]) = (arr[i], arr[i - 1]);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }

            return arr;
        }
        // Сортировка вставками
        public static int[] Inserts(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var key = arr[i];
                var j = i;
                while ((j > 1) && (arr[j - 1] > key))
                {
                    int k = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = k;
                    j--;
                }

                arr[j] = key;
            }

            return arr;
        }
    }
}
