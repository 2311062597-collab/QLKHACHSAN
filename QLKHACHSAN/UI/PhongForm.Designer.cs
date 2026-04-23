namespace QLKHACHSAN.UI
{
    partial class PhongForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTrangThaiPhong = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRefreshPhong = new System.Windows.Forms.Button();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.btnSuaPhong = new System.Windows.Forms.Button();
            this.dgvBangPhong = new System.Windows.Forms.DataGridView();
            this.cbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.blGia = new System.Windows.Forms.Label();
            this.btnqlLoaiPhong = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblmotaLoaiPhong = new System.Windows.Forms.Label();
            this.cbTang = new System.Windows.Forms.ComboBox();
            this.btnTimPhong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimPhong = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cblocLoaiPhong = new System.Windows.Forms.ComboBox();
            this.cbLocTang = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangPhong)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mô tả : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Giá :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Loại Phòng :";
            // 
            // cbTrangThaiPhong
            // 
            this.cbTrangThaiPhong.FormattingEnabled = true;
            this.cbTrangThaiPhong.Location = new System.Drawing.Point(25, 380);
            this.cbTrangThaiPhong.Name = "cbTrangThaiPhong";
            this.cbTrangThaiPhong.Size = new System.Drawing.Size(259, 28);
            this.cbTrangThaiPhong.TabIndex = 3;
            this.cbTrangThaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbTrangThaiPhong_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tầng :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Số Phòng:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRefreshPhong);
            this.groupBox4.Controls.Add(this.btnThemPhong);
            this.groupBox4.Controls.Add(this.btnSuaPhong);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(30, 634);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(662, 96);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // btnRefreshPhong
            // 
            this.btnRefreshPhong.BackColor = System.Drawing.Color.Navy;
            this.btnRefreshPhong.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRefreshPhong.Location = new System.Drawing.Point(469, 35);
            this.btnRefreshPhong.Name = "btnRefreshPhong";
            this.btnRefreshPhong.Size = new System.Drawing.Size(121, 41);
            this.btnRefreshPhong.TabIndex = 5;
            this.btnRefreshPhong.Text = "Refresh";
            this.btnRefreshPhong.UseVisualStyleBackColor = false;
            this.btnRefreshPhong.Click += new System.EventHandler(this.btnRefreshPhong_Click);
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.BackColor = System.Drawing.Color.Navy;
            this.btnThemPhong.ForeColor = System.Drawing.SystemColors.Window;
            this.btnThemPhong.Location = new System.Drawing.Point(267, 35);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(121, 41);
            this.btnThemPhong.TabIndex = 4;
            this.btnThemPhong.Text = "Thêm";
            this.btnThemPhong.UseVisualStyleBackColor = false;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // btnSuaPhong
            // 
            this.btnSuaPhong.BackColor = System.Drawing.Color.Navy;
            this.btnSuaPhong.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSuaPhong.Location = new System.Drawing.Point(55, 35);
            this.btnSuaPhong.Name = "btnSuaPhong";
            this.btnSuaPhong.Size = new System.Drawing.Size(121, 41);
            this.btnSuaPhong.TabIndex = 3;
            this.btnSuaPhong.Text = "Sửa";
            this.btnSuaPhong.UseVisualStyleBackColor = false;
            this.btnSuaPhong.Click += new System.EventHandler(this.btnSuaPhong_Click);
            // 
            // dgvBangPhong
            // 
            this.dgvBangPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangPhong.Location = new System.Drawing.Point(722, 28);
            this.dgvBangPhong.Name = "dgvBangPhong";
            this.dgvBangPhong.RowHeadersWidth = 51;
            this.dgvBangPhong.RowTemplate.Height = 24;
            this.dgvBangPhong.Size = new System.Drawing.Size(764, 686);
            this.dgvBangPhong.TabIndex = 9;
            this.dgvBangPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangPhong_CellContentClick);
            // 
            // cbLoaiPhong
            // 
            this.cbLoaiPhong.FormattingEnabled = true;
            this.cbLoaiPhong.Location = new System.Drawing.Point(22, 88);
            this.cbLoaiPhong.Name = "cbLoaiPhong";
            this.cbLoaiPhong.Size = new System.Drawing.Size(259, 28);
            this.cbLoaiPhong.TabIndex = 9;
            this.cbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbLoaiPhong_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.blGia);
            this.groupBox3.Controls.Add(this.btnqlLoaiPhong);
            this.groupBox3.Controls.Add(this.cbLoaiPhong);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(30, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 249);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại Phòng ";
            // 
            // blGia
            // 
            this.blGia.AutoSize = true;
            this.blGia.Location = new System.Drawing.Point(97, 139);
            this.blGia.Name = "blGia";
            this.blGia.Size = new System.Drawing.Size(38, 20);
            this.blGia.TabIndex = 10;
            this.blGia.Text = "Giá ";
            this.blGia.Click += new System.EventHandler(this.blGia_Click);
            // 
            // btnqlLoaiPhong
            // 
            this.btnqlLoaiPhong.BackColor = System.Drawing.Color.Navy;
            this.btnqlLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnqlLoaiPhong.ForeColor = System.Drawing.SystemColors.Window;
            this.btnqlLoaiPhong.Location = new System.Drawing.Point(22, 190);
            this.btnqlLoaiPhong.Name = "btnqlLoaiPhong";
            this.btnqlLoaiPhong.Size = new System.Drawing.Size(259, 41);
            this.btnqlLoaiPhong.TabIndex = 10;
            this.btnqlLoaiPhong.Text = "Quản lý loại phòng";
            this.btnqlLoaiPhong.UseVisualStyleBackColor = false;
            this.btnqlLoaiPhong.Click += new System.EventHandler(this.btnqlLoaiPhong_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trạng thái:";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(25, 107);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(266, 26);
            this.txtSoPhong.TabIndex = 3;
            this.txtSoPhong.TextChanged += new System.EventHandler(this.txtSoPhong_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblmotaLoaiPhong);
            this.groupBox2.Controls.Add(this.cbTang);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbTrangThaiPhong);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSoPhong);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(381, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 595);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblmotaLoaiPhong
            // 
            this.lblmotaLoaiPhong.AutoSize = true;
            this.lblmotaLoaiPhong.Location = new System.Drawing.Point(22, 504);
            this.lblmotaLoaiPhong.Name = "lblmotaLoaiPhong";
            this.lblmotaLoaiPhong.Size = new System.Drawing.Size(49, 20);
            this.lblmotaLoaiPhong.TabIndex = 11;
            this.lblmotaLoaiPhong.Text = "mô tả";
            this.lblmotaLoaiPhong.Click += new System.EventHandler(this.lblmotaLoaiPhong_Click);
            // 
            // cbTang
            // 
            this.cbTang.FormattingEnabled = true;
            this.cbTang.Location = new System.Drawing.Point(25, 244);
            this.cbTang.Name = "cbTang";
            this.cbTang.Size = new System.Drawing.Size(259, 28);
            this.cbTang.TabIndex = 16;
            this.cbTang.SelectedIndexChanged += new System.EventHandler(this.cbTang_SelectedIndexChanged);
            // 
            // btnTimPhong
            // 
            this.btnTimPhong.BackColor = System.Drawing.Color.Navy;
            this.btnTimPhong.ForeColor = System.Drawing.SystemColors.Window;
            this.btnTimPhong.Location = new System.Drawing.Point(188, 91);
            this.btnTimPhong.Name = "btnTimPhong";
            this.btnTimPhong.Size = new System.Drawing.Size(93, 41);
            this.btnTimPhong.TabIndex = 2;
            this.btnTimPhong.Text = "Tìm kiếm";
            this.btnTimPhong.UseVisualStyleBackColor = false;
            this.btnTimPhong.Click += new System.EventHandler(this.btnTimPhong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Phòng :";
            // 
            // txtTimPhong
            // 
            this.txtTimPhong.Location = new System.Drawing.Point(22, 91);
            this.txtTimPhong.Multiline = true;
            this.txtTimPhong.Name = "txtTimPhong";
            this.txtTimPhong.Size = new System.Drawing.Size(154, 41);
            this.txtTimPhong.TabIndex = 0;
            this.txtTimPhong.TextChanged += new System.EventHandler(this.txtTimPhong_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cblocLoaiPhong);
            this.groupBox1.Controls.Add(this.cbLocTang);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnTimPhong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTimPhong);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 340);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm ";
            // 
            // cblocLoaiPhong
            // 
            this.cblocLoaiPhong.FormattingEnabled = true;
            this.cblocLoaiPhong.Location = new System.Drawing.Point(22, 271);
            this.cblocLoaiPhong.Name = "cblocLoaiPhong";
            this.cblocLoaiPhong.Size = new System.Drawing.Size(259, 28);
            this.cblocLoaiPhong.TabIndex = 6;
            this.cblocLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cblocLoaiPhong_SelectedIndexChanged);
            // 
            // cbLocTang
            // 
            this.cbLocTang.FormattingEnabled = true;
            this.cbLocTang.Location = new System.Drawing.Point(22, 193);
            this.cbLocTang.Name = "cbLocTang";
            this.cbLocTang.Size = new System.Drawing.Size(259, 28);
            this.cbLocTang.TabIndex = 5;
            this.cbLocTang.SelectedIndexChanged += new System.EventHandler(this.cbLocTang_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Lọc theo loại phòng :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Lọc theo tầng :";
            // 
            // PhongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 733);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvBangPhong);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhongForm";
            this.Text = "PhongForm";
            this.Load += new System.EventHandler(this.PhongForm_Load_1);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangPhong)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrangThaiPhong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRefreshPhong;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnSuaPhong;
        private System.Windows.Forms.DataGridView dgvBangPhong;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimPhong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblmotaLoaiPhong;
        private System.Windows.Forms.Label blGia;
        private System.Windows.Forms.ComboBox cbTang;
        private System.Windows.Forms.Button btnqlLoaiPhong;
        private System.Windows.Forms.ComboBox cblocLoaiPhong;
        private System.Windows.Forms.ComboBox cbLocTang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}