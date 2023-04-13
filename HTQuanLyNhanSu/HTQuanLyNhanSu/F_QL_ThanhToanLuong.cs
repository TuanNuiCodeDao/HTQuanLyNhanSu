using DocumentFormat.OpenXml.Wordprocessing;
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
using System.Windows.Forms;

namespace HTQuanLyNhanSu
{
    public partial class F_QL_ThanhToanLuong : Form
    {
        public F_QL_ThanhToanLuong()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            loadCbNhanVien();
            loadDS();
            dateThangNam.ShowUpDown = true;
        }
        private void loadCbNhanVien()
        {
            cbMaNV.Items.Clear();
            cbMaNV.DataSource = NhanVienDAO.Instance.loadDS();
            cbMaNV.DisplayMember = "MaNV";
            if (NhanVienDAO.Instance.loadDS().Count > 0)
            {
                cbMaNV.Text = NhanVienDAO.Instance.loadDS()[0].MaNV;
                NhanVien nv = NhanVienDAO.Instance.getByMa(cbMaNV.Text);
                tbHoTen.Text = nv.HoTen;
            }
        }    
        private void loadDS()
        {
            DateTime d = dateThangNam.Value;
            List<Cong> l = CongDAO.Instance.loadDSByThangNam(d.Month, d.Year);
            dgvTTLuong.Rows.Clear();
            foreach (Cong item in l)
            {
                ThanhToanLuong ttl = ThanhToanLuongDAO.Instance.getByMaCong(item.MaCong);
                NhanVien nv = NhanVienDAO.Instance.getByMa(item.MaNV);
                string trangThai = "Chưa thanh toán";
                if(ttl.TrangThai==1)
                    trangThai = "Đã thanh toán";
                dgvTTLuong.Rows.Add(ttl.MaTTL, nv.MaNV, nv.HoTen, ttl.TamUng, ttl.Thuong,ttl.KhauTruBHXH,ttl.ThucLinh,trangThai);
            }
        }
        private void F_QL_ThanhToanLuong_Load(object sender, EventArgs e)
        {

        }

        private void nudThuong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.Instance.getByMa(cbMaNV.Text);
            if (nv != null)
                tbHoTen.Text = nv.HoTen;
            loadLuong();
        }
        private void loadLuong()
        {
            DateTime d = dateThangNam.Value;
            Cong c = CongDAO.Instance.getByMaNV_Thang_Nam(cbMaNV.Text, d.Month, d.Year);
            if (c == null)
                return;
            ThanhToanLuong ttl = ThanhToanLuongDAO.Instance.getByMaCong(c.MaCong);
            nudBHXH.Value = ttl.KhauTruBHXH;
            nudTamUng.Value = ttl.TamUng;
            nudThuong.Value = ttl.Thuong;
            string trangThai = "Chưa thanh toán";
            if (ttl.TrangThai == 1)
                trangThai = "Đã thanh toán";
            tbTrangThai.Text = trangThai;
            tbThucLinh.Text = ttl.ThucLinh + "";
            tbSoNgayLamViec.Text = c.SoNgayCong + "";
            tbSoNgayNghiHuongLuong.Text = c.SoNgayNghiHuongLuong + "";
            tbTongSoNgayCong.Text = (c.SoNgayCong + c.SoNgayNghiHuongLuong) + "";
        }
        private void dateThangNam_ValueChanged(object sender, EventArgs e)
        {
            loadDS();
            loadLuong();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d = dateThangNam.Value;
            Cong c = CongDAO.Instance.getByMaNV_Thang_Nam(cbMaNV.Text, d.Month, d.Year);
            ThanhToanLuong ttl = ThanhToanLuongDAO.Instance.getByMaCong(c.MaCong);
            if (ttl.TrangThai==1)
            {
                MessageBox.Show("Thanh toán lương này đã hoàn tất !", "Nhắc nhở");
                return;
            }
            ThanhToanLuongDAO.Instance.sua(ttl.MaTTL,(int)nudTamUng.Value,(int)nudThuong.Value, (int)nudBHXH.Value);
            loadDS();
            loadLuong();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbTrangThai.Text == "Đã thanh toán")
            {
                MessageBox.Show("Thanh toán lương này đã hoàn tất !", "Nhắc nhở");
                return;
            }
            DateTime d = dateThangNam.Value;
            Cong c = CongDAO.Instance.getByMaNV_Thang_Nam(cbMaNV.Text, d.Month, d.Year);
            ThanhToanLuong ttl = ThanhToanLuongDAO.Instance.getByMaCong(c.MaCong);
            ThanhToanLuongDAO.Instance.thanhToan(ttl.MaTTL);
            loadDS();
            loadLuong();
            MessageBox.Show("Thanh toán lương thành công ", "Thông báo");
        }
    }
}
