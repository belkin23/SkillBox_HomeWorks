using System;

// Задание 3. Создать метод, принимающий текст. 
// Результатом работы метода должен быть новый текст, в котором
// удалены все кратные рядом стоящие символы, оставив по одному 
// Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
// Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день

namespace Theme5_Add_Ex3
{
    internal class Program
    {
        /// <summary>
        /// Метод, удаляющий лишние буквы в словах
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        static string RemoveDuplicateСharacters(string phrase) // Принимает фразу 
        {
            phrase = phrase.ToLower(); // Преобразуем всю фразу в нижний регистр
            string[] words = new string[phrase.Length];

            string resPhrase = "";

            string[] separatingStrings = { " ", ",", ".", "!", "?", "\t", ":" }; // Строка разделителей
            words = phrase.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries); // Разбиваем фразу лона слова используя разделители, удаляя пустые строки

            for (int i = 0; i < words.Length; i++) // Перебираем каждое слово
            {
                char[] letters = words[i].ToCharArray(); // Преобразуем слово в массив символов-букв
                string resWord = letters[0].ToString();  // Так как первый элемент не сравниваем, сразу пишем его в слово

                for (int j = 1; j < letters.Length; j++) // Перебираем буквы в слове
                {
                    if (letters[j] != letters[j - 1]) resWord += letters[j].ToString(); // Если буквы не совпадают, сохраняем их в новое слово                
                }

                resPhrase += resWord + " "; // Складываем новую фразу из новых слов
            }
            return resPhrase; // возвращаем исправленную фразу
        }

        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.Clear();
                Console.WriteLine("Введите фразу с лишними буквами в словах:");
                string Phrase = Console.ReadLine();
                Console.WriteLine();

                Phrase = RemoveDuplicateСharacters(Phrase);

                Console.WriteLine($"Без лишних букв: {Phrase}");


                Console.WriteLine("\nНажмите [1] - Проверить другое предложение? [любая другая кнопка] - Выход ");
                if (Console.ReadKey().Key != ConsoleKey.D1) break;
            }
        }
    }
}
