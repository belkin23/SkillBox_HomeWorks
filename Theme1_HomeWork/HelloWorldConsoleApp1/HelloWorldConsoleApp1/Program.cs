using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Урок 1, задание 1
// Студент Афонин Сергей
// Цель домашнего задания:
// Создать своё первое приложение для платформы .NET. 
// Создать простое консольное приложение, которое будет выводить текст на экран

namespace HelloWorldConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!"); // Выводим текст в консоль
            Console.ReadKey(); // Задержка закрытия окна консоли до нажатия любой клавиши
        }
    }
}
