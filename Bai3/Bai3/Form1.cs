using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        // 1. Danh sách gốc lưu toàn bộ đơn sửa chữa
        private BindingList<RepairOrder> _masterList = new BindingList<RepairOrder>();

        // 2. BindingSource điều hướng hiển thị và lọc dữ liệu lên DataGridView
        private BindingSource _bindingSource = new BindingSource();

        // 3. Đường dẫn lưu file ảnh đang chọn
        private string _currentImagePath = string.Empty;

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
            this.Text = "Quản lý Đơn Dịch vụ Sửa chữa - Repair Service Tracker";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Nạp danh mục Loại thiết bị
            cboDeviceType.Items.Clear();
            cboDeviceType.Items.AddRange(new object[] { "Laptop", "Điện thoại", "Máy tính bảng", "PC Để bàn", "Khác" });
            cboDeviceType.SelectedIndex = 0;

            // Nạp danh mục Trạng thái xử lý
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" });
            cboStatus.SelectedIndex = 0;

            // Nạp danh mục Lọc trạng thái
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.AddRange(new object[] { "-- Tất cả trạng thái --", "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" });
            cboFilterStatus.SelectedIndex = 0;

            // Cấu hình DateTimePicker tiếp nhận
            DateTimePicker dtpReceive = GetReceiveDatePicker();
            if (dtpReceive != null)
            {
                dtpReceive.Format = DateTimePickerFormat.Custom;
                dtpReceive.CustomFormat = "dd/MM/yyyy HH:mm";
                dtpReceive.Value = DateTime.Now;
            }

            // Cấu hình PictureBox giữ tỷ lệ ảnh, không bị méo (Yêu cầu 4)
            picDevice.SizeMode = PictureBoxSizeMode.Zoom;
            picDevice.BorderStyle = BorderStyle.FixedSingle;

            // Cấu hình NumericUpDown chi phí dự kiến
            nudEstimatedCost.Minimum = 0;
            nudEstimatedCost.Maximum = 1000000000;
            nudEstimatedCost.ThousandsSeparator = true;

            // Cấu hình DataGridView với cột tự định nghĩa (AutoGenerateColumns = false)
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(RepairOrder.OrderId), HeaderText = "Mã Đơn", FillWeight = 60 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(RepairOrder.CustomerName), HeaderText = "Khách Hàng", FillWeight = 110 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(RepairOrder.Phone), HeaderText = "Số ĐT", FillWeight = 85 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(RepairOrder.DeviceType), HeaderText = "Thiết Bị", FillWeight = 80 });

            var colDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(RepairOrder.ReceiveDate),
                HeaderText = "Ngày Tiếp Nhận",
                FillWeight = 100
            };
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvOrders.Columns.Add(colDate);

            // Cột Chi phí định dạng "N0" (Yêu cầu 3)
            var colCost = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(RepairOrder.EstimatedCost),
                HeaderText = "Chi Phí Dự Kiến",
                FillWeight = 95
            };
            colCost.DefaultCellStyle.Format = "N0";
            colCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOrders.Columns.Add(colCost);

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(RepairOrder.Status), HeaderText = "Trạng Thái", FillWeight = 85 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(RepairOrder.IssueDescription), HeaderText = "Mô Tả Lỗi", FillWeight = 130 });

            // Gán dữ liệu vào bảng
            dgvOrders.DataSource = _bindingSource;

            // Bắt sự kiện chọn dòng
            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;

            // Bắt sự kiện tìm kiếm nếu bạn đặt tên ô tìm kiếm là txtSearch
            TextBox searchBox = GetSearchTextBox();
            if (searchBox != null && searchBox.Name != "textBox1")
            {
                searchBox.TextChanged += (s, e) => ApplyFilterAndSearch();
            }
        }

        private DateTimePicker GetReceiveDatePicker()
        {
            Control[] c = this.Controls.Find("dtpReceiveDate", true);
            if (c.Length > 0 && c[0] is DateTimePicker dtp1) return dtp1;

            c = this.Controls.Find("dateTimePicker1", true);
            if (c.Length > 0 && c[0] is DateTimePicker dtp2) return dtp2;

            return null;
        }

        private TextBox GetSearchTextBox()
        {
            Control[] c = this.Controls.Find("txtSearch", true);
            if (c.Length > 0 && c[0] is TextBox txt1) return txt1;

            c = this.Controls.Find("textBox1", true);
            if (c.Length > 0 && c[0] is TextBox txt2) return txt2;

            return null;
        }

        private void InitSampleData()
        {
            _masterList.Add(new RepairOrder
            {
                OrderId = "SC001",
                CustomerName = "Nguyễn Văn Tuấn",
                Phone = "0987111222",
                DeviceType = "Laptop",
                ReceiveDate = DateTime.Now.AddDays(-1),
                EstimatedCost = 450000,
                Status = "Đang sửa",
                IssueDescription = "Thay bàn phím cơ và vệ sinh quạt tản nhiệt",
                ImagePath = ""
            });

            _masterList.Add(new RepairOrder
            {
                OrderId = "SC002",
                CustomerName = "Trần Thị Lan",
                Phone = "0912333444",
                DeviceType = "Điện thoại",
                ReceiveDate = DateTime.Now.AddDays(-2),
                EstimatedCost = 1200000,
                Status = "Chờ linh kiện",
                IssueDescription = "Màn hình bị sọc xanh sau khi rơi nước",
                ImagePath = ""
            });

            _masterList.Add(new RepairOrder
            {
                OrderId = "SC003",
                CustomerName = "Lê Hoàng Phúc",
                Phone = "0905555666",
                DeviceType = "PC Để bàn",
                ReceiveDate = DateTime.Now.AddDays(-3),
                EstimatedCost = 350000,
                Status = "Hoàn tất",
                IssueDescription = "Cài lại hệ điều hành và nâng cấp ổ cứng SSD",
                ImagePath = ""
            });
        }
        #endregion

        #region Thuật toán Tìm kiếm tức thời & Lọc trạng thái
        private void ApplyFilterAndSearch()
        {
            TextBox searchBox = GetSearchTextBox();
            string keyword = searchBox != null ? searchBox.Text.Trim().ToLower() : string.Empty;
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filtered = _masterList.Where(o =>
            {
                // Tìm kiếm tức thời theo mã đơn, tên khách hàng hoặc số điện thoại
                bool matchKeyword = string.IsNullOrEmpty(keyword) ||
                                    o.OrderId.ToLower().Contains(keyword) ||
                                    o.CustomerName.ToLower().Contains(keyword) ||
                                    o.Phone.Contains(keyword);

                // Lọc theo trạng thái
                bool matchStatus = (selectedStatus == "-- Tất cả trạng thái --" || string.IsNullOrEmpty(selectedStatus)) ||
                                   o.Status == selectedStatus;

                return matchKeyword && matchStatus;
            }).ToList();

            _bindingSource.DataSource = new BindingList<RepairOrder>(filtered);

            // Tính tổng chi phí của các đơn chưa hoàn tất (không tính đơn 'Hoàn tất' và 'Đã hủy')
            decimal pendingCost = _masterList
                .Where(o => o.Status != "Hoàn tất" && o.Status != "Đã hủy")
                .Sum(o => o.EstimatedCost);

            // Cập nhật StatusStrip
            lblStatusCount.Text = $"Số đơn hiển thị: {filtered.Count} / {_masterList.Count}";
            lblTotalPendingCost.Text = $"Tổng chi phí chưa hoàn tất: {pendingCost:N0} VNĐ";
        }
        #endregion

        #region Nạp dữ liệu khi chọn dòng trên DataGridView
        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Current is RepairOrder current)
            {
                txtServiceId.Text = current.OrderId;
                txtCustomerName.Text = current.CustomerName;
                txtPhone.Text = current.Phone;
                cboDeviceType.SelectedItem = current.DeviceType;

                DateTimePicker dtpReceive = GetReceiveDatePicker();
                if (dtpReceive != null) dtpReceive.Value = current.ReceiveDate;

                nudEstimatedCost.Value = current.EstimatedCost;
                cboStatus.SelectedItem = current.Status;
                txtIssueDescription.Text = current.IssueDescription;
                _currentImagePath = current.ImagePath;

                DisplayImage(_currentImagePath);
                errorProvider1?.Clear();
            }
        }

        private void DisplayImage(string path)
        {
            if (picDevice.Image != null)
            {
                picDevice.Image.Dispose();
                picDevice.Image = null;
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(path);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        picDevice.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    picDevice.Image = null;
                }
            }
        }
        #endregion

        #region Kiểm tra hợp lệ dữ liệu (Validation & ErrorProvider)
        private bool ValidateData(bool isNew)
        {
            bool isValid = true;
            errorProvider1?.Clear();

            string orderId = txtServiceId.Text.Trim();
            string name = txtCustomerName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string desc = txtIssueDescription.Text.Trim();

            // 1. Mã đơn không trùng
            if (string.IsNullOrEmpty(orderId))
            {
                errorProvider1?.SetError(txtServiceId, "Mã đơn không được để trống!");
                isValid = false;
            }
            else if (isNew && _masterList.Any(o => o.OrderId.Equals(orderId, StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1?.SetError(txtServiceId, "Mã đơn đã tồn tại trên hệ thống!");
                isValid = false;
            }

            // 2. Tên và Số điện thoại không để trống
            if (string.IsNullOrEmpty(name))
            {
                errorProvider1?.SetError(txtCustomerName, "Tên khách hàng không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrEmpty(phone))
            {
                errorProvider1?.SetError(txtPhone, "Số điện thoại không được để trống!");
                isValid = false;
            }

            // 3. Chi phí dự kiến phải là số không âm
            if (nudEstimatedCost.Value < 0)
            {
                errorProvider1?.SetError(nudEstimatedCost, "Chi phí dự kiến không được âm!");
                isValid = false;
            }

            // 4. Mô tả lỗi bắt buộc
            if (string.IsNullOrEmpty(desc))
            {
                errorProvider1?.SetError(txtIssueDescription, "Mô tả lỗi bắt buộc phải nhập!");
                isValid = false;
            }

            return isValid;
        }
        #endregion

        #region Các thao tác CRUD dữ liệu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData(isNew: true)) return;

            DateTimePicker dtpReceive = GetReceiveDatePicker();
            DateTime receiveDate = dtpReceive != null ? dtpReceive.Value : DateTime.Now;

            var newOrder = new RepairOrder
            {
                OrderId = txtServiceId.Text.Trim().ToUpper(),
                CustomerName = txtCustomerName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DeviceType = cboDeviceType.SelectedItem.ToString(),
                ReceiveDate = receiveDate,
                EstimatedCost = nudEstimatedCost.Value,
                Status = cboStatus.SelectedItem.ToString(),
                IssueDescription = txtIssueDescription.Text.Trim(),
                ImagePath = _currentImagePath
            };

            _masterList.Add(newOrder);
            ApplyFilterAndSearch();
            _bindingSource.Position = _bindingSource.IndexOf(newOrder);

            MessageBox.Show("Tiếp nhận đơn sửa chữa mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is RepairOrder current)
            {
                if (!ValidateData(isNew: false)) return;

                DateTimePicker dtpReceive = GetReceiveDatePicker();

                current.CustomerName = txtCustomerName.Text.Trim();
                current.Phone = txtPhone.Text.Trim();
                current.DeviceType = cboDeviceType.SelectedItem.ToString();
                if (dtpReceive != null) current.ReceiveDate = dtpReceive.Value;
                current.EstimatedCost = nudEstimatedCost.Value;
                current.Status = cboStatus.SelectedItem.ToString();
                current.IssueDescription = txtIssueDescription.Text.Trim();
                current.ImagePath = _currentImagePath;

                ApplyFilterAndSearch();
                MessageBox.Show("Cập nhật thông tin đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn từ bảng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is RepairOrder current)
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn [{current.OrderId}] của khách {current.CustomerName}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    _masterList.Remove(current);
                    ApplyFilterAndSearch();
                    btnClear_Click(sender, e);
                    MessageBox.Show("Đã xóa đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtServiceId.Text = "SC" + DateTime.Now.ToString("HHmmss");
            txtCustomerName.Clear();
            txtPhone.Clear();
            cboDeviceType.SelectedIndex = 0;

            DateTimePicker dtpReceive = GetReceiveDatePicker();
            if (dtpReceive != null) dtpReceive.Value = DateTime.Now;

            nudEstimatedCost.Value = 0;
            cboStatus.SelectedIndex = 0;
            txtIssueDescription.Clear();
            _currentImagePath = string.Empty;
            DisplayImage(null);
            errorProvider1?.Clear();
            txtCustomerName.Focus();
        }
        #endregion

        #region Xử lý Ảnh thiết bị
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh thiết bị sửa chữa";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImagePath = ofd.FileName;
                    DisplayImage(_currentImagePath);
                }
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _currentImagePath = string.Empty;
            DisplayImage(null);
        }
        #endregion

        #region MenuStrip: Xuất CSV & Thoát
        private void menuExportCsv_Click(object sender, EventArgs e)
        {
            var currentDisplayList = _bindingSource.List.OfType<RepairOrder>().ToList();
            if (currentDisplayList.Count == 0)
            {
                MessageBox.Show("Danh sách hiển thị đang trống, không thể xuất file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = $"DonSuaChua_{DateTime.Now:yyyyMMdd_HHmm}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("Mã Đơn,Khách Hàng,Số Điện Thoại,Loại Thiết Bị,Ngày Tiếp Nhận,Chi Phí Dự Kiến,Trạng Thái,Mô Tả Lỗi");

                        foreach (var item in currentDisplayList)
                        {
                            sb.AppendLine($"{EscapeCsv(item.OrderId)}," +
                                          $"{EscapeCsv(item.CustomerName)}," +
                                          $"{EscapeCsv(item.Phone)}," +
                                          $"{EscapeCsv(item.DeviceType)}," +
                                          $"{item.ReceiveDate:dd/MM/yyyy HH:mm}," +
                                          $"{item.EstimatedCost}," +
                                          $"{EscapeCsv(item.Status)}," +
                                          $"{EscapeCsv(item.IssueDescription)}");
                        }

                        // Ghi file UTF-8 có BOM để Excel không lỗi font tiếng Việt
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show($"Đã xuất {currentDisplayList.Count} đơn ra file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void menuExit_Click(object sender, EventArgs e) => Application.Exit();
        #endregion

        #region Các sự kiện lọc và sự kiện phụ giữ lại tránh lỗi Designer
        private void textBox1_TextChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSearch();

        private void Form1_Load(object sender, EventArgs e) { }
        private void menuFile_Click(object sender, EventArgs e) { }
        private void txtServiceId_TextChanged(object sender, EventArgs e) { }
        private void txtCustomerName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void cboDeviceType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void nudEstimatedCost_ValueChanged(object sender, EventArgs e) { }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtIssueDescription_TextChanged(object sender, EventArgs e) { }
        private void picDevice_Click(object sender, EventArgs e) { }
        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblStatusCount_Click(object sender, EventArgs e) { }
        private void lblTotalPendingCost_Click(object sender, EventArgs e) { }
        #endregion
    }

    #region Model Class: RepairOrder
    public class RepairOrder : INotifyPropertyChanged
    {
        private string _orderId;
        private string _customerName;
        private string _phone;
        private string _deviceType;
        private DateTime _receiveDate;
        private decimal _estimatedCost;
        private string _status;
        private string _issueDescription;
        private string _imagePath;

        public string OrderId { get => _orderId; set { _orderId = value; OnPropertyChanged(); } }
        public string CustomerName { get => _customerName; set { _customerName = value; OnPropertyChanged(); } }
        public string Phone { get => _phone; set { _phone = value; OnPropertyChanged(); } }
        public string DeviceType { get => _deviceType; set { _deviceType = value; OnPropertyChanged(); } }
        public DateTime ReceiveDate { get => _receiveDate; set { _receiveDate = value; OnPropertyChanged(); } }
        public decimal EstimatedCost { get => _estimatedCost; set { _estimatedCost = value; OnPropertyChanged(); } }
        public string Status { get => _status; set { _status = value; OnPropertyChanged(); } }
        public string IssueDescription { get => _issueDescription; set { _issueDescription = value; OnPropertyChanged(); } }
        public string ImagePath { get => _imagePath; set { _imagePath = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
}