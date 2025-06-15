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
using DiplomUchetSC.Enums;
using DiplomUchetSC.Models;
using DiplomUchetSC.Views.Pages.MainPages;

namespace DiplomUchetSC
{
    public partial class MainWindow : Window
    {

        private readonly User _currentUser;

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            MainTabControl.SelectedIndex = 0;
            SetTabAccess();
        }
        private void SetTabAccess()
        {
            foreach (TabItem tab in MainTabControl.Items)
            {
                if (tab.Tag == null) continue;

                switch (tab.Tag.ToString())
                {
                    case "Employees":
                        tab.IsEnabled = _currentUser.Role == Role.DIRECTOR;
                        break;

                    case "Stats":
                        tab.IsEnabled = _currentUser.Role != Role.REPAIRMAN;
                        break;
                }
            }
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