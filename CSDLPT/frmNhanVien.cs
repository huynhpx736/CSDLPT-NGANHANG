using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CSDLPT
{
    public partial class frmNhanVien : Form
    {
        int vitri = 0;
        string macn = "";
        bool btn_Them_clicked = false;
        string tk;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
            this.ChuyenTienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.ChuyenTienTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            this.GoiRutTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GoiRutTableAdapter.Fill(this.DS.GD_GOIRUT);

            //loi khi khong co nhan vien hoac khach hang
            // macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            macn = Program.tenChiNhanh;

            ///
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NGANHANG")
            {
                cmbChiNhanh.Enabled = true;
                btn_Them.Enabled = btn_Sua.Enabled = btn_Ghi.Enabled = btn_Xoa.Enabled = btn_PhucHoi.Enabled = btn_ChuyenCN.Enabled = panelControl2.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_Refresh.Enabled = btn_ChuyenCN.Enabled = true;
            }

        }

        private void btn_Thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void nhanVienBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl2.Enabled = true;
            textMaNV.ReadOnly = false;
            vitri = bdsNV.Position;
            bdsNV.AddNew();
            textMaCN.Text = macn;
            //int ma = 0;
            //try
            //{
            //    string strlenh1 = "SELECT MaNV = ISNULL(MAX(CAST(SUBSTRING(MANV, 3, LEN(MANV) - 2) AS INT)), 0) FROM NhanVien";

            //    Program.myReader = Program.ExecSqlDataReader(strlenh1);

            //    if (Program.myReader != null && Program.myReader.HasRows)
            //    {
            //        Program.myReader.Read();
            //        ma = Program.myReader.GetInt32(0) + 2;
            //    }
            //    if (ma < 10)
            //    {
            //        textMaNV.Text = "NV" + '0' + ma.ToString();
            //    }
            //    else
            //    {
            //        textMaNV.Text = "NV" + ma.ToString();
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    Program.conn.Close();
            //}

            btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_Refresh.Enabled = btn_Thoat.Enabled  = false;
            btn_Ghi.Enabled = btn_PhucHoi.Enabled = true;
            gcNV.Enabled = false;
            btn_Them_clicked = true;

        }

        private void btn_PhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btn_Them.Enabled == false) { bdsNV.Position = vitri; }
            gcNV.Enabled = true;
            panelControl2.Enabled = false;

            btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_Refresh.Enabled = btn_Thoat.Enabled = true;
            btn_Ghi.Enabled = btn_PhucHoi.Enabled = false;
            btn_Them_clicked = false;
            try
            {
                this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl2.Enabled = true;
            vitri = bdsNV.Position;
            btn_Them_clicked = false;

            btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_Refresh.Enabled = btn_ChuyenCN.Enabled = btn_Thoat.Enabled = false;
            btn_Ghi.Enabled = btn_PhucHoi.Enabled = true;
            gcNV.Enabled = false;
        }

        private void btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Refresh: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            string TTX = ((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString();
            if (bdsChuyenTien.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì nhân viên này đã thực hiện giao dịch chuyển tiền!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGoiRut.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì nhân viên này đã thực hiện giao dịch gởi/rút!", "", MessageBoxButtons.OK);
                return;
            }
            if (manv == Program.username)
            {
                MessageBox.Show("Không thể xóa vì nhân viên này đang đăng nhập!", "", MessageBoxButtons.OK);
                return;
            }
            if (TTX == "1")
            {
                MessageBox.Show("Không thể xóa vì nhân viên này không làm ở chi nhánh này!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có chắc là muốn xóa nhân viên này không?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string strlenh1 = "DECLARE @table1 TABLE " +
                                    "([Tai khoan] NVARCHAR(10)," +
                                    "[Ma nhan vien] NVARCHAR(10)," +
                                    "HOTEN NVARCHAR(50)," +
                                    "Nhom NVARCHAR(20));" +
                                    "INSERT INTO @table1 " +
                                    "EXEC frmTaoLogin_LayTKLG;" +
                                    "SELECT * FROM @table1 WHERE [Ma nhan vien] = '" + textMaNV.Text.TrimEnd() + "'";

                    using (SqlDataReader myReader = Program.ExecSqlDataReader(strlenh1))
                    {
                        if (myReader != null && myReader.HasRows)
                        {
                            myReader.Read();
                            tk = myReader.GetString(0);
                            string cml1 = "EXEC SP_DROPUSER " + manv + "; \r\nEXEC SP_DROPLOGIN " + tk + ";";
                            Program.ExecSqlNonQuery(cml1);
                            bdsNV.RemoveCurrent();
                            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.NhanVienTableAdapter.Update(this.DS.NhanVien);
                            MessageBox.Show("Xoá thành công !", "", MessageBoxButtons.OK);
                        }
                        else
                        {
                            bdsNV.RemoveCurrent();
                            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.NhanVienTableAdapter.Update(this.DS.NhanVien);
                            MessageBox.Show("Xoá thành công !", "", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Có lỗi khi xóa nhân viên!" + ex.Message, "", MessageBoxButtons.OK);
                    this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
                finally
                {
                    Program.conn.Close();
                }

            }
            if (bdsNV.Count == 0) btn_Xoa.Enabled = false;
        }

        private bool kiemtra()
        {
            
            String manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString().TrimEnd();
            if (textMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "", MessageBoxButtons.OK);
                textMaNV.Focus();
                return false;
            }
            if (textHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được để trống!", "", MessageBoxButtons.OK);
                textHo.Focus();
                return false;
            }
            if (!textHo.Text.Split(' ').All(word => word.All(Char.IsLetter)))
            {
                MessageBox.Show("Họ nhân viên không hợp lệ!", "", MessageBoxButtons.OK);
                textHo.Focus();
                return false;
            }
            if (textTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "", MessageBoxButtons.OK);
                textTen.Focus();
                return false;
            }
            if (!textTen.Text.All(Char.IsLetter))
            {
                MessageBox.Show("Tên nhân viên không hợp lệ!", "", MessageBoxButtons.OK);
                textTen.Focus();
                return false;
            }
            if (textCMND.Text.Trim() == "")
            {
                MessageBox.Show("CMND nhân viên không được để trống!", "", MessageBoxButtons.OK);
                textCMND.Focus();
                return false;
            }
            if (textCMND.Text.Length != 10)
            {
                MessageBox.Show("CMND nhân viên không đúng 10 chữ số!", "", MessageBoxButtons.OK);
                textCMND.Focus();
                return false;
            }
            if (!textCMND.Text.All(Char.IsDigit))
            {
                MessageBox.Show("CMND nhân viên không hợp lệ!", "", MessageBoxButtons.OK);
                textCMND.Focus();
                return false;
            }

           
            if (cmbPhai.Text.Trim() != "Nam" && cmbPhai.Text.Trim() != "Nữ")
            {
                MessageBox.Show("Phái nhân viên không hợp lệ!", "", MessageBoxButtons.OK);
                textDiaChi.Focus();
                return false;
            }
            if (textSoDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại nhân viên không được để trống!", "", MessageBoxButtons.OK);
                textSoDT.Focus();
                return false;
            }
            if (textSoDT.Text.Length >= 12 || !textSoDT.Text.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "", MessageBoxButtons.OK);
                textSoDT.Focus();
                return false;
            }

            if (btn_Them_clicked == true || manv != textMaNV.Text.TrimEnd())
            {
                string strlenh2 = "EXEC KtraTrungMANV '" + textMaNV.Text.TrimEnd() + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh2);
                if (Program.myReader == null)
                {
                    Program.myReader.Read();
                    MessageBox.Show("Mã nhân viên đã tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return false;
                }
                Program.myReader.Close();

                string strlenh1 = "EXEC KtraTrungCMND '" + textCMND.Text.TrimEnd() + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh1);
                if (Program.myReader == null) return false;
                Program.myReader.Read();
                if (Program.myReader.HasRows)
                {
                    MessageBox.Show("CMND đã tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return false;
                }
                Program.myReader.Close();
            }
            if (btn_Them_clicked == false && textCMND.Text != ((DataRowView)bdsNV[bdsNV.Position])["CMND"].ToString())
            {
                string strlenh1 = "EXEC KtraTrungCMND '" + textCMND.Text.TrimEnd() + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh1);
                if (Program.myReader == null) return false;
                Program.myReader.Read();
                if (Program.myReader.HasRows)
                {
                    MessageBox.Show("CMND đã tồn tại \nVui lòng nhập lại", "", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return false;
                }
                Program.myReader.Close();
            }

            return true;
        }

        private void btn_Ghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool ketQua = kiemtra();
            if (ketQua == false)
                return;

            try
            {
                bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NhanVienTableAdapter.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi nhân viên! " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            btn_Them.Enabled = btn_Sua.Enabled = btn_Xoa.Enabled = btn_Refresh.Enabled = btn_Thoat.Enabled = true;
            btn_Ghi.Enabled = btn_PhucHoi.Enabled  = panelControl2.Enabled = false;
            gcNV.Enabled = true;
            btn_Them_clicked = false;
        }



        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới!", "", MessageBoxButtons.OK);
            }
            else
            {
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
                this.GoiRutTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GoiRutTableAdapter.Fill(this.DS.GD_GOIRUT);
                this.ChuyenTienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.ChuyenTienTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            }
        }

        private void gcNV_Click(object sender, EventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
