using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_Ex1
{ 
    //Задание 1. Метод разделения строки на слова

    internal class Program
    {
        /// <summary>
        /// Метод, разделяющий предложение на отдельные слова
        /// </summary>
        /// <param name="words"></param>
        /// <returns>Массив слов</returns>
        static string[] GetIndividualWords(string words)
        {
            return words.Split(' '); 
        }

        /// <summary>
        ///  Метод, выводящий предложение по одному слову на экран
        /// </summary>
        /// <param name="SplitWords"></param>
        static void PrintWords(string[] SplitWords)
        {
            for (int i = 0; i < SplitWords.Length; i++)
            {
                Console.WriteLine(SplitWords[i]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");
            string inputPhrase = Console.ReadLine();
            Console.WriteLine();

            PrintWords(GetIndividualWords(inputPhrase)); // Вызываем метод вывода слов на экран аргументом которого является результат метода разделяющего предложение на отдельные слова

            Console.ReadKey();
        }
    }
}
