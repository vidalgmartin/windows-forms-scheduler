﻿namespace C969.CustomerForms
{
    partial class CustomerRecords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customerRecordsGrid = new System.Windows.Forms.DataGridView();
            this.customerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addCustomerBtn = new System.Windows.Forms.Button();
            this.updateCustomerBtn = new System.Windows.Forms.Button();
            this.deleteCustomerBtn = new System.Windows.Forms.Button();
            this.appointmentsGrid = new System.Windows.Forms.DataGridView();
            this.appointmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteAppointmentBtn = new System.Windows.Forms.Button();
            this.updateAppointmentBtn = new System.Windows.Forms.Button();
            this.addAppointmentBtn = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.dateViewBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.appointmentsReportBtn = new System.Windows.Forms.Button();
            this.userSchedulesBtn = new System.Windows.Forms.Button();
            this.customerAppointmentsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerRecordsGrid
            // 
            this.customerRecordsGrid.AllowUserToAddRows = false;
            this.customerRecordsGrid.AllowUserToDeleteRows = false;
            this.customerRecordsGrid.AllowUserToResizeColumns = false;
            this.customerRecordsGrid.AllowUserToResizeRows = false;
            this.customerRecordsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerRecordsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerRecordsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.customerRecordsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerRecordsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerId,
            this.nameColumn,
            this.addressId,
            this.addressColumn,
            this.cityColumn,
            this.countryColumn,
            this.phoneColumn});
            this.customerRecordsGrid.EnableHeadersVisualStyles = false;
            this.customerRecordsGrid.Location = new System.Drawing.Point(65, 81);
            this.customerRecordsGrid.MultiSelect = false;
            this.customerRecordsGrid.Name = "customerRecordsGrid";
            this.customerRecordsGrid.ReadOnly = true;
            this.customerRecordsGrid.RowHeadersVisible = false;
            this.customerRecordsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerRecordsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerRecordsGrid.ShowEditingIcon = false;
            this.customerRecordsGrid.Size = new System.Drawing.Size(800, 250);
            this.customerRecordsGrid.TabIndex = 0;
            // 
            // customerId
            // 
            this.customerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customerId.DataPropertyName = "customerId";
            this.customerId.FillWeight = 304.5685F;
            this.customerId.HeaderText = "Customer ID";
            this.customerId.Name = "customerId";
            this.customerId.ReadOnly = true;
            this.customerId.Width = 90;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "customerName";
            this.nameColumn.FillWeight = 59.08629F;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // addressId
            // 
            this.addressId.DataPropertyName = "addressId";
            this.addressId.HeaderText = "AddressID";
            this.addressId.Name = "addressId";
            this.addressId.ReadOnly = true;
            this.addressId.Visible = false;
            // 
            // addressColumn
            // 
            this.addressColumn.DataPropertyName = "address";
            this.addressColumn.FillWeight = 59.08629F;
            this.addressColumn.HeaderText = "Address";
            this.addressColumn.Name = "addressColumn";
            this.addressColumn.ReadOnly = true;
            // 
            // cityColumn
            // 
            this.cityColumn.DataPropertyName = "city";
            this.cityColumn.FillWeight = 59.08629F;
            this.cityColumn.HeaderText = "City";
            this.cityColumn.Name = "cityColumn";
            this.cityColumn.ReadOnly = true;
            // 
            // countryColumn
            // 
            this.countryColumn.DataPropertyName = "country";
            this.countryColumn.FillWeight = 59.08629F;
            this.countryColumn.HeaderText = "Country";
            this.countryColumn.Name = "countryColumn";
            this.countryColumn.ReadOnly = true;
            // 
            // phoneColumn
            // 
            this.phoneColumn.DataPropertyName = "phone";
            this.phoneColumn.FillWeight = 59.08629F;
            this.phoneColumn.HeaderText = "Phone";
            this.phoneColumn.Name = "phoneColumn";
            this.phoneColumn.ReadOnly = true;
            // 
            // addCustomerBtn
            // 
            this.addCustomerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addCustomerBtn.Location = new System.Drawing.Point(614, 337);
            this.addCustomerBtn.Name = "addCustomerBtn";
            this.addCustomerBtn.Size = new System.Drawing.Size(75, 30);
            this.addCustomerBtn.TabIndex = 1;
            this.addCustomerBtn.Text = "Add";
            this.addCustomerBtn.UseVisualStyleBackColor = true;
            this.addCustomerBtn.Click += new System.EventHandler(this.addCustomerBtn_Click);
            // 
            // updateCustomerBtn
            // 
            this.updateCustomerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateCustomerBtn.Location = new System.Drawing.Point(702, 337);
            this.updateCustomerBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.updateCustomerBtn.Name = "updateCustomerBtn";
            this.updateCustomerBtn.Size = new System.Drawing.Size(75, 30);
            this.updateCustomerBtn.TabIndex = 2;
            this.updateCustomerBtn.Text = "Update";
            this.updateCustomerBtn.UseVisualStyleBackColor = true;
            this.updateCustomerBtn.Click += new System.EventHandler(this.updateCustomerBtn_Click);
            // 
            // deleteCustomerBtn
            // 
            this.deleteCustomerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteCustomerBtn.Location = new System.Drawing.Point(790, 337);
            this.deleteCustomerBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.deleteCustomerBtn.Name = "deleteCustomerBtn";
            this.deleteCustomerBtn.Size = new System.Drawing.Size(75, 30);
            this.deleteCustomerBtn.TabIndex = 3;
            this.deleteCustomerBtn.Text = "Delete";
            this.deleteCustomerBtn.UseVisualStyleBackColor = true;
            this.deleteCustomerBtn.Click += new System.EventHandler(this.deleteCustomerBtn_Click);
            // 
            // appointmentsGrid
            // 
            this.appointmentsGrid.AllowUserToAddRows = false;
            this.appointmentsGrid.AllowUserToDeleteRows = false;
            this.appointmentsGrid.AllowUserToResizeColumns = false;
            this.appointmentsGrid.AllowUserToResizeRows = false;
            this.appointmentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appointmentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.appointmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentId,
            this.dataGridViewTextBoxColumn1,
            this.customerName,
            this.type,
            this.start,
            this.end});
            this.appointmentsGrid.EnableHeadersVisualStyles = false;
            this.appointmentsGrid.Location = new System.Drawing.Point(65, 505);
            this.appointmentsGrid.MultiSelect = false;
            this.appointmentsGrid.Name = "appointmentsGrid";
            this.appointmentsGrid.ReadOnly = true;
            this.appointmentsGrid.RowHeadersVisible = false;
            this.appointmentsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.appointmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsGrid.ShowEditingIcon = false;
            this.appointmentsGrid.Size = new System.Drawing.Size(800, 250);
            this.appointmentsGrid.TabIndex = 5;
            // 
            // appointmentId
            // 
            this.appointmentId.DataPropertyName = "appointmentId";
            this.appointmentId.FillWeight = 45F;
            this.appointmentId.HeaderText = "AppointmentID";
            this.appointmentId.Name = "appointmentId";
            this.appointmentId.ReadOnly = true;
            this.appointmentId.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "customerId";
            this.dataGridViewTextBoxColumn1.FillWeight = 30F;
            this.dataGridViewTextBoxColumn1.HeaderText = "CustomerID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "customerName";
            this.customerName.FillWeight = 60F;
            this.customerName.HeaderText = "Name";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.FillWeight = 60.10604F;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // start
            // 
            this.start.DataPropertyName = "start";
            this.start.FillWeight = 60.10604F;
            this.start.HeaderText = "Start";
            this.start.Name = "start";
            this.start.ReadOnly = true;
            // 
            // end
            // 
            this.end.DataPropertyName = "end";
            this.end.FillWeight = 60.10604F;
            this.end.HeaderText = "End";
            this.end.Name = "end";
            this.end.ReadOnly = true;
            // 
            // deleteAppointmentBtn
            // 
            this.deleteAppointmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAppointmentBtn.Location = new System.Drawing.Point(790, 761);
            this.deleteAppointmentBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.deleteAppointmentBtn.Name = "deleteAppointmentBtn";
            this.deleteAppointmentBtn.Size = new System.Drawing.Size(75, 30);
            this.deleteAppointmentBtn.TabIndex = 8;
            this.deleteAppointmentBtn.Text = "Delete";
            this.deleteAppointmentBtn.UseVisualStyleBackColor = true;
            this.deleteAppointmentBtn.Click += new System.EventHandler(this.deleteAppointmentBtn_Click);
            // 
            // updateAppointmentBtn
            // 
            this.updateAppointmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateAppointmentBtn.Location = new System.Drawing.Point(702, 761);
            this.updateAppointmentBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.updateAppointmentBtn.Name = "updateAppointmentBtn";
            this.updateAppointmentBtn.Size = new System.Drawing.Size(75, 30);
            this.updateAppointmentBtn.TabIndex = 7;
            this.updateAppointmentBtn.Text = "Update";
            this.updateAppointmentBtn.UseVisualStyleBackColor = true;
            this.updateAppointmentBtn.Click += new System.EventHandler(this.updateAppointmentBtn_Click);
            // 
            // addAppointmentBtn
            // 
            this.addAppointmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addAppointmentBtn.Location = new System.Drawing.Point(614, 761);
            this.addAppointmentBtn.Name = "addAppointmentBtn";
            this.addAppointmentBtn.Size = new System.Drawing.Size(75, 30);
            this.addAppointmentBtn.TabIndex = 6;
            this.addAppointmentBtn.Text = "Add";
            this.addAppointmentBtn.UseVisualStyleBackColor = true;
            this.addAppointmentBtn.Click += new System.EventHandler(this.addAppointmentBtn_Click);
            // 
            // datePicker
            // 
            this.datePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePicker.Location = new System.Drawing.Point(489, 471);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(214, 20);
            this.datePicker.TabIndex = 9;
            // 
            // dateViewBtn
            // 
            this.dateViewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateViewBtn.Location = new System.Drawing.Point(709, 468);
            this.dateViewBtn.Name = "dateViewBtn";
            this.dateViewBtn.Size = new System.Drawing.Size(75, 23);
            this.dateViewBtn.TabIndex = 10;
            this.dateViewBtn.Text = "view";
            this.dateViewBtn.UseVisualStyleBackColor = true;
            this.dateViewBtn.Click += new System.EventHandler(this.dateViewBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.Location = new System.Drawing.Point(790, 468);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 11;
            this.resetBtn.Text = "reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // appointmentsReportBtn
            // 
            this.appointmentsReportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentsReportBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.appointmentsReportBtn.Location = new System.Drawing.Point(65, 761);
            this.appointmentsReportBtn.Name = "appointmentsReportBtn";
            this.appointmentsReportBtn.Size = new System.Drawing.Size(120, 40);
            this.appointmentsReportBtn.TabIndex = 12;
            this.appointmentsReportBtn.Text = "Appointments by Month";
            this.appointmentsReportBtn.UseVisualStyleBackColor = false;
            this.appointmentsReportBtn.Click += new System.EventHandler(this.appointmentsReportBtn_Click);
            // 
            // userSchedulesBtn
            // 
            this.userSchedulesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userSchedulesBtn.Location = new System.Drawing.Point(317, 761);
            this.userSchedulesBtn.Name = "userSchedulesBtn";
            this.userSchedulesBtn.Size = new System.Drawing.Size(120, 40);
            this.userSchedulesBtn.TabIndex = 13;
            this.userSchedulesBtn.Text = "User Schedules";
            this.userSchedulesBtn.UseVisualStyleBackColor = true;
            this.userSchedulesBtn.Click += new System.EventHandler(this.userSchedulesBtn_Click);
            // 
            // customerAppointmentsBtn
            // 
            this.customerAppointmentsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerAppointmentsBtn.Location = new System.Drawing.Point(191, 761);
            this.customerAppointmentsBtn.Name = "customerAppointmentsBtn";
            this.customerAppointmentsBtn.Size = new System.Drawing.Size(120, 40);
            this.customerAppointmentsBtn.TabIndex = 14;
            this.customerAppointmentsBtn.Text = "Appointments by Customer";
            this.customerAppointmentsBtn.UseVisualStyleBackColor = true;
            this.customerAppointmentsBtn.Click += new System.EventHandler(this.customerAppointmentsBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Appointments";
            // 
            // CustomerRecords
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 861);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerAppointmentsBtn);
            this.Controls.Add(this.userSchedulesBtn);
            this.Controls.Add(this.appointmentsReportBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.dateViewBtn);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.deleteAppointmentBtn);
            this.Controls.Add(this.updateAppointmentBtn);
            this.Controls.Add(this.addAppointmentBtn);
            this.Controls.Add(this.appointmentsGrid);
            this.Controls.Add(this.deleteCustomerBtn);
            this.Controls.Add(this.updateCustomerBtn);
            this.Controls.Add(this.addCustomerBtn);
            this.Controls.Add(this.customerRecordsGrid);
            this.Name = "CustomerRecords";
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerRecordsGrid;
        private System.Windows.Forms.Button addCustomerBtn;
        private System.Windows.Forms.Button updateCustomerBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressId;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneColumn;
        private System.Windows.Forms.Button deleteCustomerBtn;
        private System.Windows.Forms.DataGridView appointmentsGrid;
        private System.Windows.Forms.Button deleteAppointmentBtn;
        private System.Windows.Forms.Button updateAppointmentBtn;
        private System.Windows.Forms.Button addAppointmentBtn;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button dateViewBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button appointmentsReportBtn;
        private System.Windows.Forms.Button userSchedulesBtn;
        private System.Windows.Forms.Button customerAppointmentsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
    }
}