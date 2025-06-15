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
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {

        private readonly Order _order;

        public EditOrderPage(Models.Order selectedOrder)
        {
            InitializeComponent();
            _order = selectedOrder;
            
        }

        private void DeviceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool is_current = true;

            using (var db = new ApplicationContext())
            {

                var orderToUpdate = db.Orders.Find(_order.Id);

                var oldStatus = orderToUpdate.OrderStatus;

                orderToUpdate.Client = (Client)ClientComboBox.SelectedItem;
                orderToUpdate.Client.Number_phone = ClientPhoneBox.Text;
                orderToUpdate.DeviceType = (DeviceType)DeviceTypeComboBox.SelectedItem;
                orderToUpdate.Brand = (Brand)BrandComboBox.SelectedItem;
                orderToUpdate.Model = ModelTextBox.Text;
                orderToUpdate.Fault = FaultTextBox.Text;
                orderToUpdate.Premilinary_cost = int.Parse(PreliminaryCostTextBox.Text);
                orderToUpdate.Final_cost = int.Parse(FinalCostTextBox.Text);
                orderToUpdate.Comments = CommentTextBox.Text;
                orderToUpdate.Completed_work = CompletedWorkTextBox.Text;
                orderToUpdate.OrderStatus = (OrderStatus)StatusComboBox.SelectedItem;
                orderToUpdate.Guarantee = (Guarantee)GuaranteeComboBox.SelectedItem;

                if (orderToUpdate.OrderStatus == OrderStatus.ISSUED) 
                {
                    orderToUpdate.Issued_at = DateTime.Now;
                    is_current = false;
                }

                if (orderToUpdate.OrderStatus == OrderStatus.GUARANTEE && oldStatus != OrderStatus.GUARANTEE)
                {
                    string guaranteeNote = $"\nПринят по гарантии {DateTime.Now:dd.MM.yyyy HH:mm}";
                    orderToUpdate.Comments = string.IsNullOrEmpty(orderToUpdate.Comments)
                        ? guaranteeNote
                        : orderToUpdate.Comments + guaranteeNote;

                    CommentTextBox.Text = orderToUpdate.Comments;

                    orderToUpdate.Is_guarantee = true;
                }



                db.SaveChanges();
                MessageBox.Show("Сохранено");


                if (is_current)
                {
                    OrdersPage.TabControl.SelectedIndex = 1;
                }
                else
                {
                    OrdersPage.TabControl.SelectedIndex = 2;
                }
            }


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var clients = db.Clients.ToList();
                var deviceTypes = db.DeviceTypes.ToList();
                var brands = db.Brands.ToList();

                ClientComboBox.ItemsSource = clients;
                ClientComboBox.DisplayMemberPath = "Full_name";

                DeviceTypeComboBox.ItemsSource = deviceTypes;
                DeviceTypeComboBox.DisplayMemberPath = "Name";

                BrandComboBox.ItemsSource = brands;
                BrandComboBox.DisplayMemberPath = "Name";

                StatusComboBox.ItemsSource = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>();
                GuaranteeComboBox.ItemsSource = Enum.GetValues(typeof(Guarantee)).Cast<Guarantee>();

                if (_order.Client != null)
                {
                    ClientComboBox.SelectedItem = clients.FirstOrDefault(c => c.Id == _order.Client.Id);
                    ClientPhoneBox.Text = _order.Client.Number_phone;
                }

                if (_order.DeviceType != null)
                {
                    DeviceTypeComboBox.SelectedItem = deviceTypes.FirstOrDefault(d => d.Id == _order.DeviceType.Id);
                }

                if (_order.Brand != null)
                {
                    BrandComboBox.SelectedItem = brands.FirstOrDefault(b => b.Id == _order.Brand.Id);
                }

                StatusComboBox.SelectedItem = _order.OrderStatus;
                GuaranteeComboBox.SelectedItem = _order.Guarantee;

                ModelTextBox.Text = _order.Model;
                FaultTextBox.Text = _order.Fault;
                PreliminaryCostTextBox.Text = _order.Premilinary_cost.ToString();
                FinalCostTextBox.Text = _order.Final_cost.ToString();
               
                CommentTextBox.Text = _order.Comments;
            }
        }
    }
}
