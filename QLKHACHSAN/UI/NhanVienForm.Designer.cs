namespace QLKHACHSAN.UI
{
    partial class NhanVienForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimNV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimNV = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDCNV = new System.Windows.Forms.TextBox();
            this.txtCCCDNV = new System.Windows.Forms.TextBox();
            this.txtSDTNV = new System.Windows.Forms.TextBox();
            this.radNuNV = new System.Windows.Forms.RadioButton();
            this.radNamNV = new System.Windows.Forms.RadioButton();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTrangThaiNV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCVNV = new System.Windows.Forms.ComboBox();
            this.txtMKNV = new System.Windows.Forms.TextBox();
            this.txtTKNV = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.btnSuaNV = new System.Windows.Forms.Button();
            this.dgvBangNV = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangNV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTimNV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(47, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm ";
            // 
            // btnTimNV
            // 
            this.btnTimNV.BackColor = System.Drawing.Color.Navy;
            this.btnTimNV.ForeColor = System.Drawing.SystemColors.Window;
            this.btnTimNV.Location = new System.Drawing.Point(79, 121);
            this.btnTimNV.Name = "btnTimNV";
            this.btnTimNV.Size = new System.Drawing.Size(121, 41);
            this.btnTimNV.TabIndex = 2;
            this.btnTimNV.Text = "Tìm kiếm";
            this.btnTimNV.UseVisualStyleBackColor = false;
            this.btnTimNV.Click += new System.EventHandler(this.btnTimNV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài khoản/ Tên/ SĐT:";
            // 
            // txtTimNV
            // 
            this.txtTimNV.Location = new System.Drawing.Point(22, 85);
            this.txtTimNV.Name = "txtTimNV";
            this.txtTimNV.Size = new System.Drawing.Size(259, 30);
            this.txtTimNV.TabIndex = 0;
            this.txtTimNV.TextChanged += new System.EventHandler(this.txtTimNV_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDCNV);
            this.groupBox2.Controls.Add(this.txtCCCDNV);
            this.groupBox2.Controls.Add(this.txtSDTNV);
            this.groupBox2.Controls.Add(this.radNuNV);
            this.groupBox2.Controls.Add(this.radNamNV);
            this.groupBox2.Controls.Add(this.txtTenNV);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(398, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 595);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(113, 527);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(60, 25);
            this.lbl.TabIndex = 15;
            this.lbl.Text = "lương";
            this.lbl.Click += new System.EventHandler(this.lbl_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 527);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 25);
            this.label11.TabIndex = 14;
            this.label11.Text = "Lương:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 417);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 25);
            this.label10.TabIndex = 13;
            this.label10.Text = "Địa chỉ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 25);
            this.label9.TabIndex = 12;
            this.label9.Text = "Giới tính:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "SĐT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "CCCD:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Họ Và Tên:";
            // 
            // txtDCNV
            // 
            this.txtDCNV.Location = new System.Drawing.Point(27, 457);
            this.txtDCNV.Name = "txtDCNV";
            this.txtDCNV.Size = new System.Drawing.Size(266, 30);
            this.txtDCNV.TabIndex = 8;
            this.txtDCNV.TextChanged += new System.EventHandler(this.txtDCNV_TextChanged);
            // 
            // txtCCCDNV
            // 
            this.txtCCCDNV.Location = new System.Drawing.Point(22, 176);
            this.txtCCCDNV.Name = "txtCCCDNV";
            this.txtCCCDNV.Size = new System.Drawing.Size(266, 30);
            this.txtCCCDNV.TabIndex = 7;
            this.txtCCCDNV.TextChanged += new System.EventHandler(this.txtCCCDNV_TextChanged);
            // 
            // txtSDTNV
            // 
            this.txtSDTNV.Location = new System.Drawing.Point(22, 263);
            this.txtSDTNV.Name = "txtSDTNV";
            this.txtSDTNV.Size = new System.Drawing.Size(266, 30);
            this.txtSDTNV.TabIndex = 6;
            this.txtSDTNV.TextChanged += new System.EventHandler(this.txtSDTNV_TextChanged);
            // 
            // radNuNV
            // 
            this.radNuNV.AutoSize = true;
            this.radNuNV.Location = new System.Drawing.Point(167, 359);
            this.radNuNV.Name = "radNuNV";
            this.radNuNV.Size = new System.Drawing.Size(58, 29);
            this.radNuNV.TabIndex = 5;
            this.radNuNV.TabStop = true;
            this.radNuNV.Text = "Nữ";
            this.radNuNV.UseVisualStyleBackColor = true;
            this.radNuNV.CheckedChanged += new System.EventHandler(this.radNuNV_CheckedChanged);
            // 
            // radNamNV
            // 
            this.radNamNV.AutoSize = true;
            this.radNamNV.Location = new System.Drawing.Point(36, 359);
            this.radNamNV.Name = "radNamNV";
            this.radNamNV.Size = new System.Drawing.Size(74, 29);
            this.radNamNV.TabIndex = 4;
            this.radNamNV.TabStop = true;
            this.radNamNV.Text = "Nam";
            this.radNamNV.UseVisualStyleBackColor = true;
            this.radNamNV.CheckedChanged += new System.EventHandler(this.radNamNV_CheckedChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(25, 85);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(266, 30);
            this.txtTenNV.TabIndex = 3;
            this.txtTenNV.TextChanged += new System.EventHandler(this.txtTenNV_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTrangThaiNV);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbCVNV);
            this.groupBox3.Controls.Add(this.txtMKNV);
            this.groupBox3.Controls.Add(this.txtTKNV);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(47, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 397);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tài Khoản";
            // 
            // cbTrangThaiNV
            // 
            this.cbTrangThaiNV.FormattingEnabled = true;
            this.cbTrangThaiNV.Location = new System.Drawing.Point(22, 329);
            this.cbTrangThaiNV.Name = "cbTrangThaiNV";
            this.cbTrangThaiNV.Size = new System.Drawing.Size(259, 33);
            this.cbTrangThaiNV.TabIndex = 9;
            this.cbTrangThaiNV.SelectedIndexChanged += new System.EventHandler(this.cbTrangThaiNV_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chức vụ: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tài khoản:";
            // 
            // cbCVNV
            // 
            this.cbCVNV.FormattingEnabled = true;
            this.cbCVNV.Location = new System.Drawing.Point(22, 237);
            this.cbCVNV.Name = "cbCVNV";
            this.cbCVNV.Size = new System.Drawing.Size(259, 33);
            this.cbCVNV.TabIndex = 3;
            this.cbCVNV.SelectedIndexChanged += new System.EventHandler(this.cbCVNV_SelectedIndexChanged);
            // 
            // txtMKNV
            // 
            this.txtMKNV.Location = new System.Drawing.Point(22, 160);
            this.txtMKNV.Name = "txtMKNV";
            this.txtMKNV.Size = new System.Drawing.Size(259, 30);
            this.txtMKNV.TabIndex = 2;
            this.txtMKNV.TextChanged += new System.EventHandler(this.txtMKNV_TextChanged);
            // 
            // txtTKNV
            // 
            this.txtTKNV.Location = new System.Drawing.Point(22, 71);
            this.txtTKNV.Name = "txtTKNV";
            this.txtTKNV.Size = new System.Drawing.Size(259, 30);
            this.txtTKNV.TabIndex = 1;
            this.txtTKNV.TextChanged += new System.EventHandler(this.txtTKNV_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRefresh);
            this.groupBox4.Controls.Add(this.btnThemNV);
            this.groupBox4.Controls.Add(this.btnSuaNV);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(47, 723);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(662, 80);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Navy;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRefresh.Location = new System.Drawing.Point(469, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 41);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnThemNV
            // 
            this.btnThemNV.BackColor = System.Drawing.Color.Navy;
            this.btnThemNV.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThemNV.Location = new System.Drawing.Point(267, 29);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(121, 41);
            this.btnThemNV.TabIndex = 4;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = false;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.BackColor = System.Drawing.Color.Navy;
            this.btnSuaNV.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSuaNV.Location = new System.Drawing.Point(55, 29);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(121, 41);
            this.btnSuaNV.TabIndex = 3;
            this.btnSuaNV.Text = "Sửa";
            this.btnSuaNV.UseVisualStyleBackColor = false;
            this.btnSuaNV.Click += new System.EventHandler(this.btnSuaNV_Click);
            // 
            // dgvBangNV
            // 
            this.dgvBangNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangNV.Location = new System.Drawing.Point(760, 117);
            this.dgvBangNV.Name = "dgvBangNV";
            this.dgvBangNV.RowHeadersWidth = 51;
            this.dgvBangNV.RowTemplate.Height = 24;
            this.dgvBangNV.Size = new System.Drawing.Size(1093, 686);
            this.dgvBangNV.TabIndex = 4;
            this.dgvBangNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangNV_CellContentClick);
            // 
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 892);
            this.Controls.Add(this.dgvBangNV);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NhanVienForm";
            this.Text = "NhanVienForm";
            this.Load += new System.EventHandler(this.NhanVienForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTimNV;
        private System.Windows.Forms.DataGridView dgvBangNV;
        private System.Windows.Forms.RadioButton radNuNV;
        private System.Windows.Forms.RadioButton radNamNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtMKNV;
        private System.Windows.Forms.TextBox txtTKNV;
        private System.Windows.Forms.TextBox txtCCCDNV;
        private System.Windows.Forms.TextBox txtSDTNV;
        private System.Windows.Forms.TextBox txtDCNV;
        private System.Windows.Forms.ComboBox cbCVNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTimNV;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.Button btnSuaNV;
        private System.Windows.Forms.ComboBox cbTrangThaiNV;
    }
}