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
        static bool WriteToFile(string fileName)
        {
            if (File.Exists(fileName)) // Определяет, существует ли заданный файл.
            {
                int countLines = 0;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((sr.ReadLine()) != null) // Пока в потоке есть данные, считываем построчно
                    {
                        countLines++; // Считаем строки в файле, чтобы присвоить ID следующей записи
                    }
                }
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    char key = 'д';
                    //ID
                    //Дату и время добавления записи
                    //Ф.И.О.
                    //Возраст
                    //Рост
                    //Дату рождения
                    //Место рождения

                    do
                    {
                        string note = string.Empty;

                        note += $"{countLines + 1}#"; // Добавляем в строку ID

                        string now = DateTime.Now.ToShortTimeString(); // Добавляем в строку текущее время
                        note += $"{now}#";

                        Console.Write("\nВведите фамилию имя и отчество сотрудника через пробел: ");
                        note += $"{Console.ReadLine()}#";

                        Console.Write("Введите возраст сотрудника: ");
                        note += $"{Console.ReadLine()}#";

                        Console.Write("Введите рост сотрудника: ");
                        note += $"{Console.ReadLine()}#";

                        Console.Write("Введите дату рождения сотрудника: ");
                        note += $"{Console.ReadLine()}#";

                        Console.Write("Введите место рождения сотрудника: ");
                        note += $"{Console.ReadLine()}#";

                        sw.WriteLine(note); // Добавляем сформированную строку в файл

                        Console.WriteLine($"Данные сотрудника добавлены в справочник.");
                        Console.Write("Продожить н/д"); key = Console.ReadKey(true).KeyChar;
                        countLines++;

                    } while (char.ToLower(key) == 'д');
                }
                return true; // Данные внесены в файл
            }
            else
            {
                return false; // Файла не существует
            }
        }
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
                                bool writed;
                                if (writed = WriteToFile(fileName))
                                {
                                    Console.WriteLine("Изменения сохранены в файл...");
                                    break;
                                }
                                else
                                {
                                    File.Create(fileName).Close();
                                    Console.WriteLine($"Программа не нашла файл {fileName}... Теперь он создан, нажмите любую кнопку...");
                                    Console.ReadKey();
                                    break;
                                }
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
