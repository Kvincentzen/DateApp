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
        public static void createUProfil(string fname, string lname, int age, string height, string kilo, int sex, int uID)
        {
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            SqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO USERPROFIL(FNAME, LNAME, AGE, HEIGHT,KILO,SEX,USERID) values('" + fname + "', '" + lname +"', '" + age +"', '" + height +"', '" + kilo +"', '" + sex +"', '" + uID + "');";
                cmd.ExecuteNonQuery();
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
        public static void createUProfil(string fname, int age, string height, string kilo, int sex, int uID)
        {
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            SqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO USERPROFIL(FNAME, AGE, HEIGHT,KILO,SEX,USERID) values('" + fname + "', '" + age + "', '" + height + "', '" + kilo + "', '" + sex + "', '" + uID + "');";
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = "SELECT * FROM USERS WHERE USERNAME = '"+user+"' AND PASS = '"+pass+"'";
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
                if (loginSuccessful)
                {
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                    Console.ReadKey();
                }
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
        public static int findUserID(string u)
        {
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            SqlCommand cmd;
            int UserID;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT USERID FROM USERS WHERE USERNAME = '"+u+"'";
                UserID = Convert.ToInt32(cmd.ExecuteScalar());
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
            return UserID;
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
        public static void pullData(int uID)
        {
            DataTable dataTable = new DataTable();
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            string query = "SELECT * FROM USERPROFIL WHERE USERID ='" + uID + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            connection.Close();
            foreach (DataRow data in dataTable.Rows)
            {
                Console.WriteLine(data["FNAME"].ToString() + " " + data["LNAME"].ToString());
                Console.WriteLine("alder = "+data["AGE"].ToString());
                Console.WriteLine("Højde = "+data["HEIGHT"].ToString());
                Console.WriteLine("Vægt = "+data["KILO"].ToString());
                Console.WriteLine("Køn = "+data["SEX"].ToString());

            }
            da.Dispose();
        }
        public static void findMatch(int uID)
        {
            var connection = new SqlConnection(@"Server =SKAB1-PC-03\SQLEXPRESS; Database = DATEDB; Trusted_Connection=True;");
            SqlCommand cmd;
            var sex = 0;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT SEX FROM USERPROFIL WHERE USERID = " + uID + ";";
                sex = Convert.ToInt32(cmd.ExecuteScalar());
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
            if (sex == 1)
            {
                cmd.CommandText = "SELECT USERID FROM USERPROFIL WHERE SEX = 3;";
            }
            if (sex == 2)
            {

            }
            if (sex == 3)
            {

            }
            if (sex == 4)
            {

            }
        }
    }
}
