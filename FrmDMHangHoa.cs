using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace demo
{
    public partial class FrmDMHangHoa : Form
    {
        SqlConnection con = new SqlConnection();
        public FrmDMHangHoa()
        {
            InitializeComponent();
        }

        private void FrmDMHangHoa_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-UH0D2FE\\SQLEXPRESS01;Initial Catalog=Qly_Banhang;Integrated Security=True";
            con.ConnectionString = connectionString;
            con.Open();
            //string sql = "select * from DMHang";

            //SqlDataAdapter adp = new SqlDataAdapter(sql,con);
            //DataTable tableDMHang = new DataTable();
            //adp.Fill(tableDMHang);
            //dataGridView_DMhang.DataSource = tableDMHang;
            loadDataToGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //delete from DMHang where MaHang='001'
            string sql = "Delete from DMHang where MaHang=' " + txtmahang.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            //sql = "select * from DMHang";
            //SqlDataAdapter adp = new SqlDataAdapter(sql, con);

            //DataTable tableDMHang = new DataTable();
            //adp.Fill(tableDMHang);

            //dataGridView_DMhang.DataSource = tableDMHang;
            loadDataToGridview();
        }
        private void loadDataToGridview()
        {
            string sql = "select * from DMHang";

            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tableDMHang = new DataTable();
            adp.Fill(tableDMHang);
            dataGridView_DMhang.DataSource = tableDMHang;
        }

        private void dataGridView_DMhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGiaBan.Text = dataGridView_DMhang.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtGiaNhap.Text = dataGridView_DMhang.CurrentRow.Cells["GiaNhap"].Value.ToString();
            txtmahang.Text = dataGridView_DMhang.CurrentRow.Cells["MaHang"].Value.ToString();
            txtsoluong.Text = dataGridView_DMhang.CurrentRow.Cells["soLuong"].Value.ToString();
            txttenhang.Text = dataGridView_DMhang.CurrentRow.Cells["TenHang"].Value.ToString();

            txtmahang.Enabled = false;
        }
    }
}
