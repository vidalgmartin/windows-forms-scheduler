using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static C969.CustomerForms.CustomerRecords;
using static C969.Database.DbConnection;

namespace C969.Forms.AppointmentForms
{
    public partial class AddAppointment : Form
    {
        int selectedCustomerId;
        public AddAppointment(string customerName, int customerId)
        {
            InitializeComponent();
            nameInput.Text = customerName;
            selectedCustomerId = customerId;

            // custom time format to remove seconds
            timePicker.CustomFormat = "hh:mm tt";
        }

        public void createAppointment(string type)
        {
            try
            {
                // combine selected date and time
                DateTime start = datePicker.Value.Date.AddHours(timePicker.Value.Hour).AddMinutes(timePicker.Value.Minute);
                DateTime end = start.AddMinutes(30);

                // convert to UTC
                DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(start);
                DateTime endUtc = TimeZoneInfo.ConvertTimeToUtc(end);

                // check for overlapping appointments
                string checkQuery = @"
                SELECT COUNT(*) FROM appointment 
                WHERE (@start BETWEEN start AND end) 
                OR (@end BETWEEN start AND end) 
                OR (start BETWEEN @start AND @end) 
                OR (end BETWEEN @start AND @end)";

                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@start", startUtc);
                    checkCmd.Parameters.AddWithValue("@end", endUtc);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Error: Appointment overlaps with an existing appointment.");
                        return;
                    }
                }

                // convert to EST
                TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime startEST = TimeZoneInfo.ConvertTime(start, estZone);
                DateTime endEST = TimeZoneInfo.ConvertTime(end, estZone);

                // check for EST business hours
                if (startEST.Hour < 9 || startEST.Hour >= 17  || endEST.Hour == 17 && endEST.Minute == 01 || startEST.DayOfWeek == DayOfWeek.Saturday || startEST.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Appointments can only be scheduled Monday through Friday between 9 AM and 5 PM EST.");
                    return;
                }

                string query = @"
                    INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                    VALUES (@customerId, @userId, '', '', '', '', @type, '', @start, @end, NOW(), @createdBy, NOW(), @lastUpdateBy);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", selectedCustomerId);
                    cmd.Parameters.AddWithValue("userId", currentUserId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@start", startUtc);
                    cmd.Parameters.AddWithValue("@end", endUtc);
                    cmd.Parameters.AddWithValue("@createdBy", currentUser);
                    cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Appointment added");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // validate non empty input fields
            TextBox[] inputFields = { typeInput };
            if (!ValidationHelper.ValidateFields(inputFields))
            {
                return;
            };

            string type = typeInput.Text.Trim();
            createAppointment(type);
        }
    }
}
