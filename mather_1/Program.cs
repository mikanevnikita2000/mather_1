using System;
using System.Threading;

namespace mather_1
{
    class Program
    {
        private static void Main()
        {
            bool isEnabled = true;
            while (isEnabled)
            {
                Name(true);
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
        static bool AdditionAndSubtractionAndMultiplication(int num)
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
            Console.WriteLine("что бы ввести ответ нажми \"1\"");
            (string sec,int otvet) = timer();
            Console.WriteLine(sec);
            while (!result)
            {
                if (expectedResult == otvet)
                {
                    result = true;
                    Console.WriteLine("Молодец! Правильно!");
                    // здесь надо записать рузультат в бд
                    Query.write_example_to_db2(1, visibleExpression, true, sec);
                    return;
                }
                else
                {
                    Console.WriteLine("попробуй ещё раз");
                    Query.write_example_to_db2(1, visibleExpression, false, sec);

                }
                
                Console.WriteLine(sec);
            }
            return;
        }
        internal static (string secu, int otvet) timer()
        {
            int sec = 0;
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.D1))
            {
                
                Thread.Sleep(2000);
               
                sec = sec + 1;
            }
            int otvet = Convert.ToInt32(Console.ReadLine());
            string secu = Convert.ToString(sec);
            return (secu, otvet);
        }
        static void Name(bool torf)
        {
            Query.write_example_to_db_name();
            if (torf == false)
            {
                Console.WriteLine("Как тебя зовут?");
                string name = Console.ReadLine();
                Console.WriteLine("сколько тебе лет?");
                int age = Int32.Parse(Console.ReadLine());
                Query.write_example_to_db1(name, age, 10);
            }
            else
            {
                Console.WriteLine("уже есть такое имя");
            }
        }
        internal static bool Bolen(bool torf) 
        {
            Name(torf);
            return torf;
        }
    }
    
}