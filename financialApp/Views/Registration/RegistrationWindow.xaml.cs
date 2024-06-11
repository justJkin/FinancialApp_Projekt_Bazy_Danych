using System;
using System.Windows;
using financialApp.Interfaces;
using financialApp.Services;

namespace financialApp.Views
{
    public partial class RegistrationWindow : Window
    {
        private readonly IUserService _userService;
        private readonly FinancialService _financialService;

        public RegistrationWindow(IUserService userService, FinancialService financialService)
        {
            InitializeComponent();
            _userService = userService;
            _financialService = financialService;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_userService.RegisterUser(username, email, password))
                {
                    MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoginWindow loginWindow = new LoginWindow(_userService, _financialService);
                    loginWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}\n\n{ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow(_userService, _financialService);
            loginWindow.Show();
            this.Close();
        }
    }
}
