using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DateApp
{
    class SqlCommands
    {
        public static void createUser(string Username, string Pass)
        {
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            SqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO USERS(USERNAME, PASS) values('" + Username + "', '"+ Pass +"');";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Tilføjede " + Username + " til User databasen.");
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
        public static void loginUser(string user, string pass)
        {
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            SqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT FROM USERS WHERE USERNAME = '"+user+"' AND PASS = '"+pass+"'";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Tilføjede " + Username + " til User databasen.");
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

        public class PullDataTest
        {
            private DataTable dataTable = new DataTable();

            //public PullDataTest()
            //{
            //}


            public void PullData(string user)
            {
                var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
                string query = "SELECT * FROM USERPROFIL WHERE USER ID ='"+user+"'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                connection.Close();
                da.Dispose();
            }
        }
    }
}
