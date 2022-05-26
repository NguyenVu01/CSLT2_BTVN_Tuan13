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
            tblChatLieu = DAO.LoadDataToTable(sql);
            DataGridViewCL.DataSource = tblChatLieu;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetValues()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //(Check du lieu) Kiem tra nguoi dung nhap ban ghi roi thi moi LUU
            //Ham Trim se loai bo cac khoang trang
            if (txtMaChatLieu.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenChatLieu.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChatLieu.Focus();
                return;
            }

            string sql = "SELECT MaChatlieu FROM ChatLieu WHERE MaChatlieu = '" +txtMaChatLieu.Text + "'";
            if (DAO.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChatLieu.Focus();
                txtMaChatLieu.Text = "";
                return;
            }

            if (!DAO.CheckKey(sql))
            {
                try
                {
                    sql = "INSERT INTO ChatLieu(Machatlieu,Tenchatlieu) VALUES(N'" + txtMaChatLieu.Text + "', '" + txtTenChatLieu.Text + "')";
                    SqlCommand myCommand = new SqlCommand(sql, DAO.con);                     // Khai báo đối tượng SqlCommand
                    myCommand.ExecuteNonQuery();
                    Load_DataGridView();
                    ResetValues();

                    //Sau khi thuc hien thanh cong thi lai hien cac nut len de su dung tiep
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnBoqua.Enabled = false;
                    btnLuu.Enabled = false;
                    txtMaChatLieu.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaChatLieu.Text = DataGridViewCL.CurrentRow.Cells[0].Value.ToString();
            txtTenChatLieu.Text = DataGridViewCL.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ban co muon xoa khong?","Thong bao",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE from Chatlieu WHERE Machatlieu= '" + txtMaChatLieu.Text + "'";
                    SqlCommand myCommand = new SqlCommand(sql, DAO.con);
                    myCommand.ExecuteNonQuery();
                    Load_DataGridView();
                    txtMaChatLieu.Text = "";
                    txtTenChatLieu.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xoa khong thanh cong!" + ex.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            txtMaChatLieu.Enabled = true;
            txtMaChatLieu.Focus();
            txtMaChatLieu.Focus();
        }
    }
}
