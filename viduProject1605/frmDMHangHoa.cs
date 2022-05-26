using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace viduProject1605
{
    public partial class frmDMHangHoa : Form
    {
        DataTable tblH = new DataTable();
        public frmDMHangHoa()
        {
            InitializeComponent();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmDMHangHoa_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Machatlieu, Tenchatlieu FROM Chatlieu";
            txtMahang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            DAO.FillCombo(sql,cboMachatlieu, "Machatlieu", "Tenchatlieu");
            cboMachatlieu.SelectedIndex = -1;
            ResetValues();
        }

        private void ResetValues()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            cboMachatlieu.Text = "";
            txtSoluong.Text = "0";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhichu.Text = "";
        }


        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mahang, Tenhang, Machatlieu, Soluong, Dongianhap, Dongiaban FROM Hang";
            tblH = DAO.LoadDataToTable(sql);
            DataGridView.DataSource = tblH;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Chất liệu";
            DataGridView.Columns[3].HeaderText = "Số lượng";
            DataGridView.Columns[4].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[5].HeaderText = "Đơn giá bán";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 200;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThemMCL_Click(object sender, EventArgs e)
        {
            frmDMChatLieu f = new frmDMChatLieu();
            f.ShowDialog();
            string sql = "SELECT Machatlieu, Tenchatlieu FROM Chatlieu";
            DAO.FillCombo(sql, cboMachatlieu, "Machatlieu", "Tenchatlieu");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }

        }
    }
}
