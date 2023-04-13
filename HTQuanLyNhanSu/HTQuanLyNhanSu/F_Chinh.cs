using HTQuanLyNhanSu.DAO;
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
    public partial class F_Chinh : Form
    {
        private Form formCon;
        public F_Chinh()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            formCon = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void quanLyNhanSuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "Quản lý thông tin phòng ban";
            OpenChildForm(new F_QL_PhongBan());
        }

        private void quảnLýChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "Quản lý thông tin chức vụ";
            OpenChildForm(new F_QL_ChucVu());
        }

        private void heThongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Chinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýNghỉPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (NhanVienDAO.Instance.loadDS().Count == 0)
            {
                MessageBox.Show("Hãy thêm nhân viên trước !", "Nhắc nhở");
                return;
            }*/
            lbTieuDe.Text = "Quản lý thông tin nghỉ phép";
            OpenChildForm(new F_QL_NghiPhep());
        }

        private void quanLyLuongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NhanVienDAO.Instance.loadDS().Count == 0)
            {
                MessageBox.Show("Hãy thêm nhân viên trước !", "Nhắc nhở");
                return;
            }
            lbTieuDe.Text = "Quản lý thông tin chấm công";
            OpenChildForm(new F_QL_ChamCong());
        }

        private void quảnLýThưởngPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NhanVienDAO.Instance.loadDS().Count == 0)
            {
                MessageBox.Show("Hãy thêm nhân viên trước !", "Nhắc nhở");
                return;
            }
            lbTieuDe.Text = "Quản lý thông tin thưởng phạt";
            OpenChildForm(new F_QL_ThuongPhat());
        }

        private void quảnLýThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhongBanDAO.Instance.loadDS().Count == 0)
            {
                MessageBox.Show("Hãy thêm phòng ban trước !", "Nhắc nhở");
                return;
            }
            if (ChucVuDAO.Instance.loadDS().Count == 0)
            {
                MessageBox.Show("Hãy thêm chức vụ trước !", "Nhắc nhở");
                return;
            }
            lbTieuDe.Text = "Quản lý thông tin nhân viên";
            OpenChildForm(new F_QL_NhanSu());
        }

        private void thanhToánLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NhanVienDAO.Instance.loadDS().Count == 0)
            {
                MessageBox.Show("Hãy thêm nhân viên trước !", "Nhắc nhở");
                return;
            }
            lbTieuDe.Text = "Quản lý thông tin thanh toán lương";
            OpenChildForm(new F_QL_ThanhToanLuong());
        }

        private void ThôngTinDdangNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FThongTinDangNhap f = new FThongTinDangNhap();
            f.ShowDialog();
        }
    }
}
