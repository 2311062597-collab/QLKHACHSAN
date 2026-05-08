namespace QLKHACHSAN.UI
{
    partial class DichVuForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.btnRefreshDV = new System.Windows.Forms.Button();
            this.btnSuaDV = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoTaDV = new System.Windows.Forms.TextBox();
            this.cbTrangThaiDv = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDichVuloai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimDV = new System.Windows.Forms.Button();
            this.txtTimDV = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDV
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDV.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDV.Location = new System.Drawing.Point(261, 111);
            this.dgvDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDV.Name = "dgvDV";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDV.RowHeadersWidth = 51;
            this.dgvDV.RowTemplate.Height = 24;
            this.dgvDV.Size = new System.Drawing.Size(652, 470);
            this.dgvDV.TabIndex = 13;
            this.dgvDV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDV_CellContentClick);
            this.dgvDV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDV_CellDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnXoaDV);
            this.groupBox4.Controls.Add(this.btnThemDV);
            this.groupBox4.Controls.Add(this.btnRefreshDV);
            this.groupBox4.Controls.Add(this.btnSuaDV);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(18, 478);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(228, 104);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.BackColor = System.Drawing.Color.Navy;
            this.btnXoaDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoaDV.Location = new System.Drawing.Point(124, 58);
            this.btnXoaDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(88, 28);
            this.btnXoaDV.TabIndex = 15;
            this.btnXoaDV.Text = "Xóa";
            this.btnXoaDV.UseVisualStyleBackColor = false;
            this.btnXoaDV.Click += new System.EventHandler(this.btnXoaDV_Click);
            // 
            // btnThemDV
            // 
            this.btnThemDV.BackColor = System.Drawing.Color.Navy;
            this.btnThemDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThemDV.Location = new System.Drawing.Point(13, 58);
            this.btnThemDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(88, 28);
            this.btnThemDV.TabIndex = 14;
            this.btnThemDV.Text = "Thêm";
            this.btnThemDV.UseVisualStyleBackColor = false;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // btnRefreshDV
            // 
            this.btnRefreshDV.BackColor = System.Drawing.Color.Navy;
            this.btnRefreshDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshDV.Location = new System.Drawing.Point(124, 25);
            this.btnRefreshDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefreshDV.Name = "btnRefreshDV";
            this.btnRefreshDV.Size = new System.Drawing.Size(88, 28);
            this.btnRefreshDV.TabIndex = 11;
            this.btnRefreshDV.Text = "Refresh";
            this.btnRefreshDV.UseVisualStyleBackColor = false;
            this.btnRefreshDV.Click += new System.EventHandler(this.btnRefreshDV_Click);
            // 
            // btnSuaDV
            // 
            this.btnSuaDV.BackColor = System.Drawing.Color.Navy;
            this.btnSuaDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSuaDV.Location = new System.Drawing.Point(13, 24);
            this.btnSuaDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSuaDV.Name = "btnSuaDV";
            this.btnSuaDV.Size = new System.Drawing.Size(88, 28);
            this.btnSuaDV.TabIndex = 11;
            this.btnSuaDV.Text = "Sửa";
            this.btnSuaDV.UseVisualStyleBackColor = false;
            this.btnSuaDV.Click += new System.EventHandler(this.btnSuaDV_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtMoTaDV);
            this.groupBox3.Controls.Add(this.cbTrangThaiDv);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtTenDV);
            this.groupBox3.Controls.Add(this.txtDonGia);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbDichVuloai);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 59);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(228, 414);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dịch Vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mô tả : ";
            // 
            // txtMoTaDV
            // 
            this.txtMoTaDV.Location = new System.Drawing.Point(18, 314);
            this.txtMoTaDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMoTaDV.Multiline = true;
            this.txtMoTaDV.Name = "txtMoTaDV";
            this.txtMoTaDV.Size = new System.Drawing.Size(195, 70);
            this.txtMoTaDV.TabIndex = 19;
            this.txtMoTaDV.TextChanged += new System.EventHandler(this.txtMoTaDV_TextChanged);
            // 
            // cbTrangThaiDv
            // 
            this.cbTrangThaiDv.FormattingEnabled = true;
            this.cbTrangThaiDv.Location = new System.Drawing.Point(18, 235);
            this.cbTrangThaiDv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTrangThaiDv.Name = "cbTrangThaiDv";
            this.cbTrangThaiDv.Size = new System.Drawing.Size(195, 28);
            this.cbTrangThaiDv.TabIndex = 18;
            this.cbTrangThaiDv.SelectedIndexChanged += new System.EventHandler(this.cbTrangThaiDv_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tên Dịch Vụ :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 212);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Trạng thái : ";
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(16, 52);
            this.txtTenDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(195, 26);
            this.txtTenDV.TabIndex = 1;
            this.txtTenDV.TextChanged += new System.EventHandler(this.txtTenDV_TextChanged);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(18, 176);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(195, 26);
            this.txtDonGia.TabIndex = 3;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 153);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Đơn giá : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Loại dịch vụ : ";
            // 
            // cbDichVuloai
            // 
            this.cbDichVuloai.FormattingEnabled = true;
            this.cbDichVuloai.Location = new System.Drawing.Point(18, 110);
            this.cbDichVuloai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDichVuloai.Name = "cbDichVuloai";
            this.cbDichVuloai.Size = new System.Drawing.Size(195, 28);
            this.cbDichVuloai.TabIndex = 15;
            this.cbDichVuloai.SelectedIndexChanged += new System.EventHandler(this.cbDichVuloai_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(412, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 10;
            // 
            // btnTimDV
            // 
            this.btnTimDV.BackColor = System.Drawing.Color.Navy;
            this.btnTimDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimDV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimDV.Location = new System.Drawing.Point(825, 66);
            this.btnTimDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimDV.Name = "btnTimDV";
            this.btnTimDV.Size = new System.Drawing.Size(88, 28);
            this.btnTimDV.TabIndex = 10;
            this.btnTimDV.Text = "Tìm Kiếm";
            this.btnTimDV.UseVisualStyleBackColor = false;
            this.btnTimDV.Click += new System.EventHandler(this.btnTimDV_Click);
            // 
            // txtTimDV
            // 
            this.txtTimDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimDV.Location = new System.Drawing.Point(626, 70);
            this.txtTimDV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimDV.Name = "txtTimDV";
            this.txtTimDV.Size = new System.Drawing.Size(195, 26);
            this.txtTimDV.TabIndex = 0;
            this.txtTimDV.TextChanged += new System.EventHandler(this.txtTimDV_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(261, 70);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Quản Lý loại Dịch vụ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tìm kiếm theo tên : ";
            // 
            // DichVuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLKHACHSAN.Properties.Resources.anh_moi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1150, 601);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimDV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvDV);
            this.Controls.Add(this.txtTimDV);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DichVuForm";
            this.Text = "DichVuForm";
            this.Load += new System.EventHandler(this.DichVuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRefreshDV;
        private System.Windows.Forms.Button btnSuaDV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimDV;
        private System.Windows.Forms.TextBox txtTimDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDichVuloai;
        private System.Windows.Forms.ComboBox cbTrangThaiDv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMoTaDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}