using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme4_ex2
{
    internal class Program
    {
        /// <summary>
        /// Задание 2. Наименьший элемент в последовательности
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину последовательности:");
            int numElements = int.Parse(Console.ReadLine()); // Запоминаем длину последовательности

            int[] sequence = new int [numElements]; // Создаём одномерный массив для сохранения последовательности

            int minNum = int.MaxValue; // Минимальное число последовательности

            for (int i = 0; i < numElements; i++)
            {
                Console.WriteLine("\nВведите элемент последовательности и нажмите Enter:");
                sequence[i] = int.Parse(Console.ReadLine()); // Заполняем массив с экрана
            }

            for (int i = 0; i < numElements; i++) // Перебираем все элементы массива
            {
                if(minNum > sequence[i]) minNum = sequence[i]; // Ищем минимальное число в массиве
            }

            Console.WriteLine($"\nМинимальное число последовательности = {minNum}"); // Выводим минимальное число последовательности
            Console.ReadKey();
        }
    }
}
