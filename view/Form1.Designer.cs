namespace Baibaocao.net
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvBooks = new DataGridView();
            panel3 = new Panel();
            txtGhiChu = new TextBox();
            cboTacGia = new ComboBox();
            cboTheLoai = new ComboBox();
            cboNXB = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtNamSX = new TextBox();
            label2 = new Label();
            txtTenSach = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            panel1 = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            tabPage2 = new TabPage();
            readerControl1 = new ReaderControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(2, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(797, 446);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvBooks);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(789, 418);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(7, 103);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.Size = new Size(510, 314);
            dgvBooks.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Controls.Add(txtGhiChu);
            panel3.Controls.Add(cboTacGia);
            panel3.Controls.Add(cboTheLoai);
            panel3.Controls.Add(cboNXB);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtNamSX);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtTenSach);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(538, 103);
            panel3.Name = "panel3";
            panel3.Size = new Size(243, 314);
            panel3.TabIndex = 5;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(94, 255);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(144, 48);
            txtGhiChu.TabIndex = 0;
            // 
            // cboTacGia
            // 
            cboTacGia.FormattingEnabled = true;
            cboTacGia.Location = new Point(96, 214);
            cboTacGia.Name = "cboTacGia";
            cboTacGia.Size = new Size(142, 23);
            cboTacGia.TabIndex = 1;
            // 
            // cboTheLoai
            // 
            cboTheLoai.FormattingEnabled = true;
            cboTheLoai.Location = new Point(96, 184);
            cboTheLoai.Name = "cboTheLoai";
            cboTheLoai.Size = new Size(142, 23);
            cboTheLoai.TabIndex = 2;
            // 
            // cboNXB
            // 
            cboNXB.FormattingEnabled = true;
            cboNXB.Location = new Point(96, 152);
            cboNXB.Name = "cboNXB";
            cboNXB.Size = new Size(142, 23);
            cboNXB.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 245);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 4;
            label6.Text = "Ghi chú";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 214);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 5;
            label5.Text = "Tác giả";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 187);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 6;
            label4.Text = "Thể loại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 155);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 7;
            label3.Text = "Nhà xuất bản";
            // 
            // txtNamSX
            // 
            txtNamSX.Location = new Point(96, 116);
            txtNamSX.Name = "txtNamSX";
            txtNamSX.Size = new Size(139, 23);
            txtNamSX.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 116);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 9;
            label2.Text = "Năm sản xuất";
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(96, 70);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.Size = new Size(139, 23);
            txtTenSach.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 73);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 11;
            label1.Text = "Tên sách";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Location = new Point(536, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 78);
            panel2.TabIndex = 6;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(13, 33);
            txtTimKiem.Name = "txtTimKiem";
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
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Location = new Point(7, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 78);
            panel1.TabIndex = 7;
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
            // tabPage2
            // 
            tabPage2.Controls.Add(readerControl1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(789, 418);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quản lý độc giả";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // readerControl1
            // 
            readerControl1.Dock = DockStyle.Fill;
            readerControl1.Name = "readerControl1";
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(789, 418);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(789, 418);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 461);
            Controls.Add(tabControl1);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgvBooks;
        private Panel panel3;
        private TextBox txtGhiChu;
        private ComboBox cboTacGia;
        private ComboBox cboTheLoai;
        private ComboBox cboNXB;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtNamSX;
        private Label label2;
        private TextBox txtTenSach;
        private Label label1;
        private Panel panel2;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Panel panel1;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TabPage tabPage2;
        private ReaderControl readerControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
    }
}
