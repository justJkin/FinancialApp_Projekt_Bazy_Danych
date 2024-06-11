using System.Windows;
using System.Windows.Controls;
using financialApp.Interfaces;
using financialApp.Models;
using financialApp.Services;

namespace financialApp.Views.Admin
{
    public partial class AdminDashboard : Window
    {
        private readonly IUserService _userService;
        private readonly FinancialService _financialService;
        private readonly string _userRole;

        public AdminDashboard(IUserService userService, FinancialService financialService, string userRole)
        {
            InitializeComponent();
            _userService = userService;
            _financialService = financialService;
            _userRole = userRole;
            if (_userRole != "Admin")
            {
                // Ukryj funkcje dostępne tylko dla administratorów
                AdminButton.Visibility = Visibility.Collapsed;
            }
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userService.GetAllUsers();
            UsersListView.ItemsSource = users;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Password,
                Email = EmailTextBox.Text
            };

            try
            {
                _userService.CreateUser(user);
                LoadUsers();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem is User selectedUser)
            {
                try
                {
                    selectedUser.Username = UsernameTextBox.Text;
                    selectedUser.Password = PasswordTextBox.Password;
                    selectedUser.Email = EmailTextBox.Text;
                    _userService.UpdateUser(selectedUser);
                    LoadUsers();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem is User selectedUser)
            {
                try
                {
                    _userService.DeleteUser(selectedUser.UserID);
                    LoadUsers();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow(_userService, _financialService);
            loginWindow.Show();
            this.Close();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
