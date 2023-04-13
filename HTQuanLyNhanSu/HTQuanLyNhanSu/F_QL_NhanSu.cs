using HTQuanLyNhanSu.DAO;
using HTQuanLyNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;

namespace HTQuanLyNhanSu
{
    public partial class F_QL_NhanSu : Form
    {
        public F_QL_NhanSu()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvNhanVien.Rows.Clear();
            List<NhanVien> l = NhanVienDAO.Instance.loadDS();
            foreach (NhanVien i in l)
            {
                PhongBan p = PhongBanDAO.Instance.getByMa(i.MaPB);
                ChucVu cv = ChucVuDAO.Instance.getByMa(i.MaCV);
                string gioiTinh = "Nam";
                if (i.GioiTinh == 1)
                    gioiTinh = "Nữ";
                dgvNhanVien.Rows.Add(i.MaNV, i.HoTen, p.Ten, cv.Ten, gioiTinh, i.NgaySinh.ToShortDateString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            F_Them_CapNhat_NhanVien f = new F_Them_CapNhat_NhanVien("");
            f.ShowDialog();
            loadDS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell c in dgvNhanVien.SelectedCells)
            {
                DataGridViewRow r = dgvNhanVien.Rows[c.RowIndex];
                string ma = Convert.ToString(r.Cells[0].Value);
                if (string.IsNullOrEmpty(ma))
                {
                    MessageBox.Show("Hãy chọn nhân viên cần cập nhật trước !", "Nhắc nhở");
                    return;
                }
                F_Them_CapNhat_NhanVien f = new F_Them_CapNhat_NhanVien(ma);
                f.ShowDialog();
                loadDS();
                return;
            }
            MessageBox.Show("Hãy chọn nhân viên cần cập nhật trước !", "Nhắc nhở");
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell c in dgvNhanVien.SelectedCells)
            {
                DataGridViewRow r = dgvNhanVien.Rows[c.RowIndex];
                string ma = Convert.ToString(r.Cells[0].Value);
                if (string.IsNullOrEmpty(ma))
                {
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa nhân viên '" + ma + "' ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    NhanVienDAO.Instance.xoa(ma);
                    loadDS();
                }
                return;
            }
            MessageBox.Show("Hãy chọn nhân viên cần xóa trước !", "Nhắc nhở");
        }

        private void btHDLD_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell c in dgvNhanVien.SelectedCells)
            {
                DataGridViewRow r = dgvNhanVien.Rows[c.RowIndex];
                string ma = Convert.ToString(r.Cells[0].Value);
                if (string.IsNullOrEmpty(ma))
                {
                    return;
                }
                F_QL_HopDong f = new F_QL_HopDong(ma);
                f.ShowDialog();
                return;
            }
            MessageBox.Show("Hãy chọn nhân viên cần xem hợp đồng lao động trước !", "Nhắc nhở");
        }

        private void btLuong_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell c in dgvNhanVien.SelectedCells)
            {
                DataGridViewRow r = dgvNhanVien.Rows[c.RowIndex];
                string ma = Convert.ToString(r.Cells[0].Value);
                if (string.IsNullOrEmpty(ma))
                {
                    return;
                }
                F_QL_Luong f = new F_QL_Luong(ma);
                f.ShowDialog();
                return;
            }
            MessageBox.Show("Hãy chọn nhân viên cần xem quá trình lương trước !", "Nhắc nhở");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                DateTime dt = DateTime.Now;
                string s = dt.ToString(), duongDan = "";
                int j = 0;
                while (j < s.Length)
                {
                    if (s[j] == '/' || s[j] == ' ' || s[j] == ':')
                        duongDan += '_';
                    else duongDan += s[j];
                    j++;
                }
                string filepath = f.SelectedPath + "\\ThongTinNhanVien" + duongDan + ".xlsx";
                XLWorkbook wbook = new XLWorkbook();
                var ws = wbook.Worksheets.Add("Nhân viên");
                List<NhanVien> lNV = NhanVienDAO.Instance.loadDS();
                ws.Cell(1, 1).Value = "STT";
                ws.Cell(1, 2).Value = "Mã nhân viên";
                ws.Cell(1, 3).Value = "Họ tên";
                ws.Cell(1, 4).Value = "Giới tính";
                ws.Cell(1, 5).Value = "Ngày sinh";
                ws.Cell(1, 6).Value = "SĐT";
                ws.Cell(1, 7).Value = "Dân tộc";
                ws.Cell(1, 8).Value = "Tôn giáo";
                ws.Cell(1, 9).Value = "CMND";
                ws.Cell(1, 10).Value = "Đảng viên";
                ws.Cell(1, 11).Value = "Phòng ban";
                ws.Cell(1, 12).Value = "Chức vụ";
                ws.Cell(1, 13).Value = "BHYT";
                ws.Cell(1, 14).Value = "BHXH";
                ws.Cell(1, 15).Value = "Học vấn";
                ws.Cell(1, 16).Value = "Ngoại ngữ";
                ws.Cell(1, 17).Value = "Quê quán";
                ws.Cell(1, 18).Value = "Địa chỉ";
                ws.Cell(1, 19).Value = "Đường dẫn file ảnh";
                for (int i = 0; i < lNV.Count; i++)
                {
                    ws.Cell(i + 2, 1).Value = i + 1;
                    ws.Cell(i + 2, 2).Value = lNV[i].MaNV;
                    ws.Cell(i + 2, 3).Value = lNV[i].HoTen;
                    string gioiTinh = "Nam";
                    if (lNV[i].GioiTinh == 1)
                        gioiTinh = "Nữ";
                    string dangVien = "Không";
                    if (lNV[i].DangVien == 1)
                        dangVien = "Có";
                    PhongBan pb = PhongBanDAO.Instance.getByMa(lNV[i].MaPB);
                    ChucVu cv = ChucVuDAO.Instance.getByMa(lNV[i].MaCV);
                    ws.Cell(i + 2, 4).Value = gioiTinh;
                    ws.Cell(i + 2, 5).Value = lNV[i].NgaySinh.ToShortDateString();
                    ws.Cell(i + 2, 6).Value = lNV[i].Sdt;
                    ws.Cell(i + 2, 7).Value = lNV[i].DanToc;
                    ws.Cell(i + 2, 8).Value = lNV[i].TonGiao;
                    ws.Cell(i + 2, 9).Value = lNV[i].SoCMND;
                    ws.Cell(i + 2, 10).Value = dangVien;
                    ws.Cell(i + 2, 11).Value = pb.Ten;
                    ws.Cell(i + 2, 12).Value = cv.Ten;
                    ws.Cell(i + 2, 13).Value = lNV[i].SoBHYT;
                    ws.Cell(i + 2, 14).Value = lNV[i].SoBHXH;
                    ws.Cell(i + 2, 15).Value = lNV[i].HocVan;
                    ws.Cell(i + 2, 16).Value = lNV[i].NgoaiNgu;
                    ws.Cell(i + 2, 17).Value = lNV[i].QueQuan;
                    ws.Cell(i + 2, 18).Value = lNV[i].DiaChi;
                    ws.Cell(i + 2, 19).Value = lNV[i].Anh;
                }
                try
                {
                    wbook.SaveAs(filepath);
                    MessageBox.Show("Xuất file Excel thành công\nĐường dẫn : " + filepath, "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Xuất file Excel thất bại !", "Thông báo");
                }
            }
        }
    }
}
