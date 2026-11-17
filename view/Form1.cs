using System.Data.Common;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Baibaocao.net.DataAccess;

namespace Baibaocao.net
{
    public partial class Form1 : Form
    {
        private int _selectedId = 0;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dgvBooks.CellClick += dgvBooks_CellClick;
            btnTimKiem.Click += btnTimKiem_Click;
            btnXoa.Click += btnXoa_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadComboBoxes();
        }
        private void LoadBooks(String keyword = "")
        {
            using (var db = new LibraryContext())
            {
                var query = db.Books
                            .Include(b => b.Publisher)
                            .Include(b => b.BooksAuthors).ThenInclude(ba => ba.Author)
                            .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
                            .AsNoTracking()
                            .AsQueryable();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(b => b.BookTitle.Contains(keyword));
                }
                var data = query.ToList().Select(b => new
                {
                    Ma = b.Id,
                    TenSach = b.BookTitle,
                    NhaXuatBan = b.Publisher?.PublisherName,
                    NamXuatBan = b.PublishYear,
                    TacGia = string.Join(",", b.BooksAuthors.Select(x => x.Author.AuthorName)),
                    TheLoai = string.Join(",", b.BookCategories.Select(x => x.Category.CategoryName))
                }).ToList();
                dgvBooks.DataSource = data;
            }
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

            dgvBooks.Columns["Ma"].HeaderText = "Mã";
            dgvBooks.Columns["TenSach"].HeaderText = "Tên sách";
            dgvBooks.Columns["NhaXuatBan"].HeaderText = "Nhà xuất bản";
            dgvBooks.Columns["NamXuatBan"].HeaderText = "Năm XB";
            dgvBooks.Columns["TacGia"].HeaderText = "Tác giả";
            dgvBooks.Columns["TheLoai"].HeaderText = "Thể loại";
            dgvBooks.Columns["Ma"].FillWeight = 30;
        }
        private void LoadComboBoxes()
        {
            using (var db = new LibraryContext())
            {
                cboNXB.DataSource = db.Publishers.AsNoTracking().ToList();
                cboNXB.DisplayMember = "PublisherName";
                cboNXB.ValueMember = "Id";

                cboTacGia.DataSource = db.Authors.AsNoTracking().ToList();
                cboTacGia.DisplayMember = "AuthorName";
                cboTacGia.ValueMember = "Id";

                cboTheLoai.DataSource = db.Categories.AsNoTracking().ToList();
                cboTheLoai.DisplayMember = "CategoryName";
                cboTheLoai.ValueMember = "Id";
            }
        }
        private void dgvBooks_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvBooks.Rows[e.RowIndex];
            _selectedId= Convert.ToInt32(row.Cells["Ma"].Value);
            txtTenSach.Text = row.Cells["TenSach"].Value?.ToString();
            txtNamSX.Text = row.Cells["NamXuatBan"].Value?.ToString();
            cboNXB.Text = row.Cells["NhaXuatBan"].Value?.ToString();
        }
        private void btnTimKiem_Click(Object sender, EventArgs e)
        {
            LoadBooks(txtTimKiem.Text.Trim());
        }
        private void btnXoa_Click(Object sender,EventArgs e)
        {
            if(_selectedId == 0)
            {
                MessageBox.Show("Hãy chọn sách cần xóa");
                return;
            }
            if (MessageBox.Show("Xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            using(var db=new LibraryContext())
            {
                var book = db.Books
                    .Include(b => b.BooksAuthors)
                    .Include(b => b.BookCategories)
                    .FirstOrDefault(b => b.Id == _selectedId);
                if(book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
            _selectedId = 0;
            LoadBooks();
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
