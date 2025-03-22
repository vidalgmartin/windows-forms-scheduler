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
    public partial class UpdateAppointment : Form
    {
        public event Action AppointmentUpdated;
        int selectedAppointmentId;
        int selectedCustomerId;
        public UpdateAppointment(int appointmentId, int customerId, string customerName, string type, DateTime start)
        {
            InitializeComponent();

            // custom time format to remove date and seconds
            timePicker.CustomFormat = "hh:mm tt";

            selectedAppointmentId = appointmentId;
            selectedCustomerId = customerId;
            nameInput.Text = customerName;
            typeInput.Text = type;

            // convert to UTC and then to local time for display
            DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(start);
            DateTime startLocal = TimeZoneInfo.ConvertTimeFromUtc(startUtc, TimeZoneInfo.Local);

            datePicker.Value = startLocal;
            timePicker.Value = startLocal;
        }

        public void SaveAppointmentUpdate(int appointmentId, int customerId, string type, DateTime start, DateTime end)
        {
            try
            {
                // convert time to UTC
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
                        MessageBox.Show("Appointment overlaps with an existing appointment.");
                        return;
                    }
                }

                // convert time to EST
                TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime startEST = TimeZoneInfo.ConvertTime(start, estZone);
                DateTime endEST = TimeZoneInfo.ConvertTime(end, estZone);

                // check for EST business hours
                if (startEST.Hour < 9 || startEST.Hour >= 17 || endEST.Hour == 17 && endEST.Minute == 01 || startEST.DayOfWeek == DayOfWeek.Saturday || startEST.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Appointments can only be scheduled Monday through Friday between 9 AM and 5 PM EST.");
                    return;
                }

                string query = @"
                    UPDATE appointment 
                    SET customerId = @customerId, 
                        type = @type, 
                        start = @start, 
                        end = @end, 
                        lastUpdate = NOW(), 
                        lastUpdateBy = @lastUpdateBy
                    WHERE appointmentId = @appointmentId;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@start", startUtc);
                    cmd.Parameters.AddWithValue("@end", endUtc);
                    cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Appointment updated successfully.");
                AppointmentUpdated?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message);
            } 
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // validate non empty input fields
            TextBox[] inputFields = { typeInput };
            if (!ValidationHelper.ValidateFields(inputFields))
            {
                return;
            };

            int appointmentId = selectedAppointmentId;
            int customerId = selectedCustomerId;
            string type = typeInput.Text.Trim();
            DateTime start = datePicker.Value.Date.AddHours(timePicker.Value.Hour).AddMinutes(timePicker.Value.Minute);
            DateTime end = start.AddMinutes(30);

            SaveAppointmentUpdate(appointmentId, customerId, type, start, end);
        }
    }
}
