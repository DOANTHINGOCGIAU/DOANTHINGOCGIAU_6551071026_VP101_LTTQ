namespace DOANTHINGOCGIAU_6551071026_VP101_LTTQ
{
    public partial class frmCongViec : Form
    {
        public frmCongViec()
        {
            InitializeComponent();
        }
        private void DatTrangThaiBanDau()
        {
            btnThem.Enabled=true;
            btnSua.Enabled=false;
            btnXoa.Enabled=false;
            btnThoat.Enabled=true;
            txtMaCongViec.ReadOnly=false;
            txtMaCongViec.Clear();
            txtTenCongViec.Clear();
            txtMaCongViec.Focus();
        }
        private void BatCheDoChonDong()
        {
            btnThem.Enabled=false;
            btnSua.Enabled=true;
            btnXoa.Enabled=true;
            btnThoat.Enabled=false;
            txtMaCongViec.ReadOnly =true;
        }
        private void BatCheDoNhapMoi()
        {
            btnThem.Enabled=false;
            btnSua.Enabled=true;
            btnXoa.Enabled=true;
            btnThoat.Enabled=false;

        }
        private void frmCongViec_Load(object sender, EventArgs e)
        {
            DatTrangThaiBanDau();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenCongViec.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên công việc không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCongViec.Focus(); return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maHangDangChon==0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trên bảng", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr= MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc [{txtTenCongViec}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.No) {
        }
    }
}
