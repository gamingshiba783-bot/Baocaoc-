namespace Baibaocao.net
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            txtMatKhau = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnDangNhap = new Button();
            label3 = new Label();
            btnDangKy = new Button();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(0, 18);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(380, 40);
            lblTieuDe.Text = "ĐĂNG NHẬP";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(40, 82);
            label1.Name = "label1";
            label1.Text = "Tên đăng nhập";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new Point(150, 78);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(190, 23);
            txtTenDangNhap.TabIndex = 0;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(40, 122);
            label2.Name = "label2";
            label2.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new Point(150, 118);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(190, 23);
            txtMatKhau.TabIndex = 1;
            txtMatKhau.UseSystemPasswordChar = true;
            //
            // chkHienMatKhau
            //
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(150, 150);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.TabIndex = 2;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            //
            // btnDangNhap
            //
            btnDangNhap.Location = new Point(150, 182);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(190, 38);
            btnDangNhap.TabIndex = 3;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(40, 246);
            label3.Name = "label3";
            label3.Text = "Chưa có tài khoản?";
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(150, 238);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(190, 32);
            btnDangKy.TabIndex = 4;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            //
            // LoginForm
            //
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(380, 295);
            Controls.Add(lblTieuDe);
            Controls.Add(label1);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label2);
            Controls.Add(txtMatKhau);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(label3);
            Controls.Add(btnDangKy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Quản lý thư viện";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTieuDe, label1, label2, label3;
        private TextBox txtTenDangNhap, txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap, btnDangKy;
    }
}
