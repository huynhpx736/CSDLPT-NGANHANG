using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSDLPT_NGANHANG
{
    public partial class frmMain1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain1()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        //public void HienThiMenu()
        //{
        //    switch (Program.mGroup)
        //    {
        //        case "NGANHANG":
        //            rib_QuanLy.Visible = true;
        //            ribBaoCao.Visible = true;
        //            ribNghiepVu.Visible = false;
        //            ribSaoKe.Visible = false;
        //            Program.frmChinh.btn_TaoTK.Enabled = true;
        //            Program.frmChinh.btn_TaoTKKH.Enabled = false;
        //            Program.frmChinh.MANV.Visible = true;
        //            break;
        //        case "CHINHANH":
        //            rib_QuanLy.Visible = true;
        //            ribNghiepVu.Visible = true;
        //            ribBaoCao.Visible = true;
        //            ribSaoKe.Visible = false;
        //            Program.frmChinh.btn_TaoTK.Enabled = true;
        //            Program.frmChinh.btn_TaoTKKH.Enabled = true;
        //            Program.frmChinh.MANV.Visible = true;
        //            break;
        //        case "KHACHHANG":
        //            rib_QuanLy.Visible = false;
        //            ribNghiepVu.Visible = false;
        //            ribBaoCao.Visible = false;
        //            ribSaoKe.Visible = true;
        //            Program.frmChinh.btn_TaoTK.Enabled = false;
        //            Program.frmChinh.btn_TaoTKKH.Enabled = false;
        //            Program.frmChinh.MANV.Visible = false;
        //            break;
        //    }

        private void logout()
        {
            foreach (Form f in this.MdiChildren)
                f.Dispose();
        }


        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            logout();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
