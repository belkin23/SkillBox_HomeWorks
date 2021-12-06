using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Студент Афонин Сергей
namespace Theme3_ex2
{
    internal class Program
    {
        /// <summary>
        /// Программа подсчёта суммы карт в игре «21»
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Зравствуйте! Я посчитаю ваши карты в BlackJack. \nСколько карт у вас на руках?"); // Приветсвуем пользователя и предлагаем ввести количество карт
            int NumberOfCards = int.Parse(Console.ReadLine()); // Запоминаем сколько карт у пользователя

            int sum = 0; // Объявляем переменную для подсчёта суммы карт

            for (int i = 0; i < NumberOfCards; i++) // Организуем ввод номиналов карт по количеству карт пользователя
            {                
                Console.WriteLine("Введите свою карту. 2 - 10 или J, Q, K, T ?" );
                string userCard = Console.ReadLine(); // Запоминаем номинал введённой карты
                switch (userCard)
                {  // Расчитываем сумму карт пользователя в зависимости от введённого номинала
                    case "2":
                        sum = sum + 2;
                        break;
                    case "3":
                        sum = sum + 3;
                        break;
                    case "4":
                        sum = sum + 4;
                        break;
                    case "5":
                        sum = sum + 5;
                        break;
                    case "6":
                        sum = sum + 6;
                        break;
                    case "7":
                        sum = sum + 7;
                        break;
                    case "8":
                        sum = sum + 8;
                        break;
                    case "9":
                        sum = sum + 9;
                        break;
                    case "10":
                        sum = sum + 10;
                        break;
                    case ("J"):
                        sum = sum + 10;
                        break;
                    case ("Q"):
                        sum = sum + 10;
                        break;
                    case ("K"):
                        sum = sum + 10;
                        break;
                    case ("T"):
                        sum = sum + 10;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверный номинал карты..."); // Если пользователь ввел неизвестный символ
                        i--; // не считаем эту попытку в цикле количества карт
                        break;
                }
            }
            Console.WriteLine($"Сумма выших карт равна {sum}"); // Выводим сумму очков карт
            Console.ReadKey(); // Выходим из приложения при нажатии любой клавиши
        }
    }
}
