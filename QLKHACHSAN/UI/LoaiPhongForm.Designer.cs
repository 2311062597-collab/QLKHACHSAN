namespace QLKHACHSAN.UI
{
    partial class LoaiPhongForm
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
            this.dgvLoaiPhong = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnXoaLoaiPhong = new System.Windows.Forms.Button();
            this.btnThemLoaiPhong = new System.Windows.Forms.Button();
            this.btnRefreshLoaiPhong = new System.Windows.Forms.Button();
            this.btnSuaLoaiPhong = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMoTaLoaiPhong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenLoaiPhong = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimLoaiPhong = new System.Windows.Forms.Button();
            this.txtTimLoaiPhong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoaiPhong
            // 
            this.dgvLoaiPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiPhong.Location = new System.Drawing.Point(268, 41);
            this.dgvLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLoaiPhong.Name = "dgvLoaiPhong";
            this.dgvLoaiPhong.RowHeadersWidth = 51;
            this.dgvLoaiPhong.RowTemplate.Height = 24;
            this.dgvLoaiPhong.Size = new System.Drawing.Size(857, 557);
            this.dgvLoaiPhong.TabIndex = 17;
            this.dgvLoaiPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiPhong_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnXoaLoaiPhong);
            this.groupBox4.Controls.Add(this.btnThemLoaiPhong);
            this.groupBox4.Controls.Add(this.btnRefreshLoaiPhong);
            this.groupBox4.Controls.Add(this.btnSuaLoaiPhong);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 479);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(228, 119);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // btnXoaLoaiPhong
            // 
            this.btnXoaLoaiPhong.BackColor = System.Drawing.Color.Navy;
            this.btnXoaLoaiPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoaLoaiPhong.Location = new System.Drawing.Point(122, 71);
            this.btnXoaLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoaLoaiPhong.Name = "btnXoaLoaiPhong";
            this.btnXoaLoaiPhong.Size = new System.Drawing.Size(88, 28);
            this.btnXoaLoaiPhong.TabIndex = 15;
            this.btnXoaLoaiPhong.Text = "Xóa";
            this.btnXoaLoaiPhong.UseVisualStyleBackColor = false;
            this.btnXoaLoaiPhong.Click += new System.EventHandler(this.btnXoaLoaiPhong_Click);
            // 
            // btnThemLoaiPhong
            // 
            this.btnThemLoaiPhong.BackColor = System.Drawing.Color.Navy;
            this.btnThemLoaiPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThemLoaiPhong.Location = new System.Drawing.Point(18, 25);
            this.btnThemLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemLoaiPhong.Name = "btnThemLoaiPhong";
            this.btnThemLoaiPhong.Size = new System.Drawing.Size(88, 28);
            this.btnThemLoaiPhong.TabIndex = 14;
            this.btnThemLoaiPhong.Text = "Thêm";
            this.btnThemLoaiPhong.UseVisualStyleBackColor = false;
            this.btnThemLoaiPhong.Click += new System.EventHandler(this.btnThemLoaiPhong_Click);
            // 
            // btnRefreshLoaiPhong
            // 
            this.btnRefreshLoaiPhong.BackColor = System.Drawing.Color.Navy;
            this.btnRefreshLoaiPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshLoaiPhong.Location = new System.Drawing.Point(122, 25);
            this.btnRefreshLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefreshLoaiPhong.Name = "btnRefreshLoaiPhong";
            this.btnRefreshLoaiPhong.Size = new System.Drawing.Size(88, 28);
            this.btnRefreshLoaiPhong.TabIndex = 11;
            this.btnRefreshLoaiPhong.Text = "Refresh";
            this.btnRefreshLoaiPhong.UseVisualStyleBackColor = false;
            this.btnRefreshLoaiPhong.Click += new System.EventHandler(this.btnRefreshLoaiPhong_Click);
            // 
            // btnSuaLoaiPhong
            // 
            this.btnSuaLoaiPhong.BackColor = System.Drawing.Color.Navy;
            this.btnSuaLoaiPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSuaLoaiPhong.Location = new System.Drawing.Point(18, 71);
            this.btnSuaLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSuaLoaiPhong.Name = "btnSuaLoaiPhong";
            this.btnSuaLoaiPhong.Size = new System.Drawing.Size(88, 28);
            this.btnSuaLoaiPhong.TabIndex = 11;
            this.btnSuaLoaiPhong.Text = "Sửa";
            this.btnSuaLoaiPhong.UseVisualStyleBackColor = false;
            this.btnSuaLoaiPhong.Click += new System.EventHandler(this.btnSuaLoaiPhong_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMoTaLoaiPhong);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtGia);
            this.groupBox3.Controls.Add(this.txtTenLoaiPhong);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 162);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(228, 298);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại Phòng";
            // 
            // txtMoTaLoaiPhong
            // 
            this.txtMoTaLoaiPhong.Location = new System.Drawing.Point(18, 204);
            this.txtMoTaLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMoTaLoaiPhong.Multiline = true;
            this.txtMoTaLoaiPhong.Name = "txtMoTaLoaiPhong";
            this.txtMoTaLoaiPhong.Size = new System.Drawing.Size(195, 78);
            this.txtMoTaLoaiPhong.TabIndex = 14;
            this.txtMoTaLoaiPhong.TextChanged += new System.EventHandler(this.txtMoTaLoaiPhong_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mô tả : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Giá : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên loại phòng :";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(18, 136);
            this.txtGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(195, 26);
            this.txtGia.TabIndex = 2;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // txtTenLoaiPhong
            // 
            this.txtTenLoaiPhong.Location = new System.Drawing.Point(16, 69);
            this.txtTenLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenLoaiPhong.Name = "txtTenLoaiPhong";
            this.txtTenLoaiPhong.Size = new System.Drawing.Size(195, 26);
            this.txtTenLoaiPhong.TabIndex = 1;
            this.txtTenLoaiPhong.TextChanged += new System.EventHandler(this.txtTenLoaiPhong_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTimLoaiPhong);
            this.groupBox1.Controls.Add(this.txtTimLoaiPhong);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(228, 127);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tìm Theo Tên : ";
            // 
            // btnTimLoaiPhong
            // 
            this.btnTimLoaiPhong.BackColor = System.Drawing.Color.Navy;
            this.btnTimLoaiPhong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimLoaiPhong.Location = new System.Drawing.Point(59, 94);
            this.btnTimLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimLoaiPhong.Name = "btnTimLoaiPhong";
            this.btnTimLoaiPhong.Size = new System.Drawing.Size(88, 28);
            this.btnTimLoaiPhong.TabIndex = 10;
            this.btnTimLoaiPhong.Text = "Tìm Kiếm";
            this.btnTimLoaiPhong.UseVisualStyleBackColor = false;
            // 
            // txtTimLoaiPhong
            // 
            this.txtTimLoaiPhong.Location = new System.Drawing.Point(16, 65);
            this.txtTimLoaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimLoaiPhong.Name = "txtTimLoaiPhong";
            this.txtTimLoaiPhong.Size = new System.Drawing.Size(195, 26);
            this.txtTimLoaiPhong.TabIndex = 0;
            this.txtTimLoaiPhong.TextChanged += new System.EventHandler(this.txtTimLoaiPhong_TextChanged);
            // 
            // LoaiPhongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLKHACHSAN.Properties.Resources.anh_moi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1138, 629);
            this.Controls.Add(this.dgvLoaiPhong);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoaiPhongForm";
            this.Text = "LoaiPhongForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiPhong;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnXoaLoaiPhong;
        private System.Windows.Forms.Button btnThemLoaiPhong;
        private System.Windows.Forms.Button btnRefreshLoaiPhong;
        private System.Windows.Forms.Button btnSuaLoaiPhong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTenLoaiPhong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimLoaiPhong;
        private System.Windows.Forms.TextBox txtTimLoaiPhong;
        private System.Windows.Forms.TextBox txtMoTaLoaiPhong;
        private System.Windows.Forms.Label label4;
    }
}