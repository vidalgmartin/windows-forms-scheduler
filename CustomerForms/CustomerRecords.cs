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

namespace C969.CustomerForms
{
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {
            InitializeComponent();

            GetCustomerRecords();
            customerRecordsGrid.DataSource = Customers;
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

        public void GetCustomerRecords()
        {
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
            addCustomer.Show();
        }

        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                UpdateCustomer updateCustomer = new UpdateCustomer(customer);
                updateCustomer.Show();
            }
        }
    }
}
