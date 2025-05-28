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
using DiplomUchetSC.Views.Pages.MainPages.OrdersPages;

namespace DiplomUchetSC.Views.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();

            OrdersTabControl.SelectedIndex = 1;
            OrdersFrame.Navigate(new CurrentOrdersPage());

        }

        private void OrdersTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersTabControl.SelectedItem is TabItem selectedTab)
            {
                switch (selectedTab.Tag.ToString())
                {
                    case "Add":
                        OrdersFrame.Navigate(new AddOrderPage());
                        break;

                    case "Current":
                        OrdersFrame.Navigate(new CurrentOrdersPage());
                        break;

                    case "Issued":
                        OrdersFrame.Navigate(new IssuedOrdersPage());
                        break;

                }

            }
        }
    }
}
