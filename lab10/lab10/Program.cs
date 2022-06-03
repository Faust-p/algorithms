using System;
using System.Collections.Generic;
using System.IO;

namespace lab10
{
    class Program
    {
        static StreamReader Input = new StreamReader("input.txt");
        static StreamWriter Output = new StreamWriter("output.txt");
        static int N, M, L;
        static Queue<int> queue = new Queue<int>();
        static bool end = false;

        static bool NumberOfPendant(char[,] Garden)
        {
            if (end)
                return true;
            int i, j, time;

            while (queue.Count != 0)
            {
                // Извлекаем координаты
                j = queue.Dequeue();
                i = queue.Dequeue();
                time = queue.Dequeue();

                // Ищем королеву
                if (j > 0 && Garden[j - 1, i] == 'K') // Сверху
                    return ++time <= L ? true : false;

                if (j < N - 1 && Garden[j + 1, i] == 'K') // Снизу
                    return ++time <= L ? true : false;

                if (i > 0 && Garden[j, i - 1] == 'K') // Слева
                    return ++time <= L ? true : false;

                if (i < M - 1 && Garden[j, i + 1] == 'K') // Справа
                    return ++time <= L ? true : false;

                // Королеву не нашли. Следующий шаг
                if (j > 0 && Garden[j - 1, i] == '0') // Вверх
                {
                    queue.Enqueue(j - 1);
                    queue.Enqueue(i);
                    queue.Enqueue(++time);
                    Garden[j - 1, i] = '1';
                    time--;
                }

                if (j < N - 1 && Garden[j + 1, i] == '0') // Вниз
                {
                    queue.Enqueue(j + 1);
                    queue.Enqueue(i);
                    queue.Enqueue(++time);
                    Garden[j + 1, i] = '1';
                    time--;
                }

                if (i > 0 && Garden[j, i - 1] == '0') // Влево
                {
                    queue.Enqueue(j);
                    queue.Enqueue(i - 1);
                    queue.Enqueue(++time);
                    Garden[j, i - 1] = '1';
                    time--;
                }

                if (i < M - 1 && Garden[j, i + 1] == '0') // Вправо
                {
                    queue.Enqueue(j);
                    queue.Enqueue(i + 1);
                    queue.Enqueue(++time);
                    Garden[j, i + 1] = '1';
                }

                return NumberOfPendant(Garden);
            }

            return false;
        }


        static void Main(string[] args)
        {
            string[] temp = Input.ReadLine().Split(" "); // Размеры сада
            N = int.Parse(temp[0]);
            M = int.Parse(temp[1]);

            char[,] Garden = new char[N, M];
            char[,] GardenCopy = new char[N, M];
            for (int i = 0; i < N; i++)
            {
                temp = Input.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                    Garden[i, j] = char.Parse(temp[j]);
            }

            temp = Input.ReadLine().Split(" ");
            Garden[int.Parse(temp[0]) - 1, int.Parse(temp[1]) - 1] = 'K'; // Координаты королевы
            L = int.Parse(temp[2]);
            int count = 0;

            for (int i = 0; i < 4; i++)
            {
                Array.Copy(Garden, GardenCopy, Garden.Length);
                while (queue.Count != 0)
                    queue.Dequeue();

                temp = Input.ReadLine().Split(" ");
                queue.Enqueue(int.Parse(temp[0]) - 1);
                queue.Enqueue(int.Parse(temp[1]) - 1);
                queue.Enqueue(0); // Время
                int podveska = int.Parse(temp[2]);
                if (NumberOfPendant(GardenCopy))
                    count += podveska;
            }

            Output.WriteLine($"{count}");
            Output.Close();

            Console.ReadKey();
        }
    }
}
