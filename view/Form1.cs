using Baibaocao.net.Controller;
using Baibaocao.net.DataAccess;
using Baibaocao.net.Model.DTO;
using Baibaocao.net.Model.Entity;
using Baibaocao.net.Model.SearchBuilder;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace Baibaocao.net
{
    public partial class Form1 : Form
    {
        private readonly BookController bookController = new BookController();
        private int selectedId = 0;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            dgvBooks.CellClick += dgvBooks_CellClick;
            btnTimKiem.Click += btnTimKiem_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }
        private void tabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
                loanControl1.RefreshData();
            else if (tabControl1.SelectedTab == tabPage3)
                bookStatusControl1.RefreshData();
            else if (tabControl1.SelectedTab == tabPage4)
                catalogControl1.RefreshData();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxes();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void LoadBooks(BookSearchBuilder? builder = null)
        {
            dgvBooks.DataSource = bookController.findAll(builder ?? new BookSearchBuilder());
            SetupGrid();
         }
        private void SetupGrid()
        {
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            SetHeader("Ma", "Mã", 30);
            SetHeader("TenSach", "Tên sách");
            SetHeader("NhaXuatBan", "Nhà xuất bản");
            SetHeader("NamXuatBan", "Năm XB");
            SetHeader("TacGia", "Tác giả");
            SetHeader("TheLoai", "Thể loại");
            foreach (var name in new[] { "PublisherId", "AuthorId", "CategoryId" })
                if (dgvBooks.Columns[name] != null) dgvBooks.Columns[name].Visible = false;
        }

        private void SetHeader(string col, string text, float weight = 100)
        {
            var c = dgvBooks.Columns[col];
            if (c == null) return;
            c.HeaderText = text;
            c.FillWeight = weight;
        }
        private void LoadComboBoxes()
        {
                cboNXB.DataSource = bookController.GetPublishers();
                cboNXB.DisplayMember = "PublisherName";
                cboNXB.ValueMember = "Id";

                cboTacGia.DataSource = bookController.GetAuthors();
                cboTacGia.DisplayMember = "AuthorName";
                cboTacGia.ValueMember = "Id";

                cboTheLoai.DataSource = bookController.GetCategories();
                cboTheLoai.DisplayMember = "CategoryName";
            cboTheLoai.ValueMember = "Id";
        }
        private void dgvBooks_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvBooks.Rows[e.RowIndex].DataBoundItem is not BookDTO bookdto) return;
            selectedId = bookdto.Ma;
            txtTenSach.Text = bookdto.TenSach;
            txtNamSX.Text = bookdto.NamXuatBan.ToString();
            cboNXB.SelectedValue = bookdto.PublisherId;
            cboTheLoai.SelectedValue = bookdto.CategoryId;
            cboTacGia.SelectedValue = bookdto.AuthorId;

        }
        private void btnTimKiem_Click(Object sender, EventArgs e)
        {
            try
            {
                LoadBooks(new BookSearchBuilder { TenSach = txtTimKiem.Text.Trim() });
            }catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void btnThem_Click(Object sender, EventArgs e)
        {
            try
            {
                var dto = ReadForm();
                dto.Ma = 0;
                bookController.Add(dto);
                ClearForm();
                LoadBooks();

            }catch(Exception ex)
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
                bookController.Update(dto);
                ClearForm();
                LoadBooks();
            }
            catch (Exception ex) { MessageBox.Show(ex.InnerException?.Message ?? ex.Message); }
        }
        private void btnXoa_Click(Object sender,EventArgs e)
        {
            if(selectedId == 0)
            {
                MessageBox.Show("Hãy chọn sách cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                bookController.Delete(selectedId);
                ClearForm();
                LoadBooks();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private BookDTO ReadForm()
        {
            int.TryParse(txtNamSX.Text, out int nam);
            return new BookDTO
            {
                TenSach = txtTenSach.Text.Trim(),
                NamXuatBan = nam,
                PublisherId = cboNXB.SelectedValue is int p ? p : 0,
                AuthorId = cboTacGia.SelectedValue is int a ? a : 0,
                CategoryId = cboTheLoai.SelectedValue is int c ? c : 0
            };
        }
        private void ClearForm()
        {
            selectedId = 0;
            txtTenSach.Clear();
            txtNamSX.Clear();
            txtGhiChu.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
