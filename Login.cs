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
using static C969.CustomerForms.CustomerRecords;
using static C969.Database.DbConnection;

namespace C969
{
    public partial class Login : Form
    {
        public string languageIso = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        public Login()
        {
            InitializeComponent();      

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
                bool userFound = false;
                string query = "SELECT * FROM user WHERE userName = @username AND password = @password AND active = 1;";               

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", usernameField.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", passwordField.Text.Trim());

                    if (usernameField.Text == "" || passwordField.Text == "")
                    {
                        errorLabel.Text = "Fields cannot be empty";

                        string translatedText = TranslateText(errorLabel.Text, languageIso);
                        translatedErrorLabel.Text = translatedText;

                        return;
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // log user entry
                            LogLogin(usernameField.Text);

                            // update currentUser and currentUserId
                            currentUser = usernameField.Text;
                            currentUserId = reader.GetInt32("userId");

                            // update userFound bool
                            userFound = true;

                            // hide login form
                            this.Hide();                                          
                        }
                        else
                        {
                            errorLabel.Text = "The username and password do not match.";

                            string translatedText = TranslateText(errorLabel.Text, languageIso);
                            translatedErrorLabel.Text = translatedText;
                        }
                    }

                    // open customer records form if user is logged in
                    if (userFound)
                    {
                        CustomerRecords customerRecordsForm = new CustomerRecords();
                        customerRecordsForm.Show();

                        // check for incoming appointment
                        UpcomingAppointment();

                        // close login form when the customer records form is close
                        customerRecordsForm.FormClosed += (s, args) => this.Close();                       
                    }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        public void LogLogin(string username)
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

        public void UpcomingAppointment()
        {
            try
            {
                DateTime timeUtc = DateTime.UtcNow;
                DateTime fifteenMinsUtc = timeUtc.AddMinutes(15);

                string query = @"
                SELECT appointmentId, start 
                FROM appointment 
                WHERE userId = @userId 
                AND start BETWEEN @now AND @fifteenMinutes
                ORDER BY start ASC
                LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    cmd.Parameters.AddWithValue("@now", timeUtc);
                    cmd.Parameters.AddWithValue("@fifteenMinutes", fifteenMinsUtc);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // convert start time from UTC to local time
                            DateTime startUtc = reader.GetDateTime("start");
                            DateTime startLocal = TimeZoneInfo.ConvertTimeFromUtc(startUtc, TimeZoneInfo.Local);

                            MessageBox.Show($"You have an appointment at {startLocal:g}.", "Upcoming Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
