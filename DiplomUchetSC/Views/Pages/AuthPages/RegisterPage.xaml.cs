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
using DiplomUchetSC.Utils;
using DiplomUchetSC.Views.Pages.AuthPages;
using DiplomUchetSC.Enums;
using DiplomUchetSC.Views.Windows;
using System.Reflection.Metadata;
using DiplomUchetSC.Models;
using System.Net;
using DiplomUchetSC.Context;
using System.Text.RegularExpressions;


namespace DiplomUchetSC.Views.Pages.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;
            string secondName = SecondName.Text;
            string firstName = FirstName.Text;
            string phoneNumber = PhoneNumber.Text;
            string email = Email.Text;

            if (login == string.Empty
                || password == string.Empty
                || secondName == string.Empty
                || firstName == string.Empty
                || phoneNumber == string.Empty
                || email == string.Empty)
            {
                MessageBox.Show("Одно или несколько полей не заполнено");
                return;
            }
            using (var db = new ApplicationContext())
            {

                if (db.Users.Any(u => u.Username == login))
                {
                    MessageBox.Show("Этот логин уже занят");
                    return;
                }

                var user = new User
                {
                    Username = login,
                    Password = password, 

                };

                db.Users.Add(user);
                db.SaveChanges();

                var personal = new Personal
                {
                    Number_phone = phoneNumber,
                    Email = email,
                    Second_name = secondName,
                    First_name = firstName,
                    User = user
                };

                db.Personals.Add(personal);
                db.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!");
                NavigationService.Navigate(new AuthPage());
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^[a-zA-Zа-яА-Я]+$"))
            {
                e.Handled = true;
            }
        }


        private void PhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
