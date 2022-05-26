using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace viduProject1605
{
    public class DAO
    {
        //Khai báo biến chứa chuỗi kết nối
        public static string ConnectionString = "Data Source=NGUYENCHOI\\SQLEXPRESS;" +
                                     "Initial Catalog=QlyBanHang;" +
                                     "Integrated Security=True";

        //Bien static la bien toan cuc khi no thay doi thi ca chuong trinh thay doi theo
        public static SqlConnection con = new SqlConnection(); //Khai báo đối tượng kết nối

        public static void Connect()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void Close()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable LoadDataToTable(string sql)
        {
            //The hien so 2 cua SqlDataAdapter(<Tham so 1>, <Tham so 2>) 
            SqlDataAdapter Myadapter = new SqlDataAdapter(sql, con);    // Khai báo
            DataTable table = new DataTable();    // Khai báo DataTable nhận dữ liệu trả về
            Myadapter.Fill(table); 	//Thực hiện câu lệnh SELECT và đổ dữ liệu vào bảng table
            return table;
        }

        //CheckKey có tác dụng kiểm tra khóa trùng
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //RunSql có tác dụng thực thi các câu lệnh SQL.
        /*        public static void RunSql(string sql)
                {
                    SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
                    cmd = new SqlCommand();	         // Khởi tạo đối tượng
                    cmd.Connection = con;	  // Gán kết nối
                    cmd.CommandText = sql;			  // Gán câu lệnh SQL
                    try
                    {
                        cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL update
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    cmd.Dispose(); //Giai phong
                    cmd = null;
                }*/

        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, con);
            DataTable mytable = new DataTable();
            Mydata.Fill(mytable);
            cbo.DataSource = mytable;
            cbo.ValueMember = ma;    // Truong gia tri
            cbo.DisplayMember = ten;    // Truong hien thi
        }


    }
}
