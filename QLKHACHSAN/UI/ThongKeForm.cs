using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class ThongKeForm : Form
    {
        private ThongKeBLL bll = new ThongKeBLL();

        public ThongKeForm()
        {
            InitializeComponent();
        }

        private void ThongKeForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        /// <summary>
        /// Initialize form controls and data
        /// </summary>
        private void InitializeForm()
        {
            try
            {
                // Set default dates (current month)
                dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtTo.Value = DateTime.Now;

                // Load chart type options
                LoadChartTypeOptions();

                // Wire up event handlers
                btnThongKe.Click += BtnThongKe_Click;

                // Load initial statistics
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load chart type options into combo box
        /// </summary>
        private void LoadChartTypeOptions()
        {
            cbLoaiBieuDo.Items.Clear();
            cbLoaiBieuDo.Items.Add("Doanh thu theo ngày");
            cbLoaiBieuDo.Items.Add("Doanh thu theo dịch vụ");
            cbLoaiBieuDo.Items.Add("Khách hàng chi tiêu nhiều nhất");
            cbLoaiBieuDo.Items.Add("Doanh thu theo tháng");
            cbLoaiBieuDo.SelectedIndex = 0;
        }

        /// <summary>
        /// Handle Statistics button click
        /// </summary>
        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        /// <summary>
        /// Load and display statistics based on selected filters
        /// </summary>
        private void LoadStatistics()
        {
            try
            {
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dtTo.Value.Date;

                // Load data based on selected chart type
                string chartType = cbLoaiBieuDo.SelectedItem?.ToString() ?? "";

                switch (chartType)
                {
                    case "Doanh thu theo ngày":
                        LoadRevenueByDate(fromDate, toDate);
                        break;
                    case "Doanh thu theo dịch vụ":
                        LoadRevenueByService(fromDate, toDate);
                        break;
                    case "Khách hàng chi tiêu nhiều nhất":
                        LoadCustomerStatistics(fromDate, toDate);
                        break;
                    case "Doanh thu theo tháng":
                        LoadMonthlyRevenue();
                        break;
                    default:
                        LoadRevenueByDate(fromDate, toDate);
                        break;
                }

                // Display total revenue
                DisplayTotalRevenue(fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load revenue by date chart and grid
        /// </summary>
        private void LoadRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = bll.GetRevenueByDateRange(fromDate, toDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Bind to DataGridView
                dgvThongKe.DataSource = dt;
                dgvThongKe.AutoResizeColumns();

                // Bind to Chart
                PopulateChart(dt, "NgayThanhToan", "DoanhThu", "Doanh thu theo ngày", SeriesChartType.Column);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvThongKe.DataSource = null;
                chartThongKe.Series.Clear();
            }
        }

        /// <summary>
        /// Load revenue by service chart and grid
        /// </summary>
        private void LoadRevenueByService(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = bll.GetRevenueByService(fromDate, toDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Bind to DataGridView
                dgvThongKe.DataSource = dt;
                dgvThongKe.AutoResizeColumns();

                // Bind to Chart
                PopulateChart(dt, "TenDichVu", "DoanhThu", "Doanh thu theo dịch vụ", SeriesChartType.Pie);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvThongKe.DataSource = null;
                chartThongKe.Series.Clear();
            }
        }

        /// <summary>
        /// Load customer statistics
        /// </summary>
        private void LoadCustomerStatistics(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = bll.GetServiceUsageByCustomer(fromDate, toDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Bind to DataGridView
                dgvThongKe.DataSource = dt;
                dgvThongKe.AutoResizeColumns();

                // Bind to Chart
                PopulateChart(dt, "KhachHang", "TongChiTieu", "Khách hàng chi tiêu nhiều nhất", SeriesChartType.Column);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvThongKe.DataSource = null;
                chartThongKe.Series.Clear();
            }
        }

        /// <summary>
        /// Load monthly revenue statistics
        /// </summary>
        private void LoadMonthlyRevenue()
        {
            int currentYear = DateTime.Now.Year;
            DataTable dt = bll.GetMonthlyRevenue(currentYear);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Add month names
                DataTable displayTable = dt.Clone();
                displayTable.Columns.Add("ThangTen");
                displayTable.Columns["ThangTen"].SetOrdinal(0);

                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = displayTable.NewRow();
                    int month = Convert.ToInt32(row["Thang"]);
                    newRow["ThangTen"] = bll.GetMonthName(month);
                    newRow["Thang"] = row["Thang"];
                    newRow["DoanhThu"] = row["DoanhThu"];
                    displayTable.Rows.Add(newRow);
                }

                // Bind to DataGridView
                dgvThongKe.DataSource = displayTable;
                dgvThongKe.AutoResizeColumns();

                // Bind to Chart
                PopulateChart(dt, "Thang", "DoanhThu", "Doanh thu năm " + currentYear, SeriesChartType.Line);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê cho năm này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvThongKe.DataSource = null;
                chartThongKe.Series.Clear();
            }
        }

        /// <summary>
        /// Populate chart with data
        /// </summary>
        private void PopulateChart(DataTable dt, string xAxisColumn, string yAxisColumn, string title, SeriesChartType chartType)
        {
            try
            {
                chartThongKe.Series.Clear();
                chartThongKe.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                Series series = new Series("Series1");
                series.ChartType = chartType;

                foreach (DataRow row in dt.Rows)
                {
                    string xValue = row[xAxisColumn].ToString();
                    double yValue = Convert.ToDouble(row[yAxisColumn]);
                    series.Points.AddXY(xValue, yValue);
                }

                chartThongKe.Series.Add(series);
                chartThongKe.Titles.Clear();
                chartThongKe.Titles.Add(title);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Display total revenue
        /// </summary>
        private void DisplayTotalRevenue(DateTime fromDate, DateTime toDate)
        {
            try
            {
                decimal totalRevenue = bll.GetTotalRevenue(fromDate, toDate);
                string formattedRevenue = bll.FormatCurrency(totalRevenue);
                lblTongDoanhThu.Text = "Tổng doanh thu: " + formattedRevenue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng doanh thu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle chart type selection change
        /// </summary>
        private void CbLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        /// <summary>
        /// Add event handler in designer
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbLoaiBieuDo.SelectedIndexChanged += CbLoaiBieuDo_SelectedIndexChanged;
        }
    }
}
