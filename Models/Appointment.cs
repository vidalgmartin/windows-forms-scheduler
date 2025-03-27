using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static C969.Database.DbConnection;

namespace C969.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static BindingList<Appointment> GetAppointments()
        {
            BindingList<Appointment> appointments = new BindingList<Appointment>();

            try
            {
                string query = @"
                    SELECT 
                        a.appointmentId, 
                        a.customerId, 
                        c.customerName, 
                        a.type, 
                        a.start, 
                        a.end
                    FROM appointment a
                    JOIN customer c ON a.customerId = c.customerId
                    ORDER BY a.start ASC;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // get UTC times from DB
                            DateTime startUtc = reader.GetDateTime("start");
                            DateTime endUtc = reader.GetDateTime("end");

                            // convert to local time
                            DateTime startLocal = TimeZoneInfo.ConvertTimeFromUtc(startUtc, TimeZoneInfo.Local);
                            DateTime endLocal = TimeZoneInfo.ConvertTimeFromUtc(endUtc, TimeZoneInfo.Local);

                            appointments.Add(new Appointment
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                CustomerId = reader.GetInt32("customerId"),
                                CustomerName = reader.GetString("customerName"),
                                Type = reader.GetString("type"),
                                Start = startLocal,
                                End = endLocal
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return appointments;
        }

        public static void DeleteAppointment(int appointmentId)
        {
            try
            {
                string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                    DialogResult confirm = MessageBox.Show("Proceed to delete this appointment?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
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
