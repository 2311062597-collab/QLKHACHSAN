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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbBoLoc = new System.Windows.Forms.GroupBox();
            this.cbLoaiBieuDo = new System.Windows.Forms.ComboBox();
            this.lblLoaiBieuDo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnThongKe = new System.Windows.Forms.Button();
            this.grbBieuDo = new System.Windows.Forms.GroupBox();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grbBangThongKe = new System.Windows.Forms.GroupBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.grbTongQuan = new System.Windows.Forms.GroupBox();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
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
            this.grbBoLoc.Location = new System.Drawing.Point(2, 16);
            this.grbBoLoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBoLoc.Name = "grbBoLoc";
            this.grbBoLoc.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBoLoc.Size = new System.Drawing.Size(974, 81);
            this.grbBoLoc.TabIndex = 0;
            this.grbBoLoc.TabStop = false;
            this.grbBoLoc.Text = "Bộ lọc thống kê";
            // 
            // cbLoaiBieuDo
            // 
            this.cbLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiBieuDo.FormattingEnabled = true;
            this.cbLoaiBieuDo.Location = new System.Drawing.Point(520, 28);
            this.cbLoaiBieuDo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbLoaiBieuDo.Name = "cbLoaiBieuDo";
            this.cbLoaiBieuDo.Size = new System.Drawing.Size(136, 28);
            this.cbLoaiBieuDo.TabIndex = 1;
            // 
            // lblLoaiBieuDo
            // 
            this.lblLoaiBieuDo.AutoSize = true;
            this.lblLoaiBieuDo.Location = new System.Drawing.Point(458, 32);
            this.lblLoaiBieuDo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoaiBieuDo.Name = "lblLoaiBieuDo";
            this.lblLoaiBieuDo.Size = new System.Drawing.Size(59, 20);
            this.lblLoaiBieuDo.TabIndex = 1;
            this.lblLoaiBieuDo.Text = "Biểu đồ:";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(310, 28);
            this.dtTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(136, 25);
            this.dtTo.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(240, 32);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(68, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(85, 29);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 25);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(22, 32);
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(59, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày :";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(690, 26);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(112, 28);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // grbBieuDo
            // 
            this.grbBieuDo.Controls.Add(this.chartThongKe);
            this.grbBieuDo.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBieuDo.ForeColor = System.Drawing.Color.Blue;
            this.grbBieuDo.Location = new System.Drawing.Point(2, 110);
            this.grbBieuDo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBieuDo.Name = "grbBieuDo";
            this.grbBieuDo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBieuDo.Size = new System.Drawing.Size(466, 349);
            this.grbBieuDo.TabIndex = 5;
            this.grbBieuDo.TabStop = false;
            this.grbBieuDo.Text = "Biểu đồ thống kê";
            // 
            // chartThongKe
            // 
            this.chartThongKe.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chartThongKe.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Location = new System.Drawing.Point(4, 31);
            this.chartThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartThongKe.Name = "chartThongKe";
            series1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DashedDownwardDiagonal;
            series1.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series1.BorderColor = System.Drawing.Color.Red;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.DimGray;
            series1.LabelFormat = "#,##0";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            series1.YValuesPerPoint = 6;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            series2.IsXValueIndexed = true;
            series2.LabelForeColor = System.Drawing.Color.DimGray;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series2.MarkerSize = 7;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series2";
            series2.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartThongKe.Series.Add(series1);
            this.chartThongKe.Series.Add(series2);
            this.chartThongKe.Size = new System.Drawing.Size(442, 211);
            this.chartThongKe.TabIndex = 0;
            this.chartThongKe.Text = "chart1";
            this.chartThongKe.Click += new System.EventHandler(this.chartThongKe_Click);
            // 
            // grbBangThongKe
            // 
            this.grbBangThongKe.Controls.Add(this.dgvThongKe);
            this.grbBangThongKe.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBangThongKe.ForeColor = System.Drawing.Color.Blue;
            this.grbBangThongKe.Location = new System.Drawing.Point(472, 102);
            this.grbBangThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBangThongKe.Name = "grbBangThongKe";
            this.grbBangThongKe.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbBangThongKe.Size = new System.Drawing.Size(874, 349);
            this.grbBangThongKe.TabIndex = 6;
            this.grbBangThongKe.TabStop = false;
            this.grbBangThongKe.Text = "Dữ liệu thống kê";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(4, 24);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(866, 320);
            this.dgvThongKe.TabIndex = 7;
            // 
            // grbTongQuan
            // 
            this.grbTongQuan.Controls.Add(this.txtTongDoanhThu);
            this.grbTongQuan.Controls.Add(this.lblTongDoanhThu);
            this.grbTongQuan.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTongQuan.ForeColor = System.Drawing.Color.Blue;
            this.grbTongQuan.Location = new System.Drawing.Point(2, 463);
            this.grbTongQuan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbTongQuan.Name = "grbTongQuan";
            this.grbTongQuan.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbTongQuan.Size = new System.Drawing.Size(855, 57);
            this.grbTongQuan.TabIndex = 8;
            this.grbTongQuan.TabStop = false;
            this.grbTongQuan.Tag = "";
            this.grbTongQuan.Text = "Tổng quan";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Location = new System.Drawing.Point(170, 28);
            this.txtTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(166, 27);
            this.txtTongDoanhThu.TabIndex = 10;
            this.txtTongDoanhThu.Text = "0";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(50, 31);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(111, 20);
            this.lblTongDoanhThu.TabIndex = 9;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // ThongKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLKHACHSAN.Properties.Resources.anh_moi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 691);
            this.Controls.Add(this.grbTongQuan);
            this.Controls.Add(this.grbBangThongKe);
            this.Controls.Add(this.grbBieuDo);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.grbBoLoc);
            this.Location = new System.Drawing.Point(30, 40);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ThongKeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThongKeForm";
            this.Load += new System.EventHandler(this.ThongKeForm_Load);
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