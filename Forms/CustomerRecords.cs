using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using C969.Forms.AppointmentForms;
using MySql.Data.MySqlClient;
using static C969.Database.DbConnection;

namespace C969.CustomerForms
{
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {         
            InitializeComponent();
            GetCustomers();
            GetAppointments();
        }

        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public int AddressId { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
        }

        public BindingList<Customer> Customers { get; set; } = new BindingList<Customer>();

        public void GetCustomers()
        {
            // clear customer list to avoid duplication
            Customers.Clear();

            try
            {
                string query = @"
                    SELECT 
                        c.customerId,
                        c.customerName,
                        a.addressId,
                        a.address,
                        ci.city,
                        co.country,
                        a.phone
                    FROM customer c
                    JOIN address a ON c.addressId = a.addressId
                    JOIN city ci ON a.cityId = ci.cityId
                    JOIN country co ON ci.countryId = co.countryId;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {

                            Customer customer = new Customer
                            {
                                CustomerId = reader.GetInt32("customerId"),
                                CustomerName = reader.GetString("customerName"),
                                AddressId = reader.GetInt32("addressId"),
                                Address = reader.GetString("address"),
                                City = reader.GetString("city"),
                                Country = reader.GetString("country"),
                                Phone = reader.GetString("phone")
                            };

                            Customers.Add(customer);

                            // add customers data to data grid                           
                            customerRecordsGrid.DataSource = Customers;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.CustomerUpdated += GetCustomers;
            addCustomer.Show();
        }

        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                UpdateCustomer updateCustomer = new UpdateCustomer(customer);
                updateCustomer.CustomerUpdated += GetCustomers;
                updateCustomer.Show();
            }
        }

        private void DeleteCustomer(int customerId)
        {
            try
            {
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    int addressId = 0;
                    int cityId = 0;
                    int countryId = 0;

                    // get the associated addressId, cityId, and countryId before deleting the customer
                    string getIdsQuery = @"
                        SELECT a.addressId, ci.cityId, co.countryId
                        FROM customer c
                        JOIN address a ON c.addressId = a.addressId
                        JOIN city ci ON a.cityId = ci.cityId
                        JOIN country co ON ci.countryId = co.countryId
                        WHERE c.customerId = @customerId;";

                    using (MySqlCommand cmd = new MySqlCommand(getIdsQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                addressId = reader.GetInt32("addressId");
                                cityId = reader.GetInt32("cityId");
                                countryId = reader.GetInt32("countryId");
                            }
                        }
                    }

                    // delete appointments if available
                    string deleteAppointmentsQuery = "DELETE FROM appointment WHERE customerId = @customerId;";
                    using (MySqlCommand cmd = new MySqlCommand(deleteAppointmentsQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    // delete customer
                    string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId;";
                    using (MySqlCommand cmd = new MySqlCommand(deleteCustomerQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    // check if the address is still used by another customer before deleting
                    string checkAddressQuery = "SELECT COUNT(*) FROM customer WHERE addressId = @addressId;";
                    using (MySqlCommand cmd = new MySqlCommand(checkAddressQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@addressId", addressId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string deleteAddressQuery = "DELETE FROM address WHERE addressId = @addressId;";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteAddressQuery, connection, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@addressId", addressId);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // check if the city is still used by another address before deleting
                    string checkCityQuery = "SELECT COUNT(*) FROM address WHERE cityId = @cityId;";
                    using (MySqlCommand cmd = new MySqlCommand(checkCityQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@cityId", cityId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string deleteCityQuery = "DELETE FROM city WHERE cityId = @cityId;";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteCityQuery, connection, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@cityId", cityId);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // check if the country is still used by another city before deleting
                    string checkCountryQuery = "SELECT COUNT(*) FROM city WHERE countryId = @countryId;";
                    using (MySqlCommand cmd = new MySqlCommand(checkCountryQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@countryId", countryId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string deleteCountryQuery = "DELETE FROM country WHERE countryId = @countryId;";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteCountryQuery, connection, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@countryId", countryId);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    DialogResult confirm = MessageBox.Show("Proceed to delete this customer?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void deleteCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                DeleteCustomer(customer.CustomerId);
                GetCustomers();
            }
        }

        public class Appointment
        {
            public int AppointmentId { get; set; }
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string Type { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        public BindingList<Appointment> Appointments { get; set; } = new BindingList<Appointment>();

        public void GetAppointments()
        {
            // clear appointments list to avoid duplication
            Appointments.Clear();

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
                    JOIN customer c ON a.customerId = c.customerId;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                CustomerId = reader.GetInt32("customerId"),
                                CustomerName = reader.GetString("customerName"),
                                Type = reader.GetString("type"),
                                Start = reader.GetDateTime("start"),
                                End = reader.GetDateTime("end")
                            };

                            Appointments.Add(appointment);
                            appointmentsGrid.DataSource = Appointments;

                            // add the time to the columns
                            appointmentsGrid.Columns["Start"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                            appointmentsGrid.Columns["End"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                AddAppointment addAppointment = new AddAppointment(customer.CustomerName, customer.CustomerId);
                addAppointment.AppointmentUpdated += GetAppointments;
                addAppointment.Show();
            }       
        }

        private void DeleteAppointment(int appointmentId)
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
                        GetAppointments();
                    }                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.Rows.Count > 0) {
                var appointment = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;

                DeleteAppointment(appointment.AppointmentId);
            }
        }

        private void updateAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.Rows.Count > 0)
            {
                var appointment = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;

                int appointmentId = appointment.AppointmentId;
                int customerId = appointment.CustomerId;
                string customerName = appointment.CustomerName;
                string type = appointment.Type;
                DateTime start = appointment.Start;

                UpdateAppointment updateAppointment = new UpdateAppointment(appointmentId, customerId, customerName, type, start);
                updateAppointment.AppointmentUpdated += GetAppointments;
                updateAppointment.Show();
            }      
        }
    }
}
