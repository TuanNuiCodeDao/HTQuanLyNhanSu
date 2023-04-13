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
    public partial class F_QL_HopDong : Form
    {
        private string maNV;
        public F_QL_HopDong(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            load();
        }
        private void load()
        {
            NhanVien nv = NhanVienDAO.Instance.getByMa(maNV);
            tbMaNV.Text = nv.MaNV;
            tbHoTen.Text = nv.HoTen;
            loadDS();
        }
        private void loadDS()
        {
            List<HopDong> l = HopDongDAO.Instance.loadDSByMaNV(maNV);
            dgvHD.Rows.Clear();
            foreach(HopDong i in l)
            {
                string trangThai = "Còn hiệu lực";
                if (i.TrangThai == 0)
                    trangThai = "Đã hủy";
                if (i.TrangThai == 2)
                    trangThai = "Đã hết hiệu lực";
                dgvHD.Rows.Add(i.MaHD,i.NgayBD.ToShortDateString(),i.NgayKT.ToShortDateString(),trangThai);
            }
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvHD.Rows[e.RowIndex];
                HopDong hd = HopDongDAO.Instance.getByMa(r.Cells[0].Value.ToString());
                tbMaHD.Text = hd.MaHD;
                dateNgayBD.Value = hd.NgayBD;
                dateNgayKT.Value = hd.NgayKT;
                string trangThai = "Còn hiệu lực";
                if (hd.TrangThai == 0)
                    trangThai = "Đã hủy";
                if (hd.TrangThai == 2)
                    trangThai = "Đã hết hiệu lực";
                tbTrangThai.Text = trangThai;
            }catch(Exception x) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(HopDongDAO.Instance.getConHieuLucByMaNV(maNV)!=null)
            {
                MessageBox.Show("Nhân viên này đang có 1 hợp đồng còn hiệu lực !", "Nhắc nhở");
                return;
            }
            DateTime ngayBD = dateNgayBD.Value;
            DateTime ngayKT = dateNgayKT.Value;
            if (ngayBD > ngayKT.AddDays(1))
            {
                MessageBox.Show("Ngày bắt đầu và kết thúc không hợp lệ !", "Nhắc nhở");
                return;
            }
            HopDongDAO.Instance.them(maNV,ngayBD,ngayKT);
            loadDS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HopDong hd = HopDongDAO.Instance.getByMa(tbMaHD.Text);
            if(tbMaHD==null)
            {
                MessageBox.Show("Hãy chọn hợp đồng cần hủy !", "Nhắc nhở");
                return;
            }
            if (hd.TrangThai==0)
            {
                MessageBox.Show("Hợp đồng đã được hủy trước đây !", "Nhắc nhở");
                return;
            }
            if (hd.TrangThai == 2)
            {
                MessageBox.Show("Hợp đồng đã hết hiệu lực !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận hủy hợp đồng !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HopDongDAO.Instance.huy(hd.MaHD);
                loadDS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HopDong hd = HopDongDAO.Instance.getByMa(tbMaHD.Text);
            if (tbMaHD == null)
            {
                MessageBox.Show("Hãy chọn hợp đồng cần cập nhật !", "Nhắc nhở");
                return;
            }
            if (hd.TrangThai == 0)
            {
                MessageBox.Show("Hợp đồng đã được hủy trước đây !", "Nhắc nhở");
                return;
            }
            if (hd.TrangThai == 2)
            {
                MessageBox.Show("Hợp đồng đã hết hiệu lực !", "Nhắc nhở");
                return;
            }
            DateTime ngayBD = dateNgayBD.Value;
            DateTime ngayKT = dateNgayKT.Value;
            if (ngayBD > ngayKT)
            {
                MessageBox.Show("Ngày bắt đầu và kết thúc không hợp lệ !", "Nhắc nhở");
                return;
            }
            HopDongDAO.Instance.sua(hd.MaHD, ngayBD, ngayKT);
            loadDS();
        }
    }
}
