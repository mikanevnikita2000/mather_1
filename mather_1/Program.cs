using System;
using System.Threading;

namespace mather_1
{
    class Program
    {
        private static void Main()
        {
            bool isEnabled = true;
            (int id, string name_user) =User_name();
            while (isEnabled)
            {
                
                Console.WriteLine("Выбери какие примеры тебе нужны:");
                Console.WriteLine("1. Сложение ");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Статистика");
                Console.WriteLine("6. Выход");
                int num = Int32.Parse(Console.ReadLine());
                Console.Clear();
                isEnabled = AdditionAndSubtractionAndMultiplication(num,id, name_user);
                
            }
        }
        static bool AdditionAndSubtractionAndMultiplication(int num,int id, string name_user)
        {
            string visibleExpression;
            bool isEnabled = true;
            int expectedResult;           
            Random gpg = new Random();
            
            string questions;
            bool isHided = true;
            while (isHided)
            {
                int a = gpg.Next(100);
                int b = gpg.Next(100);
                if (num == 1)
                {
                    visibleExpression = ($"{a} + {b}");
                    expectedResult = a + b;
                    test(expectedResult, visibleExpression, id, name_user);
                }
                if (num == 2)
                {
                    visibleExpression = ($"{a} - {b}");
                    expectedResult = a - b;
                    test(expectedResult, visibleExpression, id, name_user);
                }
                if (num == 3)
                {
                    visibleExpression = ($"{a} * {b}");
                    expectedResult = a * b;
                    test(expectedResult, visibleExpression, id, name_user);
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
                    int generetdelitel = gpg.Next(1, 10);
                    delimoe = loc[gpg.Next(0, 9), gpg.Next(0, 9)];
                    visibleExpression = ($"{delimoe} / {generetdelitel}");
                    expectedResult = delimoe / generetdelitel;
                    test(expectedResult, visibleExpression,id, name_user);
                }
                if (num == 5)
                {
                    int sum = 0;
                    int d = 0;
                    (int table_age1, int table_correct_answers1) =Query.read_user_from_db_name2(name_user);
                    (int sumslo, int summinus, int sumumno, int sumdelen) =Query.read_user_from_db_name3(id);
                    (int[] chisla,int col) = Query.read_user_from_db_name2(id);
                    for (int i = 0; i < col; i++)
                    {
                        sum = sum+ chisla[i];
                        d++;
                    }
                    float sredznach = sum / d;
                    Console.WriteLine($"Ваше имя: {name_user}");
                    Console.WriteLine($"Ваш возраст: {table_age1}"); 
                    Console.WriteLine($"количество правельных ответов: {table_correct_answers1} ");
                    Console.WriteLine($"Ваше среднее время за последнии 100 примеров: {sredznach} секунд");
                    Console.WriteLine($"Ошибок в сложении: {sumslo}");
                    Console.WriteLine($"Ошибок в вычитании: {summinus}");
                    Console.WriteLine($"Ошибок в умнижении: {sumumno}");
                    Console.WriteLine($"Ошибок в делении: {sumdelen}");
                    Console.ReadLine();
                    Console.Clear();
                    return isEnabled;
                }
                if (num == 6)
                {
                    isEnabled = false;
                    return isEnabled;
                }
                Console.Clear();
                Console.WriteLine("Хочешь ещё пример?");
                questions = Console.ReadLine();
                if (questions == "Нет" || questions == "нет")
                {
                    Console.Clear();
                    return isEnabled;
                }
                
            }
            return isEnabled;
        }
        static void test( int expectedResult, string visibleExpression,int id, string name_user)
        {
            int pom = 0;
            while (pom!=1)
            {
                Console.WriteLine($"Сколько будет: {visibleExpression}");
                (int sec, int otvet) = timer();
                Console.WriteLine(sec);
                
                if (expectedResult == otvet)
                {
                    Console.WriteLine("Молодец! Правильно!");
                    (int id1, int table_correct_answers) = Query.read_user_from_db_name(name_user);
                    table_correct_answers = table_correct_answers + 1;
                    Query.read_user_from_db_name1(table_correct_answers, id);
                    Query.write_example_to_db2(id, visibleExpression, true, sec);
                    return;
                }
                if (expectedResult != otvet)
                {
                    Console.Clear();
                    Console.WriteLine("Попробуй ещё раз");
                    Query.write_example_to_db2(id, visibleExpression, false, sec);
                }
                Console.WriteLine(sec);
                
            }
            return;
        }
        internal static (int , int ) timer()
        {
            DateTime value1 = DateTime.Now;
            int otvet = Convert.ToInt32(Console.ReadLine());
            DateTime value2 = DateTime.Now;
            int sec =(int)(value2-value1).TotalSeconds; ;
            return (sec, otvet);
        }
        internal static (int id, string name_user) User_name()
        {
            Console.WriteLine("Введи имя:");
            string name_user = Console.ReadLine();
            (bool isUserExsist, int id, int table_correct_answers1) = ChecUser(name_user);
            if (isUserExsist == false)
            {
                Console.Clear();   
                Console.WriteLine("Пройдите регистрацию:");
                Console.WriteLine();
                Console.WriteLine(name_user);
                Console.WriteLine("Сколько тебе лет?");
                Console.WriteLine();
                int age = Int32.Parse(Console.ReadLine());
                id = id + 1;
                
                Query.write_example_to_db1(id, name_user, age, 0);
            }
            if (isUserExsist == true)
            {
                Console.WriteLine("Уже есть такое имя");
                Console.Clear();
                return (id, name_user);
            }
            Console.Clear();
            return (id, name_user);
        }
        static (bool isUserExsist,int id, int table_correct_answers1) ChecUser(string name_user)
        {
            bool isUserExsist= false;
            (int id, int table_correct_answers1) = Query.read_user_from_db_name(name_user);
            if (id != 0)
            {
                isUserExsist = true;
            }
            return (isUserExsist, id, table_correct_answers1);
        }
    }
}