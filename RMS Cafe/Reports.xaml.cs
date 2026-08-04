using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RMS_Cafe
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        // Data collections for each report type
        public ObservableCollection<IncomeReportModel> IncomeData { get; set; }
        public ObservableCollection<InventoryStatModel> InventoryData { get; set; }
        public ObservableCollection<EmployeeOwedModel> EmployeesOwedData { get; set; }

        public Reports()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            // 1. Load Income Data
            IncomeData = new ObservableCollection<IncomeReportModel>
            {
                new IncomeReportModel { Date = "25 Jun 2026", GrossSales = "R16,457.00", Discounts = "R450.00", NetSales = "R16,007.00", Tax = "R2,401.05" },
                new IncomeReportModel { Date = "24 Jun 2026", GrossSales = "R14,600.50", Discounts = "R320.00", NetSales = "R14,280.50", Tax = "R2,142.07" }
            };
            IncomeGrid.ItemsSource = IncomeData;

            // 2. Load Inventory Stats Data
            InventoryData = new ObservableCollection<InventoryStatModel>
            {
                new InventoryStatModel { ItemName = "Cappuccino (Large)", TotalSold = 145, CurrentStock = 300, NeedsRestock = "No" },
                new InventoryStatModel { ItemName = "Milk Full Cream (1L)", TotalSold = 42, CurrentStock = 4, NeedsRestock = "Yes" }
            };
            InventoryStatsGrid.ItemsSource = InventoryData;

            // 3. Load Employees Owing Data
            EmployeesOwedData = new ObservableCollection<EmployeeOwedModel>
            {
                new EmployeeOwedModel { EmpName = "John D.", Role = "Manager", OwedAmount = "R450.00", LastUpdate = "25 Jun 2026" },
                new EmployeeOwedModel { EmpName = "Sipho M.", Role = "Barista", OwedAmount = "R180.50", LastUpdate = "24 Jun 2026" },
                new EmployeeOwedModel { EmpName = "Lebo P.", Role = "Server", OwedAmount = "R65.00", LastUpdate = "20 Jun 2026" }
            };
            EmployeesOwingGrid.ItemsSource = EmployeesOwedData;
        }

        // ==========================================
        // REPORT SELECTION LOGIC
        // ==========================================
        private void ReportSelectionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Failsafe check during window initialization
            if (IncomeGrid == null) return;

            // Hide everything first
            IncomeGrid.Visibility = Visibility.Collapsed;
            InventoryStatsGrid.Visibility = Visibility.Collapsed;
            EmployeesOwingGrid.Visibility = Visibility.Collapsed;
            ComprehensiveMsg.Visibility = Visibility.Collapsed;

            // Find out which item was selected
            var selectedItem = (ListBoxItem)ReportSelectionBox.SelectedItem;
            string reportType = selectedItem.Content.ToString();

            // Show the relevant grid based on selection
            switch (reportType)
            {
                case "Income Generated":
                    IncomeGrid.Visibility = Visibility.Visible;
                    break;
                case "Inventory Stats":
                    InventoryStatsGrid.Visibility = Visibility.Visible;
                    break;
                case "Employees Owing":
                    EmployeesOwingGrid.Visibility = Visibility.Visible;
                    break;
                case "Comprehensive (All)":
                    ComprehensiveMsg.Visibility = Visibility.Visible;
                    break;
            }
        }

        // ==========================================
        // SIDEBAR NAVIGATION EVENTS
        // ==========================================
        private void NavDashboard_Click(object sender, RoutedEventArgs e) { /* Navigate to Dashboard */ }
        private void NavPOS_Click(object sender, RoutedEventArgs e) { /* Navigate to POS */ }
        private void NavInventory_Click(object sender, RoutedEventArgs e) { /* Navigate to Inventory */ }
        private void NavEmployees_Click(object sender, RoutedEventArgs e) { /* Navigate to Employees */ }
        private void NavPayroll_Click(object sender, RoutedEventArgs e) { /* Navigate to Payroll */ }
        private void NavAuditLogs_Click(object sender, RoutedEventArgs e) { /* Navigate to Audit Logs */ }
        private void NavSettings_Click(object sender, RoutedEventArgs e) { /* Navigate to Settings */ }

        // ==========================================
        // EXPORT ACTIONS
        // ==========================================
        private void BtnExportCsv_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exporting currently visible report to CSV...");
        }

        private void BtnExportPdf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Generating PDF document...");
        }
    }

    // ==========================================
    // DATA MODELS
    // ==========================================
    public class IncomeReportModel
    {
        public string Date { get; set; }
        public string GrossSales { get; set; }
        public string Discounts { get; set; }
        public string NetSales { get; set; }
        public string Tax { get; set; }
    }

    public class InventoryStatModel
    {
        public string ItemName { get; set; }
        public int TotalSold { get; set; }
        public int CurrentStock { get; set; }
        public string NeedsRestock { get; set; }
    }

    public class EmployeeOwedModel
    {
        public string EmpName { get; set; }
        public string Role { get; set; }
        public string OwedAmount { get; set; }
        public string LastUpdate { get; set; }
    }
}
