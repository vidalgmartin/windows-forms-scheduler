namespace C969
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
            this.customerRecordsGrid = new System.Windows.Forms.DataGridView();
            this.customerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerRecordsGrid
            // 
            this.customerRecordsGrid.AllowUserToAddRows = false;
            this.customerRecordsGrid.AllowUserToDeleteRows = false;
            this.customerRecordsGrid.AllowUserToResizeColumns = false;
            this.customerRecordsGrid.AllowUserToResizeRows = false;
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
            this.addressColumn,
            this.cityColumn,
            this.countryColumn,
            this.phoneColumn});
            this.customerRecordsGrid.EnableHeadersVisualStyles = false;
            this.customerRecordsGrid.Location = new System.Drawing.Point(12, 80);
            this.customerRecordsGrid.MultiSelect = false;
            this.customerRecordsGrid.Name = "customerRecordsGrid";
            this.customerRecordsGrid.ReadOnly = true;
            this.customerRecordsGrid.RowHeadersVisible = false;
            this.customerRecordsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerRecordsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerRecordsGrid.ShowEditingIcon = false;
            this.customerRecordsGrid.Size = new System.Drawing.Size(776, 206);
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
            // addressColumn
            // 
            this.addressColumn.DataPropertyName = "addressId";
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
            // CustomerRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customerRecordsGrid);
            this.Name = "CustomerRecords";
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.customerRecordsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerRecordsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneColumn;
    }
}