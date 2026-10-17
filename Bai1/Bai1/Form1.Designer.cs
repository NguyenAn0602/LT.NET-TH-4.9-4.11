namespace Bai1
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
            this.menuExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAppointmentId = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpAppointmentTime = new System.Windows.Forms.DateTimePicker();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportCsv,
            this.menuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuExportCsv
            // 
            this.menuExportCsv.Name = "menuExportCsv";
            this.menuExportCsv.Size = new System.Drawing.Size(100, 20);
            this.menuExportCsv.Text = "Xuất danh sách";
            this.menuExportCsv.Click += new System.EventHandler(this.menuExportCsv_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(49, 20);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(924, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatusCount
            // 
            this.lblStatusCount.Name = "lblStatusCount";
            this.lblStatusCount.Size = new System.Drawing.Size(153, 17);
            this.lblStatusCount.Text = "Tổng số: 0 | Đang hiển thị: 0";
            this.lblStatusCount.Click += new System.EventHandler(this.lblStatusCount_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.dgvAppointments, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(924, 363);
            this.tlpMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboFilterStatus);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtpFilterDate);
            this.panel1.Controls.Add(this.chkFilterByDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.txtReason);
            this.panel1.Controls.Add(this.cboDoctor);
            this.panel1.Controls.Add(this.dtpAppointmentTime);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtPatientName);
            this.panel1.Controls.Add(this.txtAppointmentId);
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
            this.panel1.Size = new System.Drawing.Size(394, 357);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã lịch hẹn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên bệnh nhân";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày giờ hẹn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bác sĩ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lý do khám";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Trạng thái";
            // 
            // txtAppointmentId
            // 
            this.txtAppointmentId.Location = new System.Drawing.Point(122, 8);
            this.txtAppointmentId.Name = "txtAppointmentId";
            this.txtAppointmentId.Size = new System.Drawing.Size(250, 20);
            this.txtAppointmentId.TabIndex = 7;
            this.txtAppointmentId.TextChanged += new System.EventHandler(this.txtAppointmentId_TextChanged);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(122, 34);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(250, 20);
            this.txtPatientName.TabIndex = 8;
            this.txtPatientName.TextChanged += new System.EventHandler(this.txtPatientName_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(122, 60);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // dtpAppointmentTime
            // 
            this.dtpAppointmentTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpAppointmentTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentTime.Location = new System.Drawing.Point(122, 90);
            this.dtpAppointmentTime.Name = "dtpAppointmentTime";
            this.dtpAppointmentTime.Size = new System.Drawing.Size(250, 20);
            this.dtpAppointmentTime.TabIndex = 10;
            this.dtpAppointmentTime.ValueChanged += new System.EventHandler(this.dtpAppointmentTime_ValueChanged);
            // 
            // cboDoctor
            // 
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(122, 115);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(250, 21);
            this.cboDoctor.TabIndex = 11;
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(122, 143);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(250, 20);
            this.txtReason.TabIndex = 12;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(122, 169);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(250, 21);
            this.cboStatus.TabIndex = 13;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(14, 205);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(106, 205);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(202, 205);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(297, 205);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(75, 239);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(297, 20);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tìm kiếm";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // chkFilterByDate
            // 
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFilterByDate.Location = new System.Drawing.Point(14, 274);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(126, 19);
            this.chkFilterByDate.TabIndex = 20;
            this.chkFilterByDate.Text = "Lọc theo ngày hẹn";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
            this.chkFilterByDate.CheckedChanged += new System.EventHandler(this.chkFilterByDate_CheckedChanged);
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterDate.Location = new System.Drawing.Point(146, 274);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(226, 20);
            this.dtpFilterDate.TabIndex = 21;
            this.dtpFilterDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Lọc trạng thái";
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(122, 309);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(250, 21);
            this.cboFilterStatus.TabIndex = 23;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.Location = new System.Drawing.Point(403, 3);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(518, 357);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 409);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Quản lý lịch hẹn phòng khám";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuExportCsv;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtAppointmentId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.DateTimePicker dtpAppointmentTime;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvAppointments;
    }
}

