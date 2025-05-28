using DiplomUchetSC.Context;
using DiplomUchetSC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DiplomUchetSC.Enums;

namespace DiplomUchetSC.Views.Pages.MainPages.OrdersPages
{
    public partial class CurrentOrdersPage : Page
    {

        public CurrentOrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            List<Order> orders;

            using (var db = new ApplicationContext())
            {
                //orders = db.Orders
                //    .Include(o => o.Client)
                //    .Include(o => o.DeviceType)
                //    .Include(o => o.Brand)
                //    .Where(o => o.Issued_at == null)
                //    .ToList();

                orders = GenerateTestOrders();


            }

            CurrentOrdersDataGrid.ItemsSource = orders;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private List<Order> GenerateTestOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Created_at = DateTime.Now.AddDays(-5),
                    Client = new Client { Full_name = "Иванов Иван Иванович" },
                    OrderStatus = OrderStatus.ACCEPTED,
                    DeviceType = new DeviceType { Name = "Смартфон" },
                    Brand = new Brand { Name = "Samsung" },
                    Model = "Galaxy S21",
                    Fault = "Не заряжается",
                    Premilinary_cost = 5000,
                    Issued_at = null
                },
                new Order
                {
                    Id = 2,
                    Created_at = DateTime.Now.AddDays(-4),
                    Client = new Client { Full_name = "Петров Петр Петрович" },
                    OrderStatus = OrderStatus.REPAIR,
                    DeviceType = new DeviceType { Name = "Ноутбук" },
                    Brand = new Brand { Name = "Lenovo" },
                    Model = "ThinkPad X1",
                    Fault = "Не включается",
                    Premilinary_cost = 10000,
                    Issued_at = null
                },
                new Order
                {
                    Id = 3,
                    Created_at = DateTime.Now.AddDays(-3),
                    Client = new Client { Full_name = "Сидорова Анна Михайловна" },
                    OrderStatus = OrderStatus.FINISHED,
                    DeviceType = new DeviceType { Name = "Планшет" },
                    Brand = new Brand { Name = "Apple" },
                    Model = "iPad Air",
                    Fault = "Разбит экран",
                    Premilinary_cost = 8000,
                    Issued_at = null
                },
                new Order
                {
                    Id = 4,
                    Created_at = DateTime.Now.AddDays(-2),
                    Client = new Client { Full_name = "Кузнецов Дмитрий Сергеевич" },
                    OrderStatus = OrderStatus.REPAIR,
                    DeviceType = new DeviceType { Name = "Смартфон" },
                    Brand = new Brand { Name = "Xiaomi" },
                    Model = "Redmi Note 10",
                    Fault = "Не работает микрофон",
                    Premilinary_cost = 3500,
                    Issued_at = null
                },
                new Order
                {
                    Id = 5,
                    Created_at = DateTime.Now.AddDays(-1),
                    Client = new Client { Full_name = "Смирнова Елена Викторовна" },
                    OrderStatus = OrderStatus.REPAIR,
                    DeviceType = new DeviceType { Name = "Ноутбук" },
                    Brand = new Brand { Name = "HP" },
                    Model = "Pavilion 15",
                    Fault = "Перегревается",
                    Premilinary_cost = 7000,
                    Issued_at = null
                }
            };
        }


    }
}