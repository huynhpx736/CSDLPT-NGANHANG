﻿using System;
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
    public partial class frm_GuiRut : Form
    {
        string LoaiGD = "";

        private SqlDataReader reader;

        public frm_GuiRut()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int check = 2;  //biến để kiểm tra giá trị trả về, nếu thực hiện thành công thì trả ra một MessageBox thông báo Success.
            if (txtSTK.Text.Trim() == "" || txtTien.Text.Trim() == "" || cmbGuiRut.Text.Trim() == "")
            {   
                MessageBox.Show("Số tài khoản, số tiền và loại giao dịch không được bỏ trống", "", MessageBoxButtons.OK);
                return;
            }
            
            LoaiGD = cmbGuiRut.Text;

            if (LoaiGD == "Gửi tiền") LoaiGD = "GT";
            else LoaiGD = "RT";

            string strLenh = "EXEC SP_GUIRUT '" + txtSTK.Text + "','" + txtTien.Text + "','" + LoaiGD + "','" + Program.username + "'";
            //Debug.WriteLine(strLenh);
            check = Program.ExecSqlNonQuery(strLenh);

            if (check == 0) MessageBox.Show("Giao dịch thành công!!!", "", MessageBoxButtons.OK);
            LoaiGD = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_GuiRut_Load(object sender, EventArgs e)
        {
            cmbGuiRut.Items.Add("Gửi tiền");
            cmbGuiRut.Items.Add("Rút tiền");
            cmbGuiRut.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuiRut.SelectedIndex = 0;
        }

        private void cmbGuiRut_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiGD = cmbGuiRut.Text;
        }

        private void btnCheckTK_Click(object sender, EventArgs e)
        {
            reader = Program.ExecSqlDataReader($"EXEC SP_TTKHTuSTK '{txtSTK.Text.Trim()}'");
            if (reader == null)
                return;

            reader.Read();
            txtTenND.Text = (string)reader["HO"] + " " + (string)reader["TEN"];

            reader.Close();
        }
    }
}
