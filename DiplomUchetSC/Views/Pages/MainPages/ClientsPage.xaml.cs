using DiplomUchetSC.Context;
using DiplomUchetSC.Models;
using Microsoft.IdentityModel.Tokens;
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
    public partial class ClientsPage : Page
    {
        List<Client> client;
        public ClientsPage()
        {
            InitializeComponent();
            LoadClient();
        }
        private void LoadClient()
        {
            

            using (var db = new ApplicationContext())
            {
                client = db.Clients
                    .ToList();
            }

            ClientsDataGrid.ItemsSource = client;

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (client == null) return;

            var searchText = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ClientsDataGrid.ItemsSource = client;
                return;
            }

            var filterOrders = client.Where(o => (o.Full_name?.ToLower()?.Contains(searchText) ?? false) ||
                (o.Number_phone?.ToLower()?.Contains(searchText) ?? false) ||
                (o.Id.ToString().Contains(searchText)))
                .ToList();
            ClientsDataGrid.ItemsSource = filterOrders;
        }
    }
}
