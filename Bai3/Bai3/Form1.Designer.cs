namespace Bai3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalPendingCost = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtServiceId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cboDeviceType = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nudEstimatedCost = new System.Windows.Forms.NumericUpDown();
            this.txtIssueDescription = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.picDevice = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(926, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportCsv,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(38, 20);
            this.menuFile.Text = "Tệp";
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // menuExportCsv
            // 
            this.menuExportCsv.Name = "menuExportCsv";
            this.menuExportCsv.Size = new System.Drawing.Size(192, 22);
            this.menuExportCsv.Text = "Xuất danh sách ra CSV";
            this.menuExportCsv.Click += new System.EventHandler(this.menuExportCsv_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(192, 22);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusCount,
            this.lblTotalPendingCost});
            this.statusStripMain.Location = new System.Drawing.Point(0, 462);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(926, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lblStatusCount
            // 
            this.lblStatusCount.Name = "lblStatusCount";
            this.lblStatusCount.Size = new System.Drawing.Size(99, 17);
            this.lblStatusCount.Text = "Số đơn hiển thị: 0";
            this.lblStatusCount.Click += new System.EventHandler(this.lblStatusCount_Click);
            // 
            // lblTotalPendingCost
            // 
            this.lblTotalPendingCost.Name = "lblTotalPendingCost";
            this.lblTotalPendingCost.Size = new System.Drawing.Size(188, 17);
            this.lblTotalPendingCost.Text = "Tổng chi phí chưa hoàn tất: 0 VNĐ";
            this.lblTotalPendingCost.Click += new System.EventHandler(this.lblTotalPendingCost_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.dgvOrders, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(926, 438);
            this.tlpMain.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboFilterStatus);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRemoveImage);
            this.panel1.Controls.Add(this.btnChooseImage);
            this.panel1.Controls.Add(this.picDevice);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.txtIssueDescription);
            this.panel1.Controls.Add(this.nudEstimatedCost);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.cboDeviceType);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtCustomerName);
            this.panel1.Controls.Add(this.txtServiceId);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 432);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại thiết bị";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày tiếp nhận";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chi phí dự kiến (VNĐ)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mô tả lỗi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Trạng thái";
            // 
            // txtServiceId
            // 
            this.txtServiceId.Location = new System.Drawing.Point(140, 4);
            this.txtServiceId.Name = "txtServiceId";
            this.txtServiceId.Size = new System.Drawing.Size(270, 20);
            this.txtServiceId.TabIndex = 8;
            this.txtServiceId.TextChanged += new System.EventHandler(this.txtServiceId_TextChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(140, 29);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(270, 20);
            this.txtCustomerName.TabIndex = 9;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(140, 54);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(270, 20);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // cboDeviceType
            // 
            this.cboDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceType.FormattingEnabled = true;
            this.cboDeviceType.Location = new System.Drawing.Point(140, 78);
            this.cboDeviceType.Name = "cboDeviceType";
            this.cboDeviceType.Size = new System.Drawing.Size(270, 21);
            this.cboDeviceType.TabIndex = 11;
            this.cboDeviceType.SelectedIndexChanged += new System.EventHandler(this.cboDeviceType_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "d/MM/yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(140, 105);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(270, 20);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // nudEstimatedCost
            // 
            this.nudEstimatedCost.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudEstimatedCost.Location = new System.Drawing.Point(140, 129);
            this.nudEstimatedCost.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudEstimatedCost.Name = "nudEstimatedCost";
            this.nudEstimatedCost.Size = new System.Drawing.Size(270, 20);
            this.nudEstimatedCost.TabIndex = 13;
            this.nudEstimatedCost.ThousandsSeparator = true;
            this.nudEstimatedCost.ValueChanged += new System.EventHandler(this.nudEstimatedCost_ValueChanged);
            // 
            // txtIssueDescription
            // 
            this.txtIssueDescription.Location = new System.Drawing.Point(140, 179);
            this.txtIssueDescription.Multiline = true;
            this.txtIssueDescription.Name = "txtIssueDescription";
            this.txtIssueDescription.Size = new System.Drawing.Size(270, 20);
            this.txtIssueDescription.TabIndex = 14;
            this.txtIssueDescription.TextChanged += new System.EventHandler(this.txtIssueDescription_TextChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(140, 153);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(270, 21);
            this.cboStatus.TabIndex = 15;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ảnh thiết bị";
            // 
            // picDevice
            // 
            this.picDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDevice.Location = new System.Drawing.Point(139, 209);
            this.picDevice.Name = "picDevice";
            this.picDevice.Size = new System.Drawing.Size(140, 100);
            this.picDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDevice.TabIndex = 17;
            this.picDevice.TabStop = false;
            this.picDevice.Click += new System.EventHandler(this.picDevice_Click);
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.Location = new System.Drawing.Point(317, 219);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(93, 23);
            this.btnChooseImage.TabIndex = 18;
            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImage.Location = new System.Drawing.Point(317, 272);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(93, 23);
            this.btnRemoveImage.TabIndex = 19;
            this.btnRemoveImage.Text = "Xóa ảnh";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 316);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Thêm đơn";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(121, 315);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(227, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Xóa đơn";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(335, 315);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Tìm kiếm (Mã / Tên / SĐT)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "Lọc trạng thái";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(165, 357);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(245, 20);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(165, 390);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(245, 21);
            this.cboFilterStatus.TabIndex = 27;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(443, 3);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(480, 432);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 484);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "Form1";
            this.Text = "Repair Service Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCount;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalPendingCost;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudEstimatedCost;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboDeviceType;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtServiceId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtIssueDescription;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.PictureBox picDevice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}

