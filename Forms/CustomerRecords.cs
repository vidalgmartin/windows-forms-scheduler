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
using C969.Models;
using C969.Reports;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace C969.CustomerForms
{
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {         
            InitializeComponent();
            LoadCustomers();
            LoadAppointments();
        }

        private void LoadCustomers()
        {
            customerRecordsGrid.DataSource = Customer.GetCustomers();
        }      

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.CustomerUpdated += LoadCustomers;
            addCustomer.Show();
        }

        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                UpdateCustomer updateCustomer = new UpdateCustomer(customer);
                updateCustomer.CustomerUpdated += LoadCustomers;
                updateCustomer.Show();
            }
        }

        private void deleteCustomerBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                Customer.DeleteCustomer(customer.CustomerId);
                LoadCustomers();
            }
        }

        private void LoadAppointments()
        {
            appointmentsGrid.DataSource = Appointment.GetAppointments();     
        }

        private void addAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (customerRecordsGrid.Rows.Count > 0)
            {
                var customer = (Customer)customerRecordsGrid.SelectedRows[0].DataBoundItem;

                AddAppointment addAppointment = new AddAppointment(customer.CustomerName, customer.CustomerId);
                addAppointment.AppointmentUpdated += LoadAppointments;
                addAppointment.Show();
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
                updateAppointment.AppointmentUpdated += LoadAppointments;
                updateAppointment.Show();
            }      
        }

        private void deleteAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.Rows.Count > 0)
            {
                var appointment = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;

                Appointment.DeleteAppointment(appointment.AppointmentId);
                LoadAppointments();
            }
        }

        private void dateViewBtn_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Value.Date;

            var appointmentsByDate = Appointment.GetAppointments().Where(a => a.Start.Date == selectedDate).ToList();
            appointmentsGrid.DataSource = appointmentsByDate;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void appointmentsReportBtn_Click(object sender, EventArgs e)
        {
            AppointmentReport appointmentReport = new AppointmentReport();
            appointmentReport.DisplayAppointmentReport();
        }

        private void userSchedulesBtn_Click(object sender, EventArgs e)
        {
            UserSchedule userSchedule = new UserSchedule();
            userSchedule.DisplayUserSchedules();
        }

        private void customerAppointmentsBtn_Click(object sender, EventArgs e)
        {
            CustomerAppointmentCount customerAppointmentCount = new CustomerAppointmentCount();
            customerAppointmentCount.DisplayCustomersAppointmentCounts();
        }
    }
}
