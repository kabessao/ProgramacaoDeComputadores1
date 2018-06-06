using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ZooXaml.DAO
{
    class ConexaoBanco
    {
        private MySqlConnection connection;

        public ConexaoBanco()
        {
            Initialize();
        }

        private void Initialize()
        {
            connection = new MySqlConnection("SERVER=localhost;" +
                "DATABASE=zoo;" +
                "UID=root;" +
                "PASSWORD=;");
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.MessageBox.Show("Falha ao conectar ao servidor. Consulte o Administrador");
                        break;
                    case 1045:
                        System.Windows.MessageBox.Show("Usuario e/ou senha incorretos");
                        break;
                    default:
                        break;
                }
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
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void NoReaderCommand(string query)
        {
            
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = query,

                Connection = connection
            };

            cmd.ExecuteNonQuery();

            this.CloseConnection();

        }
        
        public List<string> ReaderCommand(string query)
        {

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = query,
                Connection = connection
            };

            MySqlDataReader reader = cmd.ExecuteReader();
            
            List<string> list = new List<string>();

            while (reader.Read())
            {
            }
            return list;

        }
    }
}
