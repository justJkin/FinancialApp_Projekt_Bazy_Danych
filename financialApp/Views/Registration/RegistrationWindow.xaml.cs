using System;
using System.Windows;
using financialApp.Interfaces;
using financialApp.Services;
using System.Text.RegularExpressions;
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

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields must be filled in", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (username.Length > 50 || email.Length > 50 || password.Length > 50 || confirmPassword.Length > 50)
            {
                MessageBox.Show("Fields must not exceed 50 characters", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email address", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Najprostsze sprawdzenie formatu email
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
