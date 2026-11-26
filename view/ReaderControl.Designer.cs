namespace Baibaocao.net
{
    partial class ReaderControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panel2 = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            panel3 = new Panel();
            txtHoTen = new TextBox();
            label1 = new Label();
            dtpNgaySinh = new DateTimePicker();
            label2 = new Label();
            cboGioiTinh = new ComboBox();
            label3 = new Label();
            txtDiaChi = new TextBox();
            label4 = new Label();
            txtSDT = new TextBox();
            label5 = new Label();
            dtpNgayDangKy = new DateTimePicker();
            label6 = new Label();
            dtpNgayHetHan = new DateTimePicker();
            label7 = new Label();
            cboTrangThai = new ComboBox();
            label8 = new Label();
            dgvReaders = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).BeginInit();
            SuspendLayout();
            //
            // panel1
            //
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Location = new Point(16, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 78);
            panel1.TabIndex = 3;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(365, 22);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(105, 40);
            btnXoa.TabIndex = 0;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            //
            // btnSua
            //
            btnSua.Location = new Point(197, 22);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(105, 40);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            //
            // btnThem
            //
            btnThem.Location = new Point(27, 22);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(105, 40);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            //
            // panel2
            //
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Location = new Point(545, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 78);
            panel2.TabIndex = 2;
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(13, 33);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tên hoặc SĐT";
            txtTimKiem.Size = new Size(148, 23);
            txtTimKiem.TabIndex = 0;
            //
            // btnTimKiem
            //
            btnTimKiem.Location = new Point(167, 24);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(70, 38);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            //
            // panel3
            //
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtHoTen);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(dtpNgaySinh);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(cboGioiTinh);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtDiaChi);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtSDT);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(dtpNgayDangKy);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(dtpNgayHetHan);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(cboTrangThai);
            panel3.Location = new Point(547, 108);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 302);
            panel3.TabIndex = 1;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(8, 17);
            label1.Name = "label1";
            label1.Text = "Họ tên";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(96, 14);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(139, 23);
            txtHoTen.TabIndex = 0;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(8, 53);
            label2.Name = "label2";
            label2.Text = "Ngày sinh";
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(96, 50);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(139, 23);
            dtpNgaySinh.TabIndex = 1;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(8, 89);
            label3.Name = "label3";
            label3.Text = "Giới tính";
            //
            // cboGioiTinh
            //
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.Location = new Point(96, 86);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(139, 23);
            cboGioiTinh.TabIndex = 2;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(8, 125);
            label4.Name = "label4";
            label4.Text = "Địa chỉ";
            //
            // txtDiaChi
            //
            txtDiaChi.Location = new Point(96, 122);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(139, 23);
            txtDiaChi.TabIndex = 3;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(8, 161);
            label5.Name = "label5";
            label5.Text = "Số điện thoại";
            //
            // txtSDT
            //
            txtSDT.Location = new Point(96, 158);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(139, 23);
            txtSDT.TabIndex = 4;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(8, 197);
            label6.Name = "label6";
            label6.Text = "Ngày đăng ký";
            //
            // dtpNgayDangKy
            //
            dtpNgayDangKy.CustomFormat = "dd/MM/yyyy";
            dtpNgayDangKy.Format = DateTimePickerFormat.Custom;
            dtpNgayDangKy.Location = new Point(96, 194);
            dtpNgayDangKy.Name = "dtpNgayDangKy";
            dtpNgayDangKy.Size = new Size(139, 23);
            dtpNgayDangKy.TabIndex = 5;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(8, 233);
            label7.Name = "label7";
            label7.Text = "Ngày hết hạn";
            //
            // dtpNgayHetHan
            //
            dtpNgayHetHan.CustomFormat = "dd/MM/yyyy";
            dtpNgayHetHan.Format = DateTimePickerFormat.Custom;
            dtpNgayHetHan.Location = new Point(96, 230);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(139, 23);
            dtpNgayHetHan.TabIndex = 6;
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(8, 269);
            label8.Name = "label8";
            label8.Text = "Trạng thái";
            //
            // cboTrangThai
            //
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Hoạt động", "Bị khóa" });
            cboTrangThai.Location = new Point(96, 266);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(139, 23);
            cboTrangThai.TabIndex = 7;
            //
            // dgvReaders
            //
            dgvReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReaders.Location = new Point(16, 108);
            dgvReaders.Name = "dgvReaders";
            dgvReaders.Size = new Size(510, 302);
            dgvReaders.TabIndex = 0;
            //
            // ReaderControl
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Size = new Size(789, 418);
            Controls.Add(dgvReaders);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ReaderControl";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReaders).EndInit();
            ResumeLayout(false);
        }

        private Panel panel1, panel2, panel3;
        private Button btnThem, btnSua, btnXoa, btnTimKiem;
        private TextBox txtTimKiem, txtHoTen, txtDiaChi, txtSDT;
        private DateTimePicker dtpNgaySinh, dtpNgayDangKy, dtpNgayHetHan;
        private ComboBox cboGioiTinh, cboTrangThai;
        private Label label1, label2, label3, label4, label5, label6, label7, label8;
        private DataGridView dgvReaders;
    }
}
