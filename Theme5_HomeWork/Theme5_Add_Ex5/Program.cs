using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// *Задание 5
// Вычислить, используя рекурсию, функцию Аккермана:
// A(2, 5), A(1, 2)
// A(n, m) = m + 1, если n = 0,
//         = A(n - 1, 1), если n <> 0, m = 0,
//         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
// 
// Весь код должен быть откоммментирован

namespace Theme5_Add_Ex5
{
    internal class Program
    {
        /// <summary>
        ///  Метод, вычисляющий функцию Аккермана с помощью рекурсии
        ///  На вход получает параметры функции n и m
        ///  На выходе целое число-решение функции
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns>res=целое число-решение функции</returns>
        static int GetAkkermanFunction(int n, int m)
        {
            int res = 0; // переменная для сохранения результата
            // A(n, m) = m + 1, если n = 0,
            //         = A(n - 1, 1), если n <> 0, m = 0,
            //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
            if (n == 0) res = m + 1; // если n = 0, то решение функции = m+1
            else if (n != 0 && m == 0) res = GetAkkermanFunction(n - 1, 1); // иначе если при n не равном 0 и m равном 0, рекурсивно вызываем метод с параметрами n = n-1 (уменьшая n на 1 при каждом вызове метода) и m = 1
            else if (n > 0 && m > 0) res = GetAkkermanFunction(n - 1, GetAkkermanFunction(n, m - 1));// иначе если при n > 0 и m > 0, рекурсивно вызываем метод уменьшая n на 1 и рекурсивно вызываем метод уменьшая m на 1
            // Таким образом рано или поздно уменьшая параметры функции каждый раз при рекурсивном вызове мы придем к первому условию, т.е. получим решение функции
            
            return res;// возвращаем результат
        }
        /// <summary>
        /// Главный метод программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление функции Аккермана");

            int result = GetAkkermanFunction(2, 5); // Вызываем метод решения функции с параметрами 2, 5
            Console.WriteLine($"A(2, 5) = {result}"); // Выводим результат вычисления на экран

            result = GetAkkermanFunction(1, 2); // Вызываем метод решения функции с параметрами 1, 2
            Console.WriteLine($"A(1, 2) = {result}"); // Выводим результат вычисления на экран

            Console.ReadKey(); // Задержка закрытия окна консоли до нажатия любой клавиши
        }
        
    }
}
