using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Урок 1, задание 2
// Студент Афонин Сергей
// Цель домашнего задания:
// Научиться различать операторы Write и WriteLine.
namespace HelloWorldConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello "); // выводим каждое слово отдельно 
            Console.Write("World");
            Console.Write("!!!");
            while (Console.ReadKey().Key != ConsoleKey.Enter) 
            { } // Пока не будет нажата Enter, окно консоли не закроется
        }
    }
}
