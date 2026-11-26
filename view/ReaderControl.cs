using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Baibaocao.net
{
    public partial class ReaderControl : UserControl
    {
        private readonly ReaderController readerController = new ReaderController();
        private int selectedId = 0;
        public ReaderControl()
        {
            InitializeComponent();
            Load += ReaderControl_Load;
            dgvReaders.CellClick += dgvReaders_CellClick;
            btnTimKiem.Click += btnTimKiem_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
        }
        private void ReaderControl_Load(object? sender, EventArgs e)
        {
            // khong nap du lieu khi dang mo Form1 trong trinh thiet ke (Design)
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            try
            {
                ClearForm();
                LoadReaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void LoadReaders(ReaderSearchBuilder? builder = null)
        {
            dgvReaders.DataSource = readerController.findAll(builder ?? new ReaderSearchBuilder());
            SetupGrid();
        }
        private void SetupGrid()
        {
            dgvReaders.AllowUserToAddRows = false;
            dgvReaders.ReadOnly = true;
            dgvReaders.RowHeadersVisible = false;
            dgvReaders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReaders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReaders.BackgroundColor = Color.White;
            SetHeader("Ma", "Mã", 30);
            SetHeader("HoTen", "Họ tên", 120);
            SetHeader("NgaySinh", "Ngày sinh", 80);
            SetHeader("GioiTinh", "Giới tính", 55);
            SetHeader("DiaChi", "Địa chỉ", 80);
            SetHeader("SoDienThoai", "SĐT", 80);
            SetHeader("NgayDangKy", "Ngày ĐK", 80);
            SetHeader("NgayHetHan", "Hết hạn", 80);
            SetHeader("TrangThai", "Trạng thái", 70);
            foreach (var name in new[] { "NgaySinh", "NgayDangKy", "NgayHetHan" })
                if (dgvReaders.Columns[name] != null) dgvReaders.Columns[name].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void SetHeader(string col, string text, float weight = 100)
        {
            var c = dgvReaders.Columns[col];
            if (c == null) return;
            c.HeaderText = text;
            c.FillWeight = weight;
        }
        private void dgvReaders_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvReaders.Rows[e.RowIndex].DataBoundItem is not ReaderDTO dto) return;
            selectedId = dto.Ma;
            txtHoTen.Text = dto.HoTen;
            dtpNgaySinh.Value = dto.NgaySinh ?? DateTime.Today;
            cboGioiTinh.SelectedItem = dto.GioiTinh;
            txtDiaChi.Text = dto.DiaChi;
            txtSDT.Text = dto.SoDienThoai;
            dtpNgayDangKy.Value = dto.NgayDangKy ?? DateTime.Today;
            dtpNgayHetHan.Value = dto.NgayHetHan ?? DateTime.Today.AddYears(1);
            cboTrangThai.SelectedItem = dto.TrangThai;
        }
        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            try
            {
                var tuKhoa = txtTimKiem.Text.Trim();
                var builder = new ReaderSearchBuilder();
                // nhap toan so thi tim theo SDT, nguoc lai tim theo ten
                if (tuKhoa.Length > 0 && tuKhoa.All(char.IsDigit))
                    builder.SoDienThoai = tuKhoa;
                else
                    builder.HoTen = tuKhoa;
                LoadReaders(builder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                var dto = ReadForm();
                dto.Ma = 0;
                readerController.Add(dto);
                ClearForm();
                LoadReaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                var dto = ReadForm();
                dto.Ma = selectedId;
                readerController.Update(dto);
                ClearForm();
                LoadReaders();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Hãy chọn độc giả cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa độc giả này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                readerController.Delete(selectedId);
                ClearForm();
                LoadReaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ReaderDTO ReadForm()
        {
            return new ReaderDTO
            {
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "",
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                NgayDangKy = dtpNgayDangKy.Value.Date,
                NgayHetHan = dtpNgayHetHan.Value.Date,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? ""
            };
        }
        private void ClearForm()
        {
            selectedId = 0;
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
            cboGioiTinh.SelectedIndex = -1;
            txtDiaChi.Clear();
            txtSDT.Clear();
            dtpNgayDangKy.Value = DateTime.Today;
            dtpNgayHetHan.Value = DateTime.Today.AddYears(1);
            cboTrangThai.SelectedIndex = 0;
        }
    }
}
