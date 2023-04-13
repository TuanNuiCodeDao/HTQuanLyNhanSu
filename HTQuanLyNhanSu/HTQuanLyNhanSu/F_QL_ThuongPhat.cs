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
    public partial class F_QL_ThuongPhat : Form
    {
        public F_QL_ThuongPhat()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            loadDS();
            loadCbMaNhanVien();
            radioThuong.Checked = true;
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
            List<ThuongPhat> l = ThuongPhatDAO.Instance.loadDS();
            dgvThuongPhat.Rows.Clear();
            foreach (ThuongPhat i in l)
            {
                NhanVien nv = NhanVienDAO.Instance.getByMa(i.MaNV);
                string phanLoai = "Thưởng";
                if (i.PhanLoai == 0)
                    phanLoai = "Phạt";
                dgvThuongPhat.Rows.Add(i.MaTP, i.MaNV, nv.HoTen, i.NgayQD.ToShortDateString(), phanLoai,DataProvider.Instance.getDinhDanhHangNghin(i.SoTien),i.LyDo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbLyDo.Text=="")
            {
                MessageBox.Show("Lý do không được để trống !", "Nhắc nhở");
                return;
            }
            int phanLoai = 0;
            if (radioThuong.Checked == true)
                phanLoai = 1;
            ThuongPhatDAO.Instance.them(cbMaNV.Text, tbLyDo.Text, (int)nudSoTien.Value, phanLoai);
            loadDS();
            MessageBox.Show("Thêm mới thưởng - phạt thành công !", "Thông báo");
        }

        private void dgvThuongPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgvThuongPhat.Rows[e.RowIndex];
                tbMaTP.Text = r.Cells[0].Value.ToString();
                cbMaNV.Text = r.Cells[1].Value.ToString();
                tbHoTen.Text = r.Cells[2].Value.ToString();
                ThuongPhat tp = ThuongPhatDAO.Instance.getByMa(int.Parse(tbMaTP.Text));
                tbNgayQD.Text = tp.LyDo;
                nudSoTien.Value=tp.SoTien;
                if(tp.PhanLoai == 0)
                    radioPhat.Checked = true;
                else radioThuong.Checked = true;
            }
            catch (Exception ex)
            { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThuongPhat tp = ThuongPhatDAO.Instance.getByMa(int.Parse(tbMaTP.Text));
            if (tp == null)
            {
                MessageBox.Show("Hãy chọn thưởng - phạt cần cập nhật !", "Nhắc nhở");
                return;
            }
            if (tbLyDo.Text == "")
            {
                MessageBox.Show("Lý do không được để trống !", "Nhắc nhở");
                return;
            }
            int phanLoai = 0;
            if (radioThuong.Checked == true)
                phanLoai = 1;
            ThuongPhatDAO.Instance.sua(tp.MaTP,cbMaNV.Text, tbLyDo.Text, (int)nudSoTien.Value, phanLoai);
            loadDS();
            MessageBox.Show("Cập nhật thưởng - phạt thành công !", "Thông báo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThuongPhat tp = ThuongPhatDAO.Instance.getByMa(int.Parse(tbMaTP.Text));
            if (tp == null)
            {
                MessageBox.Show("Hãy chọn thưởng - phạt cần cập nhật !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa thưởng phạt !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ThuongPhatDAO.Instance.xoa(tp.MaTP);
                loadDS();
            }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.Instance.getByMa(cbMaNV.Text);
            if (nv != null)
                tbHoTen.Text = nv.HoTen;
        }
    }
}
