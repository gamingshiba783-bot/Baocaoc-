using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.view
{
    public partial class LoanControl : UserControl
    {
        private readonly LoanController loanController = new LoanController();
        private int selectedId = 0;
        private string selectedCondition = "";

        private sealed class StatusItem
        {
            public string Text { get; set; } = "";
            public int? Value { get; set; }
            public override string ToString() => Text;
        }

        public LoanControl()
        {
            InitializeComponent();
            Load += LoanControl_Load;
            dgvLoans.CellClick += dgvLoans_CellClick;
            btnTimKiem.Click += btnTimKiem_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTraSach.Click += btnTraSach_Click;
        }

        private void LoanControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            InitStaticComboBoxes();
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                LoadComboBoxes();
                LoadLoans();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private void InitStaticComboBoxes()
        {
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add(new StatusItem { Text = "Tất cả trạng thái", Value = null });
            cboLocTrangThai.Items.Add(new StatusItem { Text = "Đang mượn", Value = 1 });
            cboLocTrangThai.Items.Add(new StatusItem { Text = "Quá hạn", Value = 2 });
            cboLocTrangThai.Items.Add(new StatusItem { Text = "Đã trả", Value = 0 });
            cboLocTrangThai.SelectedIndex = 0;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add(new StatusItem { Text = "Đang mượn", Value = 1 });
            cboTrangThai.Items.Add(new StatusItem { Text = "Quá hạn", Value = 2 });
            cboTrangThai.Items.Add(new StatusItem { Text = "Đã trả", Value = 0 });
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadComboBoxes()
        {
            cboNhanVien.DataSource = loanController.GetEmployees();
            cboNhanVien.DisplayMember = "FullName";
            cboNhanVien.ValueMember = "Id";

            cboDocGia.DataSource = loanController.GetReaders();
            cboDocGia.DisplayMember = "FullName";
            cboDocGia.ValueMember = "Id";

            cboSach.DataSource = loanController.GetBooks();
            cboSach.DisplayMember = "BookTitle";
            cboSach.ValueMember = "Id";
        }

        private void LoadLoans(LoanSearchBuilder? builder = null)
        {
            dgvLoans.DataSource = loanController.findAll(builder ?? new LoanSearchBuilder());
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvLoans.AllowUserToAddRows = false;
            dgvLoans.ReadOnly = true;
            dgvLoans.RowHeadersVisible = false;
            dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoans.BackgroundColor = Color.White;

            SetHeader("Ma", "Mã", 35);
            SetHeader("DocGia", "Độc giả", 110);
            SetHeader("NhanVien", "Nhân viên", 90);
            SetHeader("TienPhat", "Tiền phạt", 60);
            SetHeader("TenSach", "Sách mượn", 130);
            SetHeader("NgayMuon", "Ngày mượn", 80, "dd/MM/yyyy");
            SetHeader("HanTra", "Hạn trả", 80, "dd/MM/yyyy");
            SetHeader("NgayTraThucTe", "Ngày trả", 80, "dd/MM/yyyy");
            SetHeader("TrangThai", "Trạng thái", 80);

            foreach (var name in new[] { "ReaderId", "BookId", "Status", "Details", "EmployeeId", "TinhTrangTra" })
                if (dgvLoans.Columns[name] != null) dgvLoans.Columns[name].Visible = false;
        }

        private void SetHeader(string col, string text, float weight = 100, string? format = null)
        {
            var c = dgvLoans.Columns[col];
            if (c == null) return;
            c.HeaderText = text;
            c.FillWeight = weight;
            if (!string.IsNullOrEmpty(format))
                c.DefaultCellStyle.Format = format;
        }

        private void dgvLoans_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvLoans.Rows[e.RowIndex].DataBoundItem is not LoanDTO dto) return;

            selectedId = dto.Ma;
            cboDocGia.SelectedValue = dto.ReaderId;
            if (dto.BookId > 0) cboSach.SelectedValue = dto.BookId;
            dtpNgayMuon.Value = dto.NgayMuon;
            dtpHanTra.Value = dto.HanTra;

            if (dto.NgayTraThucTe.HasValue)
            {
                dtpNgayTra.Checked = true;
                dtpNgayTra.Value = dto.NgayTraThucTe.Value;
            }
            else
            {
                dtpNgayTra.Checked = false;
            }

            selectedCondition = dto.TinhTrangTra;
            cboTrangThai.SelectedIndex = dto.Status == 2 ? 1 : dto.Status == 0 ? 2 : 0;
            if (dto.EmployeeId > 0) cboNhanVien.SelectedValue = dto.EmployeeId;
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            try
            {
                var filterStatus = (cboLocTrangThai.SelectedItem as StatusItem)?.Value;
                LoadLoans(new LoanSearchBuilder
                {
                    Keyword = txtTimKiem.Text.Trim(),
                    Status = filterStatus
                });
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
                loanController.Add(dto);
                ClearForm();
                LoadLoans();
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
                loanController.Update(dto);
                ClearForm();
                LoadLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Hãy chọn phiếu mượn cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa phiếu mượn này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                loanController.Delete(selectedId);
                ClearForm();
                LoadLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private void btnTraSach_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Hãy chọn phiếu mượn cần trả sách");
                return;
            }
            try
            {
                var returnDate = dtpNgayTra.Checked ? dtpNgayTra.Value.Date : DateTime.Today;
                var condition = "Tốt";
                loanController.ReturnBook(selectedId, null, returnDate, condition,
                    cboNhanVien.SelectedValue is int emp ? emp : 0);
                MessageBox.Show("Trả sách thành công!");
                ClearForm();
                LoadLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private LoanDTO ReadForm()
        {
            var status = (cboTrangThai.SelectedItem as StatusItem)?.Value ?? 1;
            return new LoanDTO
            {
                ReaderId = cboDocGia.SelectedValue is int r ? r : 0,
                EmployeeId = cboNhanVien.SelectedValue is int em ? em : 0,
                BookId = cboSach.SelectedValue is int b ? b : 0,
                NgayMuon = dtpNgayMuon.Value.Date,
                HanTra = dtpHanTra.Value.Date,
                NgayTraThucTe = dtpNgayTra.Checked ? dtpNgayTra.Value.Date : null,
                TinhTrangTra = selectedCondition,
                Status = status
            };
        }

        private void ClearForm()
        {
            selectedId = 0;
            dtpNgayMuon.Value = DateTime.Today;
            dtpHanTra.Value = DateTime.Today.AddDays(14);
            dtpNgayTra.Checked = false;
            selectedCondition = "";
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }
    }
}
