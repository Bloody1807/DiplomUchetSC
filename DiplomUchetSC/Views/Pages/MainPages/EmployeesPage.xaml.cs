using DiplomUchetSC.Context;
using DiplomUchetSC.Enums;
using DiplomUchetSC.Models;
using DiplomUchetSC.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiplomUchetSC.Views.Pages.MainPages
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();

        }

        private void LoadEmployees()
        {
            using (var db = new ApplicationContext())
            {
                var employees = db.Personals
                    .Include(p => p.User)
                    .Where(p => p.User != null && p.User.Role != Role.DIRECTOR)
                    .ToList();

                EmployeesDataGrid.ItemsSource = employees;
            }
        }

        private void LoadRoles()
        {
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(Role))
                    .Cast<Role>()
                    .Where(r => r != Role.DIRECTOR);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadEmployees();
                return;
            }

            using (var db = new ApplicationContext())
            {
                EmployeesDataGrid.ItemsSource = db.Personals
                    .Include(p => p.User)
                    .Where(p => (p.First_name != null && p.First_name.ToLower().Contains(searchText)) ||
                               (p.Second_name != null && p.Second_name.ToLower().Contains(searchText)) ||
                               (p.User != null && p.User.Username != null && p.User.Username.ToLower().Contains(searchText)))
                    .ToList();
            }
        }

        private Personal _selectedEmployee;

        private void EmployeesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _selectedEmployee = EmployeesDataGrid.SelectedItem as Personal;
            if (_selectedEmployee == null || _selectedEmployee.User == null) return;

            Login.Text = _selectedEmployee.User.Username;
            Passwordx.Password = _selectedEmployee.User.Password;
            LastName.Text = _selectedEmployee.Second_name;
            FirstName.Text = _selectedEmployee.First_name;
            Phone.Text = _selectedEmployee.Number_phone;
            Email.Text = _selectedEmployee.Email;
            RoleComboBox.SelectedItem = _selectedEmployee.User.Role;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Passwordx.Password;
            string lastName = LastName.Text;
            string firstName = FirstName.Text;
            string phone = Phone.Text;
            string email = Email.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            if (RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль сотрудника");
                return;
            }

            using (var db = new ApplicationContext())
            {
                var selectedEmployee = EmployeesDataGrid.SelectedItem as Personal;

                if (selectedEmployee != null && selectedEmployee.User != null)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == selectedEmployee.User.Id);
                    var personal = db.Personals.FirstOrDefault(p => p.Id == selectedEmployee.Id);

                    if (user == null || personal == null)
                    {
                        MessageBox.Show("Ошибка: сотрудник не найден");
                        return;
                    }

                    if (user.Username != login && db.Users.Any(u => u.Username == login))
                    {
                        MessageBox.Show("Этот логин уже занят");
                        return;
                    }

                    user.Username = login;
                    user.Password = password;
                    user.Role = (Role)RoleComboBox.SelectedItem;

                    personal.Number_phone = phone;
                    personal.Email = email;
                    personal.Second_name = lastName;
                    personal.First_name = firstName;

                    db.SaveChanges();
                    MessageBox.Show("Данные сотрудника успешно обновлены!");
                }
                else
                {
                    if (db.Users.Any(u => u.Username == login))
                    {
                        MessageBox.Show("Этот логин уже занят");
                        return;
                    }

                    Role selectedRole = (Role)RoleComboBox.SelectedItem;

                    var user = new User
                    {
                        Username = login,
                        Password = password,
                        Role = selectedRole
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    var personal = new Personal
                    {
                        Number_phone = phone,
                        Email = email,
                        Second_name = lastName,
                        First_name = firstName,
                        User = user
                    };

                    db.Personals.Add(personal);
                    db.SaveChanges();

                    MessageBox.Show($"Сотрудник ({selectedRole}) добавлен успешно!");
                }

                ClearFields();
                LoadEmployees();
            }
        }

        private void ClearFields()
        {
            _selectedEmployee = null;
            Login.Text = "";
            Passwordx.Password = "";
            LastName.Text = "";
            FirstName.Text = "";
            Phone.Text = "";
            Email.Text = "";
            RoleComboBox.SelectedItem = null;
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"^[a-zA-Zа-яА-Я]+$"))
            {
                e.Handled = true;
            }
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoles();
            LoadEmployees();
        }
    }
}