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
    public partial class F_QL_NghiPhep : Form
    {
        public F_QL_NghiPhep()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            loadDS();
            loadCbMaNhanVien();
        }
        private void loadCbMaNhanVien()
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
            List<NghiPhep> l = NghiPhepDAO.Instance.loadDS();
            dgvNghiPhep.Rows.Clear();
            foreach (NghiPhep i in l)
            {
                NhanVien nv = NhanVienDAO.Instance.getByMa(i.MaNV);
                string huongLuong = "Có";
                if(i.HuongLuong == 0)
                    huongLuong = "Không";
                dgvNghiPhep.Rows.Add(i.MaNP,i.MaNV,nv.HoTen,i.NgayBD.ToShortDateString(),i.NgayKT.ToShortDateString(),huongLuong);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NghiPhep np = NghiPhepDAO.Instance.getNowByMaNV(cbMaNV.Text);
            if (np!=null&&np.NgayKT.Date.AddDays(1)>DateTime.Now.Date)
            {
                MessageBox.Show("Nhân viên này hiện đang trong thời gian nghỉ phép !", "Nhắc nhở");
                return;
            }
            DateTime ngayBD = dateNgayBD.Value;
            DateTime ngayKT = dateNgayKT.Value;
            if (ngayBD > ngayKT.AddDays(1))
            {
                MessageBox.Show("Ngày bắt đầu và kết thúc không hợp lệ !", "Nhắc nhở");
                return;
            }
            int huongLuong = 0;
            if (checkHuongLuong.Checked == true)
                huongLuong = 1;
            NghiPhepDAO.Instance.them(cbMaNV.Text, ngayBD, ngayKT,tbLyDo.Text,huongLuong);
            loadDS();
        }

        private void dgvNghiPhep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvNghiPhep.Rows[e.RowIndex];
                tbMaNP.Text = r.Cells[0].Value.ToString();
                cbMaNV.Text = r.Cells[1].Value.ToString();
                tbHoTen.Text = r.Cells[2].Value.ToString();
                NghiPhep np = NghiPhepDAO.Instance.getByMa(int.Parse(tbMaNP.Text));
                dateNgayBD.Value = np.NgayBD;
                dateNgayKT.Value = np.NgayKT;
                checkHuongLuong.Checked = np.HuongLuong == 1;
            }catch(Exception ex)
            { }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.Instance.getByMa(cbMaNV.Text);
            if (nv != null)
                tbHoTen.Text = nv.HoTen;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NghiPhep np = NghiPhepDAO.Instance.getByMa(int.Parse(tbMaNP.Text));
            if(np==null)
            {
                MessageBox.Show("Hãy chọn nghỉ phép cần cập nhật !", "Nhắc nhở");
                return;
            }
            if (np.NgayKT.Date.AddDays(1)<DateTime.Now.Date)
            {
                MessageBox.Show("Lịch nghỉ phép này đã kết thúc !", "Nhắc nhở");
                return;
            }
            DateTime ngayBD = dateNgayBD.Value;
            DateTime ngayKT = dateNgayKT.Value;
            if (ngayBD > ngayKT.AddDays(1))
            {
                MessageBox.Show("Ngày bắt đầu và kết thúc không hợp lệ !", "Nhắc nhở");
                return;
            }
            int huongLuong = 0;
            if (checkHuongLuong.Checked == true)
                huongLuong = 1;
            NghiPhepDAO.Instance.sua(np.MaNP, ngayBD, ngayKT, tbLyDo.Text, huongLuong);
            loadDS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NghiPhep np = NghiPhepDAO.Instance.getByMa(int.Parse(tbMaNP.Text));
            if (np == null)
            {
                MessageBox.Show("Hãy chọn nghỉ phép cần xóa !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa lịch nghỉ !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                NghiPhepDAO.Instance.xoa(np.MaNP);
                loadDS();
            }
        }
    }
}
