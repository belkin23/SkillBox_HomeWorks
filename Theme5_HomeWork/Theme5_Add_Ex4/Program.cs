using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
// является заданная последовательность элементами арифметической или геометрической прогрессии
// 
// Примечание
//             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
//             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
//

namespace Theme5_Add_Ex4
{
    internal class Program
    {
        /// <summary>
        /// Метод, опрелеяющий, является ли принятая последовательность арифметической прогрессией
        /// возвращает true - если является и false - если нет
        /// </summary>
        /// <param name="userPhrase"></param>
        /// <returns></returns>
        static bool ArithmeticSequenceCheck(double[] sequence)
        {
            bool check = false;
            for (int i = sequence.Length - 1; i > 1; i--)
            {
                // Если разность пары рядом стоящих чисел не равна, значит последовательность не арифметическая прогрессия,
                // так как в ней к каждому следующему числу добавлено(или отнято) одно и то же число
                if(sequence[i] - sequence[i - 1] != sequence[i - 1] - sequence[i - 2])
                {
                    check = false;

                    break;
                }
                else check = true;
            }            
            return check;
        }

        /// <summary>
        /// Метод, опрелеяющий, является ли принятая последовательность геометрической прогрессией
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        static bool GeometricSequenceCheck(double[] sequence)
        {
            bool check = false;
            for (int i = sequence.Length - 1; i > 1; i--)
            {
                // Если делитель пары рядом стоящих чисел не равен, значит последовательность не геометрическая прогрессия,
                // так как в ней каждое следующее число умножается на одно и то же число
                if (sequence[i] / sequence[i - 1] != sequence[i - 1] / sequence[i - 2])
                {
                    check = false;
                    break;
                }
                else check = true;
            }
            return check;
        }

        /// <summary>
        /// Метод, проверяющий, является ли введённая пользователем последовательность числовой, а затемм вызывает методы определения этой последовательности
        /// </summary>
        /// <param name="userPhrase"></param>
        /// <returns></returns>
        static string CheckSequense(string userPhrase)
        {
            bool check = false;
            string answer = "";
            // Разбиваем фразу на отдельные слова
            string[] words = new string[userPhrase.Length];
            words = userPhrase.Split(' ');
            double[] sequence = new double[words.Length];
            // Проверяем, являются ли слова цифрами
            double number;
            for (int i = 0; i < words.Length; i++)
            {
                if (double.TryParse(words[i], out number))
                {
                    sequence[i] = number;
                    check = true;
                }
                else
                {
                    check = false;
                    Console.WriteLine("Введите только цифры через пробел, в дробных числах используйте ','");
                    break;
                }
            }

            if (check)
            {
                bool arithmeticCheck = ArithmeticSequenceCheck(sequence);
                if (arithmeticCheck) answer = "Последовательность является арифметической прогрессией";
                else answer = "Последовательность не является арифметической прогрессией";

                bool geometricCheck = GeometricSequenceCheck(sequence);
                if (geometricCheck) answer += "\nПоследовательность является геометрической прогрессией";
                else answer += "\nПоследовательность не является геометрической прогрессией";
            }
            return answer;
        }
        static void Main(string[] args)
        {
            while (1==1)
            {
                string phrase = "";
                string answer = "";
                Console.Clear();
                Console.WriteLine("Введите последовательность чисел:");
                phrase = Console.ReadLine();

                answer = CheckSequense(phrase);
                Console.WriteLine(answer);

                Console.WriteLine("\nНажмите [1] - Проверить другую последовательность цифр? [любая другая кнопка] - Выход ");
                if (Console.ReadKey().Key != ConsoleKey.D1) break;
            }
        }
    }
}
