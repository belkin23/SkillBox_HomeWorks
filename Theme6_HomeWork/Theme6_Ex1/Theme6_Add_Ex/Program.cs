using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Домашнее задание
///
/// Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации
/// своих навыков. 
/// 
/// Немного подумав они вспомнили, что не так давно на занятиях по математике
/// они проходили тему "свойства делимости целых чисел". На этом занятии преподаватель показывал
/// пример с использованием фактов делимости. 
/// Пример заключался в следующем: 
/// Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп
/// так, что если одно число делится на другое, то эти числа попадают в разные руппы. 
/// В результате этого разбиения получилось M групп, для N = 50, M = 6
/// 
/// N = 50
/// Группы получились такими: 
/// 
/// Группа 1: 1
/// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
/// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
/// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
/// Группа 5: 16 24 36 40
/// Группа 6: 32 48
/// 
/// M = 6
/// 
/// ===========
/// 
/// N = 10
/// Группы получились такими: 
/// 
/// Группа 1: 1
/// Группа 2: 2 7 9
/// Группа 3: 3 4 10
/// Группа 4: 5 6 8
/// 
/// M = 4
/// 
/// Участники хакатона решили эту задачу, добавив в неё следующие возможности:
/// 1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
///    для которого нужно подсчитать количество групп
///    Программа работает с числами N не превосходящими 1 000 000 000
///   
/// 2. В ней есть два режима работы:
///   2.1. Первый - в консоли показывается только количество групп, т е значение M
///   2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
///                 вариантов работы с файлами
///            
/// 3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
///    в секундах и миллисекундах
/// 
/// 4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
/// делает это.
/// 
/// Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
/// (добавление новых возможностей не возбраняется)
///
/// * При выполнении текущего задания, необходимо документировать код 
///   Как пометками, так и xml документацией
///   В обязательном порядке создать несколько собственных методов

namespace Theme6_Add_Ex
{
    internal class Program
    {
        /// <summary>
        /// Метод проверяет наличие файла и считывает данные в string
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>string</returns>
        static string OpenFile(string fileName)
        {
            if (File.Exists(fileName)) // Определяет, существует ли заданный файл.
            {
                // Если файл существует, читаем его
                using (StreamReader sr = new StreamReader(fileName)) // Создаем поток и читаем в него файл
                {
                    string number = sr.ReadLine();
                    
                    return number; // Возвращаем сформированные строки из файла без разделителей
                }
            }
            else
            {
                return null; // Если файла не существует, возвращаем null 
            }
        }

        /// <summary>
        ///  Метод расчитывает количество групп неделимых чисел числа N
        /// </summary>
        /// <param name="N"></param>
        /// <returns>int</returns>
        static int GetCountGroup(int N)
        {
            int group = 0;
            int num = 1;
            for (int i = 1; i <= N; i++)
            {
                if (i % num == 0)
                {
                    num = i;
                    group++;
                }
            }
            return group;
        }


        /// <summary>
        /// Метод расчитывает и записывает в файл сгруппированные неделимые числа от числа N
        /// </summary>
        /// <param name="N"></param>
        static void GetGroupFile(int N, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                //List<List<int>> list = new List<List<int>>();
                //List<string> line = new List<string>();
                //List<string> file = new List<string>();
                //StringBuilder line = new StringBuilder();
                //StringBuilder file = new StringBuilder();
                //list.Add(new List<int>());
                //List<int> list = new List<int>();

                int num = 1;
                int group = 0;

                // Чем меньше переборов всего числа, тем быстрее, т.е. один цикл самый оптимальный вариант
                // Самый эффективный по времени вычислений способ, формировать двумерный список List,
                // но для миллиарда ему не хватает памяти (в моем случае вылетает при превышении 8Гб)
                // При прямой записи файла получается очень долго (больше 3 минут), но работает так, как в пямяти ни чего не храниться
                // Формирование строки заранее в StringBuilder или в string не улучшает ситуацию, оперция записи на диск слишком долгая...
                // По всей видимости выбран не верный способ разбиения чисел на группы и их проверка на делимость...
                for (int i = 1; i <= N; i++)
                {
                    if (i % num == 0)
                    {
                        num = i;
                        group++;

                        //list.Add(new List<int>());
                        //line.Add(i.ToString());
                        //line = line + " " + i.ToString();
                        //line.Append(i);
                        //file.AppendLine(line.ToString());
                        sw.WriteLine($"\nГруппа {group}: {i}");
                        //line.Clear();
                        //line.Clear();
                    }
                    //else line = line+i.ToString();
                    //else list[group].Add(i);
                    else sw.Write($" {i}");
                    //else line.Append(i);

                }
                //sw.Write(file);
                //for (int i = 0; i < file.Count - 1; i++)
                //{
                //    //sw.Write($"Группа {i + 1}:");
                //    //sw.WriteLine(list[i]);
                //    sw.Write(file);
                //}

            }
        }

       /// <summary>
       /// Метод создаёт файл с задданным числом N
       /// </summary>
       /// <param name="fileName"></param>
        static void CreateFile(string fileName)
        {
            int key;
            if (int.TryParse(Console.ReadLine(), out key)) // Проверяем ввенные символы
            {
                if (key > 0 && key <= 1_000_000_000)
                {
                    File.WriteAllText(fileName, Convert.ToString(key)); // Создаем файл и пишем в него указанное число
                    Console.WriteLine($"Файл {fileName} создан и в него записано число {key}");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля и не больше миллиарда.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля и не больше миллиарда.");
                Console.ReadKey();
            }
        }

        static void CreateZipFile(string source)
        {
            string compressed = Path.GetFileNameWithoutExtension(source) + ".zip";
            using (FileStream ss = new FileStream(source, FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create(compressed))   // поток для записи сжатого файла
                {
                    // поток архивации
                    using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                    {
                        ss.CopyTo(cs); // копируем байты из одного потока в другой
                        Console.WriteLine("\nСжатие файла {0} завершено. Было: {1} байт  стало: {2} байт.",
                                          source,
                                          ss.Length,
                                          ts.Length);
                        Console.WriteLine($"\nСжатый файл {compressed} сохранён...");
                    }
                }
            }
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
                string fileName = "number.txt";
                DateTime date = new DateTime(2021, 09, 28, 01, 30, 00);
                Console.Clear();
                Console.WriteLine("Группировка неделящихся чисел");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("Нажмите «1» чтобы расчитать только количество групп \nНажмите «2» чтобы создать файл со сгруппированными числами");
                if (int.TryParse(Console.ReadLine(), out key))
                {
                    switch (key)
                    {
                        case 1: // Расчитываем только количество групп
                            {
                                string groupCount = null;
                                int number = 0;
                                if ((groupCount = OpenFile(fileName)) != null) // Проверяем и открываем файл с помощью метода OpenFile
                                {
                                    date = DateTime.Now; // Считываем текущее время начала вычисления
                                    number = GetCountGroup(Convert.ToInt32(groupCount)); // Вызываем метод получения количества групп
                                    TimeSpan timeSpan = DateTime.Now.Subtract(date);  // Получаем разницу времени между началом и окончанием вычислений
                                    Console.WriteLine($"Количество групп от числа {groupCount} равно {number}");
                                    Console.WriteLine($"Вычисление количества групп неделимых чисел от числа {groupCount} заняла {timeSpan.TotalMilliseconds} миллисекунд");
                                    Console.ReadKey();
                                }
                                else // Если метод OpenFile вернул null
                                {
                                    Console.WriteLine($"Файл number.txt не найден или пуст. Укажите желаемое расчётное число:");
                                    CreateFile(fileName);                                    
                                }                               
                                break;
                            }

                        case 2: // Заполняем группы неделимыми числами и сохраняем их в файл
                            {
                                string number = null;
                                if ((number = OpenFile(fileName)) != null) // Проверяем и открываем файл с помощью метода OpenFile
                                {
                                    string path = "result.txt";
                                    date = DateTime.Now; // Считываем текущее время начала вычисления
                                    GetGroupFile(Convert.ToInt32(number), path);
                                    TimeSpan timeSpan = DateTime.Now.Subtract(date);  // Получаем разницу времени между началом и окончанием вычислений
                                    Console.WriteLine($"\nФайл {path} сохранен..."); 
                                    Console.WriteLine($"\nВычисление и запись в файл количества групп неделимых чисел от числа {number}" +
                                        $"\nзаняла {timeSpan.TotalMilliseconds} миллисекунд " +
                                        $"\nили {timeSpan.TotalSeconds} секунд " +
                                        $"\nили {timeSpan.TotalMinutes} минут");
                                    Console.WriteLine($"\nДля архивации файла нажмите 1, любая другая клавиша - выход");
                                    if (Console.ReadKey().Key == ConsoleKey.D1)
                                    {
                                        CreateZipFile(path); // Вызываем метод архивации файла
                                    }
                                    Console.ReadKey();
                                }
                                else // Если метод OpenFile вернул null
                                {
                                    Console.WriteLine($"Файл number.txt не найден или пуст. Укажите желаемое расчётное число:");
                                    CreateFile(fileName);
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
