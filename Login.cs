using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static C969.Database.DbConnection;

namespace C969
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            Console.WriteLine("Culture: " + culture);
        }

        public void logLogin(string username)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Username: {username}";

            try
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\Login_History.txt", true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM user WHERE userName = @username AND password = @password AND active = 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", usernameField.Text);
                    cmd.Parameters.AddWithValue("@password", passwordField.Text);

                    if (usernameField.Text == "" || passwordField.Text == "")
                    {
                        errorLabel.Text = "Fields cannot be empty";
                        return;
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            errorLabel.Text = "User Found";

                            logLogin(usernameField.Text);
                        }
                        else
                        {
                            errorLabel.Text = "The username and password do not match.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
