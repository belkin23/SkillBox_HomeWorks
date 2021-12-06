using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Студент Афонин Сергей

//Задание 1. Создание переменных и вывод 
//Что нужно сделать
//Объявите несколько переменных, которые будут хранить следующие значения:

//Ф. И. О.
//Возраст
//Email
//Баллы по программированию
//Баллы по математике
//Баллы по физике

//Каждая переменная должна иметь:

//название, что-либо обозначающее на английском языке;
//тип данных, который наилучшим образом подходит для этой переменной. Например, для Ф.И.О. можно указать наименование 
//переменной FullName. 
// Дальше выведите всю информацию на экран. Организуйте форматированный вывод данных на экран. 

//Для решения этой задачи объявите переменные для данных, указанных выше, как это было показано в уроке 2.2. 


namespace Lesson2_exercise1
{
    internal class Program
    {
        /// <summary>
        /// Создание переменных и вывод 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string FullName = "Иванов Иван Иванович";   //Ф. И. О.
            int Age = 23;                               //Возраст
            string Email = "ivanov@mail.net";           //Email
            double ProgrammingRate = 99.5;                 //Баллы по программированию
            double MathRate = 67.9;                        //Баллы по математике
            double PhysicsRate = 85.1;                     //Баллы по физике

            // Форматированный вывод данных на экран
            string pattern = "Ф.И.О.: {0} \nВозраст: {1} \nEmail: {2} \nБаллы по программированию: {3} \nБаллы по математике: {4}  \nБаллы по физике: {5}";
            Console.WriteLine(pattern,
                              FullName,
                              Age,
                              Email,
                              ProgrammingRate,
                              MathRate,
                              PhysicsRate);
            Console.ReadKey();
        }
    }
}
