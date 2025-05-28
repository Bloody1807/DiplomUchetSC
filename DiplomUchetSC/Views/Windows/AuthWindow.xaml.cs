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
using DiplomUchetSC.Utils;
using DiplomUchetSC.Views.Pages.AuthPages;
using DiplomUchetSC.Views.Windows;

namespace DiplomUchetSC.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.Root = this;
            Navigation.CurrentFrame = AuthFrame;

            Navigation.CurrentFrame.Navigate(new AuthPage());
        }

    }
}
