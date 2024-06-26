﻿using System.Windows;
using financialApp.Views.Admin;
using financialApp.Interfaces;
using financialApp.Services;
using System.Windows.Controls;

namespace financialApp.Views
{
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        private readonly FinancialService _financialService;

        public LoginWindow(IUserService userService, FinancialService financialService)
        {
            InitializeComponent();
            _userService = userService;
            _financialService = financialService;

            // Dodajemy obsługę zdarzenia PasswordChanged dla PasswordBox
            PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (_userService.AuthenticateUser(username, password))
            {
                string role = _userService.GetUserRole(username);
                int userId = _userService.GetUserId(username);

                if (role == "Admin")
                {
                    AdminDashboard adminDashboard = new AdminDashboard(_userService, _financialService, role); // Zmiana MainWindow na AdminDashboard
                    adminDashboard.Show();
                }
                else
                {
                    UserDashboard userDashboard = new UserDashboard(_userService, _financialService, userId);
                    userDashboard.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(_userService, _financialService);
            registrationWindow.Show();
            this.Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                // Możesz usunąć to wywołanie, jeśli nie używasz już PasswordHelper
            }
        }
    }
}
