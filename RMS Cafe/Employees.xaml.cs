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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        public ObservableCollection<EmployeeModel> StaffMembers { get; set; }

        public Employees()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            StaffMembers = new ObservableCollection<EmployeeModel>
            {
                new EmployeeModel { EmployeeID = "EMP-001", FullName = "Admin User", Role = "Administrator", ContactNumber = "082 123 4567", BalanceAmount = 0, TabLimit = 1000.00m, Status = "Active" },
            new EmployeeModel { EmployeeID = "EMP-002", FullName = "John D.", Role = "Manager", ContactNumber = "083 234 5678", BalanceAmount = 450.00m, TabLimit = 500.00m, Status = "Active" },
            new EmployeeModel { EmployeeID = "EMP-003", FullName = "Sipho M.", Role = "Barista", ContactNumber = "071 345 6789", BalanceAmount = 180.50m, TabLimit = 250.00m, Status = "Active" },
            new EmployeeModel { EmployeeID = "EMP-004", FullName = "Thabo K.", Role = "Cashier", ContactNumber = "072 456 7890", BalanceAmount = 0, TabLimit = 200.00m, Status = "Active" },
            new EmployeeModel { EmployeeID = "EMP-005", FullName = "Lebo P.", Role = "Server", ContactNumber = "084 567 8901", BalanceAmount = 65.00m, TabLimit = 150.00m, Status = "Active" }
            };

            EmployeesGrid.ItemsSource = StaffMembers;
        }

        // ==========================================
        // SIDEBAR NAVIGATION EVENTS
        // ==========================================
        private void NavDashboard_Click(object sender, RoutedEventArgs e) { /* Navigate to Dashboard */ }
        private void NavPOS_Click(object sender, RoutedEventArgs e) { /* Navigate to POS */ }
        private void NavInventory_Click(object sender, RoutedEventArgs e) { /* Navigate to Inventory */ }
        private void NavReports_Click(object sender, RoutedEventArgs e) { /* Navigate to Reports */ }
        private void NavPayroll_Click(object sender, RoutedEventArgs e) { /* Navigate to Payroll */ }
        private void NavAuditLogs_Click(object sender, RoutedEventArgs e) { /* Navigate to Audit Logs */ }
        private void NavSettings_Click(object sender, RoutedEventArgs e) { /* Navigate to Settings */ }

        // ==========================================
        // EMPLOYEE ACTIONS
        // ==========================================
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Open "Add Employee" registration modal
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var emp = (sender as FrameworkElement)?.DataContext as EmployeeModel;
            if (emp != null)
            {
                // TODO: Open "Edit Employee" modal pre-filled with data
                MessageBox.Show($"Editing Profile: {emp.FullName}");
            }
        }

        private void BtnSettleTab_Click(object sender, RoutedEventArgs e)
        {
            var emp = (sender as FrameworkElement)?.DataContext as EmployeeModel;
            if (emp != null && emp.BalanceAmount > 0)
            {
                // TODO: Open payment modal to clear employee's credit balance
                MessageBox.Show($"Settle Tab for {emp.FullName}. Amount due: {emp.TabBalance}");
            }
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var emp = (sender as FrameworkElement)?.DataContext as EmployeeModel;
            if (emp != null)
            {
                // TODO: Prompt for confirmation, then deactivate/delete from DB
                MessageBox.Show($"Deactivate account requested for: {emp.FullName}");
            }
        }
    }
    public class EmployeeModel
    {
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string ContactNumber { get; set; }
        public decimal BalanceAmount { get; set; }

        public decimal TabLimit { get; set; }

        public string Status { get; set; }

        // Formats the decimal as currency for the UI
        public string TabBalance => BalanceAmount == 0 ? "R0.00" : $"R{BalanceAmount:0.00}";

        public string FormattedTabLimit => $"R{TabLimit:0.00}";

        // Turns the text red if they owe money, gray if they don't
        public string BalanceColor => BalanceAmount > 0 ? "#E74C3C" : "#888888";
    }
}
