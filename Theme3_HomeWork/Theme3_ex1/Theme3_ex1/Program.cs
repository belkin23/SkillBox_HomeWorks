using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Студент Афонин Сергей
namespace Theme3_ex1
{
    internal class Program
    {
        /// <summary>
        /// Программа определяет чётное число или нет
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое целое число..."); // Просим пользователя ввести число
            int userDigit = int.Parse(Console.ReadLine());     // Сохраняем число в переменную
            if (userDigit % 2 == 0)                            // Если число делиться без остатка, то
            {
                Console.WriteLine($"Число {userDigit} чётное"); // Число чётное, о чём и пишем на экране
            }
            else                                                // Иначе
            {
                Console.WriteLine($"Число {userDigit} не чётное");// Число не чётное, о чём и пишем на экране
            }
            Console.ReadKey();                                  // Ждём любую нажатую кнопку для выхода
        }
    }
}
