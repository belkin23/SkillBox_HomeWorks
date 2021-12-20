using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_06
{
    class Program
    {
        /// <summary>
        /// Получить кол-во групп, т.е. значение M
        /// </summary>
        /// <param name="N">максимальное число</param>
        /// <returns>кол-во групп</returns>
        static int GetCountGroups(int N)
        {
            return (int)(Math.Floor(Math.Log(N, 2)) + 1);
        }

        /// <summary>
        /// Разбивает на группы последовательность чисел по делению
        /// </summary>
        /// <param name="N">масимальное число</param>
        /// <returns>массив групп</returns>
        static int[][] GetGroups(int N)
        {
            int M = GetCountGroups(N);
            int[][] groups = new int[M][];

            groups[0] = new int[] { 1 }; ;
            groups[1] = new int[N / 2];
            groups[1][0] = 2;

            for (int i = 3; i <= N; i++)
            {
                int group = 1;
                int j = 0;
                while (groups[group][j] != 0)
                {
                    if (i % groups[group][j] == 0)
                    {
                        group++;
                        j = 0;
                        if (groups[group] == null)
                        {
                            groups[group] = new int[N / 2];
                            break;
                        }
                    }
                    else
                    {
                        j++;
                    }

                }
                groups[group][j] = i;
            }
            return groups;
        }

        /// <summary>
        /// Запись групп чисел в csv файл
        /// </summary>
        /// <param name="groups">Группа чисел</param>
        /// <param name="url">название файла или URL</param>
        static void WriteInFile(int[][] groups, string url)
        {
            using (StreamWriter sw = new StreamWriter(url, false, Encoding.Unicode))
            {
                string line;
                for (int i = 0; i < groups.GetLength(0); i++)
                {
                    line = "";
                    for (int j = 0; j < groups[i].Length; j++)
                    {
                        if (groups[i][j] == 0)
                        {
                            break;
                        }
                        line += ($"{groups[i][j]}\t");
                    }
                    sw.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Архиивирует файл csv
        /// </summary>
        /// <param name="fileName">название файла csv</param>
        /// <param name="zipFileName">название архива</param>
        static void ZipCsvFile(string fileName, string zipFileName)
        {
            using (FileStream csv = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (FileStream zip = File.Create(zipFileName))
                {
                    using (GZipStream comp = new GZipStream(zip, CompressionMode.Compress))
                    {
                        csv.CopyTo(comp);
                        Console.WriteLine("Сжатие файла {0} завершено. Было: {1}  стало: {2}.",
                                          fileName,
                                          csv.Length,
                                          zip.Length);
                    }
                }
            }
        }

        static void Main(string[] args)
        {

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

            DateTime dateStart = DateTime.Now;

            int N = Convert.ToInt32(File.ReadAllText(@"N.txt"));

            int M = GetCountGroups(N);

            int[][] groups = GetGroups(N);

            WriteInFile(groups, "result.csv");

            TimeSpan workTime = DateTime.Now - dateStart;

            Console.WriteLine($"N = {N} M = {M}");
            Console.WriteLine($"Время выполнения программы: {workTime.Seconds} секунд");

            string fileName = "result.csv";
            string zipFileName = "result.zip";

            Console.Write("Заархивировать файл (д/н): ");
            string answer = Console.ReadLine();
            
            if (answer == "д")
            {
                ZipCsvFile(fileName, zipFileName);
            }
            else
            {
                Console.WriteLine("Ты не знаешь от чего отказываешься!");
            }
            



            Console.ReadKey();

        }
        
    }
}