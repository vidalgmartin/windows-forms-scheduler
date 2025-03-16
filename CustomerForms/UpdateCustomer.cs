using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static C969.Database.DbConnection;

namespace C969.CustomerForms
{
    public partial class UpdateCustomer : Form
    {
        private CustomerRecords.Customer _customer;
        public event Action CustomerUpdated;

        public UpdateCustomer(CustomerRecords.Customer customer)
        {
            InitializeComponent();
  
            _customer = customer;

            nameInput.Text = _customer.CustomerName;
            addressInput.Text = _customer.Address;
            cityInput.Text = _customer.City;
            countryInput.Text = _customer.Country;
            phoneInput.Text = _customer.Phone;
        }
        
        public void saveCustomerUpdates(int customerId, string updatedName, string updatedAddress, string updatedCity, string updatedCountry, string updatedPhone, int addressId)
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
                        cmd.Parameters.AddWithValue("@country", updatedCountry);
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
                        cmd.Parameters.AddWithValue("@city", updatedCity);
                        cmd.Parameters.AddWithValue("@countryId", countryId);
                        cmd.Parameters.AddWithValue("@createdBy", currentUser);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        cityId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // update address
                    string updateAddressQuery = @"
                        UPDATE address 
                        SET address = @updatedAddress, cityId = @cityId, phone = @updatedPhone, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                        WHERE addressId = @addressId;";

                    using (MySqlCommand cmd = new MySqlCommand(updateAddressQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@updatedAddress", updatedAddress);
                        cmd.Parameters.AddWithValue("@cityId", cityId);
                        cmd.Parameters.AddWithValue("@updatedPhone", updatedPhone);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        cmd.Parameters.AddWithValue("@addressId", addressId);
                        cmd.ExecuteNonQuery();
                    }

                    // update customer record
                    string updateCustomerQuery = @"
                        UPDATE customer 
                        SET customerName = @updatedName, lastUpdate = NOW(), lastUpdateBy = @lastUpdateBy
                        WHERE customerId = @customerId;";

                    using (MySqlCommand cmd = new MySqlCommand(updateCustomerQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@updatedName", updatedName);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }

                    // commit transaction
                    transaction.Commit();                 
                    MessageBox.Show("Customer updated");

                    // trigger event to notify CustomerRecords
                    CustomerUpdated?.Invoke();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // validate non empty input fields
            TextBox[] inputFields = { nameInput, addressInput, cityInput, countryInput, phoneInput };
            if (!ValidationHelper.ValidateFields(inputFields))
            {
                return;
            };

            // validate phone number
            if (!ValidationHelper.ValidatePhone(phoneInput.Text))
            {
                MessageBox.Show("Invalid phone number. Only digits and dashes allowed.");
                return;
            }

            int customerId = _customer.CustomerId;
            int addressId = _customer.AddressId;
            string updatedName = nameInput.Text.Trim();
            string updatedAddress = addressInput.Text.Trim();
            string updatedCity = cityInput.Text.Trim();
            string updatedCountry = countryInput.Text.Trim();
            string updatedPhone = phoneInput.Text.Trim();

            saveCustomerUpdates(customerId, updatedName, updatedAddress, updatedCity, updatedCountry, updatedPhone, addressId);
        }
    }
}
