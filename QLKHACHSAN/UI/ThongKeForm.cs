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
        private const string Caption = "Lỗi";
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

                System.Diagnostics.Debug.WriteLine($"Loading statistics from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");

                // Load data based on selected chart type
                string chartType = cbLoaiBieuDo.SelectedItem?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"Selected chart type: {chartType}");

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
                System.Diagnostics.Debug.WriteLine($"Error loading statistics: {ex.Message}\n{ex.StackTrace}");
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
                System.Diagnostics.Debug.WriteLine("Loading revenue by date...");

                // Get aggregated data for chart
                DataTable dtChart = bll.GetRevenueByDateRange(fromDate, toDate);
                System.Diagnostics.Debug.WriteLine($"Aggregated revenue data rows: {dtChart?.Rows.Count ?? 0}");

                // Get detailed data for grid
                DataTable dtGrid = bll.GetAllDetailedTransactions(fromDate, toDate);
                System.Diagnostics.Debug.WriteLine($"Detailed transaction data rows: {dtGrid?.Rows.Count ?? 0}");

                if (dtGrid != null && dtGrid.Rows.Count > 0)
                {
                    // Bind detailed data to DataGridView
                    dgvThongKe.DataSource = dtGrid;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    System.Diagnostics.Debug.WriteLine("DataGridView populated successfully with detailed data");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No detailed data returned");
                    dgvThongKe.DataSource = null;
                }

                // Use aggregated data for chart if available
                if (dtChart != null && dtChart.Rows.Count > 0)
                {
                    PopulateChart(dtChart, "NgayThanhToan", "DoanhThu", "Doanh thu theo ngày", SeriesChartType.Column);
                    System.Diagnostics.Debug.WriteLine("Chart populated successfully");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No aggregated data for chart");
                    chartThongKe.Series.Clear();
                    chartThongKe.Titles.Clear();
                }

                if (dtGrid == null || dtGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading revenue by date: {ex.Message}\n{ex.StackTrace}");
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
                System.Diagnostics.Debug.WriteLine("Loading revenue by service...");

                // Get aggregated data for chart
                DataTable dtChart = bll.GetRevenueByService(fromDate, toDate);
                System.Diagnostics.Debug.WriteLine($"Service data rows: {dtChart?.Rows.Count ?? 0}");

                // Get detailed data for grid
                DataTable dtGrid = bll.GetAllDetailedTransactions(fromDate, toDate);
                System.Diagnostics.Debug.WriteLine($"Detailed transaction data rows: {dtGrid?.Rows.Count ?? 0}");

                if (dtGrid != null && dtGrid.Rows.Count > 0)
                {
                    // Bind detailed data to DataGridView
                    dgvThongKe.DataSource = dtGrid;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    dgvThongKe.DataSource = null;
                }

                // Use aggregated data for chart if available
                if (dtChart != null && dtChart.Rows.Count > 0)
                {
                    PopulateChart(dtChart, "TenDichVu", "DoanhThu", "Doanh thu theo dịch vụ", SeriesChartType.Pie);
                }
                else
                {
                    chartThongKe.Series.Clear();
                    chartThongKe.Titles.Clear();
                }

                if (dtGrid == null || dtGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading revenue by service: {ex.Message}\n{ex.StackTrace}");
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
                System.Diagnostics.Debug.WriteLine("Loading customer statistics...");

                // Get aggregated data for chart
                DataTable dtChart = bll.GetServiceUsageByCustomer(fromDate, toDate);
                System.Diagnostics.Debug.WriteLine($"Customer data rows: {dtChart?.Rows.Count ?? 0}");

                // Get detailed data for grid
                DataTable dtGrid = bll.GetDetailedCustomerTransactions(fromDate, toDate);
                System.Diagnostics.Debug.WriteLine($"Detailed customer transaction data rows: {dtGrid?.Rows.Count ?? 0}");

                if (dtGrid != null && dtGrid.Rows.Count > 0)
                {
                    // Bind detailed data to DataGridView
                    dgvThongKe.DataSource = dtGrid;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    dgvThongKe.DataSource = null;
                }

                // Use aggregated data for chart if available
                if (dtChart != null && dtChart.Rows.Count > 0)
                {
                    PopulateChart(dtChart, "KhachHang", "TongChiTieu", "Khách hàng chi tiêu nhiều nhất", SeriesChartType.Column);
                }
                else
                {
                    chartThongKe.Series.Clear();
                    chartThongKe.Titles.Clear();
                }

                if (dtGrid == null || dtGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading customer statistics: {ex.Message}\n{ex.StackTrace}");
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
                System.Diagnostics.Debug.WriteLine("Loading monthly revenue...");
                int currentYear = DateTime.Now.Year;

                // Get aggregated data for chart
                DataTable dtChart = bll.GetMonthlyRevenue(currentYear);
                System.Diagnostics.Debug.WriteLine($"Monthly data rows: {dtChart?.Rows.Count ?? 0}");

                // Get detailed data for grid
                DataTable dtGrid = bll.GetDetailedYearlyTransactions(currentYear);
                System.Diagnostics.Debug.WriteLine($"Detailed yearly transaction data rows: {dtGrid?.Rows.Count ?? 0}");

                if (dtGrid != null && dtGrid.Rows.Count > 0)
                {
                    // Bind detailed data to DataGridView
                    dgvThongKe.DataSource = dtGrid;
                    dgvThongKe.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    dgvThongKe.DataSource = null;
                }

                // Use aggregated data for chart if available
                if (dtChart != null && dtChart.Rows.Count > 0)
                {
                    PopulateChart(dtChart, "Thang", "DoanhThu", "Doanh thu năm " + currentYear, SeriesChartType.Line);
                }
                else
                {
                    chartThongKe.Series.Clear();
                    chartThongKe.Titles.Clear();
                }

                if (dtGrid == null || dtGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thống kê cho năm này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading monthly revenue: {ex.Message}\n{ex.StackTrace}");
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

                chartThongKe.Series.Clear();
                chartThongKe.Titles.Clear();

                chartThongKe.BackColor = Color.White;
                chartThongKe.BorderlineColor = Color.Gainsboro;
                chartThongKe.BorderlineDashStyle = ChartDashStyle.Solid;
                chartThongKe.BorderlineWidth = 1;

                if (chartThongKe.ChartAreas.Count > 0)
                {
                    ChartArea area = chartThongKe.ChartAreas[0];

                    area.BackColor = Color.White;

                    area.AxisX.Interval = 1;
                    area.AxisX.LabelStyle.Angle = 0;
                    area.AxisX.LabelStyle.ForeColor = Color.DimGray;
                    area.AxisX.MajorGrid.Enabled = false;

                    area.AxisY.LabelStyle.Format = "#,##0";
                    area.AxisY.LabelStyle.ForeColor = Color.DimGray;
                    area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
                    area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
                }

                Series series = new Series(title);
                series.ChartType = chartType;
                series.IsValueShownAsLabel = true;
                series.LabelForeColor = Color.DimGray;
                series.ToolTip = "#VALX: #VALY";

                if (chartType == SeriesChartType.Column)
                {
                    series.Color = Color.MediumSeaGreen;
                    series.LabelFormat = "#,##0";
                    series["PointWidth"] = "0.45";
                }
                else if (chartType == SeriesChartType.Line)
                {
                    series.Color = Color.OrangeRed;
                    series.BorderWidth = 3;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.MarkerSize = 7;
                    series.LabelFormat = "#,##0";
                }
                else if (chartType == SeriesChartType.Pie)
                {
                    series.Label = "#PERCENT{P0}";
                    series.LegendText = "#VALX";
                    series.ToolTip = "#VALX: #VALY";
                }

                foreach (DataRow row in dt.Rows)
                {
                    string xValue = row[xAxisColumn]?.ToString() ?? "N/A";

                    DateTime ngay;
                    if (DateTime.TryParse(xValue, out ngay))
                    {
                        xValue = ngay.ToString("dd/MM");
                    }

                    double yValue = 0;
                    object yObj = row[yAxisColumn];

                    if (yObj != null && yObj != DBNull.Value)
                    {
                        yValue = Convert.ToDouble(yObj);
                    }

                    series.Points.AddXY(xValue, yValue);
                }

                chartThongKe.Series.Add(series);

                chartThongKe.Legends.Clear();
                Legend legend = new Legend();
                legend.Docking = Docking.Bottom;
                legend.Alignment = StringAlignment.Center;
                legend.BackColor = Color.Transparent;
                chartThongKe.Legends.Add(legend);

                Title chartTitle = new Title();
                chartTitle.Text = title;
                chartTitle.Font = new Font("Arial", 12, FontStyle.Bold);
                chartTitle.ForeColor = Color.Black;
                chartThongKe.Titles.Add(chartTitle);

                chartThongKe.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ: " + ex.Message, Caption,
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

        private void chartThongKe_Click(object sender, EventArgs e)
        {

        }
    }
}

