using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class DatabaseClass
    {
        public static string connectionString = "server=localhost; database=inventory; uid=root; pwd=\"\";";
        public static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void openConnection()
            
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }

            catch( Exception state)
            {
                MessageBox.Show("Error encountered");
            }
           
        }


        public static void closeConnection()
        {
            try
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); 
                }
            }

            catch (Exception state)
            {
                MessageBox.Show("Error encountered terminating");
            }
        }
    }
}
