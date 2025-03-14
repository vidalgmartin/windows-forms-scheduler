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
using static C969.Database.DbConnection;

namespace C969
{
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {
            InitializeComponent();

            GetCustomer();
            customerRecordsGrid.DataSource = Customers;
        }

        public class Customer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string AddressId { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
        }

        public BindingList<Customer> Customers { get; set; } = new BindingList<Customer>();

        public void GetCustomer()
        {
            try
            {
                string query = @"
                                SELECT 
                                    c.customerId,
                                    c.customerName,
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
                                AddressId = reader.GetString("address"),
                                City = reader.GetString("city"),
                                Country = reader.GetString("country"),
                                Phone = reader.GetString("phone")
                            };

                            Customers.Add(customer);
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
