using DiplomUchetSC.Context;
using DiplomUchetSC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomUchetSC.Views.Pages.MainPages.OrdersPages
{
    public partial class IssuedOrdersPage : Page
    {
        private List<Order> orders;
        public IssuedOrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {

            using (var db = new ApplicationContext())
            {
                orders = db.Orders
                    .Include(o => o.Client)
                    .Include(o => o.DeviceType)
                    .Include(o => o.Brand)
                    .Where(o => o.Issued_at != null && o.OrderStatus == Enums.OrderStatus.ISSUED)
                    .ToList();
            }

            IssuedOrdersDataGrid.ItemsSource = orders;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (orders == null) return;

            var searchText = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                IssuedOrdersDataGrid.ItemsSource = orders;
                return;
            }

            var filterOrders = orders.Where(o => (o.Client?.Full_name?.ToLower()?.Contains(searchText) ?? false) ||
                (o.Client?.Number_phone?.ToLower()?.Contains(searchText) ?? false) ||
                (o.Id.ToString().Contains(searchText)))
                .ToList();
            IssuedOrdersDataGrid.ItemsSource = filterOrders;
        }

        private void IssuedOrdersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) return;

            var selectedOrder = row.Item as Order;

            if (selectedOrder != null)
            {
                NavigationService.Navigate(new EditOrderPage(selectedOrder));
            }
        }

    }
}
