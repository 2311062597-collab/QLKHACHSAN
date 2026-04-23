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
    /// <summary>
    /// Statistics Form - Displays various statistical reports and charts
    /// </summary>
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
                WireUpEventHandlers();

                // Load initial statistics (without showing validation messages)
                if (ValidateDateRange(dateTimePicker1.Value.Date, dtTo.Value.Date, false))
                {
                    LoadStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Wire up event handlers
        /// </summary>
        private void WireUpEventHandlers()
        {
            btnThongKe.Click += BtnThongKe_Click;
            cbLoaiBieuDo.SelectedIndexChanged += CbLoaiBieuDo_SelectedIndexChanged;
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
        /// Validate date range before processing
        /// </summary>
        private bool ValidateDateRange(DateTime fromDate, DateTime toDate, bool showMessage = true)
        {
            if (fromDate > toDate)
            {
                if (showMessage)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }

            if (toDate > DateTime.Now.Date)
            {
                if (showMessage)
                {
                    MessageBox.Show("Ngày kết thúc không được lớn hơn ngày hôm nay!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handle Statistics button click
        /// </summary>
        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        /// <summary>
        /// Handle chart type selection change
        /// </summary>
        private void CbLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
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

                // Validate date range
                if (!ValidateDateRange(fromDate, toDate))
                {
                    ClearVisualization();
                    return;
                }

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
                ClearVisualization();
            }
        }

        /// <summary>
        /// Load revenue by date chart and grid
        /// </summary>
        private void LoadRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable dt = bll.GetRevenueByDateRange(fromDate, toDate);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Bind to DataGridView
                    dgvThongKe.DataSource = dt;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    // Bind to Chart
                    PopulateChart(dt, "NgayThanhToan", "DoanhThu", "Doanh thu theo ngày", SeriesChartType.Column);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVisualization();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải doanh thu theo ngày: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearVisualization();
            }
        }

        /// <summary>
        /// Load revenue by service chart and grid
        /// </summary>
        private void LoadRevenueByService(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable dt = bll.GetRevenueByService(fromDate, toDate);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Bind to DataGridView
                    dgvThongKe.DataSource = dt;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    // Bind to Chart
                    PopulateChart(dt, "TenDichVu", "DoanhThu", "Doanh thu theo dịch vụ", SeriesChartType.Pie);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVisualization();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải doanh thu theo dịch vụ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearVisualization();
            }
        }

        /// <summary>
        /// Load customer statistics
        /// </summary>
        private void LoadCustomerStatistics(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataTable dt = bll.GetServiceUsageByCustomer(fromDate, toDate);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Bind to DataGridView
                    dgvThongKe.DataSource = dt;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    // Bind to Chart
                    PopulateChart(dt, "KhachHang", "TongChiTieu", "Khách hàng chi tiêu nhiều nhất", SeriesChartType.Column);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVisualization();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearVisualization();
            }
        }

        /// <summary>
        /// Load monthly revenue statistics
        /// </summary>
        private void LoadMonthlyRevenue()
        {
            try
            {
                int currentYear = DateTime.Now.Year;
                DataTable dt = bll.GetMonthlyRevenue(currentYear);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Add month names for display
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
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    // Bind to Chart
                    PopulateChart(dt, "Thang", "DoanhThu", "Doanh thu năm " + currentYear, SeriesChartType.Line);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu thống kê cho năm này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVisualization();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê hàng tháng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearVisualization();
            }
        }

        /// <summary>
        /// Clear visualization (grid and chart)
        /// </summary>
        private void ClearVisualization()
        {
            dgvThongKe.DataSource = null;
            chartThongKe.Series.Clear();
        }

        /// <summary>
        /// Populate chart with data
        /// </summary>
        private void PopulateChart(DataTable dt, string xAxisColumn, string yAxisColumn, string title, SeriesChartType chartType)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để vẽ biểu đồ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Clear existing series and titles
                chartThongKe.Series.Clear();
                chartThongKe.Titles.Clear();

                // Configure chart area
                if (chartThongKe.ChartAreas.Count > 0)
                {
                    chartThongKe.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    chartThongKe.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                }

                // Create new series
                Series series = new Series("Series1");
                series.ChartType = chartType;

                // Set series styling for better appearance
                if (chartType == SeriesChartType.Pie)
                {
                    series.Label = "#PERCENT";
                    series.ToolTip = "#VALX: #VALY";
                }
                else
                {
                    series.ToolTip = "#VALX: #VALY";
                }

                // Add data points to series
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        string xValue = row[xAxisColumn]?.ToString() ?? "N/A";
                        object yObj = row[yAxisColumn];
                        double yValue = 0;

                        if (yObj != null && yObj != DBNull.Value)
                        {
                            yValue = Convert.ToDouble(yObj);
                        }

                        series.Points.AddXY(xValue, yValue);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi xử lý dữ liệu: " + ex.Message);
                    }
                }

                // Add series to chart
                chartThongKe.Series.Add(series);

                // Add title
                Title chartTitle = new Title();
                chartTitle.Text = title;
                chartTitle.Font = new Font("Arial", 12, FontStyle.Bold);
                chartThongKe.Titles.Add(chartTitle);

                // Refresh chart
                chartThongKe.Refresh();
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
                txtTongDoanhThu.Text = formattedRevenue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng doanh thu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTongDoanhThu.Text = "0 đ";
            }
        }

        /// <summary>
        /// Add event handler in designer
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cbLoaiBieuDo != null)
            {
                cbLoaiBieuDo.SelectedIndexChanged += CbLoaiBieuDo_SelectedIndexChanged;
            }
        }
    }
}

