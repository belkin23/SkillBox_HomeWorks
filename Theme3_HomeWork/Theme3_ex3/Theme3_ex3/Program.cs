using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Студент Афонин Сергей
namespace Theme3_ex3
{
    internal class Program
    {
        /// <summary>
        /// Проверка простого числа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверки простого числа.");
            start: // Метка возврата от goto
            bool flag = false;  // Флаг простого числа
            int num = 0; // Цифра введённая пользователем
            Console.WriteLine("\nВведите целое число...");
            num = int.Parse(Console.ReadLine());           
            
            if (num == 1) // Число 1 это частный случай.. обработаем его отдельно
            {
                Console.WriteLine("В настоящее время в математике принято не относить единицу ни к простым, ни к составным числам, \nтак как это нарушает важную для теории чисел единственность разложения на простые множители.\n");
                goto start; // И вернёмся на запрос числа
            }
            int count = 1; // По условию задачи счётчик начинается с 1
            while (count < num-1) // Пока счётчик меньше заданного числа минус один
            {
                count++; // Если делить любое число на 1 получиться деление без остатка и это число ошибочно назовётся простым, по этому на первой итерации делить будем на 2
                if (num % count == 0) // Если число делиться на номер итерации без остатка, то оно простое
                {
                    flag = true; // Устанавливаем флаг простого числа
                    break;      // Останавливаем цикл (выходим из него)
                }              
            }
            if(flag == true) // Обрабатываем флаг и выводим на экран информацию о заданном числе
            {
                Console.WriteLine("Не простое");
                flag = false;
            }
            else
            {
                Console.WriteLine("Простое");
            }
            goto start; // Возвращаемся к запросу числа
        }
    }
}
