using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mather_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEnabled = true;
            while (isEnabled)
            {
                Console.WriteLine("Выбери какие примеры тебе нужны:");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Выход");
                string num = Console.ReadLine();

            }
        }
        static bool AdditionAndSubtractionAndMultiplication(string num, bool isEnabled)
        {
            int expectedResult = 0;
            int exampleResponse;
            Random gpg = new Random();
            int a = gpg.Next(100);
            int b = gpg.Next(100);
            string questions;
            bool isHided = true;
            while (isHided)
            {
                if (num == "1")
                {
                    if (expectedResult == a + b)
                    {

                        Console.WriteLine($"сколько будет: {a} + {b}");
                        exampleResponse = a + b;
                    }
                }
                if (num == "2")
                {
                    if (expectedResult == a - b)
                    {

                        Console.WriteLine($"сколько будет: {a} - {b}");
                        exampleResponse = a - b;
                    }
                }
                if (num == "3")
                {
                    if (expectedResult == a * b)
                    {

                        Console.WriteLine($"сколько будет: {a} * {b}");
                        exampleResponse = a * b;
                    }
                }
                if (num == "4")
                {

                }
                if (num == "5")
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
        static bool test(string visibleExpression, int expectedResult)
        {

            bool result = false;
            Console.WriteLine($"сколько будет: {visibleExpression}");
            while (!result)
            {
                if (expectedResult == (Convert.ToInt32(Console.ReadLine())))
                {
                    result = true;
                    Console.WriteLine("Молодец! Правильно!");
                }
                else
                {
                    Console.WriteLine("попробуй ещё раз");
                }
            }
            return result;
        }
        /*static bool TheDivisionMethod(int a, int b)
        {
            string questions;
            while (isEnabled == false)
            {
                if (prom1 == 1)
                {

                    int[,,,,,,,,] loc =
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
                    int prom2 = gpg.Next(0, 9);
                    int n = loc[prom2];
                    while (isCorrect == false)
                    {
                        Console.WriteLine($"сколько будет: {n} : 2");
                        int expectedResult = (Convert.ToInt32(Console.ReadLine()));
                        if (expectedResult == n / 2)
                        {
                            Console.WriteLine("Молодец! Правильно!");
                            isCorrect = true;
                        }
                        else
                        {
                            Console.WriteLine("попробуй ещё раз");
                        }
                    }
                }

                return isEnabled;
            }
        }*/
    }
}
