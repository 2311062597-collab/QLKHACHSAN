namespace QLKHACHSAN.UI
{
    partial class ThongKeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbBoLoc = new System.Windows.Forms.GroupBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiBieuDo = new System.Windows.Forms.Label();
            this.cbLoaiBieuDo = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.grbBieuDo = new System.Windows.Forms.GroupBox();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grbBangThongKe = new System.Windows.Forms.GroupBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.grbTongQuan = new System.Windows.Forms.GroupBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.grbBoLoc.SuspendLayout();
            this.grbBieuDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.grbBangThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.grbTongQuan.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBoLoc
            // 
            this.grbBoLoc.Controls.Add(this.cbLoaiBieuDo);
            this.grbBoLoc.Controls.Add(this.lblLoaiBieuDo);
            this.grbBoLoc.Controls.Add(this.dtTo);
            this.grbBoLoc.Controls.Add(this.lblDenNgay);
            this.grbBoLoc.Controls.Add(this.dateTimePicker1);
            this.grbBoLoc.Controls.Add(this.lblTuNgay);
            this.grbBoLoc.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBoLoc.ForeColor = System.Drawing.Color.Blue;
            this.grbBoLoc.Location = new System.Drawing.Point(20, 20);
            this.grbBoLoc.Name = "grbBoLoc";
            this.grbBoLoc.Size = new System.Drawing.Size(1140, 100);
            this.grbBoLoc.TabIndex = 0;
            this.grbBoLoc.TabStop = false;
            this.grbBoLoc.Text = "Bộ lọc thống kê";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(30, 40);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(59, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(180, 25);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(320, 40);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(68, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày :";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(390, 35);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(180, 25);
            this.dtTo.TabIndex = 3;
            // 
            // lblLoaiBieuDo
            // 
            this.lblLoaiBieuDo.AutoSize = true;
            this.lblLoaiBieuDo.Location = new System.Drawing.Point(610, 40);
            this.lblLoaiBieuDo.Name = "lblLoaiBieuDo";
            this.lblLoaiBieuDo.Size = new System.Drawing.Size(59, 20);
            this.lblLoaiBieuDo.TabIndex = 1;
            this.lblLoaiBieuDo.Text = "Biểu đồ:";
            // 
            // cbLoaiBieuDo
            // 
            this.cbLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBieuDo.FormattingEnabled = true;
            this.cbLoaiBieuDo.Location = new System.Drawing.Point(680, 35);
            this.cbLoaiBieuDo.Name = "cbLoaiBieuDo";
            this.cbLoaiBieuDo.Size = new System.Drawing.Size(180, 28);
            this.cbLoaiBieuDo.TabIndex = 1;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(920, 32);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(150, 35);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // grbBieuDo
            // 
            this.grbBieuDo.Controls.Add(this.chartThongKe);
            this.grbBieuDo.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBieuDo.ForeColor = System.Drawing.Color.Blue;
            this.grbBieuDo.Location = new System.Drawing.Point(20, 140);
            this.grbBieuDo.Name = "grbBieuDo";
            this.grbBieuDo.Size = new System.Drawing.Size(650, 430);
            this.grbBieuDo.TabIndex = 5;
            this.grbBieuDo.TabStop = false;
            this.grbBieuDo.Text = "Biểu đồ thống kê";
            // 
            // chartThongKe
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Location = new System.Drawing.Point(20, 30);
            this.chartThongKe.Name = "chartThongKe";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThongKe.Series.Add(series1);
            this.chartThongKe.Size = new System.Drawing.Size(610, 380);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "chart1";
            // 
            // grbBangThongKe
            // 
            this.grbBangThongKe.Controls.Add(this.dgvThongKe);
            this.grbBangThongKe.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBangThongKe.ForeColor = System.Drawing.Color.Blue;
            this.grbBangThongKe.Location = new System.Drawing.Point(690, 140);
            this.grbBangThongKe.Name = "grbBangThongKe";
            this.grbBangThongKe.Size = new System.Drawing.Size(470, 430);
            this.grbBangThongKe.TabIndex = 6;
            this.grbBangThongKe.TabStop = false;
            this.grbBangThongKe.Text = "Dữ liệu thống kê";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(15, 30);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(440, 380);
            this.dgvThongKe.TabIndex = 7;
            // 
            // grbTongQuan
            // 
            this.grbTongQuan.Controls.Add(this.txtTongDoanhThu);
            this.grbTongQuan.Controls.Add(this.lblTongDoanhThu);
            this.grbTongQuan.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTongQuan.ForeColor = System.Drawing.Color.Blue;
            this.grbTongQuan.Location = new System.Drawing.Point(20, 590);
            this.grbTongQuan.Name = "grbTongQuan";
            this.grbTongQuan.Size = new System.Drawing.Size(1140, 70);
            this.grbTongQuan.TabIndex = 8;
            this.grbTongQuan.TabStop = false;
            this.grbTongQuan.Tag = "";
            this.grbTongQuan.Text = "Tổng quan";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(66, 38);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(111, 20);
            this.lblTongDoanhThu.TabIndex = 9;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Location = new System.Drawing.Point(183, 35);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(220, 27);
            this.txtTongDoanhThu.TabIndex = 10;
            this.txtTongDoanhThu.Text = "0";
            // 
            // ThongKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 719);
            this.Controls.Add(this.grbTongQuan);
            this.Controls.Add(this.grbBangThongKe);
            this.Controls.Add(this.grbBieuDo);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.grbBoLoc);
            this.Location = new System.Drawing.Point(30, 40);
            this.Name = "ThongKeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThongKeForm";
            this.grbBoLoc.ResumeLayout(false);
            this.grbBoLoc.PerformLayout();
            this.grbBieuDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.grbBangThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.grbTongQuan.ResumeLayout(false);
            this.grbTongQuan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBoLoc;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblLoaiBieuDo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.ComboBox cbLoaiBieuDo;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.GroupBox grbBieuDo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.GroupBox grbBangThongKe;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.GroupBox grbTongQuan;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
    }
}