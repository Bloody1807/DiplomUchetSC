﻿using System;
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
using DiplomUchetSC.Context;
using DiplomUchetSC.Models;
using DiplomUchetSC.Utils;
using DiplomUchetSC.Views.Pages.AuthPages;
using DiplomUchetSC.Views.Windows;


namespace DiplomUchetSC.Views.Pages.AuthPages
{
    public partial class AuthPage : Page
    {
        public static User? AuthUser { get; set; } = null;

        public AuthPage()
        {
            InitializeComponent();
            CheckUser();
        }

        private void CheckUser()
        {
            using (var db = new ApplicationContext())
            {
                bool usersExist = db.Users.Any();
                SignUpBtn.IsEnabled = !usersExist;
            }
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            if (login == string.Empty
                || password == string.Empty)
            {
                MessageBox.Show("Одно или несколько полей не заполнено");
                return;
            }

            User? user = ApplicationContext.Instance.Users.AsEnumerable()
                .FirstOrDefault(u => u.Username.Equals(login, StringComparison.Ordinal) 
                && u.Password.Equals(password, StringComparison.Ordinal));
            if (user == null)
            {
                MessageBox.Show("Неверные учётные данные!");
                return;
            }

            AuthUser = user;

            MessageBox.Show("Добро пожаловать!");

            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();

            Window.GetWindow(this).Close();

        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new RegisterPage());

        }
    }
}
