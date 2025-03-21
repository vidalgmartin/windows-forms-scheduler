namespace C969.CustomerForms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.customerRecordsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerRecordsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.customerRecordsGrid.Location = new System.Drawing.Point(29, 24);
            this.customerRecordsGrid.MultiSelect = false;
            this.customerRecordsGrid.Name = "customerRecordsGrid";
            this.customerRecordsGrid.ReadOnly = true;
            this.customerRecordsGrid.RowHeadersVisible = false;
            this.customerRecordsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerRecordsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerRecordsGrid.ShowEditingIcon = false;
            this.customerRecordsGrid.Size = new System.Drawing.Size(776, 275);
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
            this.addCustomerBtn.Location = new System.Drawing.Point(479, 316);
            this.addCustomerBtn.Name = "addCustomerBtn";
            this.addCustomerBtn.Size = new System.Drawing.Size(100, 40);
            this.addCustomerBtn.TabIndex = 1;
            this.addCustomerBtn.Text = "Add";
            this.addCustomerBtn.UseVisualStyleBackColor = true;
            this.addCustomerBtn.Click += new System.EventHandler(this.addCustomerBtn_Click);
            // 
            // updateCustomerBtn
            // 
            this.updateCustomerBtn.Location = new System.Drawing.Point(592, 316);
            this.updateCustomerBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.updateCustomerBtn.Name = "updateCustomerBtn";
            this.updateCustomerBtn.Size = new System.Drawing.Size(100, 40);
            this.updateCustomerBtn.TabIndex = 2;
            this.updateCustomerBtn.Text = "Update";
            this.updateCustomerBtn.UseVisualStyleBackColor = true;
            this.updateCustomerBtn.Click += new System.EventHandler(this.updateCustomerBtn_Click);
            // 
            // deleteCustomerBtn
            // 
            this.deleteCustomerBtn.Location = new System.Drawing.Point(705, 316);
            this.deleteCustomerBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.deleteCustomerBtn.Name = "deleteCustomerBtn";
            this.deleteCustomerBtn.Size = new System.Drawing.Size(100, 40);
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
            this.appointmentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appointmentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.appointmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentId,
            this.dataGridViewTextBoxColumn1,
            this.customerName,
            this.type,
            this.start,
            this.end});
            this.appointmentsGrid.EnableHeadersVisualStyles = false;
            this.appointmentsGrid.Location = new System.Drawing.Point(29, 429);
            this.appointmentsGrid.MultiSelect = false;
            this.appointmentsGrid.Name = "appointmentsGrid";
            this.appointmentsGrid.ReadOnly = true;
            this.appointmentsGrid.RowHeadersVisible = false;
            this.appointmentsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.appointmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsGrid.ShowEditingIcon = false;
            this.appointmentsGrid.Size = new System.Drawing.Size(776, 275);
            this.appointmentsGrid.TabIndex = 5;
            // 
            // appointmentId
            // 
            this.appointmentId.DataPropertyName = "appointmentId";
            this.appointmentId.FillWeight = 45F;
            this.appointmentId.HeaderText = "AppointmentID";
            this.appointmentId.Name = "appointmentId";
            this.appointmentId.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "customerId";
            this.dataGridViewTextBoxColumn1.FillWeight = 45F;
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
            this.deleteAppointmentBtn.Location = new System.Drawing.Point(705, 720);
            this.deleteAppointmentBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.deleteAppointmentBtn.Name = "deleteAppointmentBtn";
            this.deleteAppointmentBtn.Size = new System.Drawing.Size(100, 40);
            this.deleteAppointmentBtn.TabIndex = 8;
            this.deleteAppointmentBtn.Text = "Delete";
            this.deleteAppointmentBtn.UseVisualStyleBackColor = true;
            this.deleteAppointmentBtn.Click += new System.EventHandler(this.deleteAppointmentBtn_Click);
            // 
            // updateAppointmentBtn
            // 
            this.updateAppointmentBtn.Location = new System.Drawing.Point(592, 720);
            this.updateAppointmentBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.updateAppointmentBtn.Name = "updateAppointmentBtn";
            this.updateAppointmentBtn.Size = new System.Drawing.Size(100, 40);
            this.updateAppointmentBtn.TabIndex = 7;
            this.updateAppointmentBtn.Text = "Update";
            this.updateAppointmentBtn.UseVisualStyleBackColor = true;
            this.updateAppointmentBtn.Click += new System.EventHandler(this.updateAppointmentBtn_Click);
            // 
            // addAppointmentBtn
            // 
            this.addAppointmentBtn.Location = new System.Drawing.Point(479, 720);
            this.addAppointmentBtn.Name = "addAppointmentBtn";
            this.addAppointmentBtn.Size = new System.Drawing.Size(100, 40);
            this.addAppointmentBtn.TabIndex = 6;
            this.addAppointmentBtn.Text = "Add";
            this.addAppointmentBtn.UseVisualStyleBackColor = true;
            this.addAppointmentBtn.Click += new System.EventHandler(this.addAppointmentBtn_Click);
            // 
            // CustomerRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 813);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
    }
}