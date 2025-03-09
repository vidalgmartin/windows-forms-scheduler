using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace C969.Database
{
    public class DbConnection
    {
        public static MySqlConnection connection { get; set; }

        public static void startConnection()
        {
            try
            {
                // get connection string
                string connectionStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                connection = new MySqlConnection(connectionStr);

                // open connection
                connection.Open();

                MessageBox.Show("Connection succesful");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void stopConnection()
        {
            try
            {
                // close connection
                if (connection != null)
                {
                    connection.Close();
                }

                connection = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
