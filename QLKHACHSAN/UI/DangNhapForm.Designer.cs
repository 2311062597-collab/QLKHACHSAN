namespace QLKHACHSAN.UI
{
    partial class DangNhapForm
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.picUserTop = new System.Windows.Forms.PictureBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.picBanner);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(480, 734);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Gainsboro;
            this.panelRight.Controls.Add(this.btnDangNhap);
            this.panelRight.Controls.Add(this.groupBox1);
            this.panelRight.Controls.Add(this.picUserTop);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRight.Location = new System.Drawing.Point(480, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(668, 734);
            this.panelRight.TabIndex = 0;
            // 
            // picUserTop
            // 
            this.picUserTop.BackColor = System.Drawing.Color.Transparent;
            this.picUserTop.Image = global::QLKHACHSAN.Properties.Resources.Gemini_Generated_Image_rjlogrjlogrjlogr1;
            this.picUserTop.Location = new System.Drawing.Point(266, 185);
            this.picUserTop.Name = "picUserTop";
            this.picUserTop.Size = new System.Drawing.Size(65, 80);
            this.picUserTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserTop.TabIndex = 0;
            this.picUserTop.TabStop = false;
            // 
            // picBanner
            // 
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBanner.Image = global::QLKHACHSAN.Properties.Resources.z7738595353635_f0458a46613e5b57cea3326fca87bed6;
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(480, 734);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkQuenMatKhau);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(68, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 215);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng Nhập ";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(107, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(174, 29);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Tên người dùng";
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLKHACHSAN.Properties.Resources.Gemini_Generated_Image_rjlogrjlogrjlogr1;
            this.pictureBox1.Location = new System.Drawing.Point(57, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(107, 118);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(174, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Mật khẩu";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.Image = global::QLKHACHSAN.Properties.Resources._070775A8_8CBD_4EC8_9143_AA2A5C7064A3_;
            this.pictureBox2.Location = new System.Drawing.Point(57, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lnkQuenMatKhau
            // 
            this.lnkQuenMatKhau.AutoSize = true;
            this.lnkQuenMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkQuenMatKhau.Location = new System.Drawing.Point(283, 161);
            this.lnkQuenMatKhau.Name = "lnkQuenMatKhau";
            this.lnkQuenMatKhau.Size = new System.Drawing.Size(105, 17);
            this.lnkQuenMatKhau.TabIndex = 4;
            this.lnkQuenMatKhau.TabStop = true;
            this.lnkQuenMatKhau.Text = "Quên Mật Khẩu?";
            this.lnkQuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkQuenMatKhau_LinkClicked);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(135, 530);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(280, 50);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // DangNhapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1148, 734);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DangNhapForm";
            this.Text = "DangNhapForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangNhapForm_FormClosing);
            this.Load += new System.EventHandler(this.DangNhapForm_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUserTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picUserTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.LinkLabel lnkQuenMatKhau;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}