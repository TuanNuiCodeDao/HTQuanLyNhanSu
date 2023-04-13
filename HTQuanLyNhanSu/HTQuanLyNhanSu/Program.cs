using HTQuanLyNhanSu.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyNhanSu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (NhanVienDAO.Instance.loadDS().Count>0)
            { 
                HopDongDAO.Instance.update();
                CongDAO.Instance.update();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F_DangNhap());
        }
    }
}
