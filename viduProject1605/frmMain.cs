using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viduProject1605
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Mo ket noi toi co so du lieu
             DAO.Connect();
             MessageBox.Show("Connected Successfully! Congratulations! Welcome!","Announcement",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            //BTVN: Them cau lenh de cf co thuc su muon thoat
            DAO.Close();
            Application.Exit();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            frmDMChatLieu f = new frmDMChatLieu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void mnuHanghoa_Click(object sender, EventArgs e)
        {
            frmDMHangHoa f = new frmDMHangHoa();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void mnuHoadon_Click(object sender, EventArgs e)
        {
            frmDMHoaDon f = new frmDMHoaDon();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
    }
}
