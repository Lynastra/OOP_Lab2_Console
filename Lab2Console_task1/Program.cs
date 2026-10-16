using System;

namespace Lab2Console
{
    internal class Program
    {
        static void Print(int[] a)
        {
            foreach (int x in a)
                Console.Write($"{x} ");
            Console.WriteLine();
        }

        static int[] InputArray()
        {
            int[] MyArray;

            try
            {
                Console.Write("Введите размерность массива: ");
                int n = int.Parse(Console.ReadLine()!);
                MyArray = new int[n];

                for (int i = 0; i < MyArray.Length; i++)
                {
                    Console.Write($"a[{i}] = ");
                    MyArray[i] = int.Parse(Console.ReadLine()!);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных.");
                return Array.Empty<int>();   // возвращаем пустой массив, чтобы Main не упал
            }
            catch (OverflowException)
            {
                Console.WriteLine("Переполнение.");
                return Array.Empty<int>();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти для создания нового объекта.");
                return Array.Empty<int>();
            }

            Console.WriteLine("Исходный массив:");
            Print(MyArray);

            Array.Sort(MyArray);
            Console.WriteLine("Массив отсортирован по возрастанию:");
            Print(MyArray);

            Array.Reverse(MyArray);
            Console.WriteLine("Массив отсортирован по убыванию:");
            Print(MyArray);

            // Возвращаем то, что осталось после Reverse — то есть по убыванию
            return MyArray;
        }

        static int RandomInt(int min, int max) => Random.Shared.Next(min, max);

        static int[] RandomArray(int size, int min, int max)
        {
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
                result[i] = RandomInt(min, max);
            return result;
        }

        static void Change(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] > 0) a[i] *= 2;
        }

        static void Main()
        {
            Console.WriteLine("=== Ввод массива с клавиатуры ===");
            int[] userArray = InputArray();

            Console.WriteLine();
            Console.WriteLine("=== Случайный массив + Change ===");
            int[] myArray = RandomArray(10, -50, 51);
            Console.WriteLine("Исходный массив:");
            Print(myArray);

            Change(myArray);
            Console.WriteLine("После удвоения положительных:");
            Print(myArray);
        }
    }
}