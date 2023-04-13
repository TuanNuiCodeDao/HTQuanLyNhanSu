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
    public partial class F_QL_ChucVu : Form
    {
        public F_QL_ChucVu()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvChucVu.Rows.Clear();
            List<ChucVu> l = ChucVuDAO.Instance.loadDS();
            foreach (ChucVu i in l)
            {
                DataGridViewRow row = (DataGridViewRow)dgvChucVu.Rows[0].Clone();
                row.Cells[0].Value = i.Ten;
                row.Cells[1].Value = i.Ma;
                dgvChucVu.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên chức vụ không được để trống !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Mã chức vụ không được để trống !", "Nhắc nhở");
                return;
            }
            if (tbMa.Text.IndexOf(' ') > -1)
            {
                MessageBox.Show("Mã chức vụ không được chứa ký tự trắng !", "Nhắc nhở");
                return;
            }
            if (ChucVuDAO.Instance.getByMa(tbMa.Text) != null)
            {
                MessageBox.Show("Mã chức vụ đã tồn tại !", "Nhắc nhở");
                return;
            }
            if (ChucVuDAO.Instance.getByTen(tbTen.Text) != null)
            {
                MessageBox.Show("Tên chức vụ đã tồn tại !", "Nhắc nhở");
                return;
            }
            ChucVuDAO.Instance.them(tbMa.Text, tbTen.Text);
            loadDS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChucVu cv1 = ChucVuDAO.Instance.getByMa(tbMa.Text);
            if (cv1 == null)
            {
                MessageBox.Show("Mã chức vụ không tồn tại !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên chức vụ không được để trống !", "Nhắc nhở");
                return;
            }
            ChucVu cv2 = ChucVuDAO.Instance.getByTen(tbTen.Text);
            if (cv2 != null && cv2.Ma != cv1.Ma)
            {
                MessageBox.Show("Tên chức vụ đã tồn tại !", "Nhắc nhở");
                return;
            }
            ChucVuDAO.Instance.sua(tbMa.Text, tbTen.Text);
            loadDS();
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = new DataGridViewRow();
                row = dgvChucVu.Rows[e.RowIndex];
                tbMa.Text = Convert.ToString(row.Cells[1].Value);
                if (string.IsNullOrEmpty(tbMa.Text))
                {
                    return;
                }
                tbTen.Text = Convert.ToString(row.Cells[0].Value);
            }
            catch (Exception)
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChucVu cv = ChucVuDAO.Instance.getByMa(tbMa.Text);
            if (cv == null)
            {
                MessageBox.Show("Mã chức vụ không tồn tại !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa chức vụ '" + cv.Ten + "' ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ChucVuDAO.Instance.xoa(cv.Ma);
                loadDS();
            }
        }
    }
}
