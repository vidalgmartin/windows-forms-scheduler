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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static C969.Database.DbConnection;

namespace C969.CustomerForms
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        public void createCustomer(string customerName, string address, string city, string country, string phone)
        {
            try
            {
                // using a transaction so data is only inserted if everything is successful
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    // get or insert country
                    int countryId;
                    string countryQuery = @"
                        INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                        SELECT @country, NOW(), @createdBy, NOW(), @lastUpdateBy
                        WHERE NOT EXISTS (SELECT 1 FROM country WHERE country = @country);
                        SELECT countryId FROM country WHERE country = @country;";

                    using (MySqlCommand cmd = new MySqlCommand(countryQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@createdBy", currentUser);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        countryId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // get or insert city
                    int cityId;
                    string cityQuery = @"
                        INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                        SELECT @city, @countryId, NOW(), @createdBy, NOW(), @lastUpdateBy
                        WHERE NOT EXISTS (SELECT 1 FROM city WHERE city = @city AND countryId = @countryId);
                        SELECT cityId FROM city WHERE city = @city AND countryId = @countryId;";

                    using (MySqlCommand cmd = new MySqlCommand(cityQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@countryId", countryId);
                        cmd.Parameters.AddWithValue("@createdBy", currentUser);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        cityId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // insert address
                    int addressId;
                    string addressQuery = @"
                        INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
                        VALUES (@address, '', @cityId, '', @phone, NOW(), @createdBy, NOW(), @lastUpdateBy); SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new MySqlCommand(addressQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@cityId", cityId);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@createdBy", currentUser);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        addressId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // insert customer
                    string customerQuery = @"
                        INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                        VALUES (@customerName, @addressId, 1, NOW(), @createdBy, NOW(), @lastUpdateBy);";

                    using (MySqlCommand cmd = new MySqlCommand(customerQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@customerName", customerName);
                        cmd.Parameters.AddWithValue("@addressId", addressId);
                        cmd.Parameters.AddWithValue("@createdBy", currentUser);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        cmd.ExecuteNonQuery();
                    }

                    // complete the transaction
                    transaction.Commit();
                    MessageBox.Show("Customer added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            createCustomer(nameInput.Text, addressInput.Text, cityInput.Text, countryInput.Text, phoneInput.Text);
            this.Close();
        }
    }
}
