using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Form1 : Form
    {
        // 1. Danh sách gốc lưu toàn bộ phiếu mượn
        private BindingList<CheckoutRecord> _masterList = new BindingList<CheckoutRecord>();

        // 2. BindingSource điều hướng hiển thị và hỗ trợ tìm kiếm/lọc
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetupApp();
            InitSampleData();
            RefreshOverdueStatus();
            ApplyFilterAndSearch();
        }

        #region Khởi tạo cấu hình ban đầu
        private void SetupApp()
        {
            this.Text = "Quản lý Mượn Trả Thiết Bị - Lab Equipment Checkout";
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Nạp danh mục thiết bị
            cboEquipment.Items.Clear();
            cboEquipment.Items.AddRange(new object[] {
                "Máy hiện sóng kỹ thuật số",
                "Đồng hồ vạn năng số",
                "Bộ thí nghiệm Vi điều khiển ARM",
                "Bộ nguồn DC điều chỉnh",
                "Kính hiển vi quang học",
                "Máy phát sóng âm tần"
            });
            cboEquipment.SelectedIndex = 0;

            // 2. Nạp trạng thái phiếu
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "Đang mượn", "Đã trả", "Quá hạn" });
            cboStatus.SelectedIndex = 0;

            // 3. Nạp danh mục lọc trạng thái
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.AddRange(new object[] { "-- Tất cả tình trạng --", "Đang mượn", "Quá hạn", "Đã trả" });
            cboFilterStatus.SelectedIndex = 0;

            // 4. Cấu hình DateTimePicker
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(7);
            dtpActualReturnDate.ShowCheckBox = true;
            dtpActualReturnDate.Checked = false;

            // 5. Cấu hình cột DataGridView thủ công (AutoGenerateColumns = false)
            dgvCheckouts.AutoGenerateColumns = false;
            dgvCheckouts.RowHeadersVisible = false;
            dgvCheckouts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCheckouts.MultiSelect = false;
            dgvCheckouts.ReadOnly = true;
            dgvCheckouts.AllowUserToAddRows = false;
            dgvCheckouts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCheckouts.Columns.Clear();
            dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.CheckoutId), HeaderText = "Mã Phiếu", FillWeight = 65 });
            dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.StudentId), HeaderText = "Mã SV", FillWeight = 65 });
            dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.StudentName), HeaderText = "Họ Tên SV", FillWeight = 110 });
            dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.EquipmentName), HeaderText = "Thiết Bị", FillWeight = 130 });
            dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.Quantity), HeaderText = "SL", FillWeight = 40 });

            var colBorrow = new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.BorrowDate), HeaderText = "Ngày Mượn", FillWeight = 75 };
            colBorrow.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheckouts.Columns.Add(colBorrow);

            var colDue = new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.DueDate), HeaderText = "Hạn Trả", FillWeight = 75 };
            colDue.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheckouts.Columns.Add(colDue);

            var colReturn = new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.ActualReturnDateFormatted), HeaderText = "Ngày Trả TT", FillWeight = 75 };
            dgvCheckouts.Columns.Add(colReturn);

            dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CheckoutRecord.Status), HeaderText = "Tình Trạng", FillWeight = 70 });

            // Gán dữ liệu vào DataGridView
            dgvCheckouts.DataSource = _bindingSource;

            // Sự kiện chọn dòng để nạp dữ liệu lên form nhập
            dgvCheckouts.SelectionChanged += DgvCheckouts_SelectionChanged;
        }

        private void InitSampleData()
        {
            _masterList.Add(new CheckoutRecord
            {
                CheckoutId = "PM001",
                StudentId = "SV101",
                StudentName = "Nguyễn Văn Hùng",
                EquipmentName = "Máy hiện sóng kỹ thuật số",
                Quantity = 1,
                BorrowDate = DateTime.Today.AddDays(-10),
                DueDate = DateTime.Today.AddDays(-3), // Hạn trả trước ngày hiện tại -> Quá hạn
                ActualReturnDate = null,
                Status = "Đang mượn"
            });

            _masterList.Add(new CheckoutRecord
            {
                CheckoutId = "PM002",
                StudentId = "SV102",
                StudentName = "Trần Thị Mai",
                EquipmentName = "Đồng hồ vạn năng số",
                Quantity = 2,
                BorrowDate = DateTime.Today.AddDays(-2),
                DueDate = DateTime.Today.AddDays(5),
                ActualReturnDate = null,
                Status = "Đang mượn"
            });

            _masterList.Add(new CheckoutRecord
            {
                CheckoutId = "PM003",
                StudentId = "SV103",
                StudentName = "Lê Hoàng Long",
                EquipmentName = "Bộ nguồn DC điều chỉnh",
                Quantity = 1,
                BorrowDate = DateTime.Today.AddDays(-15),
                DueDate = DateTime.Today.AddDays(-8),
                ActualReturnDate = DateTime.Today.AddDays(-8),
                Status = "Đã trả"
            });
        }
        #endregion

        #region Tự xác định phiếu quá hạn và Tìm kiếm / Lọc
        /// <summary>
        /// Yêu cầu 6: Tự xác định phiếu quá hạn khi hạn trả trước ngày hiện tại và phiếu chưa trả
        /// </summary>
        private void RefreshOverdueStatus()
        {
            foreach (var item in _masterList)
            {
                if (item.Status != "Đã trả" && item.DueDate.Date < DateTime.Today)
                {
                    item.Status = "Quá hạn";
                }
                else if (item.Status == "Quá hạn" && item.DueDate.Date >= DateTime.Today)
                {
                    item.Status = "Đang mượn";
                }
            }
        }

        private void ApplyFilterAndSearch()
        {
            RefreshOverdueStatus();

            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filtered = _masterList.Where(p =>
            {
                // Tìm kiếm theo Mã sinh viên hoặc Tên thiết bị
                bool matchKeyword = string.IsNullOrEmpty(keyword) ||
                                    p.StudentId.ToLower().Contains(keyword) ||
                                    p.EquipmentName.ToLower().Contains(keyword) ||
                                    p.StudentName.ToLower().Contains(keyword);

                // Lọc theo tình trạng phiếu
                bool matchStatus = (selectedStatus == "-- Tất cả tình trạng --" || string.IsNullOrEmpty(selectedStatus)) ||
                                   p.Status == selectedStatus;

                return matchKeyword && matchStatus;
            }).ToList();

            _bindingSource.DataSource = new BindingList<CheckoutRecord>(filtered);

            // Cập nhật StatusStrip: tổng số phiếu và số phiếu quá hạn
            int total = _masterList.Count;
            int overdueCount = _masterList.Count(p => p.Status == "Quá hạn");
            lblStatusInfo.Text = $"Tổng số phiếu: {total} | Quá hạn: {overdueCount} | Đang hiển thị sau lọc: {filtered.Count}";
        }
        #endregion

        #region Nạp dữ liệu khi chọn dòng trên DataGridView
        private void DgvCheckouts_SelectionChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Current is CheckoutRecord current)
            {
                txtCheckoutId.Text = current.CheckoutId;
                txtStudentId.Text = current.StudentId;
                txtStudentName.Text = current.StudentName;
                cboEquipment.SelectedItem = current.EquipmentName;
                nudQuantity.Value = current.Quantity;
                dtpBorrowDate.Value = current.BorrowDate;
                dtpDueDate.Value = current.DueDate;

                if (current.ActualReturnDate.HasValue)
                {
                    dtpActualReturnDate.Checked = true;
                    dtpActualReturnDate.Value = current.ActualReturnDate.Value;
                }
                else
                {
                    dtpActualReturnDate.Checked = false;
                }

                cboStatus.SelectedItem = current.Status;
                errorProvider1.Clear();
            }
        }
        #endregion

        #region Kiểm tra dữ liệu (Validation & ErrorProvider)
        private bool ValidateData(bool isNew)
        {
            bool isValid = true;
            errorProvider1.Clear();

            string checkoutId = txtCheckoutId.Text.Trim();
            string studentId = txtStudentId.Text.Trim();
            string studentName = txtStudentName.Text.Trim();

            // 1. Mã phiếu không trùng
            if (string.IsNullOrEmpty(checkoutId))
            {
                errorProvider1.SetError(txtCheckoutId, "Mã phiếu không được để trống!");
                isValid = false;
            }
            else if (isNew && _masterList.Any(p => p.CheckoutId.Equals(checkoutId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtCheckoutId, "Mã phiếu mượn đã tồn tại trên hệ thống!");
                isValid = false;
            }

            // 2. Mã sinh viên không để trống
            if (string.IsNullOrEmpty(studentId))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống!");
                isValid = false;
            }

            // Họ tên sinh viên không để trống
            if (string.IsNullOrEmpty(studentName))
            {
                errorProvider1.SetError(txtStudentName, "Họ tên sinh viên không được để trống!");
                isValid = false;
            }

            // 3. Số lượng phải lớn hơn 0
            if (nudQuantity.Value <= 0)
            {
                errorProvider1.SetError(nudQuantity, "Số lượng mượn phải lớn hơn 0!");
                isValid = false;
            }

            // 4. Hạn trả không trước ngày mượn
            if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider1.SetError(dtpDueDate, "Hạn trả không được trước ngày mượn!");
                isValid = false;
            }

            // 5. Ngày trả thực tế không trước ngày mượn
            if (dtpActualReturnDate.Checked && dtpActualReturnDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider1.SetError(dtpActualReturnDate, "Ngày trả thực tế không được trước ngày mượn!");
                isValid = false;
            }

            return isValid;
        }
        #endregion

        #region Thao tác CRUD & Nghiệp vụ hoàn trả
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData(isNew: true)) return;

            DateTime? returnDate = dtpActualReturnDate.Checked ? dtpActualReturnDate.Value.Date : (DateTime?)null;
            string status = cboStatus.SelectedItem.ToString();

            if (returnDate.HasValue) status = "Đã trả";

            var item = new CheckoutRecord
            {
                CheckoutId = txtCheckoutId.Text.Trim().ToUpper(),
                StudentId = txtStudentId.Text.Trim().ToUpper(),
                StudentName = txtStudentName.Text.Trim(),
                EquipmentName = cboEquipment.SelectedItem.ToString(),
                Quantity = (int)nudQuantity.Value,
                BorrowDate = dtpBorrowDate.Value.Date,
                DueDate = dtpDueDate.Value.Date,
                ActualReturnDate = returnDate,
                Status = status
            };

            _masterList.Add(item);
            ApplyFilterAndSearch();
            _bindingSource.Position = _bindingSource.IndexOf(item);
            MessageBox.Show("Thêm phiếu mượn mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is CheckoutRecord current)
            {
                if (!ValidateData(isNew: false)) return;

                current.StudentId = txtStudentId.Text.Trim().ToUpper();
                current.StudentName = txtStudentName.Text.Trim();
                current.EquipmentName = cboEquipment.SelectedItem.ToString();
                current.Quantity = (int)nudQuantity.Value;
                current.BorrowDate = dtpBorrowDate.Value.Date;
                current.DueDate = dtpDueDate.Value.Date;

                if (dtpActualReturnDate.Checked)
                {
                    current.ActualReturnDate = dtpActualReturnDate.Value.Date;
                    current.Status = "Đã trả";
                }
                else
                {
                    current.ActualReturnDate = null;
                    current.Status = cboStatus.SelectedItem.ToString();
                }

                ApplyFilterAndSearch();
                MessageBox.Show("Cập nhật thông tin phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is CheckoutRecord current)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu mượn [{current.CheckoutId}]?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _masterList.Remove(current);
                    ApplyFilterAndSearch();
                    btnClear_Click(sender, e);
                    MessageBox.Show("Đã xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMarkReturned_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is CheckoutRecord current)
            {
                current.ActualReturnDate = DateTime.Today;
                current.Status = "Đã trả";
                dtpActualReturnDate.Checked = true;
                dtpActualReturnDate.Value = DateTime.Today;
                cboStatus.SelectedItem = "Đã trả";

                ApplyFilterAndSearch();
                MessageBox.Show($"Đã đánh dấu hoàn trả cho phiếu {current.CheckoutId}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu từ bảng để đánh dấu đã trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCheckoutId.Text = "PM" + DateTime.Now.ToString("HHmmss");
            txtStudentId.Clear();
            txtStudentName.Clear();
            cboEquipment.SelectedIndex = 0;
            nudQuantity.Value = 1;
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(7);
            dtpActualReturnDate.Checked = false;
            cboStatus.SelectedIndex = 0;
            errorProvider1.Clear();
            txtStudentId.Focus();
        }
        #endregion

        #region Sự kiện Lọc và Tìm kiếm tức thời
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedItem?.ToString() == "Đã trả" && !dtpActualReturnDate.Checked)
            {
                dtpActualReturnDate.Checked = true;
                dtpActualReturnDate.Value = DateTime.Today;
            }
        }
        #endregion

        #region MenuStrip: Xuất CSV & Thoát
        private void ExecuteExportCsv()
        {
            var currentDisplayList = _bindingSource.List.OfType<CheckoutRecord>().ToList();
            if (currentDisplayList.Count == 0)
            {
                MessageBox.Show("Danh sách hiển thị đang trống, không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = $"PhieuMuon_{DateTime.Now:yyyyMMdd_HHmm}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("Mã Phiếu,Mã SV,Họ Tên SV,Thiết Bị,Số Lượng,Ngày Mượn,Hạn Trả,Ngày Trả Thực Tế,Tình Trạng");

                        foreach (var item in currentDisplayList)
                        {
                            sb.AppendLine($"{EscapeCsv(item.CheckoutId)}," +
                                          $"{EscapeCsv(item.StudentId)}," +
                                          $"{EscapeCsv(item.StudentName)}," +
                                          $"{EscapeCsv(item.EquipmentName)}," +
                                          $"{item.Quantity}," +
                                          $"{item.BorrowDate:dd/MM/yyyy}," +
                                          $"{item.DueDate:dd/MM/yyyy}," +
                                          $"{EscapeCsv(item.ActualReturnDateFormatted)}," +
                                          $"{EscapeCsv(item.Status)}");
                        }

                        // Lưu UTF-8 kèm BOM để Excel hiển thị tiếng Việt không lỗi phông
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show($"Đã xuất thành công {currentDisplayList.Count} phiếu ra file:\n{sfd.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void menuExportCsv_Click(object sender, EventArgs e) => ExecuteExportCsv();

        private void menuExportCsv_Click_1(object sender, EventArgs e) => ExecuteExportCsv();

        private void menuExit_Click(object sender, EventArgs e) => Application.Exit();

        private void menuExit_Click_1(object sender, EventArgs e) => Application.Exit();
        #endregion

        #region Các sự kiện trống giữ lại để Designer không báo lỗi
        private void label2_Click(object sender, EventArgs e) { }
        private void txtStudentId_TextChanged(object sender, EventArgs e) { }
        private void txtCheckoutId_TextChanged(object sender, EventArgs e) { }
        private void txtStudentName_TextChanged(object sender, EventArgs e) { }
        private void cboEquipment_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nudQuantity_ValueChanged(object sender, EventArgs e) { }
        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e) { }
        private void dtpDueDate_ValueChanged(object sender, EventArgs e) { }
        private void dtpActualReturnDate_ValueChanged(object sender, EventArgs e) { }
        private void lblStatusInfo_Click(object sender, EventArgs e) { }
        private void dgvCheckouts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void menuFile_Click(object sender, EventArgs e) { }
        #endregion
    }

    #region Model Class: CheckoutRecord
    public class CheckoutRecord : INotifyPropertyChanged
    {
        private string _checkoutId;
        private string _studentId;
        private string _studentName;
        private string _equipmentName;
        private int _quantity;
        private DateTime _borrowDate;
        private DateTime _dueDate;
        private DateTime? _actualReturnDate;
        private string _status;

        public string CheckoutId { get => _checkoutId; set { _checkoutId = value; OnPropertyChanged(); } }
        public string StudentId { get => _studentId; set { _studentId = value; OnPropertyChanged(); } }
        public string StudentName { get => _studentName; set { _studentName = value; OnPropertyChanged(); } }
        public string EquipmentName { get => _equipmentName; set { _equipmentName = value; OnPropertyChanged(); } }
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(); } }
        public DateTime BorrowDate { get => _borrowDate; set { _borrowDate = value; OnPropertyChanged(); } }
        public DateTime DueDate { get => _dueDate; set { _dueDate = value; OnPropertyChanged(); } }
        public DateTime? ActualReturnDate
        {
            get => _actualReturnDate;
            set
            {
                _actualReturnDate = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ActualReturnDateFormatted));
            }
        }

        public string ActualReturnDateFormatted => ActualReturnDate.HasValue ? ActualReturnDate.Value.ToString("dd/MM/yyyy") : "-";
        public string Status { get => _status; set { _status = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
}