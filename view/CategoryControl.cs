using System;
using System.Drawing;
using System.Windows.Forms;
using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.SearchBuilder;

namespace Baibaocao.net.view
{
    public class CategoryControl : UserControl
    {
        private readonly CategoryController controller = new CategoryController();
        private int selectedId = 0;

        private readonly Panel panelSearch = new Panel();
        private readonly TextBox txtTimKiem = new TextBox();
        private readonly Button btnTimKiem = new Button();
        private readonly DataGridView dgv = new DataGridView();
        private readonly Panel panelInput = new Panel();
        private readonly TextBox txtTen = new TextBox();
        private readonly Button btnThem = new Button();
        private readonly Button btnSua = new Button();
        private readonly Button btnXoa = new Button();
        private readonly Button btnLamMoi = new Button();

        public CategoryControl()
        {
            Size = new Size(775, 384);
            BuildUi();
            Load += (s, e) => { if (!DesignMode) RefreshData(); };
        }

        private void BuildUi()
        {
            panelSearch.BackColor = SystemColors.GradientInactiveCaption;
            panelSearch.SetBounds(4, 4, 765, 46);

            txtTimKiem.PlaceholderText = "Tìm danh mục...";
            txtTimKiem.SetBounds(10, 11, 250, 23);

            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.SetBounds(270, 8, 90, 30);
            btnTimKiem.Click += (s, e) => RefreshData();
            panelSearch.Controls.AddRange(new Control[] { txtTimKiem, btnTimKiem });

            dgv.SetBounds(4, 56, 500, 320);
            dgv.CellClick += Dgv_CellClick;

            panelInput.BackColor = SystemColors.GradientActiveCaption;
            panelInput.SetBounds(513, 56, 255, 320);

            var lblTen = new Label { Text = "Tên danh mục", AutoSize = true, Location = new Point(12, 20) };
            txtTen.SetBounds(12, 42, 236, 23);
            txtTen.MaxLength = 100;

            btnThem.Text = "Thêm";
            btnThem.SetBounds(12, 85, 112, 36);
            btnThem.Click += btnThem_Click;

            btnSua.Text = "Sửa";
            btnSua.SetBounds(136, 85, 112, 36);
            btnSua.Click += btnSua_Click;

            btnXoa.Text = "Xóa";
            btnXoa.SetBounds(12, 133, 112, 36);
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.SetBounds(136, 133, 112, 36);
            btnLamMoi.Click += (s, e) => { txtTimKiem.Clear(); ClearForm(); RefreshData(); };

            panelInput.Controls.AddRange(new Control[] { lblTen, txtTen, btnThem, btnSua, btnXoa, btnLamMoi });

            Controls.Add(panelSearch);
            Controls.Add(dgv);
            Controls.Add(panelInput);
        }

        public void RefreshData()
        {
            try
            {
                dgv.DataSource = controller.findAll(new CategorySearchBuilder { TenDanhMuc = txtTimKiem.Text.Trim() });
                SetupGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
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
            SetHeader("TenDanhMuc", "Tên danh mục", 100);
            SetHeader("SoSach", "Số sách", 30);
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
            if (dgv.Rows[e.RowIndex].DataBoundItem is not CategoryDTO dto) return;
            selectedId = dto.Ma;
            txtTen.Text = dto.TenDanhMuc;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                controller.Add(new CategoryDTO { TenDanhMuc = txtTen.Text.Trim() });
                ClearForm();
                RefreshData();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                controller.Update(new CategoryDTO { Ma = selectedId, TenDanhMuc = txtTen.Text.Trim() });
                ClearForm();
                RefreshData();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Hãy chọn danh mục cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                controller.Delete(selectedId);
                ClearForm();
                RefreshData();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtTen.Clear();
        }
    }
}
