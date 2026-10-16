using System;
//using System.Collections.Generic;

namespace Lab2Console_task2
{
    
    internal class Program
    {
        static void PrintArray(string a, int[][] mas)
        {
            Console.WriteLine(a);
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++) 
                {
                    Console.Write($"{mas[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        static void MakeArray()
        {
            try
            {
                Console.Write("Введите количество строк: ");
                int n = int.Parse(Console.ReadLine()!);

                int[][] MyArray = new int[n][];

                // Внешний цикл: по строкам
                for (int i = 0; i < n; i++)
                {
                    // Длина строки i равна i * 2
                    MyArray[i] = new int[i * 2];

                    // Внутренний цикл: по элементам строки
                    for (int j = 0; j < MyArray[i].Length; j++)
                    {
                        MyArray[i][j] = i + j;
                    }
                }

                PrintArray("Исходный массив:", MyArray);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Переполнение.");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти для создания нового объекта.");
            }
        }

        static void Main()
        {
            MakeArray();
        }
    }
}
