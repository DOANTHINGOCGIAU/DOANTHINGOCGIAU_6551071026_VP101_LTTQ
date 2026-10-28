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
            dgvDanhSachCongViec.AutoGenerateColumns = false;
            DatTrangThaiBanDau();
            await LoadDataAsync();
        }

        /// <summary>
        /// Nạp danh sách công việc từ cơ sở dữ liệu lên DataGridView
        /// </summary>
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

        /// <summary>
        /// Đưa giao diện về trạng thái ban đầu để thêm mới
        /// </summary>
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

        /// <summary>
        /// Bật trạng thái khi người dùng chọn 1 dòng trên DataGridView
        /// </summary>
        private void BatCheDoChonDong()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;

            txtMaCongViec.ReadOnly = true; // Khóa mã công việc vì là khóa chính
        }

        /// <summary>
        /// Ràng buộc TextBox Lương tháng chỉ cho phép nhập số nguyên
        /// </summary>
        private void txtLuongThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép các ký tự số (0-9) và các phím điều khiển như Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Khi người dùng click chọn 1 dòng trên bảng DataGridView
        /// </summary>
        private void dgvDanhSachCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDanhSachCongViec.Rows[e.RowIndex];
            txtMaCongViec.Text = row.Cells["colMaCongViec"].Value?.ToString() ?? "";
            txtTenCongViec.Text = row.Cells["colTenCongViec"].Value?.ToString() ?? "";
            txtLuongThang.Text = row.Cells["colLuongThang"].Value?.ToString() ?? "";

            BatCheDoChonDong();
        }

        /// <summary>
        /// Chức năng Thêm công việc mới vào cơ sở dữ liệu
        /// </summary>
        private async void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaCongViec.Text.Trim();
            string ten = txtTenCongViec.Text.Trim();
            string luong = txtLuongThang.Text.Trim();

            // Kiểm tra rỗng
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

            // Kiểm tra số nguyên dương > 0
            if (!int.TryParse(luong, out int luongInt) || luongInt <= 0)
            {
                MessageBox.Show("Lương tháng phải là số nguyên dương lớn hơn 0!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongThang.Focus();
                return;
            }

            try
            {
                using var db = new CongViecDbContext();

                // Kiểm tra trùng mã khóa chính
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

        /// <summary>
        /// Chức năng Sửa công việc đã chọn
        /// </summary>
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

        /// <summary>
        /// Chức năng Xóa công việc với thông báo xác nhận trước khi xóa
        /// </summary>
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaCongViec.Text.Trim();
            string ten = txtTenCongViec.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa trên bảng!", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thông báo xác nhận trước khi xóa
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

        /// <summary>
        /// Nút Thoát: đóng Form (sẽ kích hoạt sự kiện FormClosing để hỏi xác nhận)
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Bắt sự kiện FormClosing: Luôn hiển thị thông báo xác nhận khi thoát chương trình
        /// </summary>
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
