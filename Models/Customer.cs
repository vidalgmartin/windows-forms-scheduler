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
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public static BindingList<Customer> GetCustomers()
        {
            BindingList<Customer> customers = new BindingList<Customer>();

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
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = reader.GetInt32("customerId"),
                                CustomerName = reader.GetString("customerName"),
                                AddressId = reader.GetInt32("addressId"),
                                Address = reader.GetString("address"),
                                City = reader.GetString("city"),
                                Country = reader.GetString("country"),
                                Phone = reader.GetString("phone")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return customers;
        }

        public static void DeleteCustomer(int customerId)
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
    }
}
