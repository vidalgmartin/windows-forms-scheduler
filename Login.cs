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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using C969.CustomerForms;
using MySql.Data.MySqlClient;
using static C969.Database.DbConnection;

namespace C969
{
    public partial class Login : Form
    {
        public string languageIso = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        public Login()
        {
            InitializeComponent();

            CustomerRecords customerRecordsForm = new CustomerRecords();
            customerRecordsForm.Show();

            // default language translation to spanish
            if (languageIso == "en")
            {
                languageIso = "es";
            }

            // current user timezone
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            timezoneLabel.Text = localZone.DisplayName;
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

                        string translatedText = TranslateText(errorLabel.Text, languageIso);
                        translatedErrorLabel.Text = translatedText;

                        return;
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // log user entry
                            logLogin(usernameField.Text);

                            // update currentUser
                            currentUser = usernameField.Text;

                            // close form and open customer records

                            //CustomerRecords customerRecordsForm = new CustomerRecords();
                            //customerRecordsForm.Show();                                               
                        }
                        else
                        {
                            errorLabel.Text = "The username and password do not match.";

                            string translatedText = TranslateText(errorLabel.Text, languageIso);
                            translatedErrorLabel.Text = translatedText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public string TranslateText(string text, string languageIso)
        {
            // google translate api
            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl={languageIso}&dt=t&q={HttpUtility.UrlEncode(text)}";

            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                string result = webClient.DownloadString(url);

                // extract text from JSON like format
                int firstQuote = result.IndexOf('"') + 1;
                int secondQuote = result.IndexOf('"', firstQuote);
                return result.Substring(firstQuote, secondQuote - firstQuote);
            }
        }
    }
}
