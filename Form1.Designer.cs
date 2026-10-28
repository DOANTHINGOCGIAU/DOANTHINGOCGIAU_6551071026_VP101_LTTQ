namespace DOANTHINGOCGIAU_6551071026_VP101_LTTQ
{
    partial class frmCongViec
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblDanhMucCongViec = new Label();
            grbThongTinCongViec = new GroupBox();
            txtLuongThang = new TextBox();
            txtTenCongViec = new TextBox();
            txtMaCongViec = new TextBox();
            lblLuongThang = new Label();
            lblTenCongViec = new Label();
            lblMaCongViec = new Label();
            lblDanhSachCongViec = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            dgvDanhSachCongViec = new DataGridView();
            colMaCongViec = new DataGridViewTextBoxColumn();
            colTenCongViec = new DataGridViewTextBoxColumn();
            colLuongThang = new DataGridViewTextBoxColumn();
            errorProvider1 = new ErrorProvider(components);
            toolTip1 = new ToolTip(components);
            grbThongTinCongViec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachCongViec).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblDanhMucCongViec
            // 
            lblDanhMucCongViec.AutoSize = true;
            lblDanhMucCongViec.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDanhMucCongViec.Location = new Point(270, 9);
            lblDanhMucCongViec.Name = "lblDanhMucCongViec";
            lblDanhMucCongViec.Size = new Size(259, 30);
            lblDanhMucCongViec.TabIndex = 0;
            lblDanhMucCongViec.Text = "DANH MỤC CÔNG VIỆC";
            // 
            // grbThongTinCongViec
            // 
            grbThongTinCongViec.Controls.Add(txtLuongThang);
            grbThongTinCongViec.Controls.Add(txtTenCongViec);
            grbThongTinCongViec.Controls.Add(txtMaCongViec);
            grbThongTinCongViec.Controls.Add(lblLuongThang);
            grbThongTinCongViec.Controls.Add(lblTenCongViec);
            grbThongTinCongViec.Controls.Add(lblMaCongViec);
            grbThongTinCongViec.Location = new Point(12, 47);
            grbThongTinCongViec.Name = "grbThongTinCongViec";
            grbThongTinCongViec.Size = new Size(764, 155);
            grbThongTinCongViec.TabIndex = 2;
            grbThongTinCongViec.TabStop = false;
            grbThongTinCongViec.Text = "Thông tin công việc";
            // 
            // txtLuongThang
            // 
            txtLuongThang.Location = new Point(348, 106);
            txtLuongThang.Name = "txtLuongThang";
            txtLuongThang.Size = new Size(202, 27);
            txtLuongThang.TabIndex = 5;
            // 
            // txtTenCongViec
            // 
            txtTenCongViec.Location = new Point(348, 61);
            txtTenCongViec.Name = "txtTenCongViec";
            txtTenCongViec.Size = new Size(202, 27);
            txtTenCongViec.TabIndex = 4;
            // 
            // txtMaCongViec
            // 
            txtMaCongViec.Location = new Point(348, 16);
            txtMaCongViec.Name = "txtMaCongViec";
            txtMaCongViec.Size = new Size(202, 27);
            txtMaCongViec.TabIndex = 3;
            // 
            // lblLuongThang
            // 
            lblLuongThang.AutoSize = true;
            lblLuongThang.Location = new Point(118, 106);
            lblLuongThang.Name = "lblLuongThang";
            lblLuongThang.Size = new Size(96, 20);
            lblLuongThang.TabIndex = 2;
            lblLuongThang.Text = "Lương tháng:";
            // 
            // lblTenCongViec
            // 
            lblTenCongViec.AutoSize = true;
            lblTenCongViec.Location = new Point(118, 64);
            lblTenCongViec.Name = "lblTenCongViec";
            lblTenCongViec.Size = new Size(102, 20);
            lblTenCongViec.TabIndex = 1;
            lblTenCongViec.Text = "Tên công việc:";
            // 
            // lblMaCongViec
            // 
            lblMaCongViec.AutoSize = true;
            lblMaCongViec.Location = new Point(118, 23);
            lblMaCongViec.Name = "lblMaCongViec";
            lblMaCongViec.Size = new Size(100, 20);
            lblMaCongViec.TabIndex = 0;
            lblMaCongViec.Text = "Mã công việc:";
            // 
            // lblDanhSachCongViec
            // 
            lblDanhSachCongViec.AutoSize = true;
            lblDanhSachCongViec.Location = new Point(12, 205);
            lblDanhSachCongViec.Name = "lblDanhSachCongViec";
            lblDanhSachCongViec.Size = new Size(144, 20);
            lblDanhSachCongViec.TabIndex = 3;
            lblDanhSachCongViec.Text = "Danh sách công việc";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(155, 369);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 53);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(270, 369);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 53);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(391, 369);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 53);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(515, 369);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 53);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // dgvDanhSachCongViec
            // 
            dgvDanhSachCongViec.AllowUserToAddRows = false;
            dgvDanhSachCongViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachCongViec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachCongViec.Columns.AddRange(new DataGridViewColumn[] { colMaCongViec, colTenCongViec, colLuongThang });
            dgvDanhSachCongViec.Location = new Point(12, 234);
            dgvDanhSachCongViec.Name = "dgvDanhSachCongViec";
            dgvDanhSachCongViec.RowHeadersWidth = 51;
            dgvDanhSachCongViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachCongViec.Size = new Size(776, 129);
            dgvDanhSachCongViec.TabIndex = 10;
            // 
            // colMaCongViec
            // 
            colMaCongViec.HeaderText = "Mã công việc";
            colMaCongViec.MinimumWidth = 6;
            colMaCongViec.Name = "colMaCongViec";
            // 
            // colTenCongViec
            // 
            colTenCongViec.HeaderText = "Tên công việc";
            colTenCongViec.MinimumWidth = 6;
            colTenCongViec.Name = "colTenCongViec";
            // 
            // colLuongThang
            // 
            dataGridViewCellStyle1.Format = "=N0";
            colLuongThang.DefaultCellStyle = dataGridViewCellStyle1;
            colLuongThang.HeaderText = "Lương Tháng";
            colLuongThang.MinimumWidth = 6;
            colLuongThang.Name = "colLuongThang";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmCongViec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDanhSachCongViec);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblDanhSachCongViec);
            Controls.Add(grbThongTinCongViec);
            Controls.Add(lblDanhMucCongViec);
            Name = "frmCongViec";
            Text = "Quản lý Danh mục Công Việc-frmCongViec";
            Load += frmCongViec_Load;
            grbThongTinCongViec.ResumeLayout(false);
            grbThongTinCongViec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachCongViec).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDanhMucCongViec;
        private GroupBox grbThongTinCongViec;
        private Label lblDanhSachCongViec;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private Label lblLuongThang;
        private Label lblTenCongViec;
        private Label lblMaCongViec;
        private TextBox txtLuongThang;
        private TextBox txtTenCongViec;
        private TextBox txtMaCongViec;
        private DataGridView dgvDanhSachCongViec;
        private ErrorProvider errorProvider1;
        private DataGridViewTextBoxColumn colMaCongViec;
        private DataGridViewTextBoxColumn colTenCongViec;
        private DataGridViewTextBoxColumn colLuongThang;
        private ToolTip toolTip1;
    }
}
