using System;
using System.Drawing;
using System.Windows.Forms;
using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.view
{
    public class BookStatusControl : UserControl
    {
        private readonly BookStatusController controller = new BookStatusController();
        private int selectedId = 0;

        private sealed class StateItem
        {
            public string Text { get; set; } = "";
            public int? Value { get; set; }
            public override string ToString() => Text;
        }

        private readonly Panel panelSearch = new Panel();
        private readonly TextBox txtTimKiem = new TextBox();
        private readonly ComboBox cboLocTrangThai = new ComboBox();
        private readonly ComboBox cboLocTinhTrang = new ComboBox();
        private readonly Button btnTimKiem = new Button();
        private readonly DataGridView dgv = new DataGridView();
        private readonly Panel panelEdit = new Panel();
        private readonly Label lblChon = new Label();
        private readonly ComboBox cboTinhTrang = new ComboBox();
        private readonly NumericUpDown nudTienPhat = new NumericUpDown();
        private readonly Button btnLuu = new Button();

        public BookStatusControl()
        {
            Size = new Size(789, 418);
            BuildUi();
            Load += (s, e) => { if (!DesignMode) RefreshData(); };
        }

        private void BuildUi()
        {
            panelSearch.BackColor = SystemColors.GradientInactiveCaption;
            panelSearch.SetBounds(7, 4, 775, 46);

            txtTimKiem.PlaceholderText = "Tìm sách / độc giả...";
            txtTimKiem.SetBounds(10, 11, 200, 23);

            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.SetBounds(220, 11, 130, 23);
            cboLocTrangThai.Items.Add(new StateItem { Text = "Tất cả trạng thái", Value = null });
            cboLocTrangThai.Items.Add(new StateItem { Text = "Chưa trả", Value = 1 });
            cboLocTrangThai.Items.Add(new StateItem { Text = "Quá hạn", Value = 2 });
            cboLocTrangThai.Items.Add(new StateItem { Text = "Đã trả", Value = 3 });
            cboLocTrangThai.SelectedIndex = 0;

            cboLocTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTinhTrang.SetBounds(360, 11, 130, 23);
            cboLocTinhTrang.Items.AddRange(new object[] { "Tất cả tình trạng", "Tốt", "Hư hỏng", "Mất" });
            cboLocTinhTrang.SelectedIndex = 0;

            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.SetBounds(500, 8, 90, 30);
            btnTimKiem.Click += (s, e) => LoadData();

            panelSearch.Controls.AddRange(new Control[] { txtTimKiem, cboLocTrangThai, cboLocTinhTrang, btnTimKiem });

            dgv.SetBounds(7, 56, 775, 304);
            dgv.CellClick += Dgv_CellClick;

            panelEdit.BackColor = SystemColors.GradientActiveCaption;
            panelEdit.SetBounds(7, 366, 775, 46);

            lblChon.AutoSize = false;
            lblChon.Text = "Chọn một dòng để cập nhật";
            lblChon.TextAlign = ContentAlignment.MiddleLeft;
            lblChon.SetBounds(10, 11, 300, 23);

            var lblTt = new Label { Text = "Tình trạng", AutoSize = true, Location = new Point(320, 15) };
            cboTinhTrang.SetBounds(390, 11, 110, 23);
            cboTinhTrang.Items.AddRange(new object[] { "", "Tốt", "Hư hỏng", "Mất" });
            cboTinhTrang.SelectedIndex = 0;

            var lblPhat = new Label { Text = "Tiền phạt", AutoSize = true, Location = new Point(515, 15) };
            nudTienPhat.SetBounds(580, 11, 90, 23);
            nudTienPhat.Maximum = 100000000;
            nudTienPhat.Increment = 1000;

            btnLuu.Text = "Lưu";
            btnLuu.SetBounds(685, 8, 80, 30);
            btnLuu.Click += btnLuu_Click;

            panelEdit.Controls.AddRange(new Control[] { lblChon, lblTt, cboTinhTrang, lblPhat, nudTienPhat, btnLuu });

            Controls.Add(panelSearch);
            Controls.Add(dgv);
            Controls.Add(panelEdit);
        }

        public void RefreshData()
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private void LoadData()
        {
            var condition = cboLocTinhTrang.SelectedIndex > 0 ? cboLocTinhTrang.Text : null;
            dgv.DataSource = controller.findAll(new BookStatusSearchBuilder
            {
                Keyword = txtTimKiem.Text.Trim(),
                State = (cboLocTrangThai.SelectedItem as StateItem)?.Value,
                Condition = condition
            });
            SetupGrid();
            selectedId = 0;
            lblChon.Text = "Chọn một dòng để cập nhật";
        }

        private void SetupGrid()
        {
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;

            SetHeader("Ma", "Mã", 35);
            SetHeader("TenSach", "Tên sách", 140);
            SetHeader("DocGia", "Độc giả", 100);
            SetHeader("NgayMuon", "Ngày mượn", 75, "dd/MM/yyyy");
            SetHeader("HanTra", "Hạn trả", 75, "dd/MM/yyyy");
            SetHeader("NgayTra", "Ngày trả", 75, "dd/MM/yyyy");
            SetHeader("TinhTrang", "Tình trạng", 70);
            SetHeader("TienPhat", "Tiền phạt", 65, "N0");
            SetHeader("NhanVienNhan", "NV nhận", 85);
            SetHeader("TrangThai", "Trạng thái", 70);
            if (dgv.Columns["LoanId"] != null) dgv.Columns["LoanId"].Visible = false;
        }

        private void SetHeader(string col, string text, float weight, string? format = null)
        {
            var c = dgv.Columns[col];
            if (c == null) return;
            c.HeaderText = text;
            c.FillWeight = weight;
            if (!string.IsNullOrEmpty(format)) c.DefaultCellStyle.Format = format;
        }

        private void Dgv_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv.Rows[e.RowIndex].DataBoundItem is not BookStatusDTO dto) return;
            selectedId = dto.Ma;
            lblChon.Text = $"#{dto.Ma} - {dto.TenSach} ({dto.DocGia})";
            cboTinhTrang.Text = dto.TinhTrang;
            nudTienPhat.Value = Math.Min(nudTienPhat.Maximum, Math.Max(0, dto.TienPhat));
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            try
            {
                controller.UpdateCondition(selectedId, cboTinhTrang.Text, (int)nudTienPhat.Value);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
