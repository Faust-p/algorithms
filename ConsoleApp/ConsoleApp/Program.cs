using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace ConsoleApp
{
  public static class Program
  {
    public static void Main()

    {
      HashSet<int> listsLengths = new HashSet<int> { 10000000, 20000000, 50000000, 100000000 };
      double workTime = 0;
      int[] numbersArray;
      Generator generator;

      foreach (int length in listsLengths)
      {
        generator = new Generator(length);

        numbersArray = generator.Worst(); // Худший случай
        workTime = Stopwatch(numbersArray);
        Console.WriteLine("Элементов: {0}", length);
        Console.WriteLine("Худший случай - время: {0}", workTime);


        numbersArray = generator.Average(); // Средний случай
        workTime = Stopwatch(numbersArray);
        Console.WriteLine("Средний случай - время: {0}", workTime);


        numbersArray = generator.Best(); // Лучший случай
        workTime = Stopwatch(numbersArray);
        Console.WriteLine("Лучший случай - время: {0}\n", workTime);
      }
      Console.ReadKey();
    }


    //Проверка на возрастание
    private static bool AscendingTest(int[] numbersArray)
    {
      for (int i = 1; i < numbersArray.Length - 1; i++)
      {
        if (numbersArray[i] > numbersArray[i + 1])
        {
          return false;
        }     
      }
      return true;
    }


    // Секундомер
    private static double Stopwatch(int[] numbersArray)
    {
      Stopwatch stopwatch = new Stopwatch(); // Секундомер
      double workTime = 0;
      AscendingTest(numbersArray);
      workTime = 0; // Секундомер
      stopwatch.Reset();
      stopwatch.Start();
      AscendingTest(numbersArray);
      stopwatch.Stop();
      workTime = workTime + stopwatch.ElapsedMilliseconds;
      return workTime;
    }    
  }
}
