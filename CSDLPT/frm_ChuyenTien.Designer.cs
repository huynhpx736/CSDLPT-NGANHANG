﻿
namespace CSDLPT
{
    partial class frm_ChuyenTien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSTKC = new System.Windows.Forms.TextBox();
            this.txtSTKN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.btnCheckTKC = new System.Windows.Forms.Button();
            this.btnCheckTKN = new System.Windows.Forms.Button();
            this.txtTenNC = new System.Windows.Forms.Label();
            this.txtTenNN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSTKC
            // 
            this.txtSTKC.Location = new System.Drawing.Point(309, 88);
            this.txtSTKC.Name = "txtSTKC";
            this.txtSTKC.Size = new System.Drawing.Size(481, 28);
            this.txtSTKC.TabIndex = 0;
            // 
            // txtSTKN
            // 
            this.txtSTKN.Location = new System.Drawing.Point(309, 195);
            this.txtSTKN.Name = "txtSTKN";
            this.txtSTKN.Size = new System.Drawing.Size(481, 28);
            this.txtSTKN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số Tài Khoản Chuyển";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số Tài Khoản Nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số Tiền Chuyển";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(338, 411);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(109, 48);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(591, 411);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 48);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTien
            // 
            this.txtTien.Location = new System.Drawing.Point(309, 308);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(481, 28);
            this.txtTien.TabIndex = 2;
            // 
            // btnCheckTKC
            // 
            this.btnCheckTKC.Location = new System.Drawing.Point(844, 84);
            this.btnCheckTKC.Name = "btnCheckTKC";
            this.btnCheckTKC.Size = new System.Drawing.Size(93, 35);
            this.btnCheckTKC.TabIndex = 8;
            this.btnCheckTKC.Text = "Kiểm Tra";
            this.btnCheckTKC.UseVisualStyleBackColor = true;
            this.btnCheckTKC.Click += new System.EventHandler(this.btnCheckTKC_Click);
            // 
            // btnCheckTKN
            // 
            this.btnCheckTKN.Location = new System.Drawing.Point(844, 191);
            this.btnCheckTKN.Name = "btnCheckTKN";
            this.btnCheckTKN.Size = new System.Drawing.Size(93, 35);
            this.btnCheckTKN.TabIndex = 9;
            this.btnCheckTKN.Text = "Kiểm Tra";
            this.btnCheckTKN.UseVisualStyleBackColor = true;
            this.btnCheckTKN.Click += new System.EventHandler(this.btnCheckTKN_Click);
            // 
            // txtTenNC
            // 
            this.txtTenNC.AutoSize = true;
            this.txtTenNC.Location = new System.Drawing.Point(973, 91);
            this.txtTenNC.Name = "txtTenNC";
            this.txtTenNC.Size = new System.Drawing.Size(144, 21);
            this.txtTenNC.TabIndex = 10;
            this.txtTenNC.Text = "Tên người chuyển";
            // 
            // txtTenNN
            // 
            this.txtTenNN.AutoSize = true;
            this.txtTenNN.Location = new System.Drawing.Point(973, 198);
            this.txtTenNN.Name = "txtTenNN";
            this.txtTenNN.Size = new System.Drawing.Size(126, 21);
            this.txtTenNN.TabIndex = 11;
            this.txtTenNN.Text = "Tên người nhận";
            // 
            // frm_ChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 557);
            this.Controls.Add(this.txtTenNN);
            this.Controls.Add(this.txtTenNC);
            this.Controls.Add(this.btnCheckTKN);
            this.Controls.Add(this.btnCheckTKC);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTien);
            this.Controls.Add(this.txtSTKN);
            this.Controls.Add(this.txtSTKC);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ChuyenTien";
            this.Text = "Chuyển tiền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSTKC;
        private System.Windows.Forms.TextBox txtSTKN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.Button btnCheckTKC;
        private System.Windows.Forms.Button btnCheckTKN;
        private System.Windows.Forms.Label txtTenNC;
        private System.Windows.Forms.Label txtTenNN;
    }
}