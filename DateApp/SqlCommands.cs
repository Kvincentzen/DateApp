using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DateApp
{
    class SqlCommands
    {
        public static void addPerson(string Name)
        {
            var connection = new MySqlConnection("server=kvincentzen.com.mysql.service.one.com; port=3306; database=kvincentzen_com; uid=kvincentzen_com; PASSWORD=R6ZzF2BduHv3Mf8o2JzbkzsB; ");
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Person(Name) values('" + Name + "');";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Tilføjede " + Name + " til Person database.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        //static void showData()
        //{
        //    SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\ar\documents\visual studio 2015\Projects\DataBaseEksempel\DataBaseEksempel\Database1.mdf'; Integrated Security = True");

        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("SELECT * FROM Employees1", connection))
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        Console.WriteLine(reader.GetValue(i));
        //                    }
        //                    Console.WriteLine();
        //                }
        //            }
        //        }
        //    }
        //}
        //static void deleteEmployee(int i)
        //{
        //    var connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\ar\documents\visual studio 2015\Projects\DataBaseEksempel\DataBaseEksempel\Database1.mdf'; Integrated Security = True");
        //    SqlCommand cmd;
        //    connection.Close();
        //    cmd = new SqlCommand("DELETE FROM Employees1 WHere id=@i", connection);

        //    cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
        //    cmd.Parameters["@i"].Value = i;
        //    connection.Open();

        //    int slettet = cmd.ExecuteNonQuery();
        //    if (slettet > 0)
        //    {
        //        Console.WriteLine("Slettet - TRYK enter.");
        //        Console.ReadKey();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ikke fundet - TRYK enter");
        //        Console.ReadKey();
        //    }

        //    connection.Close();
        //}


    }
}
