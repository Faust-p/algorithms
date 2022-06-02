using System;
using System.Collections.Generic;
using System.Text;

namespace lab7
{
    public static class Sort
    {
        private static void Swap(int[] arr, int i, int j)
        {
            int swap = arr[i];
            arr[i] = arr[j];
            arr[j] = swap;
        }

        // Быстрая сортировка
        public static int[] Quick(int[] arr)
        {
            return Quick(arr, 0, arr.Length - 1);
        }

        private static int[] Quick(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return arr;
            }
            int index = ReturnIndex(arr, minIndex, maxIndex);
            Quick(arr, minIndex, index - 1);
            Quick(arr, index + 1, maxIndex);
            return arr;
        }

        private static int ReturnIndex(int[] arr, int minIndex, int maxIndex)
        {
            int marker = minIndex, index = minIndex;
            while (index <= maxIndex)
            {
                if (arr[index] <= arr[maxIndex])
                {
                    Swap(arr, marker, index);
                    marker++;
                }
                index++;
            }
            return marker - 1;
        }

        // Сортировка слиянием
        public static int[] Merge(int[] arr)
        {
            return Merge(arr, 0, arr.Length - 1);
        }
        private static int[] Merge(int[] arr, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int midIndex = (lowIndex + highIndex) / 2;
                Merge(arr, lowIndex, midIndex);
                Merge(arr, midIndex + 1, highIndex);
                if (arr[midIndex] > arr[midIndex + 1])
                {
                    Copy(arr, lowIndex, midIndex, highIndex);
                }
            }
            return arr;
        }
        private static void Copy(int[] arr, int lowIndex, int midIndex, int highIndex)
        {
            int indexLeft = lowIndex, indexRight = midIndex + 1, k = 0;
            int[] tempArr = new int[highIndex - lowIndex + 1];
            while ((indexLeft <= midIndex) && (indexRight <= highIndex))
            {
                if (arr[indexLeft] < arr[indexRight])
                {
                    tempArr[k++] = arr[indexLeft++];
                }
                else
                {
                    tempArr[k++] = arr[indexRight++];
                }
            }
            while (indexRight <= highIndex)
            {
                tempArr[k++] = arr[indexRight++];
            }
            while (indexLeft <= midIndex)
            {
                tempArr[k++] = arr[indexLeft++];
            }
            for (indexLeft = lowIndex, k = 0; indexLeft <= highIndex; indexLeft++, k++)
            {
                arr[indexLeft] = tempArr[k];
            }             
        }

        // Пирамидальная сортировка
        public static int[] Heap(int[] arr)
        {
            return Heap(arr, arr.Length);
        }
        private static int[] Heap(int[] arr, int lenght)
        {
            lenght = arr.Length - 1;
            int index = lenght / 2;
            while (index >= 0)
            {
                Heapify(arr, lenght, index);
                index--;
            }
            index = lenght;
            while (index >= 0)
            {
                Swap(arr, 0, index);
                Heapify(arr, index, 0);
                index--;
            }
            return arr;
        }
        private static void Heapify(int[] arr, int lenght, int index)
        {
            int largest = index,
            minIndex = 2 * index + 1,
            maxIndex = 2 * index + 2;
            if (minIndex < lenght)
            {
                if (arr[minIndex] > arr[maxIndex])
                {
                    largest = minIndex;
                }
                else
                {
                    largest = maxIndex;
                }
            }
            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, lenght, largest);
            }
        }
    }
}
