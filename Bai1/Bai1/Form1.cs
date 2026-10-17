using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        // 1. Danh sách lưu trữ dữ liệu gốc và BindingSource điều hướng hiển thị
        private BindingList<Appointment> _masterList = new BindingList<Appointment>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetupApp();
            InitSampleData();
            ApplyFilterAndSearch();
        }

        #region Cấu hình khởi tạo ban đầu
        private void SetupApp()
        {
            this.Text = "Quản lý Lịch hẹn Phòng khám - Clinic Appointment Manager";

            // 1. Nạp danh mục Bác sĩ
            cboDoctor.Items.Clear();
            cboDoctor.Items.AddRange(new object[] {
                "BS. Nguyễn Văn Hùng (Nội tổng quát)",
                "BS. Trần Thị Mai (Tai - Mũi - Họng)",
                "BS. Lê Hoàng Nam (Nhi khoa)",
                "BS. Phạm Minh Tuấn (Răng - Hàm - Mặt)"
            });
            cboDoctor.SelectedIndex = 0;

            // 2. Nạp danh mục Trạng thái lịch hẹn
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" });
            cboStatus.SelectedIndex = 0;

            // 3. Nạp danh mục Trạng thái trên bộ lọc
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.AddRange(new object[] { "-- Tất cả trạng thái --", "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" });
            cboFilterStatus.SelectedIndex = 0;

            // 4. Cấu hình DateTimePicker
            dtpAppointmentTime.Format = DateTimePickerFormat.Custom;
            dtpAppointmentTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpAppointmentTime.Value = DateTime.Now.AddHours(2);

            DateTimePicker dtpFilter = GetFilterDatePicker();
            if (dtpFilter != null)
            {
                dtpFilter.Format = DateTimePickerFormat.Custom;
                dtpFilter.CustomFormat = "dd/MM/yyyy";
                dtpFilter.Value = DateTime.Today;
                dtpFilter.ValueChanged += (s, e) => { if (chkFilterByDate.Checked) ApplyFilterAndSearch(); };
            }

            // 5. Cấu hình DataGridView bằng cột tự định nghĩa
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointments.Columns.Clear();
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Appointment.AppointmentId), HeaderText = "Mã Lịch", FillWeight = 65 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Appointment.PatientName), HeaderText = "Họ và Tên", FillWeight = 110 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Appointment.PhoneNumber), HeaderText = "Số ĐT", FillWeight = 85 });

            var colTime = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Appointment.AppointmentTime),
                HeaderText = "Ngày giờ hẹn",
                FillWeight = 100
            };
            colTime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvAppointments.Columns.Add(colTime);

            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Appointment.DoctorName), HeaderText = "Bác sĩ phụ trách", FillWeight = 130 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Appointment.Reason), HeaderText = "Lý do khám", FillWeight = 120 });
            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Appointment.Status), HeaderText = "Trạng thái", FillWeight = 75 });

            // Gán dữ liệu vào bảng
            dgvAppointments.DataSource = _bindingSource;

            // Bắt sự kiện chọn dòng
            dgvAppointments.SelectionChanged += DgvAppointments_SelectionChanged;
        }

        // Hàm hỗ trợ nhận diện DateTimePicker dùng để lọc ngày (do giao diện có thể là dateTimePicker1)
        private DateTimePicker GetFilterDatePicker()
        {
            Control[] controls = this.Controls.Find("dtpFilterDate", true);
            if (controls.Length > 0 && controls[0] is DateTimePicker dtp1) return dtp1;

            controls = this.Controls.Find("dateTimePicker1", true);
            if (controls.Length > 0 && controls[0] is DateTimePicker dtp2) return dtp2;

            return null;
        }

        private void InitSampleData()
        {
            _masterList.Add(new Appointment
            {
                AppointmentId = "LH001",
                PatientName = "Nguyễn Văn Tuấn",
                PhoneNumber = "0987123456",
                AppointmentTime = DateTime.Today.AddHours(9),
                DoctorName = "BS. Nguyễn Văn Hùng (Nội tổng quát)",
                Reason = "Kiểm tra huyết áp định kỳ",
                Status = "Chờ khám"
            });

            _masterList.Add(new Appointment
            {
                AppointmentId = "LH002",
                PatientName = "Lê Thị Thảo",
                PhoneNumber = "0912345678",
                AppointmentTime = DateTime.Today.AddHours(14).AddMinutes(30),
                DoctorName = "BS. Trần Thị Mai (Tai - Mũi - Họng)",
                Reason = "Đau họng, viêm amidan sốt nhẹ",
                Status = "Đang khám"
            });

            _masterList.Add(new Appointment
            {
                AppointmentId = "LH003",
                PatientName = "Trần Đình Trọng",
                PhoneNumber = "0905111222",
                AppointmentTime = DateTime.Today.AddDays(1).AddHours(10),
                DoctorName = "BS. Lê Hoàng Nam (Nhi khoa)",
                Reason = "Tư vấn dinh dưỡng cho bé",
                Status = "Chờ khám"
            });
        }
        #endregion

        #region Thuật toán Tìm kiếm tức thời & Lọc dữ liệu
        private void ApplyFilterAndSearch()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();
            bool filterDate = chkFilterByDate.Checked;

            DateTimePicker dtpFilter = GetFilterDatePicker();
            DateTime targetDate = dtpFilter != null ? dtpFilter.Value.Date : DateTime.Today;

            var filtered = _masterList.Where(a =>
            {
                // 1. Tìm tức thời theo Tên hoặc Số điện thoại
                bool matchKeyword = string.IsNullOrEmpty(keyword) ||
                                    a.PatientName.ToLower().Contains(keyword) ||
                                    a.PhoneNumber.Contains(keyword);

                // 2. Lọc theo trạng thái
                bool matchStatus = (selectedStatus == "-- Tất cả trạng thái --" || string.IsNullOrEmpty(selectedStatus)) ||
                                   a.Status == selectedStatus;

                // 3. Lọc theo ngày hẹn
                bool matchDate = !filterDate || a.AppointmentTime.Date == targetDate;

                return matchKeyword && matchStatus && matchDate;
            }).ToList();

            _bindingSource.DataSource = new BindingList<Appointment>(filtered);

            // Cập nhật số lượng lên StatusStrip
            lblStatusCount.Text = $"Tổng số: {_masterList.Count} | Đang hiển thị sau lọc: {filtered.Count}";
        }
        #endregion

        #region Nạp dữ liệu khi chọn dòng
        private void DgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Current is Appointment current)
            {
                txtAppointmentId.Text = current.AppointmentId;
                txtAppointmentId.ReadOnly = true; // Khóa mã không cho sửa khi đang xem dòng có sẵn
                txtPatientName.Text = current.PatientName;
                txtPhone.Text = current.PhoneNumber;
                dtpAppointmentTime.Value = current.AppointmentTime;
                cboDoctor.SelectedItem = current.DoctorName;
                txtReason.Text = current.Reason;
                cboStatus.SelectedItem = current.Status;

                errorProvider1.Clear();
            }
        }
        #endregion

        #region Kiểm tra dữ liệu (Validation)
        private bool ValidateData(bool isAddingNew)
        {
            bool isValid = true;
            errorProvider1.Clear();

            string id = txtAppointmentId.Text.Trim();
            string name = txtPatientName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string reason = txtReason.Text.Trim();
            DateTime appTime = dtpAppointmentTime.Value;

            // 1. Kiểm tra mã lịch hẹn
            if (string.IsNullOrEmpty(id))
            {
                errorProvider1.SetError(txtAppointmentId, "Mã lịch hẹn không được để trống!");
                isValid = false;
            }
            else if (isAddingNew && _masterList.Any(a => a.AppointmentId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtAppointmentId, "Mã lịch hẹn đã tồn tại!");
                isValid = false;
            }

            // 2. Tên bệnh nhân
            if (string.IsNullOrEmpty(name))
            {
                errorProvider1.SetError(txtPatientName, "Họ tên bệnh nhân là bắt buộc!");
                isValid = false;
            }

            // 3. Số điện thoại (10 chữ số chuẩn VN)
            if (string.IsNullOrEmpty(phone))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại không được để trống!");
                isValid = false;
            }
            else if (!Regex.IsMatch(phone, @"^(0[3|5|7|8|9])[0-9]{8}$"))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại không hợp lệ (Phải là 10 số, bắt đầu bằng 03, 05, 07, 08, 09)!");
                isValid = false;
            }

            // 4. Lý do khám
            if (string.IsNullOrEmpty(reason))
            {
                errorProvider1.SetError(txtReason, "Lý do khám không được để trống!");
                isValid = false;
            }

            // 5. Ngày hẹn không được trong quá khứ
            if (isAddingNew && appTime < DateTime.Now.AddMinutes(-5))
            {
                errorProvider1.SetError(dtpAppointmentTime, "Ngày giờ hẹn không được nằm trong quá khứ!");
                isValid = false;
            }

            return isValid;
        }
        #endregion

        #region Các sự kiện Thao tác dữ liệu (CRUD)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData(isAddingNew: true)) return;

            var newApp = new Appointment
            {
                AppointmentId = txtAppointmentId.Text.Trim().ToUpper(),
                PatientName = txtPatientName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                AppointmentTime = dtpAppointmentTime.Value,
                DoctorName = cboDoctor.SelectedItem.ToString(),
                Reason = txtReason.Text.Trim(),
                Status = cboStatus.SelectedItem.ToString()
            };

            _masterList.Add(newApp);
            ApplyFilterAndSearch();
            _bindingSource.Position = _bindingSource.IndexOf(newApp);

            MessageBox.Show("Thêm lịch hẹn mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is Appointment current)
            {
                if (!ValidateData(isAddingNew: false)) return;

                current.PatientName = txtPatientName.Text.Trim();
                current.PhoneNumber = txtPhone.Text.Trim();
                current.AppointmentTime = dtpAppointmentTime.Value;
                current.DoctorName = cboDoctor.SelectedItem.ToString();
                current.Reason = txtReason.Text.Trim();
                current.Status = cboStatus.SelectedItem.ToString();

                ApplyFilterAndSearch();
                MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is Appointment current)
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch hẹn [{current.AppointmentId}] của bệnh nhân {current.PatientName}?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _masterList.Remove(current);
                    ApplyFilterAndSearch();
                    btnClear_Click(sender, e);
                    MessageBox.Show("Đã xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAppointmentId.ReadOnly = false;
            txtAppointmentId.Text = "LH" + DateTime.Now.ToString("HHmmss");
            txtPatientName.Clear();
            txtPhone.Clear();
            dtpAppointmentTime.Value = DateTime.Now.AddHours(2);
            txtReason.Clear();
            cboDoctor.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            errorProvider1.Clear();
            txtPatientName.Focus();
        }
        #endregion

        #region Các sự kiện Lọc & Tìm kiếm tức thời
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (chkFilterByDate.Checked) ApplyFilterAndSearch();
        }
        #endregion

        #region MenuStrip: Xuất CSV & Thoát
        private void menuExportCsv_Click(object sender, EventArgs e)
        {
            var currentDisplayList = _bindingSource.List.OfType<Appointment>().ToList();

            if (currentDisplayList.Count == 0)
            {
                MessageBox.Show("Danh sách hiển thị đang trống, không thể xuất file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách lịch hẹn ra CSV";
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = $"LichHen_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("Mã lịch,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ phụ trách,Lý do khám,Trạng thái");

                        foreach (var item in currentDisplayList)
                        {
                            sb.AppendLine($"{EscapeCsv(item.AppointmentId)}," +
                                          $"{EscapeCsv(item.PatientName)}," +
                                          $"{EscapeCsv(item.PhoneNumber)}," +
                                          $"{EscapeCsv(item.AppointmentTime.ToString("dd/MM/yyyy HH:mm"))}," +
                                          $"{EscapeCsv(item.DoctorName)}," +
                                          $"{EscapeCsv(item.Reason)}," +
                                          $"{EscapeCsv(item.Status)}");
                        }

                        // Ghi file UTF-8 có BOM để Excel không lỗi font tiếng Việt
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show($"Xuất thành công {currentDisplayList.Count} lịch hẹn ra file:\n{sfd.FileName}",
                                        "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string EscapeCsv(string field)
        {
            if (string.IsNullOrEmpty(field)) return "";
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Các sự kiện trống giữ lại để Designer không báo lỗi
        private void label2_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void dtpAppointmentTime_ValueChanged(object sender, EventArgs e) { }
        private void txtAppointmentId_TextChanged(object sender, EventArgs e) { }
        private void txtPatientName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtReason_TextChanged(object sender, EventArgs e) { }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblStatusCount_Click(object sender, EventArgs e) { }
        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        #endregion
    }

    #region Class Model: Appointment
    public class Appointment : INotifyPropertyChanged
    {
        private string _appointmentId;
        private string _patientName;
        private string _phoneNumber;
        private DateTime _appointmentTime;
        private string _doctorName;
        private string _reason;
        private string _status;

        public string AppointmentId
        {
            get => _appointmentId;
            set { _appointmentId = value; OnPropertyChanged(); }
        }

        public string PatientName
        {
            get => _patientName;
            set { _patientName = value; OnPropertyChanged(); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public DateTime AppointmentTime
        {
            get => _appointmentTime;
            set { _appointmentTime = value; OnPropertyChanged(); }
        }

        public string DoctorName
        {
            get => _doctorName;
            set { _doctorName = value; OnPropertyChanged(); }
        }

        public string Reason
        {
            get => _reason;
            set { _reason = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
}