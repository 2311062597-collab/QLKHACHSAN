namespace QLKHACHSAN.UI
{
    partial class DatPhongForm
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
            this.grbDanhSachPhong = new System.Windows.Forms.GroupBox();
            this.flpPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLegendDon = new System.Windows.Forms.Button();
            this.btnLegendDangChon = new System.Windows.Forms.Button();
            this.grbHoaDonTienPhong = new System.Windows.Forms.GroupBox();
            this.dgvHoaDonPhong = new System.Windows.Forms.DataGridView();
            this.grbChucNang = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.grbThongTinDatPhong = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblNgayNhan = new System.Windows.Forms.Label();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.grbDanhSachPhong.SuspendLayout();
            this.grbHoaDonTienPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonPhong)).BeginInit();
            this.grbChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.grbThongTinDatPhong.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDanhSachPhong
            // 
            this.grbDanhSachPhong.BackColor = System.Drawing.SystemColors.Control;
            this.grbDanhSachPhong.Controls.Add(this.flpPhong);
            this.grbDanhSachPhong.Controls.Add(this.btnLegendDon);
            this.grbDanhSachPhong.Controls.Add(this.btnLegendDangChon);
            this.grbDanhSachPhong.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDanhSachPhong.ForeColor = System.Drawing.Color.Blue;
            this.grbDanhSachPhong.Location = new System.Drawing.Point(10, 60);
            this.grbDanhSachPhong.Name = "grbDanhSachPhong";
            this.grbDanhSachPhong.Size = new System.Drawing.Size(310, 690);
            this.grbDanhSachPhong.TabIndex = 0;
            this.grbDanhSachPhong.TabStop = false;
            this.grbDanhSachPhong.Text = "Danh sách phòng";
            this.grbDanhSachPhong.Enter += new System.EventHandler(this.grbDanhSachPhong_Enter);
            // 
            // flpPhong
            // 
            this.flpPhong.AutoScroll = true;
            this.flpPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpPhong.Location = new System.Drawing.Point(0, 64);
            this.flpPhong.Name = "flpPhong";
            this.flpPhong.Size = new System.Drawing.Size(305, 625);
            this.flpPhong.TabIndex = 10;
            // 
            // btnLegendDon
            // 
            this.btnLegendDon.BackColor = System.Drawing.Color.Tomato;
            this.btnLegendDon.Enabled = false;
            this.btnLegendDon.ForeColor = System.Drawing.Color.White;
            this.btnLegendDon.Location = new System.Drawing.Point(122, 35);
            this.btnLegendDon.Name = "btnLegendDon";
            this.btnLegendDon.Size = new System.Drawing.Size(75, 23);
            this.btnLegendDon.TabIndex = 1;
            this.btnLegendDon.UseVisualStyleBackColor = false;
            // 
            // btnLegendDangChon
            // 
            this.btnLegendDangChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLegendDangChon.Enabled = false;
            this.btnLegendDangChon.ForeColor = System.Drawing.Color.White;
            this.btnLegendDangChon.Location = new System.Drawing.Point(20, 35);
            this.btnLegendDangChon.Name = "btnLegendDangChon";
            this.btnLegendDangChon.Size = new System.Drawing.Size(75, 22);
            this.btnLegendDangChon.TabIndex = 0;
            this.btnLegendDangChon.UseVisualStyleBackColor = false;
            // 
            // grbHoaDonTienPhong
            // 
            this.grbHoaDonTienPhong.BackColor = System.Drawing.SystemColors.Control;
            this.grbHoaDonTienPhong.Controls.Add(this.dgvHoaDonPhong);
            this.grbHoaDonTienPhong.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHoaDonTienPhong.ForeColor = System.Drawing.Color.Blue;
            this.grbHoaDonTienPhong.Location = new System.Drawing.Point(611, 67);
            this.grbHoaDonTienPhong.Name = "grbHoaDonTienPhong";
            this.grbHoaDonTienPhong.Size = new System.Drawing.Size(699, 690);
            this.grbHoaDonTienPhong.TabIndex = 0;
            this.grbHoaDonTienPhong.TabStop = false;
            this.grbHoaDonTienPhong.Text = "Lịch sử thanh toán";
            // 
            // dgvHoaDonPhong
            // 
            this.dgvHoaDonPhong.AllowUserToAddRows = false;
            this.dgvHoaDonPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonPhong.Location = new System.Drawing.Point(8, 24);
            this.dgvHoaDonPhong.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoaDonPhong.Name = "dgvHoaDonPhong";
            this.dgvHoaDonPhong.ReadOnly = true;
            this.dgvHoaDonPhong.RowHeadersVisible = false;
            this.dgvHoaDonPhong.RowHeadersWidth = 51;
            this.dgvHoaDonPhong.RowTemplate.Height = 24;
            this.dgvHoaDonPhong.Size = new System.Drawing.Size(686, 649);
            this.dgvHoaDonPhong.TabIndex = 0;
            this.dgvHoaDonPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDonPhong_CellContentClick);
            // 
            // grbChucNang
            // 
            this.grbChucNang.BackColor = System.Drawing.SystemColors.Control;
            this.grbChucNang.Controls.Add(this.btnDong);
            this.grbChucNang.Controls.Add(this.btnDatPhong);
            this.grbChucNang.Controls.Add(this.numericUpDown1);
            this.grbChucNang.Controls.Add(this.lblGiamGia);
            this.grbChucNang.Controls.Add(this.txtTongTien);
            this.grbChucNang.Controls.Add(this.lblTongTien);
            this.grbChucNang.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChucNang.ForeColor = System.Drawing.Color.Blue;
            this.grbChucNang.Location = new System.Drawing.Point(326, 497);
            this.grbChucNang.Name = "grbChucNang";
            this.grbChucNang.Size = new System.Drawing.Size(280, 260);
            this.grbChucNang.TabIndex = 0;
            this.grbChucNang.TabStop = false;
            this.grbChucNang.Text = "Chức năng";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Blue;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(5, 226);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(128, 28);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.BackColor = System.Drawing.Color.Blue;
            this.btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDatPhong.Location = new System.Drawing.Point(137, 226);
            this.btnDatPhong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(128, 28);
            this.btnDatPhong.TabIndex = 4;
            this.btnDatPhong.Text = "Đặt Phòng ";
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(89, 137);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(105, 27);
            this.numericUpDown1.TabIndex = 3;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(5, 139);
            this.lblGiamGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(66, 20);
            this.lblGiamGia.TabIndex = 2;
            this.lblGiamGia.Text = "Giảm giá:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(89, 76);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(106, 27);
            this.txtTongTien.TabIndex = 1;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(8, 76);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(75, 20);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tiền :";
            // 
            // grbThongTinDatPhong
            // 
            this.grbThongTinDatPhong.BackColor = System.Drawing.SystemColors.Control;
            this.grbThongTinDatPhong.Controls.Add(this.dateTimePicker2);
            this.grbThongTinDatPhong.Controls.Add(this.lblNgayTra);
            this.grbThongTinDatPhong.Controls.Add(this.dateTimePicker1);
            this.grbThongTinDatPhong.Controls.Add(this.cbLoaiPhong);
            this.grbThongTinDatPhong.Controls.Add(this.txtTenPhong);
            this.grbThongTinDatPhong.Controls.Add(this.txtCCCD);
            this.grbThongTinDatPhong.Controls.Add(this.lblNgayNhan);
            this.grbThongTinDatPhong.Controls.Add(this.lblTenPhong);
            this.grbThongTinDatPhong.Controls.Add(this.lblLoaiPhong);
            this.grbThongTinDatPhong.Controls.Add(this.lblCCCD);
            this.grbThongTinDatPhong.Controls.Add(this.txtSDT);
            this.grbThongTinDatPhong.Controls.Add(this.txtTenKH);
            this.grbThongTinDatPhong.Controls.Add(this.lblTenKH);
            this.grbThongTinDatPhong.Controls.Add(this.lblSDT);
            this.grbThongTinDatPhong.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinDatPhong.ForeColor = System.Drawing.Color.Blue;
            this.grbThongTinDatPhong.Location = new System.Drawing.Point(326, 67);
            this.grbThongTinDatPhong.Name = "grbThongTinDatPhong";
            this.grbThongTinDatPhong.Size = new System.Drawing.Size(280, 420);
            this.grbThongTinDatPhong.TabIndex = 0;
            this.grbThongTinDatPhong.TabStop = false;
            this.grbThongTinDatPhong.Text = "Thông tin đặt phòng ";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(89, 382);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(131, 27);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Location = new System.Drawing.Point(13, 387);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(65, 20);
            this.lblNgayTra.TabIndex = 12;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 349);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 27);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // cbLoaiPhong
            // 
            this.cbLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiPhong.FormattingEnabled = true;
            this.cbLoaiPhong.Location = new System.Drawing.Point(16, 234);
            this.cbLoaiPhong.Name = "cbLoaiPhong";
            this.cbLoaiPhong.Size = new System.Drawing.Size(253, 28);
            this.cbLoaiPhong.TabIndex = 10;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(15, 310);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(254, 27);
            this.txtTenPhong.TabIndex = 9;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(16, 170);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(253, 27);
            this.txtCCCD.TabIndex = 8;
            // 
            // lblNgayNhan
            // 
            this.lblNgayNhan.AutoSize = true;
            this.lblNgayNhan.Location = new System.Drawing.Point(11, 352);
            this.lblNgayNhan.Name = "lblNgayNhan";
            this.lblNgayNhan.Size = new System.Drawing.Size(80, 20);
            this.lblNgayNhan.TabIndex = 7;
            this.lblNgayNhan.Text = "Ngày nhận:";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(13, 277);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(78, 20);
            this.lblTenPhong.TabIndex = 6;
            this.lblTenPhong.Text = "Tên phòng:";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(13, 210);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(81, 20);
            this.lblLoaiPhong.TabIndex = 5;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(13, 146);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(47, 20);
            this.lblCCCD.TabIndex = 4;
            this.lblCCCD.Text = "CCCD:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(16, 108);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(253, 27);
            this.txtSDT.TabIndex = 2;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(16, 48);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(253, 27);
            this.txtTenKH.TabIndex = 1;
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(11, 24);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(75, 20);
            this.lblTenKH.TabIndex = 0;
            this.lblTenKH.Text = "Tên khách:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(13, 84);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(37, 20);
            this.lblSDT.TabIndex = 0;
            this.lblSDT.Text = "SĐT:";
            // 
            // DatPhongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.grbChucNang);
            this.Controls.Add(this.grbThongTinDatPhong);
            this.Controls.Add(this.grbHoaDonTienPhong);
            this.Controls.Add(this.grbDanhSachPhong);
            this.Location = new System.Drawing.Point(10, 70);
            this.Name = "DatPhongForm";
            this.Text = "DatPhongForm";
            this.Load += new System.EventHandler(this.DatPhongForm_Load);
            this.grbDanhSachPhong.ResumeLayout(false);
            this.grbHoaDonTienPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonPhong)).EndInit();
            this.grbChucNang.ResumeLayout(false);
            this.grbChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.grbThongTinDatPhong.ResumeLayout(false);
            this.grbThongTinDatPhong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDanhSachPhong;
        private System.Windows.Forms.GroupBox grbHoaDonTienPhong;
        private System.Windows.Forms.GroupBox grbChucNang;
        private System.Windows.Forms.GroupBox grbThongTinDatPhong;
        private System.Windows.Forms.Button btnLegendDon;
        private System.Windows.Forms.Button btnLegendDangChon;
        private System.Windows.Forms.FlowLayoutPanel flpPhong;
        private System.Windows.Forms.Label lblNgayNhan;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dgvHoaDonPhong;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}