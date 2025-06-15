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
using System.Windows.Shapes;
using DiplomUchetSC.Models;

namespace DiplomUchetSC.Views.Windows.Acts
{
    public partial class IssuedActWindow : Window
    {
        public IssuedActWindow(Order order)
        {
            InitializeComponent();
            this.DataContext = order;
        }

        public void PrintAct()
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                this.LayoutTransform = new ScaleTransform(
                    printDialog.PrintableAreaWidth / this.ActualWidth,
                    printDialog.PrintableAreaHeight / this.ActualHeight);

                printDialog.PrintVisual(this, "Акт выдачи заказа");
            }
        }


    }
}
