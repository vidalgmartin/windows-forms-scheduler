using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static C969.Database.DbConnection;

namespace C969.Reports
{
    public class AppointmentReport
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Total { get; set; }

        public List<AppointmentReport> GetAppointmentReport()
        {
            List<AppointmentReport> report = new List<AppointmentReport>();

            string query = @"
                SELECT 
                    MONTH(start) AS month, 
                    YEAR(start) AS year, 
                    type, 
                    COUNT(*) AS total
                FROM appointment
                GROUP BY year, month, type
                ORDER BY year, month;";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            report.Add(new AppointmentReport
                            {
                                Month = reader.GetInt32("month"),
                                Year = reader.GetInt32("year"),
                                Type = reader.GetString("type"),
                                Total = reader.GetInt32("total")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return report;
        }

        public void DisplayAppointmentReport()
        {
            var reportData = GetAppointmentReport();

            // lambda expression to format the appointment report
            string reportText = string.Join("\n", reportData.Select(r =>
                $"{new DateTime(r.Year, r.Month, 1):MMMM yyyy}: {r.Type} - {r.Total} appointments"));

            MessageBox.Show(reportText, "Appointments Report");
        }
     }
}
