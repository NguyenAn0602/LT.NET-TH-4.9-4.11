namespace Bai2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheckoutId = new System.Windows.Forms.TextBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.cboEquipment = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpActualReturnDate = new System.Windows.Forms.DateTimePicker();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMarkReturned = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvCheckouts = new System.Windows.Forms.DataGridView();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckouts)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(920, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(283, 17);
            this.lblStatusInfo.Text = "Tổng số phiếu: 0 | Phiếu quá hạn: 0 | Đang hiển thị: 0";
            this.lblStatusInfo.Click += new System.EventHandler(this.lblStatusInfo_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.dgvCheckouts, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(920, 414);
            this.tlpMain.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboFilterStatus);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnMarkReturned);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.dtpActualReturnDate);
            this.panel1.Controls.Add(this.dtpDueDate);
            this.panel1.Controls.Add(this.dtpBorrowDate);
            this.panel1.Controls.Add(this.nudQuantity);
            this.panel1.Controls.Add(this.cboEquipment);
            this.panel1.Controls.Add(this.txtStudentName);
            this.panel1.Controls.Add(this.txtStudentId);
            this.panel1.Controls.Add(this.txtCheckoutId);
            this.panel1.Controls.Add(this.label9);
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
            this.panel1.Size = new System.Drawing.Size(414, 408);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sinh viên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên sinh viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thiết bị";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày mượn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hạn trả";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày trả thực tế";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tình trạng";
            // 
            // txtCheckoutId
            // 
            this.txtCheckoutId.Location = new System.Drawing.Point(112, 33);
            this.txtCheckoutId.Name = "txtCheckoutId";
            this.txtCheckoutId.Size = new System.Drawing.Size(281, 20);
            this.txtCheckoutId.TabIndex = 9;
            this.txtCheckoutId.TextChanged += new System.EventHandler(this.txtCheckoutId_TextChanged);
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(112, 4);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(281, 20);
            this.txtStudentId.TabIndex = 10;
            this.txtStudentId.TextChanged += new System.EventHandler(this.txtStudentId_TextChanged);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(112, 62);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(281, 20);
            this.txtStudentName.TabIndex = 11;
            this.txtStudentName.TextChanged += new System.EventHandler(this.txtStudentName_TextChanged);
            // 
            // cboEquipment
            // 
            this.cboEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipment.FormattingEnabled = true;
            this.cboEquipment.Location = new System.Drawing.Point(112, 90);
            this.cboEquipment.Name = "cboEquipment";
            this.cboEquipment.Size = new System.Drawing.Size(281, 21);
            this.cboEquipment.TabIndex = 12;
            this.cboEquipment.SelectedIndexChanged += new System.EventHandler(this.cboEquipment_SelectedIndexChanged);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(112, 120);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(281, 20);
            this.nudQuantity.TabIndex = 13;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorrowDate.Location = new System.Drawing.Point(112, 150);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(281, 20);
            this.dtpBorrowDate.TabIndex = 14;
            this.dtpBorrowDate.ValueChanged += new System.EventHandler(this.dtpBorrowDate_ValueChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(112, 179);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(281, 20);
            this.dtpDueDate.TabIndex = 15;
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // dtpActualReturnDate
            // 
            this.dtpActualReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActualReturnDate.Location = new System.Drawing.Point(112, 208);
            this.dtpActualReturnDate.Name = "dtpActualReturnDate";
            this.dtpActualReturnDate.ShowCheckBox = true;
            this.dtpActualReturnDate.Size = new System.Drawing.Size(281, 20);
            this.dtpActualReturnDate.TabIndex = 16;
            this.dtpActualReturnDate.ValueChanged += new System.EventHandler(this.dtpActualReturnDate_ValueChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(112, 235);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(281, 21);
            this.cboStatus.TabIndex = 17;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 273);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(112, 273);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(218, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(318, 273);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnMarkReturned
            // 
            this.btnMarkReturned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkReturned.Location = new System.Drawing.Point(13, 302);
            this.btnMarkReturned.Name = "btnMarkReturned";
            this.btnMarkReturned.Size = new System.Drawing.Size(380, 28);
            this.btnMarkReturned.TabIndex = 22;
            this.btnMarkReturned.Text = "Đánh dấu đã trả";
            this.btnMarkReturned.UseVisualStyleBackColor = true;
            this.btnMarkReturned.Click += new System.EventHandler(this.btnMarkReturned_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tìm kiếm (Mã SV / Thiết bị)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 343);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Lọc tình trạng";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(170, 368);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(223, 20);
            this.txtSearch.TabIndex = 25;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(170, 337);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(223, 21);
            this.cboFilterStatus.TabIndex = 26;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // dgvCheckouts
            // 
            this.dgvCheckouts.AllowUserToAddRows = false;
            this.dgvCheckouts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheckouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckouts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckouts.Location = new System.Drawing.Point(423, 3);
            this.dgvCheckouts.MultiSelect = false;
            this.dgvCheckouts.Name = "dgvCheckouts";
            this.dgvCheckouts.ReadOnly = true;
            this.dgvCheckouts.RowHeadersVisible = false;
            this.dgvCheckouts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckouts.Size = new System.Drawing.Size(494, 408);
            this.dgvCheckouts.TabIndex = 1;
            this.dgvCheckouts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckouts_CellContentClick);
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
            this.menuExportCsv.Click += new System.EventHandler(this.menuExportCsv_Click_1);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(192, 22);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 460);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Lab Equipment Checkout";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckouts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.ComboBox cboEquipment;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtCheckoutId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMarkReturned;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpActualReturnDate;
        private System.Windows.Forms.DataGridView dgvCheckouts;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
    }
}

