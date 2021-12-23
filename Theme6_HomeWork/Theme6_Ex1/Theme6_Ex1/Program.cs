using System;
using System.IO;
using System.Text;

//справочник «Сотрудники»
namespace Theme6_Ex1
{
    internal class Program
    {
        /// <summary>
        /// Метод проверяет наличие файла и считывает данные в StringBuilder без разделителя
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>StringBuilder</returns>
        static StringBuilder OpenFile(string fileName)
        {
            if (File.Exists(fileName)) // Определяет, существует ли заданный файл.
            {
                // Если файл существует, читаем его
                using (StreamReader sr = new StreamReader(fileName)) // Создаем поток и читаем в него файл
                {
                    string line; // Одна строка файла
                    string[] data = new string[7]; // Содержимое строки файла без разделителей
                    StringBuilder sb1 = new StringBuilder(); // Обьект для хранения прочитанных строк из файла без разделителей

                    while ((line = sr.ReadLine()) != null) // Пока в потоке есть данные, считываем построчно
                    {
                        data = line.Split('#'); // Записываем данные между разделителями
                        sb1.AppendLine($"{data[0]} {data[1]} {data[2]} {data[3]} {data[4]} {data[5]} {data[6]}"); // Собираем строку
                    }
                    return sb1; // Возвращаем сформированные строки из файла без разделителей
                }
            }
            else
            {
                return null; // Если файла не существует, возвращаем null 
            }
        }
        /// <summary>
        /// Метод записывает данные из консоли в файл, если файл существует
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>StringBuilder</returns>
        static bool WriteToFile(string fileName, string note)
        {
            if (File.Exists(fileName)) // Определяет, существует ли заданный файл.
            {                
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(note); //записываем строку в файл
                }
                return true; // Данные внесены в файл
            }
            else
            {
                return false; // Файла не существует
            }
        }

        /// <summary>
        /// Метод, формирует строку для записи в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        static string CreateLine(string fileName, string[] line)
        {
            string note = null;
            int countLines = 0;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((sr.ReadLine()) != null) // Пока в потоке есть данные, считываем построчно
                {
                    countLines++; // Считаем строки в файле, чтобы присвоить ID следующей записи
                }
            }
            string now = DateTime.Now.ToShortTimeString(); // Добавляем в строку текущее время
            note = $"{countLines + 1}#{now}#{line[0]}#{line[1]}#{line[2]}#{line[3]}#{line[4]}"; // Подготавливаем строку
            return note;
        }
        /// <summary>
        /// Главный метод программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                int key = 0;
                string fileName = "Employees.txt";
                Console.Clear();
                Console.WriteLine("Cправочник «Сотрудники»");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("Нажмите «1» чтобы вывести данные на экран, \nНажмите «2» чтобы заполнить данные и добавить новую запись");
                if (int.TryParse(Console.ReadLine(), out key))
                {
                    switch (key)
                    {
                        case 1: // Выводим данные файла на экран
                            {
                                if (OpenFile(fileName) != null)
                                {
                                    StringBuilder sb = OpenFile(fileName);
                                    if (sb.Length == 0)
                                    {
                                        Console.WriteLine("Файл пуст. Нажмите любую кнопку...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    Console.WriteLine(sb);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    File.Create(fileName).Close();
                                    Console.WriteLine($"Программа не нашла файл {fileName}... Теперь он создан, нажмите любую кнопку...");
                                    Console.ReadKey();
                                    break;
                                }
                                break;
                            }

                        case 2: // Заполняем данные и пишем в файл
                            {
                                if (File.Exists(fileName)) // Определяет, существует ли заданный файл.
                                {
                                    //ID
                                    //Дату и время добавления записи
                                    //Ф.И.О.
                                    //Возраст
                                    //Рост
                                    //Дату рождения
                                    //Место рождения
                                    char keyD = 'д';
                                    
                                    do
                                    {
                                        string note = string.Empty;
                                        string[] line = new string[5];

                                        Console.Write("\nВведите фамилию имя и отчество сотрудника через пробел: ");
                                        line[0] = Console.ReadLine();

                                        Console.Write("Введите возраст сотрудника: ");
                                        line[1] = Console.ReadLine();

                                        Console.Write("Введите рост сотрудника: ");
                                        line[2] = Console.ReadLine();

                                        Console.Write("Введите дату рождения сотрудника: ");
                                        line[3] = Console.ReadLine();

                                        Console.Write("Введите место рождения сотрудника: ");
                                        line[4] = Console.ReadLine();

                                        note = CreateLine(fileName, line); // Вызываем метод подготовки строки

                                        if (WriteToFile(fileName, note)) // Вызываем метод записи строки о сотруднике в файл
                                        {
                                            Console.WriteLine($"Данные сотрудника добавлены в справочник.");
                                            Console.Write("Продожить н/д");
                                            keyD = Console.ReadKey(true).KeyChar;
                                            //break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Ошибка записи в файл... Нажмите любую кнопку...");
                                            Console.ReadKey();
                                            break;
                                        }

                                    } while (char.ToLower(keyD) == 'д');


                                }
                                else
                                {
                                    File.Create(fileName).Close();
                                    Console.WriteLine($"Программа не нашла файл {fileName}... Теперь он создан...");
                                    Console.ReadKey();
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine($"Вы ввели не верный символ. Введите '1' или '2'");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine($"Вы ввели не верный символ. Введите '1' или '2'. Для продолжения нажмите Enter...");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}
