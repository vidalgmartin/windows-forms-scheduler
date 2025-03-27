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
    public class CustomerAppointmentCount
    {
        public string CustomerName { get; set; }
        public int AppointmentCount { get; set; }

        public List<CustomerAppointmentCount> GetCustomerAppointmentCounts()
        {
            List<CustomerAppointmentCount> customerCounts = new List<CustomerAppointmentCount>();

            string query = @"
                SELECT 
                    c.customerName, 
                    COUNT(a.appointmentId) AS appointmentCount 
                FROM appointment a
                JOIN customer c ON a.customerId = c.customerId
                GROUP BY c.customerName
                ORDER BY appointmentCount DESC;";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerCounts.Add(new CustomerAppointmentCount
                            {
                                CustomerName = reader.GetString("customerName"),
                                AppointmentCount = reader.GetInt32("appointmentCount")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return customerCounts;
        }

        public void DisplayCustomersAppointmentCounts()
        {
            var customers = GetCustomerAppointmentCounts();

            // lambda expression to format customer appointment counts
            string reportText = string.Join("\n", customers.Select(c =>
                $"{c.CustomerName}: {c.AppointmentCount} appointments"));

            MessageBox.Show(reportText, "Customers Appointment Counts");
        }
    }
}
