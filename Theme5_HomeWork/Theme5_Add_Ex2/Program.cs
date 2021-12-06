using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 2.
// 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
// 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
// Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
// Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
// 1. Ответ: А
// 2. ГГГГ, ДДДД
//
namespace Theme5_Add_Ex2
{
    internal class Program
    {
        /// <summary>
        /// Метод, разделяющий предложение на отдельные слова, и возвращающий слова с минимальным количеством букв
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns>Массив слов</returns>
        static string MinWords(string phrase)
        {
            string[] words = new string[phrase.Length]; // Маасив слов
            string resPhrase = ""; // Результирующая фраза
            string[] separatingStrings = { " ", ",", ".", "!", "?", "\t", ":" }; // Строка разделителей
            words = phrase.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries); // Разбиваем используя разделители, удаляя пустые строки

            // Определяем самое короткое слово во фразе
            int minLength = words[0].Length;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < minLength)
                {
                    minLength = words[i].Length;
                }
            }

            // Находим все слова с минимальным размером
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == minLength)
                {
                    resPhrase += words[i] + " ";
                }
            }
            return resPhrase;
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

        /// <summary>
        /// Метод, разделяющий предложение на отдельные слова, и возвращающий слова с максимальным количеством букв
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns>Массив слов</returns>
        static string MaxWords(string phrase)
        {
            string[] words = new string[phrase.Length]; // Маасив слов
            string resPhrase = ""; // Результирующая фраза
            string[] separatingStrings = { " ", ",", ".", "!", "?", "\t", ":" }; // Строка разделителей
            words = phrase.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries); // Разбиваем используя разделители, удаляя пустые строки

            // Определяем самое длинное слово во фразе
            int maxLength = words[0].Length;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                }
            }

            // Находим все слова с максимальным размером
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == maxLength)
                {
                    resPhrase += words[i] + " ";
                }
            }
            return resPhrase;
        }

        /// <summary>
        /// главный метод программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.Clear();
                Console.WriteLine("Введите предложение:");
                string Phrase = Console.ReadLine();
                Console.WriteLine();
                string resPhrase;

                resPhrase = MinWords(Phrase);

                Console.WriteLine($"Слово (или слова) с минимальным количеством букв: {resPhrase}");

                resPhrase = MaxWords(Phrase);

                Console.WriteLine($"\nСлово (или слова) с максимальным количеством букв: {resPhrase}");

                Console.WriteLine("\nНажмите [1] - Проверить другое предложение? [любая другая кнопка] - Выход ");
                if (Console.ReadKey().Key != ConsoleKey.D1) break;
            }            
        }
    }
}
