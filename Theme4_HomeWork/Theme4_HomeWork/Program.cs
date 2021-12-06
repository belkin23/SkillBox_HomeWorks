using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme4_HomeWork
{
    internal class Program
    {
        /// <summary>
        /// Задание 1. Случайная матрица
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк матрицы:");
            int row = int.Parse(Console.ReadLine()); // Запоминаем количество строк матрицы
            Console.WriteLine("Введите количество столбцов матрицы:");
            int col = int.Parse(Console.ReadLine()); // Запоминаем количество столбцов матрицы
            Console.WriteLine(); // Выводим пустую строку

            int[,] matrix = new int[row, col]; // Задание двумерного массива - матрицы, заданного пользователем размера

            Random random = new Random();  // Инициализируем переменную для генерации случайных чисел

            int matrixSum = 0; // Обьявляем и инициализируем переменную для суммы элементов матрицы

            for (int i = 0; i < row; i++) // Перебираем строки матрицы
            {
                for (int j = 0; j < col; j++) // Перебираем столбцы матрицы
                {
                    matrix[i, j] = random.Next(10); // Заполняем матрицу случайными числами от 0 до 9
                    Console.Write($"{matrix[i, j]} "); // Выводим матрицу на экран по ячейкам
                    matrixSum = matrixSum + matrix[i, j]; // Считаем сумму элементов матрицы
                }
                Console.WriteLine(); // Выводим пустую строку после каждой строки матрицы
            }
            Console.WriteLine($"\nСумма всех элементов матрицы = {matrixSum}"); 
            Console.ReadKey();
        }
    }
}
