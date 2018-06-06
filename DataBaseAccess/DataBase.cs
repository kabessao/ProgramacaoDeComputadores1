using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataBaseAccess
{
    public class DataBase
    {

        MySqlConnection connection;

        public  DataBase(string database, string server, string userId)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Database = database,
                Server = server,
                UserID = userId,
                
            };

            connection = new MySqlConnection(builder.ToString());

        }

        public void Command(string query)
        {

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();

            }
        } 

        public bool[] ConnectionTest()
        {
            bool[] test = new bool[2];
            test[0] = OpenConnection();
            test[1] = CloseConnection();
            return test;

        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
