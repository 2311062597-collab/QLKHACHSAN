namespace QLKHACHSAN.UI
{
    partial class LoaiDichVuForm
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
            this.dgvLoaiDV = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRefreshLoaiDV = new System.Windows.Forms.Button();
            this.btnSuaLoaiDV = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThemLoaiDV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDVtinh = new System.Windows.Forms.TextBox();
            this.txtTenLoaiDV = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimLoaiDV = new System.Windows.Forms.Button();
            this.txtTimLoaiDV = new System.Windows.Forms.TextBox();
            this.btnXoaLoaiDV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiDV)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoaiDV
            // 
            this.dgvLoaiDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiDV.Location = new System.Drawing.Point(380, 40);
            this.dgvLoaiDV.Name = "dgvLoaiDV";
            this.dgvLoaiDV.RowHeadersWidth = 51;
            this.dgvLoaiDV.RowTemplate.Height = 24;
            this.dgvLoaiDV.Size = new System.Drawing.Size(1143, 686);
            this.dgvLoaiDV.TabIndex = 13;
            this.dgvLoaiDV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiDV_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnXoaLoaiDV);
            this.groupBox4.Controls.Add(this.btnThemLoaiDV);
            this.groupBox4.Controls.Add(this.btnRefreshLoaiDV);
            this.groupBox4.Controls.Add(this.btnSuaLoaiDV);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(38, 580);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(304, 146);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // btnRefreshLoaiDV
            // 
            this.btnRefreshLoaiDV.BackColor = System.Drawing.Color.Navy;
            this.btnRefreshLoaiDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshLoaiDV.Location = new System.Drawing.Point(163, 31);
            this.btnRefreshLoaiDV.Name = "btnRefreshLoaiDV";
            this.btnRefreshLoaiDV.Size = new System.Drawing.Size(118, 35);
            this.btnRefreshLoaiDV.TabIndex = 11;
            this.btnRefreshLoaiDV.Text = "Refresh";
            this.btnRefreshLoaiDV.UseVisualStyleBackColor = false;
            this.btnRefreshLoaiDV.Click += new System.EventHandler(this.btnRefreshLoaiDV_Click);
            // 
            // btnSuaLoaiDV
            // 
            this.btnSuaLoaiDV.BackColor = System.Drawing.Color.Navy;
            this.btnSuaLoaiDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSuaLoaiDV.Location = new System.Drawing.Point(24, 87);
            this.btnSuaLoaiDV.Name = "btnSuaLoaiDV";
            this.btnSuaLoaiDV.Size = new System.Drawing.Size(118, 35);
            this.btnSuaLoaiDV.TabIndex = 11;
            this.btnSuaLoaiDV.Text = "Sửa";
            this.btnSuaLoaiDV.UseVisualStyleBackColor = false;
            this.btnSuaLoaiDV.Click += new System.EventHandler(this.btnSuaLoaiDV_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDVtinh);
            this.groupBox3.Controls.Add(this.txtTenLoaiDV);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(38, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 367);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại Dịch Vụ";
            // 
            // btnThemLoaiDV
            // 
            this.btnThemLoaiDV.BackColor = System.Drawing.Color.Navy;
            this.btnThemLoaiDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThemLoaiDV.Location = new System.Drawing.Point(24, 31);
            this.btnThemLoaiDV.Name = "btnThemLoaiDV";
            this.btnThemLoaiDV.Size = new System.Drawing.Size(118, 35);
            this.btnThemLoaiDV.TabIndex = 14;
            this.btnThemLoaiDV.Text = "Thêm";
            this.btnThemLoaiDV.UseVisualStyleBackColor = false;
            this.btnThemLoaiDV.Click += new System.EventHandler(this.btnThemLoaiDV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đơn Vị Tính : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên Loại Dịch Vụ :";
            // 
            // txtDVtinh
            // 
            this.txtDVtinh.Location = new System.Drawing.Point(22, 260);
            this.txtDVtinh.Name = "txtDVtinh";
            this.txtDVtinh.Size = new System.Drawing.Size(259, 30);
            this.txtDVtinh.TabIndex = 2;
            this.txtDVtinh.TextChanged += new System.EventHandler(this.txtDVtinh_TextChanged);
            // 
            // txtTenLoaiDV
            // 
            this.txtTenLoaiDV.Location = new System.Drawing.Point(22, 122);
            this.txtTenLoaiDV.Name = "txtTenLoaiDV";
            this.txtTenLoaiDV.Size = new System.Drawing.Size(259, 30);
            this.txtTenLoaiDV.TabIndex = 1;
            this.txtTenLoaiDV.TextChanged += new System.EventHandler(this.txtTenLoaiDV_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTimLoaiDV);
            this.groupBox1.Controls.Add(this.txtTimLoaiDV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 156);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tìm Theo Tên : ";
            // 
            // btnTimLoaiDV
            // 
            this.btnTimLoaiDV.BackColor = System.Drawing.Color.Navy;
            this.btnTimLoaiDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimLoaiDV.Location = new System.Drawing.Point(79, 116);
            this.btnTimLoaiDV.Name = "btnTimLoaiDV";
            this.btnTimLoaiDV.Size = new System.Drawing.Size(118, 35);
            this.btnTimLoaiDV.TabIndex = 10;
            this.btnTimLoaiDV.Text = "Tìm Kiếm";
            this.btnTimLoaiDV.UseVisualStyleBackColor = false;
            this.btnTimLoaiDV.Click += new System.EventHandler(this.btnTimLoaiDV_Click);
            // 
            // txtTimLoaiDV
            // 
            this.txtTimLoaiDV.Location = new System.Drawing.Point(22, 80);
            this.txtTimLoaiDV.Name = "txtTimLoaiDV";
            this.txtTimLoaiDV.Size = new System.Drawing.Size(259, 30);
            this.txtTimLoaiDV.TabIndex = 0;
            this.txtTimLoaiDV.TextChanged += new System.EventHandler(this.txtTimLoaiDV_TextChanged);
            // 
            // btnXoaLoaiDV
            // 
            this.btnXoaLoaiDV.BackColor = System.Drawing.Color.Navy;
            this.btnXoaLoaiDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoaLoaiDV.Location = new System.Drawing.Point(163, 87);
            this.btnXoaLoaiDV.Name = "btnXoaLoaiDV";
            this.btnXoaLoaiDV.Size = new System.Drawing.Size(118, 35);
            this.btnXoaLoaiDV.TabIndex = 15;
            this.btnXoaLoaiDV.Text = "Xóa";
            this.btnXoaLoaiDV.UseVisualStyleBackColor = false;
            this.btnXoaLoaiDV.Click += new System.EventHandler(this.btnXoaLoaiDV_Click);
            // 
            // LoaiDichVuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 754);
            this.Controls.Add(this.dgvLoaiDV);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoaiDichVuForm";
            this.Text = "LoaiDichVuForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiDV)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.dgvLoaiDV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiDV_CellDoubleClick);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiDV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRefreshLoaiDV;
        private System.Windows.Forms.Button btnSuaLoaiDV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThemLoaiDV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDVtinh;
        private System.Windows.Forms.TextBox txtTenLoaiDV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimLoaiDV;
        private System.Windows.Forms.TextBox txtTimLoaiDV;
        private System.Windows.Forms.Button btnXoaLoaiDV;
    }
}