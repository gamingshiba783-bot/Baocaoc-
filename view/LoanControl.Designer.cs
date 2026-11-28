using System.Drawing;
using System.Windows.Forms;

namespace Baibaocao.net.view
{
    partial class LoanControl
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelActions = new Panel();
            btnTraSach = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panelSearch = new Panel();
            cboLocTrangThai = new ComboBox();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvLoans = new DataGridView();
            panelInput = new Panel();
            cboNhanVien = new ComboBox();
            lblNhanVien = new Label();
            cboTrangThai = new ComboBox();
            lblTrangThai = new Label();
            dtpNgayTra = new DateTimePicker();
            lblNgayTra = new Label();
            dtpHanTra = new DateTimePicker();
            lblHanTra = new Label();
            dtpNgayMuon = new DateTimePicker();
            lblNgayMuon = new Label();
            cboSach = new ComboBox();
            lblSach = new Label();
            cboDocGia = new ComboBox();
            lblDocGia = new Label();

            panelActions.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            panelInput.SuspendLayout();
            SuspendLayout();

            // panelActions
            panelActions.BackColor = SystemColors.ActiveCaption;
            panelActions.Controls.Add(btnTraSach);
            panelActions.Controls.Add(btnXoa);
            panelActions.Controls.Add(btnSua);
            panelActions.Controls.Add(btnThem);
            panelActions.Location = new Point(7, 2);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(510, 78);
            panelActions.TabIndex = 0;

            // btnThem
            btnThem.Location = new Point(14, 20);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(105, 40);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;

            // btnSua
            btnSua.Location = new Point(135, 20);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(105, 40);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;

            // btnXoa
            btnXoa.Location = new Point(256, 20);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(105, 40);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;

            // btnTraSach
            btnTraSach.Location = new Point(377, 20);
            btnTraSach.Name = "btnTraSach";
            btnTraSach.Size = new Size(118, 40);
            btnTraSach.TabIndex = 3;
            btnTraSach.Text = "Trả sách";
            btnTraSach.UseVisualStyleBackColor = true;

            // panelSearch
            panelSearch.BackColor = SystemColors.GradientInactiveCaption;
            panelSearch.Controls.Add(cboLocTrangThai);
            panelSearch.Controls.Add(txtTimKiem);
            panelSearch.Controls.Add(btnTimKiem);
            panelSearch.Location = new Point(536, 2);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(245, 78);
            panelSearch.TabIndex = 1;

            // txtTimKiem
            txtTimKiem.Location = new Point(10, 12);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm độc giả / sách...";
            txtTimKiem.Size = new Size(150, 23);
            txtTimKiem.TabIndex = 0;

            // cboLocTrangThai
            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.FormattingEnabled = true;
            cboLocTrangThai.Location = new Point(10, 44);
            cboLocTrangThai.Name = "cboLocTrangThai";
            cboLocTrangThai.Size = new Size(150, 23);
            cboLocTrangThai.TabIndex = 1;

            // btnTimKiem
            btnTimKiem.Location = new Point(166, 18);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(70, 42);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;

            // dgvLoans
            dgvLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoans.Location = new Point(7, 94);
            dgvLoans.Name = "dgvLoans";
            dgvLoans.Size = new Size(510, 318);
            dgvLoans.TabIndex = 2;

            // panelInput
            panelInput.BackColor = SystemColors.GradientActiveCaption;
            panelInput.Controls.Add(cboNhanVien);
            panelInput.Controls.Add(lblNhanVien);
            panelInput.Controls.Add(cboTrangThai);
            panelInput.Controls.Add(lblTrangThai);
            panelInput.Controls.Add(dtpNgayTra);
            panelInput.Controls.Add(lblNgayTra);
            panelInput.Controls.Add(dtpHanTra);
            panelInput.Controls.Add(lblHanTra);
            panelInput.Controls.Add(dtpNgayMuon);
            panelInput.Controls.Add(lblNgayMuon);
            panelInput.Controls.Add(cboSach);
            panelInput.Controls.Add(lblSach);
            panelInput.Controls.Add(cboDocGia);
            panelInput.Controls.Add(lblDocGia);
            panelInput.Location = new Point(536, 94);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(245, 318);
            panelInput.TabIndex = 3;

            // lblDocGia & cboDocGia
            lblDocGia.AutoSize = true;
            lblDocGia.Location = new Point(10, 18);
            lblDocGia.Name = "lblDocGia";
            lblDocGia.Size = new Size(50, 15);
            lblDocGia.Text = "Độc giả";

            cboDocGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDocGia.FormattingEnabled = true;
            cboDocGia.Location = new Point(92, 15);
            cboDocGia.Name = "cboDocGia";
            cboDocGia.Size = new Size(143, 23);
            cboDocGia.TabIndex = 0;

            // lblSach & cboSach
            lblSach.AutoSize = true;
            lblSach.Location = new Point(10, 58);
            lblSach.Name = "lblSach";
            lblSach.Size = new Size(65, 15);
            lblSach.Text = "Sách mượn";

            cboSach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSach.FormattingEnabled = true;
            cboSach.Location = new Point(92, 55);
            cboSach.Name = "cboSach";
            cboSach.Size = new Size(143, 23);
            cboSach.TabIndex = 1;

            // lblNgayMuon & dtpNgayMuon
            lblNgayMuon.AutoSize = true;
            lblNgayMuon.Location = new Point(10, 98);
            lblNgayMuon.Name = "lblNgayMuon";
            lblNgayMuon.Size = new Size(66, 15);
            lblNgayMuon.Text = "Ngày mượn";

            dtpNgayMuon.Format = DateTimePickerFormat.Short;
            dtpNgayMuon.Location = new Point(92, 95);
            dtpNgayMuon.Name = "dtpNgayMuon";
            dtpNgayMuon.Size = new Size(143, 23);
            dtpNgayMuon.TabIndex = 2;

            // lblHanTra & dtpHanTra
            lblHanTra.AutoSize = true;
            lblHanTra.Location = new Point(10, 138);
            lblHanTra.Name = "lblHanTra";
            lblHanTra.Size = new Size(46, 15);
            lblHanTra.Text = "Hạn trả";

            dtpHanTra.Format = DateTimePickerFormat.Short;
            dtpHanTra.Location = new Point(92, 135);
            dtpHanTra.Name = "dtpHanTra";
            dtpHanTra.Size = new Size(143, 23);
            dtpHanTra.TabIndex = 3;

            // lblNgayTra & dtpNgayTra
            lblNgayTra.AutoSize = true;
            lblNgayTra.Location = new Point(10, 178);
            lblNgayTra.Name = "lblNgayTra";
            lblNgayTra.Size = new Size(51, 15);
            lblNgayTra.Text = "Ngày trả";

            dtpNgayTra.Checked = false;
            dtpNgayTra.Format = DateTimePickerFormat.Short;
            dtpNgayTra.Location = new Point(92, 175);
            dtpNgayTra.Name = "dtpNgayTra";
            dtpNgayTra.ShowCheckBox = true;
            dtpNgayTra.Size = new Size(143, 23);
            dtpNgayTra.TabIndex = 4;

            // lblTrangThai & cboTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(10, 218);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(60, 15);
            lblTrangThai.Text = "Trạng thái";

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(92, 215);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(143, 23);
            cboTrangThai.TabIndex = 5;

            // lblNhanVien & cboNhanVien
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(10, 258);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(62, 15);
            lblNhanVien.Text = "Nhân viên";

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(92, 255);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(143, 23);
            cboNhanVien.TabIndex = 6;

            // LoanControl
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panelInput);
            Controls.Add(dgvLoans);
            Controls.Add(panelSearch);
            Controls.Add(panelActions);
            Name = "LoanControl";
            Size = new Size(789, 418);

            panelActions.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelActions;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTraSach;
        private Panel panelSearch;
        private TextBox txtTimKiem;
        private ComboBox cboLocTrangThai;
        private Button btnTimKiem;
        private DataGridView dgvLoans;
        private Panel panelInput;
        private Label lblDocGia;
        private ComboBox cboDocGia;
        private Label lblSach;
        private ComboBox cboSach;
        private Label lblNgayMuon;
        private DateTimePicker dtpNgayMuon;
        private Label lblHanTra;
        private DateTimePicker dtpHanTra;
        private Label lblNgayTra;
        private DateTimePicker dtpNgayTra;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Label lblNhanVien;
        private ComboBox cboNhanVien;
    }
}
