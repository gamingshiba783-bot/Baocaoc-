using Baibaocao.net.Controller;
using Baibaocao.net.Util;
using System.Windows.Forms;

namespace Baibaocao.net
{
    public partial class LoginForm : Form
    {
        private readonly AccountController accountController = new AccountController();
        public LoginForm()
        {
            InitializeComponent();
            btnDangNhap.Click += btnDangNhap_Click;
            btnDangKy.Click += btnDangKy_Click;
            chkHienMatKhau.CheckedChanged += (s, e) => txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            try
            {
                var user = accountController.Login(txtTenDangNhap.Text, txtMatKhau.Text);
                Session.CurrentUser = user;
                DialogResult = DialogResult.OK;   // Program.cs se mo form chinh
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }
        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            using (var f = new RegisterForm())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    // dien san ten dang nhap vua tao
                    txtTenDangNhap.Text = f.TenDangNhapMoi;
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
        }
    }
}
