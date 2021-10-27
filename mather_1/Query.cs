using MySql.Data.MySqlClient;
using System;
using Tutorial.SqlConn;

namespace mather_1
{
    public class Query
    {
        public static (int id, int table_correct_answers1) read_user_from_db_name(string user_name)
        {
            string q1 = $"SELECT * FROM users WHERE name='{user_name}';";
            (int id, string table_name1, int table_age1, int table_correct_answers1) = query_reader(q1);
            return (id, table_correct_answers1);
        }
        public static int read_user_from_db_name1(int table_correct_answers1, int id)
        { 
            string q1 = $"UPDATE `users`SET `correct_answers` = {table_correct_answers1} WHERE `id` = {id};  ";
            //(int id1, string table_name1, int table_age1, int table_correct_answers) = query_reader(q1);
           // table_correct_answers = table_correct_answers1;
            query_execute(q1);
            return  table_correct_answers1;
        }
        public static void write_example_to_db1(int id,string name, int age, int time)
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
            string q1 = $"SELECT * FROM users WHERE name='{name}';";
            query_execute(q1);
            query_reader("SELECT * FROM users;");
            if (true)
            {
                q1 = $"insert into users ( name, age, correct_answers) values ( \"{name}\", {age}, {time});";
                query_execute(q1);
                //query_reader("SELECT * FROM users;");
            }
        }
        public static void write_example_to_db2(int user_id, string example,bool answer, string time)
        {
            //insert into result (id, user_id, example, answer, time) values (1, 1, "2 + 2", 1, "10");
            string q1 = $"insert into result ( user_id, example, answer, time) values ( {user_id}, \"{example}\", {answer}, \"{time}\");";
            query_execute(q1);
            //query_reader("SELECT * FROM result");
        }
        static void query_execute(string expr)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            MySqlCommand cmd1 = new MySqlCommand("show schemas;", conn);  
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


        static (int table_id1, string table_name1, int table_age1, int table_correct_answers1) query_reader(string expr)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            MySqlCommand cmd1 = new MySqlCommand("show schemas;", conn);   // ("use new;");
            
            cmd1.ExecuteNonQuery();

            MySqlCommand cmd2 = new MySqlCommand(expr, conn);
            MySqlDataReader read = cmd2.ExecuteReader();
            int table_id1 = 0;
            string table_name1 = "";
            int table_age1 = 0;
            int table_correct_answers1 = 0;
            if (read != null )
            {
                while (read.Read())
                {
                    table_id1 = Convert.ToInt32(read["id"]);
                    table_name1 = Convert.ToString(read["name"]);
                    table_age1 = Convert.ToInt32(read["age"]);
                    table_correct_answers1 = Convert.ToInt32(read["correct_answers"]);

                    return (table_id1, table_name1, table_age1, table_correct_answers1);
                }
            }
            conn.Close();
            conn.Dispose();
            return (table_id1, table_name1, table_age1, table_correct_answers1);
        }


    }
}
