using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;

namespace mather_1
{
    public class Query
    {
        public static void write_example_to_db(int user_id, string example,bool answer, string time)
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

            if (read != null)
            {
                while (read.Read())
                {
                    int table_id = Convert.ToInt32(read["id"]);
                    int table_user_id = Convert.ToInt32(read["user_id"]);
                    string table_expression = Convert.ToString(read["example"]);
                    int answer = Convert.ToInt32(read["answer"]);
                    string time = Convert.ToString(read["time"]);
                    Console.WriteLine(table_id + " : " + table_user_id + " : " + table_expression + " : " + answer + " : " + time);
                }
            }

            conn.Close();
            conn.Dispose();
        }
    }
}
