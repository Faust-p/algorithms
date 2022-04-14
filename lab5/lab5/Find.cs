using System;

namespace lab5
{
    public static class Finder
    {
        public static int Linear(int[] array, int numberFind)
        {
            int i = 0;
            while (i < array.Length - 1 && array[i] != numberFind)
            {
                i++;
            }
            if (array[i] == numberFind)
            {
                return i;
            }
            return -1;
        }
        public static int WithBarrier(int[] array, int numberFind)
        {
            int i = 0;
            while (array[i] != numberFind)
            {
                i++;
            }
            if (i == array.Length - 1)
            {
                return -1;
            }
            return i;
        }

        public static int Binary(int[] array, int numberFind)
        {
            int Start = 0;
            int End = array.Length - 1;
            int res = -1;

            while (Start <= End)
            {
                int middle = (End + Start) / 2;

                if (numberFind <= array[middle])
                {
                    if (numberFind == array[middle])
                    {
                        res = middle;
                    }

                    End = middle - 1;
                }
                else
                {
                    Start = middle + 1;
                }
            }
            return res;
        }

        public static int Jump(int[] array, int numberFind)
        {
            int Start = 0;
            int step = Convert.ToInt32(Math.Sqrt(array.Length));
            int End = step;
            while (End < array.Length)
            {
                if (numberFind < array[End])
                {
                    for (int i = Start; i < End; i++)
                    {
                        if (numberFind == array[i])
                        {
                            return i;
                        }
                    }

                    return -1;
                }

                Start += step;
                End += step;
            }
            for (int i = Start; i < array.Length; i++)
            {
                if (numberFind == array[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}