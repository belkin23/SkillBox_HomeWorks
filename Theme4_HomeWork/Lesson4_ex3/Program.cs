using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_ex3
{
    internal class Program
    {
        /// <summary>
        /// Задание 3. Игра «Угадай число» 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Это игра Угадай число");
            Console.WriteLine("Введите максимальное целое число диапазона"); 
            int maxNum = int.Parse(Console.ReadLine()); // Запоминаем введёное пользователем число
            Random random = new Random();  // Инициализируем переменную для генерации случайных чисел
            int secretNum = random.Next(0, maxNum+1); // Генерируем случайное угадываемое число
            
            while(1==1) // Пока пользовательне угадает или не устанет спрашиваем число
            {
                Console.WriteLine("Введите угадываемое число:");
                var inputKey = Console.ReadLine();
                if (inputKey == "")
                {
                    Console.WriteLine($"Загаданное число = {secretNum}");
                    break;
                }
                else if (int.Parse(inputKey) > secretNum)
                {
                    Console.WriteLine("Загаданное число меньше!");
                }
                else if (int.Parse(inputKey) < secretNum)
                {
                    Console.WriteLine("Загаданное число больше!");
                }
                else if (int.Parse(inputKey) == secretNum)
                {
                    Console.WriteLine("Вы угадали!");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
