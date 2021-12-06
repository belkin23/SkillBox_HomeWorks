using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme1
{
    internal class Program
    {        /// <summary>
             /// Записная книжка
             /// </summary>
             /// <param name="args">Главная функция</param>
        static void Main(string[] args)
        {
            // Заказчик просит написать программу «Записная книжка». Оплата фиксированная - $ 120.

            // В данной программе, должна быть возможность изменения значений нескольких переменных для того,
            // чтобы персонифецировать вывод данных, под конкретного пользователя.

            // Для этого нужно: 
            // 1. Создать несколько переменных разных типов, в которых могут храниться данные
            //    - имя;
            //    - возраст;
            //    - рост;
            //    - баллы по трем предметам: история, математика, русский язык;

            // 2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, 
            //    указанным в пункте 1.

            // 3. Реализовать возможность печатки информации на консоли при помощи 
            //    - обычного вывода;
            //    - форматированного вывода;
            //    - использования интерполяции строк;

            // 4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

            // **
            // 5. В качестве бонусной части, за дополнительную оплату $50, заказчик просит реализовать 
            //    возможность вывода данных в центре консоли.

            string Name = "";           //Переменная для хранения имени
            int Age = 0;                //Переменная для хранения возраста
            double Height = 0;          //Переменная для хранения роста
            double HistoryRange = 0;    //Переменная для хранения балла по истории
            double MathRange = 0;       //Переменная для хранения балла по математике
            double RussianRate = 0;     //Переменная для хранения балла по Русскому языку
            double AverageRange = 0;    //Переменная для хранения среднего балла

            Console.WriteLine("Записная книжка"); 
            Start:                                  //Метка возврата для функции goto
            try                                     //Для обработки ошибок ввода, обработаем исключение 
            {
                // Инициализируем переменные, данными введёнными пользователем с экрана
                Console.WriteLine("\nВведите имя:");
                Name = Console.ReadLine();          
                
                Console.WriteLine("\nВведите возраст:");
                Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nВведите рост:");
                Height = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nВведите баллы по истории:");
                HistoryRange = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nВведите баллы по математике:");
                MathRange = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nВведите баллы по Русскому языку:");
                RussianRate = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex) // Обрабатываем исключение, если ввод не верный
            {
                Console.WriteLine(ex.Message + "\nВозможно вы ввели букву вместо цифры...");
                goto Start; // Возвращаемся по метке, снова просим пользователя ввести информацию
            }

            // Расчитем средний балл (среднее арифметическое)
            AverageRange = (HistoryRange + MathRange + RussianRate) / 3;

            int key;                // Объявляем переменную для текущей нажатой кнопки меню
            string messageOutput;   // Объявляем переменную для строки, которая будет выведена на экран, что бы определить его длину
            int paddingWeight;      // Объявляем переменную для расчёта отступа слева, при выводе текста по центру

            do
            {
                // Выводим меню на экран, что бы понять каким способом вывести информацию
                Console.Clear();
                Console.WriteLine("\nВыберите способ вывода информации...");
                Console.WriteLine("\nНажмите[1], затем Enter - для вывода обычным способом");
                Console.WriteLine("\nНажмите[2], затем Enter - для вывода форматированным способом");
                Console.WriteLine("\nНажмите[3], затем Enter - для вывода интерполяцией строк");
                Console.WriteLine("\nНажмите[Esc] - для выхода");

                try
                {
                    key = int.Parse(Console.ReadLine()); // Запоминаем нажатую крнопку согласно меню

                    // Спрашиваем пользователя как выровнять текст
                    Console.WriteLine("\nВыберите способ вывода информации...");
                    Console.WriteLine("\nНажмите[1], затем Enter - для выравнивания слева");
                    Console.WriteLine("\nНажмите[2], затем Enter - для выравнивания по центру");
                    int keypadding = int.Parse(Console.ReadLine()); // Запоминаем какой вариант выбрал пользователь

                    // Инициализируем переменную строки вывода 
                    messageOutput = "1 - Имя: " + Name + ". Возраст: " + Age + ". Рост: " + Height + ". Средний балл: " + AverageRange;
                    // Расчитываем отступ слева для вывода по центру 
                    paddingWeight = Console.WindowWidth / 2 - messageOutput.Length / 2;
                    Console.Clear();
                    switch (key)
                    {                        
                        case 1:                    // Пользователь выбрал "Вывод обычным способом"
                            if (keypadding == 2)
                            {
                                Console.SetCursorPosition(paddingWeight, 0); // Если пользватель выбрал "По центру.."
                                //задаём начальное положение курсора со смещением слева
                            }  
                            // Если пользователь выбрал "По левому краю", то курсор по умолчанию
                            Console.WriteLine(messageOutput);  // Выводим информацию обычным способом
                            break; // Выходим из цикла
                        case 2:   // Пользователь выбрал "Вывод форматированным способом"
                            string pattern = "2 - Имя: {0} Возраст: {1} Рост: {2} Средний балл: {3}";
                            if (keypadding == 2)
                            {
                                Console.SetCursorPosition(paddingWeight, 0);
                            }
                            Console.WriteLine(pattern,
                                              Name,
                                              Age,
                                              Height,
                                              AverageRange);
                            break;
                        case 3:     // Пользователь выбрал "Вывод интерполяцией строк"
                            if (keypadding == 2)
                            {
                                Console.SetCursorPosition(paddingWeight, 0);
                            }
                            Console.WriteLine($"3 - Имя: {Name} Возраст: {Age} Рост: {Height} Средний балл: {AverageRange}");
                            break;
                    }
                }
                catch (Exception) // Обрабатываем исключение, если нажата не верная кнопка
                { 
                    Console.WriteLine("Введите цифру согласно меню и нажмите Enter..."); 
                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); // Выходим из приложения нажатием Escape
        }
    }
}
