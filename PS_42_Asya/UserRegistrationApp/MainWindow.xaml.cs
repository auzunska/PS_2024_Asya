using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Windows;

namespace UserRegistrationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Capture input data from the user interface
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string facNum = FacNumTextBox.Text;

            // Simple validation to ensure fields are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(facNum))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Save the new user to the database
            try
            {
                using (var context = new DatabaseContext())
                {
                    var newUser = new DatabaseUser
                    {
                        Names = name,
                        Email = email,
                        Password = password,
                        FacNum = facNum,
                        Role = Welcome.Others.UserRolesEnum.STUDENT,
                        Expires = DateTime.Now.AddYears(1) 
                    };

                    // Add the new user to the Users DbSet
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }

                // Notify success and clear fields
                MessageBox.Show("User successfully registered!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                NameTextBox.Clear();
                EmailTextBox.Clear();
                PasswordBox.Clear();
                FacNumTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
