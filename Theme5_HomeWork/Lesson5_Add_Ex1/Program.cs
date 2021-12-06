using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 1.
// Воспользовавшись решением задания 3 четвертого модуля
// 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
// 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
// 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение

namespace Lesson5_Add_Ex1
{
    internal class Program
    {
        /// <summary>
        /// метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
        /// </summary>
        /// <param name="Matrix"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        static int[,] MatrixMultipliedOnNumber(int[,] Matrix, int factor)
        {
            int row = Matrix.GetLength(0);
            int col = Matrix.GetLength(1);
            int[,] resMatrix = new int[row, col];

            for (int i = 0; i < row; i++) 
            {
                for (int j = 0; j < col; j++) 
                {
                    resMatrix[i, j] = Matrix[i, j] * factor; // Умножаем каждый элемент матрицы на заданное число
                }
            }
            return resMatrix;
        }

        /// <summary>
        /// метод, принимающий две матрицы, возвращающий их сумму
        /// </summary>
        /// <param name="Matrix1"></param>
        /// <param name="Matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixSumOnMatrix(int[,] Matrix1, int[,] Matrix2)
        {
            int row = Matrix1.GetLength(0);
            int col = Matrix1.GetLength(1);
            int[,] sumMatrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    sumMatrix[i, j] = Matrix1[i, j] + Matrix2[i, j]; // Складываем каждый элемент первой матрицы со второй
                }
            }
            return sumMatrix;
        }

        /// <summary>
        /// метод, принимающий две матрицы, возвращающий их произведение
        /// </summary>
        /// <param name="Matrix1"></param>
        /// <param name="Matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixMultipliedOnMatrix(int[,] Matrix1, int[,] Matrix2)
        {
            int row = Matrix1.GetLength(0);
            int col = Matrix1.GetLength(1);
            int row2 = Matrix2.GetLength(0);
            int col2 = Matrix2.GetLength(1);

            int[,] resMatrix = new int[row, col2];

            for (int i = 0; i < row; i++)                           // Перебираем строки матрицы
            {
                for (int j = 0; j < col2; j++)                       // Перебираем столбцы матрицы
                {
                    for (int k = 0; k < row2; k++)
                    {
                        resMatrix[i, j] += Matrix1[i, k] * Matrix2[k, j]; // Перемножаем элементы матриц
                    }
                }
            }
            return resMatrix;
        }

        /// <summary>
        /// Метод, принимающий матрицу и выводящий её на экран
        /// </summary>
        /// <param name="Matrix"></param>
        static void PrintMatrix(int[,] Matrix)
        {
            int row = Matrix.GetLength(0);
            int col = Matrix.GetLength(1);
            for (int i = 0; i < row; i++) // Перебираем строки матрицы
            {
                for (int j = 0; j < col; j++) // Перебираем столбцы матрицы
                {
                    Console.Write($"{Matrix[i, j],-6} "); // Выводим матрицу на экран по ячейкам
                }
                Console.Write("\n");
            }
        }

        static Random random = new Random();  // Если поместить внутрь метода, генерирует одинаковые последовательности чисел

        /// <summary>
        /// метод, заполняющий матрицу рандомными числами
        /// </summary>
        /// <param name="Matrix"></param>
        /// <returns></returns>
        static int[,] GetRandomMatrix(int[,] Matrix)
        {
            int row = Matrix.GetLength(0);
            int col = Matrix.GetLength(1);
            for (int i = 0; i < row; i++) // Перебираем строки матрицы
            {
                for (int j = 0; j < col; j++) // Перебираем столбцы матрицы
                {
                    Matrix[i, j] = random.Next(1, 10); // Заполняем матрицу случайными числами от 1 до 9
                }
            }            
            return Matrix;            
        }

        static void Main(string[] args)
        {
            while (1 == 1)
            {
                int row = 0;    // Количество строк матрицы
                int col = 0;    // Количество столбцов матрицы
                int row2 = 0;    // Количество строк перемножаемой матрицы
                int col2 = 0;    // Количество столбцов перемножаемой матрицы
                int factor = 0; // Множитель матрицы
                int key = 0;    // Клавиша нажатая пользователем
                int alg = 0;    // Признак алгоритма
                int[,] resmatrix = new int[row, col2];

                Console.Clear();
                Console.WriteLine("\nВведите количество строк матрицы:");
                if (int.TryParse(Console.ReadLine(), out key))
                {
                    if (key > 0)
                    {
                        row = key; // Запоминаем количество строк матрицы
                    }

                    else
                    {
                        Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля. Для продолжения нажмите Enter...");
                    Console.ReadLine();
                    continue;
                }
                Console.WriteLine("Введите количество столбцов матрицы:");
                if (int.TryParse(Console.ReadLine(), out key))
                {
                    if (key > 0)
                    {
                        col = key; // Запоминаем количество столбцов матрицы
                    }

                    else
                    {
                        Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля. Для продолжения нажмите Enter...");
                    Console.ReadLine();
                    continue;
                }
                int[,] matrix = new int[row, col]; // Задание двумерного массива - матрицы, заданного пользователем размера
                
                Console.WriteLine(); // Выводим пустую строку            

                while (1 == 1) // Организуем меню с операциями на матрицей
                {
                    Console.WriteLine("\nВыберите опрецию над матрицами:");
                    Console.WriteLine("\n[1] - умножение на число, [2] - сложение, [3] - перемножение");
                    if (int.TryParse(Console.ReadLine(), out key))
                    {
                        if (key == 1)
                        {
                            alg = key; // Умножение на число
                            break;
                        }
                        else if (key == 2)
                        {
                            alg = key; // Сложение матриц
                            break;

                        }
                        else if (key == 3)
                        {
                            alg = key; // Перемножение матриц
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Вы ввели не верный символ. Введите целое число от 1 до 3.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Вы ввели не верный символ. Введите целое число. Для продолжения нажмите Enter...");
                        Console.ReadLine();
                        continue;
                    }
                }

                switch (alg) // Выпоняем выбранный алгоритм
                {
                    case 1: // Умножение матрицы на число
                        {
                            Console.WriteLine("Введите на какое число умножить матрицу:");
                            if (int.TryParse(Console.ReadLine(), out factor)) { }// Запоминаем множитель                    
                            else
                            {
                                Console.WriteLine($"Вы ввели не верный символ. Введите целое число. Для продолжения нажмите Enter...");
                                Console.ReadLine();
                                continue;
                            }

                            Console.WriteLine(); // Выводим пустую строку            

                            Console.WriteLine($"\nИсходная матрица {row} x {col}:\n");

                            matrix = GetRandomMatrix(matrix);
                            PrintMatrix(matrix);
                            
                            Console.WriteLine($"\nИсходная матрица умноженная на {factor} = \n");
                            
                            resmatrix = MatrixMultipliedOnNumber(matrix, factor);
                            PrintMatrix(resmatrix);

                            break;
                        }
                    case 2: // Сложение матриц
                        {
                            Console.WriteLine(); // Выводим пустую строку            

                            Console.WriteLine($"\nИсходная матрица {row} x {col}:\n");
                            
                            matrix = GetRandomMatrix(matrix);
                            PrintMatrix(matrix);

                            int[,] matrix2 = new int[row, col]; // Задание двумерного массива - матрицы, заданного пользователем размера
                            Console.WriteLine("\nМатрица которую суммируем с исходной:\n");

                            matrix2 = GetRandomMatrix(matrix2);
                            PrintMatrix(matrix2);

                            Console.WriteLine($"\nСумма матриц = \n");
                            resmatrix = MatrixSumOnMatrix(matrix, matrix2);
                            PrintMatrix(resmatrix);

                            break;
                        }

                    case 3: // Перемножение матриц
                        {
                            Console.WriteLine(); // Выводим пустую строку

                            Console.WriteLine($"\nИсходная матрица {row} x {col}:\n");

                            matrix = GetRandomMatrix(matrix);
                            PrintMatrix(matrix);

                            while (1 == 1)
                            {
                                Console.WriteLine($"\nВведите количество строк матрицы на которую перемножаем (должно быть равным количеству столбцов исходной матрицы = {col}):");
                                if (int.TryParse(Console.ReadLine(), out key))
                                {
                                    if (key > 0 && key == col)
                                    {
                                        row2 = key; // Запоминаем количество строк матрицы
                                    }

                                    else
                                    {
                                        //Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля. Для продолжения нажмите Enter...");
                                    Console.ReadLine();
                                    continue;
                                }
                                Console.WriteLine("Введите количество столбцов матрицы на которую перемножаем:");
                                if (int.TryParse(Console.ReadLine(), out key))
                                {
                                    if (key > 0)
                                    {
                                        col2 = key; // Запоминаем количество столбцов матрицы
                                        break;
                                    }

                                    else
                                    {
                                        //Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля.");
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Вы ввели не верный символ. Введите целое число больше нуля. Для продолжения нажмите Enter...");
                                    Console.ReadLine();
                                    continue;
                                }
                            }
                            int[,] matrix2 = new int[row2, col2];
                            Console.WriteLine($"\nМатрица которую перемножаем с исходной {row2} x {col2}:\n");
                           
                            matrix2 = GetRandomMatrix(matrix2);
                            PrintMatrix(matrix2);
                            
                            Console.WriteLine($"\nПроизведение матриц {row} x {col2} = \n");

                            resmatrix = MatrixMultipliedOnMatrix(matrix, matrix2);  
                            PrintMatrix(resmatrix);

                            break;
                        }
                    default:
                        {
                            break;
                        }

                }
                Console.WriteLine("\nНажмите [1] - Расчитать другую матрицу? [любая другая кнопка] - Выход ");
                if (Console.ReadKey().Key != ConsoleKey.D1) break;
            }
        }
    }
}
