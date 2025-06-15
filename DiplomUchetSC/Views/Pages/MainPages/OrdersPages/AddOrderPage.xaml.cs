using DiplomUchetSC.Context;
using DiplomUchetSC.Enums;
using DiplomUchetSC.Models;
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
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(ClientComboBox.Text)
                ||string.IsNullOrWhiteSpace(ClientPhoneBox.Text)
                ||string.IsNullOrWhiteSpace(DeviceTypeComboBox.Text) 
                ||string.IsNullOrWhiteSpace(BrandComboBox.Text)
                ||string.IsNullOrWhiteSpace(ModelTextBox.Text)
                ||string.IsNullOrWhiteSpace(FaultTextBox.Text) 
                ||string.IsNullOrWhiteSpace(PreliminaryCostTextBox.Text))
            {
                MessageBox.Show("Одно или несколько полей не заполнено");
                return;
            }
            using (var db = new ApplicationContext())
            {
                Client client;
                if (ClientComboBox.SelectedItem is Client selectedClient)
                {
                    client = db.Clients.Find(selectedClient.Id);
                }
                else
                {
                    client = new Client
                    {
                        Full_name = ClientComboBox.Text,
                        Number_phone = ClientPhoneBox.Text,
                    };
                    db.Clients.Add(client);
                }

                DeviceType deviceType;
                if (DeviceTypeComboBox.SelectedItem is DeviceType selectedDeviceType)
                {
                    deviceType = db.DeviceTypes.Find(selectedDeviceType.Id);
                }
                else
                {
                    deviceType = new DeviceType
                    {
                        Name = DeviceTypeComboBox.Text
                    };
                    db.DeviceTypes.Add(deviceType);
                }

                Brand brand;
                if (BrandComboBox.SelectedItem is Brand selectedBrand)
                {
                    brand = db.Brands.Find(selectedBrand.Id);
                }
                else
                {
                    brand = new Brand
                    {
                        Name = BrandComboBox.Text
                    };
                    db.Brands.Add(brand);
                }

                var order = new Order
                {
                    Created_at = DateTime.Now,
                    Client = client,
                    DeviceType = deviceType,
                    Brand = brand,
                    Model = ModelTextBox.Text,
                    Fault = FaultTextBox.Text,
                    Premilinary_cost = int.Parse(PreliminaryCostTextBox.Text),
                    Comments = CommentTextBox.Text,
                    OrderStatus = OrderStatus.ACCEPTED
                };
                db.Orders.Add(order);
                db.SaveChanges();
                MessageBox.Show("Заказ сохранен");
                OrdersPage.TabControl.SelectedIndex = 1;
                
            }

        }


        private void DeviceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is Client selectedClient)
            {
                ClientPhoneBox.Text = selectedClient.Number_phone;
            }


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientComboBox.ItemsSource = ApplicationContext.Instance.Clients.ToList();
            DeviceTypeComboBox.ItemsSource = ApplicationContext.Instance.DeviceTypes.ToList();
            BrandComboBox.ItemsSource = ApplicationContext.Instance.Brands.ToList();    
        }
    }
}
