using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
    /// Interaction logic for POSTerminal.xaml
    /// </summary>
    public partial class POSTerminal : Window
    {
        public ObservableCollection<ProductModel> Products { get; set; }
        public ObservableCollection<CartItemModel> CartItems { get; set; }

        public POSTerminal()
        {
            InitializeComponent();
            this.DataContext = this;

            LoadDummyData();
        }

        // Properties bound in the Order Summary UI
        public string OrderNumber { get; set; } = "Order #kzn_10247";
        public string OrderDate { get; set; } = "25 Jun 2026, 10:17 pm";
        public string CartTotal { get; set; } = "R158.70";

        private void LoadDummyData()
        {
            // Populate the Product Grid
            Products = new ObservableCollection<ProductModel>
            {
                new ProductModel { Name = "Cappuccino", Price = "R24.00" },
                new ProductModel { Name = "Hot Chocolate", Price = "R15.00" },
                new ProductModel { Name = "Latte", Price = "R25.00" },
                new ProductModel { Name = "Espresso", Price = "R15.00" },
                new ProductModel { Name = "Iced Coffee", Price = "R28.00" },
                new ProductModel { Name = "Milkshake", Price = "R30.00" },
                new ProductModel { Name = "Cheesecake", Price = "R35.00" },
                new ProductModel { Name = "Muffin", Price = "R20.00" },
                new ProductModel { Name = "Croissant", Price = "R18.00" },
                new ProductModel { Name = "Sandwich", Price = "R35.00" },
                new ProductModel { Name = "Brownie", Price = "R20.00" },
                new ProductModel { Name = "Extra Shot", Price = "R5.00" },
                new ProductModel { Name = "Almond Milk", Price = "R6.00" },
                new ProductModel { Name = "Oat Milk", Price = "R6.00" },
                new ProductModel { Name = "Vanilla Syrup", Price = "R5.00" },
                new ProductModel { Name = "Caramel Syrup", Price = "R5.00" }
            };

            ProductGrid.ItemsSource = Products;

            // Populate the Order Cart
            CartItems = new ObservableCollection<CartItemModel>
            {
                new CartItemModel { Name = "Cappuccino", Qty = "2", UnitPrice = "R25.00", TotalPrice = "R50.00" },
                new CartItemModel { Name = "Americano", Qty = "1", UnitPrice = "R20.00", TotalPrice = "R20.00" },
                new CartItemModel { Name = "Cheesecake", Qty = "1", UnitPrice = "R35.00", TotalPrice = "R35.00" },
                new CartItemModel { Name = "Iced Coffee", Note = "Extra Shot", Qty = "1", UnitPrice = "R33.00", TotalPrice = "R33.00" }
            };

            CartGrid.ItemsSource = CartItems;
        }
        

        // ==========================================
        // SIDEBAR NAVIGATION EVENTS
        // ==========================================
        private void NavDashboard_Click(object sender, RoutedEventArgs e) { /* Navigate */ }
        private void NavInventory_Click(object sender, RoutedEventArgs e) { /* Navigate */ }
        private void NavEmployees_Click(object sender, RoutedEventArgs e) { /* Navigate */ }
        private void NavReports_Click(object sender, RoutedEventArgs e) { /* Navigate */ }
        private void NavPayroll_Click(object sender, RoutedEventArgs e) { /* Navigate */ }
        private void NavAuditLogs_Click(object sender, RoutedEventArgs e) { /* Navigate */ }
        private void NavSettings_Click(object sender, RoutedEventArgs e) { /* Navigate */ }

        // ==========================================
        // MAIN POS ACTIONS
        // ==========================================
        private void BtnViewToggle_Click(object sender, RoutedEventArgs e) { /* Toggle Grid/List view */ }
        private void BtnHoldSale_Click(object sender, RoutedEventArgs e) { /* Suspend current transaction */ }
        private void BtnMoreOptions_Click(object sender, RoutedEventArgs e) { /* Open context menu */ }

        private void BtnCustomItem_Click(object sender, RoutedEventArgs e) { /* Add unlisted item */ }
        private void BtnDiscount_Click(object sender, RoutedEventArgs e) { /* Apply order discount */ }
        private void BtnNote_Click(object sender, RoutedEventArgs e) { /* Add note to order */ }
        private void BtnClearCart_Click(object sender, RoutedEventArgs e) { /* Empty cart collection */ }

        // ==========================================
        // CART ITEMS ACTIONS
        // ==========================================
        private void BtnDecreaseQty_Click(object sender, RoutedEventArgs e) { /* Logic to decrease Qty */ }
        private void BtnIncreaseQty_Click(object sender, RoutedEventArgs e) { /* Logic to increase Qty */ }
        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e) { /* Remove specific item */ }
        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e) { /* Cancel entire order */ }

        // ==========================================
        // PAYMENT & HARDWARE ACTIONS
        // ==========================================
        private void BtnPayCash_Click(object sender, RoutedEventArgs e) { /* Set method to Cash */ }
        private void BtnPayCard_Click(object sender, RoutedEventArgs e) { /* Set method to Card */ }
        private void BtnPayMobile_Click(object sender, RoutedEventArgs e) { /* Set method to Mobile */ }
        private void BtnPay_Click(object sender, RoutedEventArgs e) { /* Finalize transaction, generate kzn_ receipt, clear cart */ }
        private void BtnOpenCashDrawer_Click(object sender, RoutedEventArgs e) { /* Send signal to printer/drawer */ }
    }

    // ==========================================
    // DATA MODELS
    // ==========================================
    public class ProductModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        // public string ImagePath { get; set; } <-- Add this when you implement real images
    }

    public class CartItemModel
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Qty { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }

        // Helper to hide the extra note block if there is no note
        public Visibility HasNote => string.IsNullOrEmpty(Note) ? Visibility.Collapsed : Visibility.Visible;
    }
}