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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        public ObservableCollection<InventoryItemModel> InventoryItems { get; set; }

        public Inventory()
        {
            InitializeComponent();
            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            InventoryItems = new ObservableCollection<InventoryItemModel>
            {
                new InventoryItemModel { SKU = "CF-100", Name = "Americano Beans (500g)", Category = "Ingredients", StockQuantity = 3, UnitCost = "R120.00", RetailPrice = "N/A" },
                new InventoryItemModel { SKU = "MK-200", Name = "Milk Full Cream (1L)", Category = "Ingredients", StockQuantity = 5, UnitCost = "R18.00", RetailPrice = "N/A" },
                new InventoryItemModel { SKU = "BK-101", Name = "Croissant", Category = "Food", StockQuantity = 45, UnitCost = "R8.00", RetailPrice = "R18.00" },
                new InventoryItemModel { SKU = "BK-102", Name = "Cheesecake Slice", Category = "Food", StockQuantity = 12, UnitCost = "R15.00", RetailPrice = "R35.00" },
                new InventoryItemModel { SKU = "SY-300", Name = "Vanilla Syrup (750ml)", Category = "Ingredients", StockQuantity = 22, UnitCost = "R85.00", RetailPrice = "N/A" },
                new InventoryItemModel { SKU = "PK-500", Name = "Takeaway Cups (Medium)", Category = "Packaging", StockQuantity = 450, UnitCost = "R1.50", RetailPrice = "N/A" }
            };

            InventoryGrid.ItemsSource = InventoryItems;
        }

        // ==========================================
        // SIDEBAR NAVIGATION EVENTS
        // ==========================================
        private void NavDashboard_Click(object sender, RoutedEventArgs e) { /* Navigate to Dashboard */ }
        private void NavPOS_Click(object sender, RoutedEventArgs e) { /* Navigate to POS */ }
        private void NavEmployees_Click(object sender, RoutedEventArgs e) { /* Navigate to Employees */ }
        private void NavReports_Click(object sender, RoutedEventArgs e) { /* Navigate to Reports */ }
        private void NavPayroll_Click(object sender, RoutedEventArgs e) { /* Navigate to Payroll */ }
        private void NavAuditLogs_Click(object sender, RoutedEventArgs e) { /* Navigate to Audit Logs */ }
        private void NavSettings_Click(object sender, RoutedEventArgs e) { /* Navigate to Settings */ }

        // ==========================================
        // INVENTORY ACTIONS
        // ==========================================
        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Open "Add Product" modal or page
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Generate and save CSV of current inventory grid
        }

        private void BtnEditItem_Click(object sender, RoutedEventArgs e)
        {
            // Get the item that was clicked
            var item = (sender as FrameworkElement)?.DataContext as InventoryItemModel;
            if (item != null)
            {
                // TODO: Open "Edit Product" modal pre-filled with item data
                MessageBox.Show($"Editing: {item.Name}");
            }
        }

        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as InventoryItemModel;
            if (item != null)
            {
                // TODO: Prompt for confirmation, then delete from database and collection
                MessageBox.Show($"Delete requested for: {item.Name}");
            }
        }
    }
    public class InventoryItemModel
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }
        public string UnitCost { get; set; }
        public string RetailPrice { get; set; }

        // Dynamic logic for the UI
        public string Status => StockQuantity <= 5 ? "Low Stock" : "In Stock";

        // Returns a Hex color string based on stock level. 
        // Red for low stock, green for healthy stock.
        public string StatusColor => StockQuantity <= 5 ? "#E74C3C" : "#27AE60";
    }
}
