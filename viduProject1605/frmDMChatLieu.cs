using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace viduProject1605
{
    public partial class frmDMChatLieu : Form
    {
        //datatable chinh 1 la the hien cua dataset. dataset chua cac datatable
        DataTable tblChatLieu = new DataTable();
        public frmDMChatLieu()
        {
            InitializeComponent();
        }

        private void frmDMChatLieu_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Machatlieu, Tenchatlieu FROM Chatlieu order by Machatlieu ASC";
            tblChatLieu = DAO.GetDataToTable(sql);
            DataGridView.DataSource = tblChatLieu;
            DataGridView.Columns[0].HeaderText = "Mã chất liệu";
            DataGridView.Columns[1].HeaderText = "Tên chất liệu";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 440;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }




        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //tat 3 nut dau tien: Them sua xoa
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Hien thi nut Luu de luu ban ghi moi la 2 dong duoc go tren 2 textbox
            btnLuu.Enabled = true;
            //Hien thi bo qua neu nguoi dung khong muon them moi ban ghi do nua
            btnBoqua.Enabled = true;
            //Sau khi Luu hoac Bo qua thi xoa trang du lieu de nguoi dung nhap lai
            ResetValues();
            txtMaChatLieu.Enabled = true;
            txtMaChatLieu.Focus();
        }

        private void ResetValues()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra nguoi dung nhap ban ghi roi thi moi LUU
            //Ham Trim se loai bo cac khoang trang
            if (txtMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChatLieu.Focus();
                return;
            }

            string sql = "SELECT MaChatlieu FROM ChatLieu WHERE MaChatlieu =N'" +txtMaChatLieu.Text.Trim() + "'";
            if (DAO.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChatLieu.Focus();
                txtMaChatLieu.Text = "";
                return;
            }
            sql = "INSERT INTO ChatLieu(Machatlieu,Tenchatlieu) VALUES(N'" + txtMaChatLieu.Text + "',N'" + txtTenChatLieu.Text + "')";
            DAO.RunSql(sql);
            Load_DataGridView();
            ResetValues();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }
    }
}
