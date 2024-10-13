using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;

namespace AdminRegisterApp
{
    public class WelcomeViewModel : UserViewModel
    {
        private string _newPassword;
        private User _currentUser;

        public WelcomeViewModel(User user) : base(user)
        {

            _currentUser = user;
            ChangePasswordCommand = new Command(ChangePassword(_currentUser));
        }

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangePasswordCommand { get; }

        private void ChangePassword(User currentUser)
        {
            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                Application.Current.MainPage.DisplayAlert("Error", "New password cannot be empty!", "OK");
                return;
            }

            using (var context = new DatabaseContext())
            {
                var userToUpdate = context.Users.Find(currentUser);
                if (userToUpdate != null)
                {
                    userToUpdate.Password = NewPassword;
                    context.SaveChanges();

                    Application.Current.MainPage.DisplayAlert("Success", "Password changed successfully!", "OK");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error", "User not found!", "OK");
                }
            }
            NewPassword = string.Empty;
        }
    }
}
