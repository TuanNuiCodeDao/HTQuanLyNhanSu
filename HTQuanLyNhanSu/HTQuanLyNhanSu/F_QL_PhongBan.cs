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
    public partial class F_QL_PhongBan : Form
    {
        public F_QL_PhongBan()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvPhongBan.Rows.Clear();
            List<PhongBan> l = PhongBanDAO.Instance.loadDS();
            foreach (PhongBan i in l)
            {
                DataGridViewRow row = (DataGridViewRow)dgvPhongBan.Rows[0].Clone();
                row.Cells[0].Value = i.Ten;
                row.Cells[1].Value = i.Ma;
                dgvPhongBan.Rows.Add(row);
            }
        }

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = new DataGridViewRow();
                row = dgvPhongBan.Rows[e.RowIndex];
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên phòng ban không được để trống !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Mã phòng ban không được để trống !", "Nhắc nhở");
                return;
            }
            if (tbMa.Text.IndexOf(' ')>-1)
            {
                MessageBox.Show("Mã phòng ban không được chứa ký tự trắng !", "Nhắc nhở");
                return;
            }
            if (PhongBanDAO.Instance.getByMa(tbMa.Text)!=null)
            {
                MessageBox.Show("Mã phòng ban đã tồn tại !", "Nhắc nhở");
                return;
            }
            if (PhongBanDAO.Instance.getByTen(tbTen.Text) != null)
            {
                MessageBox.Show("Tên phòng ban đã tồn tại !", "Nhắc nhở");
                return;
            }
            PhongBanDAO.Instance.them(tbMa.Text, tbTen.Text);
            loadDS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PhongBan p1 = PhongBanDAO.Instance.getByMa(tbMa.Text);
            if(p1==null)
            {
                MessageBox.Show("Mã phòng ban không tồn tại !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên phòng ban không được để trống !", "Nhắc nhở");
                return;
            }
            PhongBan p2 = PhongBanDAO.Instance.getByTen(tbTen.Text);
            if (p2 != null&&p2.Ma!=p1.Ma)
            {
                MessageBox.Show("Tên phòng ban đã tồn tại !", "Nhắc nhở");
                return;
            }
            PhongBanDAO.Instance.sua(tbMa.Text, tbTen.Text);
            loadDS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PhongBan p = PhongBanDAO.Instance.getByMa(tbMa.Text);
            if (p == null)
            {
                MessageBox.Show("Mã phòng ban không tồn tại !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa phòng ban '" + p.Ten + "' ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                PhongBanDAO.Instance.xoa(p.Ma);
                loadDS();
            }
        }
    }
}
