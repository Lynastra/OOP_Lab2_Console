using System;

namespace Lab2Console_task3
{
    internal class Program
    {
        // Печать одномерного массива
        static void Print(string title, int[] a)
        {
            Console.Write(title + " ");
            foreach (int x in a)
                Console.Write($"{x} ");
            Console.WriteLine();
        }

        // Печать ступенчатого массива
        static void PrintArray(string title, int[][] mas)
        {
            Console.WriteLine(title);
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write($"{mas[i][j],4} ");
                }
                Console.WriteLine();
            }
        }

        // Создание квадратного ступенчатого массива n * n со случайными числами
        static int[][] MakeRandomMatrix(int n, int min, int max)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = Random.Shared.Next(min, max);
                }
            }
            return result;
        }

        // Сумма чётных положительных элементов по столбцам
        static int[] SumEvenPositiveByColumns(int[][] mas)
        {
            int n = mas.Length;
            int[] result = new int[n];

            for (int j = 0; j < n; j++) // внешний цикл - по столбцам
            {
                int sum = 0;
                for (int i = 0; i < n; i++) // внутренний - по строкам
                {
                    int x = mas[i][j];
                    if (x > 0 && x % 2 == 0)
                    {
                        sum += x;
                    }
                }
                result[j] = sum;
            }
            return result;
        }

        static void Main()
        {
            try
            {
                Console.Write("Введите размер n: ");
                int n = int.Parse(Console.ReadLine()!);

                int[][] matrix = MakeRandomMatrix(n, -50, 51);

                PrintArray("Исходная матрица:", matrix);

                int[] sums = SumEvenPositiveByColumns(matrix);

                Print("Суммы по столбцам:", sums);
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
    }
}