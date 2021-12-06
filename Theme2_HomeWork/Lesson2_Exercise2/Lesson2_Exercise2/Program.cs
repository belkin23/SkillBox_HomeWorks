using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Студент Афонин Сергей
//Задание 2.Реализация подсчёта количества баллов по всем предметам

namespace Lesson2_Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FullName = "Иванов Иван Иванович";       //Ф. И. О.
            int Age = 23;                                   //Возраст
            string Email = "ivanov@mail.net";               //Email
            double ProgrammingRate = 99.5;                  //Баллы по программированию
            double MathRate = 67.9;                         //Баллы по математике
            double PhysicsRate = 85.1;                      //Баллы по физике
            double MiddleRate = (ProgrammingRate + MathRate + PhysicsRate) / 3; //Расчёт среднего балла

            // Форматированный вывод данных на экран
            string pattern = "Ф.И.О.: {0} \nВозраст: {1} \nEmail: {2} \nБаллы по программированию: {3} \nБаллы по математике: {4}  \nБаллы по физике: {5}";
            Console.WriteLine(pattern,
                              FullName,
                              Age,
                              Email,
                              ProgrammingRate,
                              MathRate,
                              PhysicsRate);
            Console.WriteLine("\nДля вывода среднего балла нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine($"\nСредний балл составляет: {MiddleRate}");
            Console.ReadKey();
        }
    }
}
