using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5__Ex2
{
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
        ///  Метод переворачивает слова во фразе и выводит эту фразу на экран, вызывая метод разделения предложения на отдельные слова
        /// </summary>
        /// <param name="inputPhrase"></param>
        static string InversePhrase(string inputPhrase)
        {
            string[] SplitWords = GetIndividualWords(inputPhrase);

            string ResultString = "";

            for (int i = SplitWords.Length-1; i >= 0; i--)
            {
                ResultString += SplitWords[i] + " ";
            }

            return ResultString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");
            string inputPhrase = Console.ReadLine();
            
            Console.WriteLine();

            string outPhrase = InversePhrase(inputPhrase); 
            Console.WriteLine(outPhrase);

            Console.ReadKey();
        }
    }
}
