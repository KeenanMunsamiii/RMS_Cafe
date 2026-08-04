using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;




namespace RMS_Cafe
{
    public partial class Dashboard : Window
    {
        // Example collection for your DataGrid
        public ObservableCollection<Transaction> RecentTransactions { get; set; }

        public Dashboard()
        {
            InitializeComponent();
        

        // Load some dummy data so the layout looks like the design
        LoadDummyData();
        }

        private void LoadDummyData()
        {
            RecentTransactions = new ObservableCollection<Transaction>
            {
                new Transaction { ReceiptNo = "kzn_10247", Amount = "R85.00", Time = "10:45 AM" },
                new Transaction { ReceiptNo = "kzn_10246", Amount = "R120.00", Time = "10:32 AM" },
                new Transaction { ReceiptNo = "kzn_10245", Amount = "R42.50", Time = "10:28 AM" },
                new Transaction { ReceiptNo = "kzn_10244", Amount = "R65.00", Time = "10:15 AM" },
                new Transaction { ReceiptNo = "kzn_10243", Amount = "R150.00", Time = "09:58 AM" }
            };

            // Bind the DataGrid to this list
            //TransactionsGrid.ItemsSource = RecentTransactions;
          
        }

        // ==========================================
        // SIDEBAR NAVIGATION EVENTS
        // ==========================================

        private void NavDashboard_Click(object sender, RoutedEventArgs e)
        {
            // Already here, maybe refresh data?
        }

        private void NavPOS_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to POS Terminal
            POSTerminal p = new POSTerminal();
            this.Hide();
            p.Show();


        }

        private void NavInventory_Click(object sender, RoutedEventArgs e)
        {
           Inventory i = new Inventory();
            this.Hide();
            i.Show();
        }

        private void NavEmployees_Click(object sender, RoutedEventArgs e)
        {
            Employees em = new Employees();
            this.Hide();
            em.Show();
        }

        private void NavReports_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to Reports View
        }

        private void NavPayroll_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Handle Payroll CSV Export logic
        }

        private void NavAuditLogs_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to Audit Logs
        }

        private void NavSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to Settings View
        }

        // ==========================================
        // HEADER & ACTION EVENTS
        // ==========================================

        private void BtnNotifications_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Open notification flyout or window
        }

        private void CmbChartFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Update chart data based on selected timeframe (This Week / This Month)
        }

        private void BtnViewAllAlerts_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Open full alerts view
        }

        private void BtnViewAllTransactions_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to full transactions/receipt history view
        }

        private void BtnViewAllCredit_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to Employee Credit/Tab management view
        }
    }

    // Simple model for the DataGrid binding
    public class Transaction
    {
        public string ReceiptNo { get; set; }
        public string Amount { get; set; }
        public string Time { get; set; }
    }
}