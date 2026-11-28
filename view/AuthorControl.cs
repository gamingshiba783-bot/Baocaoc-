using System;
using System.Drawing;
using System.Windows.Forms;
using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.view
{
    public class AuthorControl : UserControl
    {
        private readonly AuthorController controller = new AuthorController();
        private int selectedId = 0;

        private readonly TextBox txtTimKiem = new TextBox();
        private readonly DataGridView dgv = new DataGridView();
        private readonly TextBox txtTen = new TextBox();
        private readonly TextBox txtDiaChi = new TextBox();
        private readonly TextBox txtNamSinh = new TextBox();

        public AuthorControl()
        {
            Size = new Size(775, 384);
            BuildUi();
            Load += (s, e) => { if (!DesignMode) RefreshData(); };
        }

        private void BuildUi()
        {
            var panelSearch = new Panel { BackColor = SystemColors.GradientInactiveCaption };
            panelSearch.SetBounds(4, 4, 765, 46);
            txtTimKiem.PlaceholderText = "Tìm tác giả...";
            txtTimKiem.SetBounds(10, 11, 250, 23);
            var btnTimKiem = new Button { Text = "Tìm kiếm" };
            btnTimKiem.SetBounds(270, 8, 90, 30);
            btnTimKiem.Click += (s, e) => RefreshData();
            panelSearch.Controls.AddRange(new Control[] { txtTimKiem, btnTimKiem });

            dgv.SetBounds(4, 56, 500, 320);
            dgv.CellClick += Dgv_CellClick;

            var panelInput = new Panel { BackColor = SystemColors.GradientActiveCaption };
            panelInput.SetBounds(513, 56, 255, 320);

            var lblTen = new Label { Text = "Tên tác giả", AutoSize = true, Location = new Point(12, 12) };
            txtTen.SetBounds(12, 32, 230, 23);
            txtTen.MaxLength = 150;
            var lblDc = new Label { Text = "Địa chỉ", AutoSize = true, Location = new Point(12, 68) };
            txtDiaChi.SetBounds(12, 88, 230, 23);
            txtDiaChi.MaxLength = 255;
            var lblNs = new Label { Text = "Năm sinh", AutoSize = true, Location = new Point(12, 124) };
            txtNamSinh.SetBounds(12, 144, 230, 23);

            var btnThem = new Button { Text = "Thêm" };
            btnThem.SetBounds(12, 190, 110, 36);
            btnThem.Click += (s, e) => Run(() => controller.Add(ReadForm()));
            var btnSua = new Button { Text = "Sửa" };
            btnSua.SetBounds(132, 190, 110, 36);
            btnSua.Click += (s, e) => Run(() => { var d = ReadForm(); d.Ma = selectedId; controller.Update(d); });
            var btnXoa = new Button { Text = "Xóa" };
            btnXoa.SetBounds(12, 236, 110, 36);
            btnXoa.Click += btnXoa_Click;
            var btnLamMoi = new Button { Text = "Làm mới" };
            btnLamMoi.SetBounds(132, 236, 110, 36);
            btnLamMoi.Click += (s, e) => { txtTimKiem.Clear(); ClearForm(); RefreshData(); };

            panelInput.Controls.AddRange(new Control[] { lblTen, txtTen, lblDc, txtDiaChi, lblNs, txtNamSinh, btnThem, btnSua, btnXoa, btnLamMoi });

            Controls.Add(panelSearch);
            Controls.Add(dgv);
            Controls.Add(panelInput);
        }

        public void RefreshData()
        {
            try
            {
                dgv.DataSource = controller.findAll(new AuthorSearchBuilder { Keyword = txtTimKiem.Text.Trim() });
                SetupGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }

        private void SetupGrid()
        {
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            SetHeader("Ma", "Mã", 25);
            SetHeader("TenTacGia", "Tên tác giả", 100);
            SetHeader("DiaChi", "Địa chỉ", 70);
            SetHeader("NamSinh", "Năm sinh", 40);
            SetHeader("SoSach", "Số sách", 35);
        }

        private void SetHeader(string col, string text, float weight)
        {
            var c = dgv.Columns[col];
            if (c == null) return;
            c.HeaderText = text;
            c.FillWeight = weight;
        }

        private void Dgv_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv.Rows[e.RowIndex].DataBoundItem is not AuthorDTO dto) return;
            selectedId = dto.Ma;
            txtTen.Text = dto.TenTacGia;
            txtDiaChi.Text = dto.DiaChi;
            txtNamSinh.Text = dto.NamSinh?.ToString() ?? "";
        }

        private AuthorDTO ReadForm()
        {
            int? year = null;
            var text = txtNamSinh.Text.Trim();
            if (text.Length > 0)
            {
                if (!int.TryParse(text, out int y)) throw new Exception("Năm sinh phải là số");
                year = y;
            }
            return new AuthorDTO { TenTacGia = txtTen.Text.Trim(), DiaChi = txtDiaChi.Text.Trim(), NamSinh = year };
        }

        private void Run(Action action)
        {
            try
            {
                action();
                ClearForm();
                RefreshData();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Hãy chọn tác giả cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa tác giả này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            Run(() => controller.Delete(selectedId));
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtTen.Clear();
            txtDiaChi.Clear();
            txtNamSinh.Clear();
        }
    }
}
