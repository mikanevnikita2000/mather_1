using System;
using System.Threading;

namespace mather_1
{
    class Program
    {
        static void Main()
        {
            bool isEnabled = true;
            while (isEnabled)
            {
                Console.WriteLine("Как тебя зовут?");
                string name = Console.ReadLine();
                Query.write_example_to_db_name(name);
                Console.WriteLine("сколько тебе лет?");
                int age = Int32.Parse(Console.ReadLine());
                Query.write_example_to_db1(name, age, 10);
                Console.WriteLine("Выбери какие примеры тебе нужны:");
                Console.WriteLine("1. Сложение ");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Выход");
                int num = Int32.Parse(Console.ReadLine());
                isEnabled = AdditionAndSubtractionAndMultiplication(num);
                
            }
        }
        st bool AdditionAndSubtractionAndMultiplication(int num)
        {
            string visibleExpression;
            bool isEnabled = true;
            int expectedResult;           
            Random gpg = new Random();
            int a = gpg.Next(100);
            int b = gpg.Next(100);
            string questions;
            bool isHided = true;
            while (isHided)
            {
                if (num == 1)
                {
                    visibleExpression = ($"{a} + {b}");
                    expectedResult = a + b;
                    test(expectedResult, visibleExpression);
                }
                if (num == 2)
                {
                    visibleExpression = ($"{a} - {b}");
                    expectedResult = a - b;
                    test(expectedResult, visibleExpression);
                }
                if (num == 3)
                {
                    visibleExpression = ($"{a} * {b}");
                    expectedResult = a * b;
                    test(expectedResult, visibleExpression);
                }
                if (num == 4)
                {
                    int[,] loc =
                    {
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9},
                        { 4, 6, 8, 10, 12, 14, 16, 18, 20 },
                        { 6, 9, 12, 15, 18, 21, 24, 28, 30 },
                        { 8, 12, 16, 20, 24, 28, 32, 36, 40 },
                        { 10, 15, 20, 25, 30, 35, 40, 45, 50 },
                        { 12, 18, 24, 30, 36, 42, 48, 54, 60 },
                        { 14, 21, 28, 35, 42, 49, 56, 63, 70 },
                        { 16, 24, 32, 40, 48, 56, 64, 72, 80 },
                        { 18, 27, 36, 45, 54, 63, 72, 81, 90 },
                    };
                    int delimoe;
                    int generetdelitel = gpg.Next(0, 9);
                    delimoe = loc[gpg.Next(0, 9), gpg.Next(0, 9)];
                    visibleExpression = ($"{delimoe} / {generetdelitel}");
                    expectedResult = delimoe / generetdelitel;
                    test(expectedResult, visibleExpression);
                }
                if (num == 5)
                {
                    isEnabled = false;
                }
                Console.WriteLine("Хочешь ещё пример?");
                questions = Console.ReadLine();
                if (questions == "Нет" || questions == "нет")
                {
                    isHided = false;
                }
            }
            return isEnabled;
        }
        static void test( int expectedResult, string visibleExpression)
        {
            bool result = false;
            Console.WriteLine($"сколько будет: {visibleExpression}");
            /*while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter))
            {
                Console.WriteLine("Текущие дата и время: {0}", DateTime.Now.ToString());
                Thread.Sleep(2000);
            }*/
            while (!result)
            {
                if (expectedResult == (Convert.ToInt32(Console.ReadLine())))
                {
                    result = true;
                    Console.WriteLine("Молодец! Правильно!");
                    // здесь надо записать рузультат в бд
                    Query.write_example_to_db2(1, visibleExpression, true, "0");
                    return;
                }
                else
                {
                    Console.WriteLine("попробуй ещё раз");
                    Query.write_example_to_db2(1, visibleExpression, false, "0");
                }

            }
        }
    }
}