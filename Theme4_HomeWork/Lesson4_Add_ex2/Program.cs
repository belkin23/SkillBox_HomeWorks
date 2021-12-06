using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Add_ex2
{
    // * Задание 2
    // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
    // 
    // При N = 9. Треугольник выглядит следующим образом:
    //                                 1
    //                             1       1
    //                         1       2       1
    //                     1       3       3       1
    //                 1       4       6       4       1
    //             1       5      10      10       5       1
    //         1       6      15      20      15       6       1
    //     1       7      21      35      35       21      7       1
    //                                                              
    //                                                              
    // Простое решение:                                                             
    // 1
    // 1       1
    // 1       2       1
    // 1       3       3       1
    // 1       4       6       4       1
    // 1       5      10      10       5       1
    // 1       6      15      20      15       6       1
    // 1       7      21      35      35       21      7       1
    // 
    // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля
    internal class Program
    {
        /// <summary>
        /// приложение строящее первых N строк треугольника паскаля. N < 25
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.Clear();
                Console.WriteLine("Введите количество строк треугольника Паскаля (максимум 25): ");
                int row = int.Parse(Console.ReadLine());
                if (row > 25) { row = 25; } // ограничиваем 25 строками

                int[] triangle = new int[row]; // Объявляем одномерный массив для хранения цифр в треугольнике паскаля
                triangle[0] = 1; // Инициализируем первый элемент массива
                string str = ""; // Переменная для составления строки
                int paddingWeight = 0; // Переменная для расчёта отступа слева

                for (int i = 0; i < row; i++) // Цикл по количеству строк
                { 
                    int pad = 0; // Для расчёта смещения 
                    int count = 0; // Для расчёта отступа
                    for (int j = 0; j <= i; j++) // Расчитываем содержимое каждой строки
                    {
                        int tmp = triangle[j]; 
                        triangle[j] = triangle[j] + pad; // Расчитываем каждую следующую цифру складывая ее с предыдущей
                        pad = tmp;

                        str = str + Convert.ToString(triangle[j]); // Формируем строку для вывода
                        count = count + Convert.ToString(triangle[j]).Length; // Считаем отступ
                        if (triangle[j] < 10) { str = str + " "; count++;} // Добавляем пробелы после цифр в зависимости от их разряда
                        if (triangle[j] < 100) { str = str + " "; count++; }
                        if (triangle[j] < 1000) { str = str + " "; count++; }
                        if (triangle[j] < 10000) { str = str + " "; count++; }
                        if (triangle[j] < 100000) { str = str + " "; count++; }
                        if (triangle[j] < 1000000) { str = str + " "; count++; }
                        if (triangle[j] < 10000000) { str = str + " "; count++; }
                    }

                    paddingWeight = (row * 4) - (count / 2); // Высчитываем положение курсора в зависимости от количества заданных строк треугольнтка и длины строки
                    Console.SetCursorPosition(paddingWeight, i + 2); // Смещаем начальное положение курсора от левого края и от верхнего
                    Console.Write($"{str}"); // Выводим строку треугольника

                    Console.WriteLine(); // Переходим на следующую строку
                    str = "";            // Обнуляем содержимое строки         
                    count = 0;           // Обнуляем отступ
                }
                Console.WriteLine("\nНажмите [1] - Построить ещё треугольник? [любая другая кнопка] - Выход ");
                if (Console.ReadKey().Key != ConsoleKey.D1) break;
            }
        }
    }
}
