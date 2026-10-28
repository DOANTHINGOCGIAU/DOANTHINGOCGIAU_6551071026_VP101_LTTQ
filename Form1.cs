using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using DOANTHINGOCGIAU_6551071026_VP101_LTTQ.Models;

namespace DOANTHINGOCGIAU_6551071026_VP101_LTTQ
{
    public partial class frmCongViec : Form
    {
        public frmCongViec()
        {
            InitializeComponent();
        }

        private async void frmCongViec_Load(object sender, EventArgs e)
        {
            txtMaCongViec.MaxLength = 10;
            txtLuongThang.MaxLength = 8;
            dgvDanhSachCongViec.AutoGenerateColumns = false;
            dgvDanhSachCongViec.CellFormatting += dgvDanhSachCongViec_CellFormatting;

            DatTrangThaiBanDau();
            await LoadDataAsync();
        }
        private void dgvDanhSachCongViec_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachCongViec.Columns[e.ColumnIndex].Name == "colLuongThang" && e.Value != null)
            {
                if (long.TryParse(e.Value.ToString(), out long val))
                {
                    e.Value = val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using var db = new CongViecDbContext();
                var danhSach = await db.CongViecs.AsNoTracking().OrderBy(x => x.MaCongViec).ToListAsync();
                dgvDanhSachCongViec.DataSource = danhSach;
                dgvDanhSachCongViec.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatTrangThaiBanDau()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;

            txtMaCongViec.ReadOnly = false;
            txtMaCongViec.Clear();
            txtTenCongViec.Clear();
            txtLuongThang.Clear();
            txtMaCongViec.Focus();
        }
        private void BatCheDoChonDong()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            txtMaCongViec.ReadOnly = true; 

        private void txtLuongThang_KeyPress(object sender, KeyPressEventArgs e)
        {
       
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
private void dgvDanhSachCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDanhSachCongViec.Rows[e.RowIndex];
            txtMaCongViec.Text = row.Cells["colMaCongViec"].Value?.ToString() ?? "";
            txtTenCongViec.Text = row.Cells["colTenCongViec"].Value?.ToString() ?? "";
            txtLuongThang.Text = row.Cells["colLuongThang"].Value?.ToString() ?? "";

            BatCheDoChonDong();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaCongViec.Text.Trim();
            string ten = txtTenCongViec.Text.Trim();
            string luong = txtLuongThang.Text.Trim();


            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Mã công việc không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCongViec.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên công việc không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCongViec.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(luong))
            {
                MessageBox.Show("Lương tháng không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongThang.Focus();
                return;
            }

            if (!int.TryParse(luong, out int luongInt) || luongInt <= 0)
            {
                MessageBox.Show("Lương tháng phải là số nguyên dương lớn hơn 0!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongThang.Focus();
                return;
            }

            try
            {
                using var db = new CongViecDbContext();

 
                if (await db.CongViecs.AnyAsync(x => x.MaCongViec == ma))
                {
                    MessageBox.Show($"Mã công việc [{ma}] đã tồn tại trong hệ thống!", "Trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCongViec.Focus();
                    return;
                }

                CongViec cv = new CongViec
                {
                    MaCongViec = ma,
                    TenCongViec = ten,
                    LuongThang = luong
                };

                db.CongViecs.Add(cv);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                DatTrangThaiBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaCongViec.Text.Trim();
            string ten = txtTenCongViec.Text.Trim();
            string luong = txtLuongThang.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn công việc cần sửa trên bảng!", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên công việc không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCongViec.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(luong))
            {
                MessageBox.Show("Lương tháng không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongThang.Focus();
                return;
            }

            if (!int.TryParse(luong, out int luongInt) || luongInt <= 0)
            {
                MessageBox.Show("Lương tháng phải là số nguyên dương lớn hơn 0!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongThang.Focus();
                return;
            }

            try
            {
                using var db = new CongViecDbContext();
                var cv = await db.CongViecs.FindAsync(ma);

                if (cv == null)
                {
                    MessageBox.Show($"Không tìm thấy công việc có mã [{ma}]!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cv.TenCongViec = ten;
                cv.LuongThang = luong;

                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                DatTrangThaiBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaCongViec.Text.Trim();
            string ten = txtTenCongViec.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trên bảng!", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa công việc [{ten}] (Mã: {ma}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                using var db = new CongViecDbContext();
                var cv = await db.CongViecs.FindAsync(ma);

                if (cv != null)
                {
                    db.CongViecs.Remove(cv);
                    await db.SaveChangesAsync();

                    MessageBox.Show("Xóa công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    DatTrangThaiBanDau();
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy công việc có mã [{ma}] để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCongViec_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
