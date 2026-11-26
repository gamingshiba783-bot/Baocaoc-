namespace Baibaocao.net
{
    partial class RegisterForm
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
            txtHoTen = new TextBox();
            label2 = new Label();
            txtTenDangNhap = new TextBox();
            label3 = new Label();
            txtMatKhau = new TextBox();
            label4 = new Label();
            txtXacNhan = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnDangKy = new Button();
            btnHuy = new Button();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(0, 18);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(380, 40);
            lblTieuDe.Text = "ĐĂNG KÝ TÀI KHOẢN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(30, 82);
            label1.Name = "label1";
            label1.Text = "Họ tên";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(150, 78);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 23);
            txtHoTen.TabIndex = 0;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(30, 122);
            label2.Name = "label2";
            label2.Text = "Tên đăng nhập";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new Point(150, 118);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(200, 23);
            txtTenDangNhap.TabIndex = 1;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(30, 162);
            label3.Name = "label3";
            label3.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new Point(150, 158);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(200, 23);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.UseSystemPasswordChar = true;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(30, 202);
            label4.Name = "label4";
            label4.Text = "Nhập lại mật khẩu";
            //
            // txtXacNhan
            //
            txtXacNhan.Location = new Point(150, 198);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.Size = new Size(200, 23);
            txtXacNhan.TabIndex = 3;
            txtXacNhan.UseSystemPasswordChar = true;
            //
            // chkHienMatKhau
            //
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(150, 230);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.TabIndex = 4;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(150, 262);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(95, 38);
            btnDangKy.TabIndex = 5;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            //
            // btnHuy
            //
            btnHuy.Location = new Point(255, 262);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 38);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            //
            // RegisterForm
            //
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            CancelButton = btnHuy;
            ClientSize = new Size(380, 325);
            Controls.Add(lblTieuDe);
            Controls.Add(label1);
            Controls.Add(txtHoTen);
            Controls.Add(label2);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label3);
            Controls.Add(txtMatKhau);
            Controls.Add(label4);
            Controls.Add(txtXacNhan);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnDangKy);
            Controls.Add(btnHuy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng ký tài khoản";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTieuDe, label1, label2, label3, label4;
        private TextBox txtHoTen, txtTenDangNhap, txtMatKhau, txtXacNhan;
        private CheckBox chkHienMatKhau;
        private Button btnDangKy, btnHuy;
    }
}
