using DiplomUchetSC.Context;
using DiplomUchetSC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DiplomUchetSC.Enums;
using System.Windows;
using System.Windows.Data;


namespace DiplomUchetSC.Views.Pages.MainPages.OrdersPages
{
    public partial class CurrentOrdersPage : Page
    {
        private List<Order> orders;

        public CurrentOrdersPage()
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
                    .Where(o => o.OrderStatus != OrderStatus.ISSUED)
                    .ToList();
            }


            CurrentOrdersDataGrid.ItemsSource = orders;


        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (orders == null) return;

            var searchText = SearchTextBox.Text.Trim().ToLower();

            if(string.IsNullOrEmpty(searchText))
            {
                CurrentOrdersDataGrid.ItemsSource = orders;
                return;
            }

            var filterOrders = orders.Where(o => (o.Client?.Full_name?.ToLower()?.Contains(searchText) ?? false) ||
                (o.Client?.Number_phone?.ToLower()?.Contains(searchText) ?? false) ||
                (o.Id.ToString().Contains(searchText)))
                .ToList();
            CurrentOrdersDataGrid.ItemsSource = filterOrders;
        }

        private void CurrentOrdersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) return;

            var selectedOrder = row.Item as Order;

            if (selectedOrder != null)
            {
                NavigationService.Navigate(new EditOrderPage(selectedOrder));
            }
        }

        private void Guarantee_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Final_CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}