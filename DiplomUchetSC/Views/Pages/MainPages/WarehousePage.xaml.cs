using DiplomUchetSC.Context;
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

namespace DiplomUchetSC.Views.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        public WarehousePage()
        {
            InitializeComponent();
            LoadWarehouse();
        }
        private void LoadWarehouse()
        {
            List<Warehouse> warehouse;

            using (var db = new ApplicationContext())
            {
                warehouse = db.Warehouse
                    .ToList();


            }

            WarehouseDataGrid.ItemsSource = warehouse;

        }
    }
}
