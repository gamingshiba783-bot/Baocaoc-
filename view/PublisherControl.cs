using System;
using System.Drawing;
using System.Windows.Forms;
using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.view
{
    public class PublisherControl : UserControl
    {
        private readonly PublisherController controller = new PublisherController();
        private int selectedId = 0;

        private readonly TextBox txtTimKiem = new TextBox();
        private readonly DataGridView dgv = new DataGridView();
        private readonly TextBox txtTen = new TextBox();
        private readonly TextBox txtDiaChi = new TextBox();
        private readonly TextBox txtDienThoai = new TextBox();
        private readonly TextBox txtEmail = new TextBox();

        public PublisherControl()
        {
            Size = new Size(775, 384);
            BuildUi();
            Load += (s, e) => { if (!DesignMode) RefreshData(); };
        }

        private void BuildUi()
        {
            var panelSearch = new Panel { BackColor = SystemColors.GradientInactiveCaption };
            panelSearch.SetBounds(4, 4, 765, 46);
            txtTimKiem.PlaceholderText = "Tìm nhà xuất bản...";
            txtTimKiem.SetBounds(10, 11, 250, 23);
            var btnTimKiem = new Button { Text = "Tìm kiếm" };
            btnTimKiem.SetBounds(270, 8, 90, 30);
            btnTimKiem.Click += (s, e) => RefreshData();
            panelSearch.Controls.AddRange(new Control[] { txtTimKiem, btnTimKiem });

            dgv.SetBounds(4, 56, 500, 320);
            dgv.CellClick += Dgv_CellClick;

            var panelInput = new Panel { BackColor = SystemColors.GradientActiveCaption };
            panelInput.SetBounds(513, 56, 255, 320);

            var lblTen = new Label { Text = "Tên nhà xuất bản", AutoSize = true, Location = new Point(12, 8) };
            txtTen.SetBounds(12, 26, 230, 23);
            txtTen.MaxLength = 150;
            var lblDc = new Label { Text = "Địa chỉ", AutoSize = true, Location = new Point(12, 58) };
            txtDiaChi.SetBounds(12, 76, 230, 23);
            txtDiaChi.MaxLength = 255;
            var lblSdt = new Label { Text = "Điện thoại", AutoSize = true, Location = new Point(12, 108) };
            txtDienThoai.SetBounds(12, 126, 230, 23);
            txtDienThoai.MaxLength = 20;
            var lblEmail = new Label { Text = "Email", AutoSize = true, Location = new Point(12, 158) };
            txtEmail.SetBounds(12, 176, 230, 23);
            txtEmail.MaxLength = 100;

            var btnThem = new Button { Text = "Thêm" };
            btnThem.SetBounds(12, 216, 110, 36);
            btnThem.Click += (s, e) => Run(() => controller.Add(ReadForm()));
            var btnSua = new Button { Text = "Sửa" };
            btnSua.SetBounds(132, 216, 110, 36);
            btnSua.Click += (s, e) => Run(() => { var d = ReadForm(); d.Ma = selectedId; controller.Update(d); });
            var btnXoa = new Button { Text = "Xóa" };
            btnXoa.SetBounds(12, 262, 110, 36);
            btnXoa.Click += btnXoa_Click;
            var btnLamMoi = new Button { Text = "Làm mới" };
            btnLamMoi.SetBounds(132, 262, 110, 36);
            btnLamMoi.Click += (s, e) => { txtTimKiem.Clear(); ClearForm(); RefreshData(); };

            panelInput.Controls.AddRange(new Control[] { lblTen, txtTen, lblDc, txtDiaChi, lblSdt, txtDienThoai, lblEmail, txtEmail, btnThem, btnSua, btnXoa, btnLamMoi });

            Controls.Add(panelSearch);
            Controls.Add(dgv);
            Controls.Add(panelInput);
        }

        public void RefreshData()
        {
            try
            {
                dgv.DataSource = controller.findAll(new PublisherSearchBuilder { Keyword = txtTimKiem.Text.Trim() });
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
            SetHeader("TenNXB", "Tên NXB", 90);
            SetHeader("DiaChi", "Địa chỉ", 60);
            SetHeader("DienThoai", "Điện thoại", 60);
            SetHeader("Email", "Email", 80);
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
            if (dgv.Rows[e.RowIndex].DataBoundItem is not PublisherDTO dto) return;
            selectedId = dto.Ma;
            txtTen.Text = dto.TenNXB;
            txtDiaChi.Text = dto.DiaChi;
            txtDienThoai.Text = dto.DienThoai;
            txtEmail.Text = dto.Email;
        }

        private PublisherDTO ReadForm()
        {
            return new PublisherDTO
            {
                TenNXB = txtTen.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
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
                MessageBox.Show("Hãy chọn nhà xuất bản cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa nhà xuất bản này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            Run(() => controller.Delete(selectedId));
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtTen.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
        }
    }
}
