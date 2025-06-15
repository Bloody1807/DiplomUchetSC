using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiplomUchetSC.Models;
using DiplomUchetSC.Views.Pages.MainPages;

namespace DiplomUchetSC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainTabControl.SelectedItem is TabItem selectedTab)
            {
                switch (selectedTab.Tag.ToString())
                {
                    case "Orders":
                        MainFrame.Navigate(new OrdersPage());
                        break;

                    case "Stats":
                        MainFrame.Navigate(new StatsPage());
                        break;

                    case "Clients":
                        MainFrame.Navigate(new ClientsPage());
                        break;

                    case "Warehouse":
                        MainFrame.Navigate(new WarehousePage());
                        break;

                    case "Employees":
                        MainFrame.Navigate(new EmployeesPage());
                        break;
                }

            }
        }

    }
}