using MySql.Data.MySqlClient;
using System;
using Tutorial.SqlConn;

namespace mather_1
{
    public class Query
    {
        public static void write_example_to_db_name()
        {
            string q1 = $"SELECT * FROM user WHERE name='Ybrbnf';";
            query_execute(q1);
            query_reader("SELECT * FROM user");
        }
        public static void write_example_to_db1(string name, int age, int time)
        {
            /*//Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            MySqlCommand cmd1 = new MySqlCommand("show schemas;", conn);   // ("use new;");
            //посылаем запрос
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнения запроса 1");
                return;
            }
            //insert into result (id, user_id, example, answer, time) values (1, 1, "2 + 2", 1, "10");
            MySqlCommand cmd2 = new MySqlCommand(expr, conn);
            MySqlDataReader read = cmd2.ExecuteReader();
            if (read != null)
            {
                while (read.Read())
                {
                    int table_id = Convert.ToInt32(read["id"]);
                    string table_user_name = Convert.ToString(read["name"]);
                    if (table_user_name == name)
                    {

                    }
                }
            }*/
            string q1 = $"SELECT * FROM user WHERE name='{name}';";
            query_execute(q1);
            query_reader("SELECT * FROM user");
            if (true)
            {
                q1 = $"insert into user (id, name, age, correct_answers) values (1, \"{name}\", {age}, {time});";
                query_execute(q1);
                query_reader("SELECT * FROM user");
            }
        }
        public static void write_example_to_db2(int user_id, string example,bool answer, string time)
        {
            //insert into result (id, user_id, example, answer, time) values (1, 1, "2 + 2", 1, "10");
            string q1 = $"insert into result (id, user_id, example, answer, time) values (1, {user_id}, \"{example}\", {answer}, \"{time}\");";
            query_execute(q1);
            query_reader("SELECT * FROM result");
        }
        static void query_execute(string expr)
        {
            //Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            MySqlCommand cmd1 = new MySqlCommand("show schemas;", conn);   // ("use new;");
            //посылаем запрос
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнения запроса 1");
                return;
            }
            MySqlCommand cmd2 = new MySqlCommand(expr, conn);
            //посылаем запрос
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнения запроса 2");
                return;
            }
            conn.Close();
            conn.Dispose();
        }


        static void query_reader(string expr)
        {
            //Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            MySqlCommand cmd1 = new MySqlCommand("show schemas;", conn);   // ("use new;");
            //посылаем запрос
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнения запроса 1");
                return;
            }

            MySqlCommand cmd2 = new MySqlCommand(expr, conn);
            MySqlDataReader read = cmd2.ExecuteReader();

            /*if (read != null)
            {
                while (read.Read())
                {
                    int table_id = Convert.ToInt32(read["id"]);
                    string table_user_name = Convert.ToString(read["name"]);
                    if (table_user_name == "")
                    {
                        
                        
                    }
                    Console.WriteLine(table_id + " : " + table_user_name );
                }
            }*/
            bool torf = false;
            int a = 0;
            Console.WriteLine("Как тебя зовут?");
            string name = Console.ReadLine();
            
                if (read != null || a ==0)
                {
                    while (read.Read()|| a !=1)
                    {
                        int table_id = Convert.ToInt32(read["id"]);
                        string table_user_id = Convert.ToString(read["name"]);
                        int table_expression = Convert.ToInt32(read["age"]);
                        int answer = Convert.ToInt32(read["correct_answers"]);
                    
                        if (table_user_id == name)
                        {
                            Console.WriteLine("есть такое имя");
                            a=1;
                            torf = true;
                            Program.Bolen(torf);
                        }
                        else
                        {
                            Console.WriteLine("нет такого имени");
                            Program.Bolen(torf);
                        }
                        Console.WriteLine(table_id + " : " + table_user_id + " : " + table_expression + " : " + answer );
                    }
                }


            conn.Close();
            conn.Dispose();
        }
    }
}
