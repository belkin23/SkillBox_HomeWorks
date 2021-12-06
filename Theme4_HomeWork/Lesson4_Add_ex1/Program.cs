using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_Add_ex1
{
    // Задание 1.
    // Заказчик просит вас написать приложение по учёту финансов
    // и продемонстрировать его работу.
    // Суть задачи в следующем: 
    // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
    // За год получены два массива – расходов и поступлений.
    // Определить прибыли по месяцам
    // Количество месяцев с положительной прибылью.
    // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
    // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
    // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

    // Пример
    //       
    // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
    //     1              100 000             80 000                 20 000
    //     2              120 000             90 000                 30 000
    //     3               80 000             70 000                 10 000
    //     4               70 000             70 000                      0
    //     5              100 000             80 000                 20 000
    //     6              200 000            120 000                 80 000
    //     7              130 000            140 000                -10 000
    //     8              150 000             65 000                 85 000
    //     9              190 000             90 000                100 000
    //    10              110 000             70 000                 40 000
    //    11              150 000            120 000                 30 000
    //    12              100 000             80 000                 20 000
    // 
    // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
    // Месяцев с положительной прибылью: 10
    internal class Program
    {
        /// <summary>
        /// приложение по учёту финансов
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] income = new int[12];   // Массив хранящий доходы
            int[] expenses = new int[12]; // Массив хранящий расходы
            //int [,] profit = new int[2,12];   // Массив хранящий худшие месяцы вместе с их номерами по прибыли
            int[] profit = new int[12];   // Массив хранящий худшие месяцяцы по прибыли
            int[] month = new int[12];    // Массив для хранения месяцев

            Random random = new Random(); // Инициализируем переменную для генерации случайных чисел

            while (1 == 1)
            {
                Console.Clear();
                bool rnd = false;             // Признак заполнения случайными числами
                int countProfitMonth = 0;     // Количество прибыльных месяцев

                Console.WriteLine("Учёт финансов");
                Console.WriteLine("Ввести данные вручную, нажмите [1]. Ввести данные случайными числами для демонстрации, нажмите [2]");
                if (Console.ReadKey().Key == ConsoleKey.D2) rnd = true;
                if (Console.ReadKey().Key == ConsoleKey.D1) rnd = false;

                for (int i = 0; i < income.Length; i++) // Перебираем массивы по элементам
                {
                    if (rnd == true) // Если пользователь нажал 2, заполняем массивы случайными числами
                    {
                        income[i] = random.Next(0, 3);
                        expenses[i] = random.Next(0, 3);
                    }
                    else if (rnd == false) // иначе заполняем массив введёнными пользователем данными
                    {
                        Console.WriteLine($"\nВведите доходы за {i + 1} месяц: ");
                        income[i] = int.Parse(Console.ReadLine());
                        Console.WriteLine($"\nВведите расходы за {i + 1} месяц: ");
                        expenses[i] = int.Parse(Console.ReadLine());
                    }
                    profit[i] = income[i] - expenses[i]; // Расчитываем прибыль
                    if (profit[i] > 0) countProfitMonth++; // Расчитываем количество прибыльных месяцев
                    month[i] = i;         // Сохраняем номер месяца в массив  
                }

                Console.WriteLine("\n\nМесяц      Доход, тыс. руб.    Расход, тыс. руб.   Прибыль, тыс. руб.");

                for (int i = 0; i < income.Length; i++)
                {
                    Console.Write($"{i + 1,5} {income[i],20} {expenses[i],20} {profit[i],20}\n"); // Выводим массивы на экран по ячейкам с выравниванием
                }
                Console.WriteLine($"\nКоличество месяцев с прибылью за год: {countProfitMonth}");

                //// сортировка массива "пузырьком"
                //int t1, t2; // Временные переменные для сортировки
                //for (int i = 0; i < income.Length - 1; i++)
                //{
                //    for (int j = i + 1; j < income.Length; j++)
                //    {
                //if (profit[1, i] > profit[1, j]) // сортируем массив с прибылью вместе с номером месяца
                //{
                //    t1 = profit[0, i];
                //    t2 = profit[1, i];
                //    profit[0, i] = profit[0, j]; 
                //    profit[1, i] = profit[1, j];
                //    profit[0, j] = t1;
                //    profit[1, j] = t2;
                //}

                //    }
                //}

                Array.Sort(profit, month); // Сортируем массив прибыли вместе с массивом месяцев

                Console.Write($"\nТри (или больше если равны) месяца с худшей прибылью за год: ");
                int count = 0;

                for (int i = 0; i < profit.Length - 1; i++)
                {
                    if (profit[i] == profit[i + 1])
                    {
                        Console.Write($"{month[i] + 1}, ");
                        if (i == 10)  // Если 11 месяц равен 12, то выводим и 12
                        {
                            Console.Write($"{month[i + 1] + 1}. ");
                        }
                    }
                    else if (profit[i] < profit[i + 1])
                    {

                        Console.Write($"{month[i] + 1}, ");
                        if (i == 10) // Если 11 месяц меньше 12, то выводим и 12 и count < 3
                        {
                            Console.Write($"{month[i + 1] + 1}. ");
                        }
                        count++;
                        if (count >= 3) break;
                    }
                }                    
        
                Console.WriteLine("\n\nНажмите [1] - Посчитать прибыль еще раз? [любая другая кнопка] - Выход\n");
                if (Console.ReadKey().Key != ConsoleKey.D1) break;
            }
            
        }
    }
}
