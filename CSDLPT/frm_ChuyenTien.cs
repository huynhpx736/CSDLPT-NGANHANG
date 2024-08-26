using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLPT
{
    public partial class frm_ChuyenTien : Form
    {
        int check = 2;  //biến để kiểm tra giá trị trả về, nếu thực hiện thành công thì trả ra một MessageBox thông báo Success.

        private SqlDataReader reader;

        public frm_ChuyenTien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtSTKC.Text.Trim() == "" || txtTien.Text.Trim() == "" || txtSTKN.Text.Trim() == "")
            {   
                MessageBox.Show("Số tài khoản, số tiền không được bỏ trống!!", "", MessageBoxButtons.OK);
                return;
            }

            if(txtSTKC.Text.Trim() == txtSTKN.Text.Trim())
            {
                MessageBox.Show("Số tài khoản chuyển và số tài khoản nhận không được trùng nhau!!", "", MessageBoxButtons.OK);
                return;
            }

            string strLenh = "EXEC SP_CHUYENTIEN '" + txtSTKC.Text + "','" + txtSTKN.Text + "','" + txtTien.Text + "','" + Program.username + "'";
           
            check = Program.ExecSqlNonQuery(strLenh);
            if (check == 0) MessageBox.Show("Giao dịch thành công!!!", "", MessageBoxButtons.OK);
        }

        private void btnCheckTKC_Click(object sender, EventArgs e)
        {
            reader = Program.ExecSqlDataReader($"EXEC SP_TTKHTuSTK '{txtSTKC.Text.Trim()}'");
            if (reader == null)
                return;

            reader.Read();
            txtTenNC.Text = (string)reader["HO"] + " " + (string)reader["TEN"];

            reader.Close();
        }

        private void btnCheckTKN_Click(object sender, EventArgs e)
        {
            reader = Program.ExecSqlDataReader($"EXEC SP_TTKHTuSTK '{txtSTKN.Text.Trim()}'");
            if (reader == null)
                return;

            reader.Read();
            txtTenNN.Text = (string)reader["HO"] + " " + (string)reader["TEN"];

            reader.Close();
        }
    }
}
