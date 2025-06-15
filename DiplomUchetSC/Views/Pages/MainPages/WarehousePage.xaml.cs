using DiplomUchetSC.Context;
using DiplomUchetSC.Models;
using DiplomUchetSC.Views.Pages.MainPages.OrdersPages;
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

namespace DiplomUchetSC.Views.Pages.MainPages
{

    public partial class WarehousePage : Page
    {
        private List<Warehouse> warehouse;
        private Warehouse selectedWarehouse; 

        public WarehousePage()
        {
            InitializeComponent();
            LoadWarehouse();
        }

        private void LoadWarehouse()
        {
            using (var db = new ApplicationContext())
            {
                warehouse = db.Warehouse.ToList();
                WarehouseDataGrid.ItemsSource = warehouse;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SpareTBox.Text) ||
                string.IsNullOrWhiteSpace(AmountTBox.Text) ||
                string.IsNullOrEmpty(PriceTBox.Text))
            {
                MessageBox.Show("Одно или несколько полей не заполнено");
                return;
            }

            using (var db = new ApplicationContext())
            {
                if (selectedWarehouse == null)
                {
                    var newItem = new Warehouse
                    {
                        Name = SpareTBox.Text,
                        Amount = int.Parse(AmountTBox.Text),
                        Price = int.Parse(PriceTBox.Text)
                    };
                    db.Warehouse.Add(newItem);
                }
                else
                {
                    var itemToUpdate = db.Warehouse.Find(selectedWarehouse.Id);
                    if (itemToUpdate != null) 
                    {
                        itemToUpdate.Name = SpareTBox.Text;
                        itemToUpdate.Amount = int.Parse(AmountTBox.Text);
                        itemToUpdate.Price = int.Parse(PriceTBox.Text);
                    }

                }

                db.SaveChanges();
                MessageBox.Show("Сохранено");
                LoadWarehouse();
                ClearFields();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (warehouse == null) return;

            var searchText = SearchTextBox.Text.Trim().ToLower();

            WarehouseDataGrid.ItemsSource = string.IsNullOrEmpty(searchText)
                ? warehouse
                : warehouse.Where(o => o.Name?.ToLower()?.Contains(searchText) ?? false).ToList();
        }

        private void WarehouseDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) return;

            this.selectedWarehouse = row.Item as Warehouse;

            if (selectedWarehouse != null)
            {
                SpareTBox.Text = selectedWarehouse.Name;
                AmountTBox.Text = selectedWarehouse.Amount.ToString();
                PriceTBox.Text = selectedWarehouse.Price.ToString();
            }


        }
        private void ClearFields()
        {
            selectedWarehouse = null;
            SpareTBox.Clear();
            AmountTBox.Clear();
            PriceTBox.Clear();
        }

        private void ClientPhoneBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedWarehouse == null)
            {
                MessageBox.Show("Выберите запись для удаления");
                return;
            }

            if (MessageBox.Show($"Удалить запись: {selectedWarehouse.Name}?",
                               "Подтверждение",
                               MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var db = new ApplicationContext())
                {
                    var item = db.Warehouse.Find(selectedWarehouse.Id);
                    if (item != null)
                    {
                        db.Warehouse.Remove(item);
                        db.SaveChanges();
                        MessageBox.Show("Запись удалена");
                        LoadWarehouse();
                        ClearFields();
                    }
                }
            }
        }
    }
}
