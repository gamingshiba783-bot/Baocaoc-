using Baibaocao.net.Controller;
using Baibaocao.net.Model.DTO;
using System.Windows.Forms;

namespace Baibaocao.net
{
    public partial class RegisterForm : Form
    {
        private readonly AccountController accountController = new AccountController();
        public string TenDangNhapMoi { get; private set; } = "";

        public RegisterForm()
        {
            InitializeComponent();
            btnDangKy.Click += btnDangKy_Click;
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            chkHienMatKhau.CheckedChanged += (s, e) =>
            {
                txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
                txtXacNhan.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            };
        }
        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            try
            {
                var dto = new RegisterDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text,
                    XacNhanMatKhau = txtXacNhan.Text
                };
                accountController.Register(dto);
                MessageBox.Show("Đăng ký thành công! Hãy đăng nhập.", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenDangNhapMoi = dto.TenDangNhap;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
