using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.Model;

namespace AdminRegisterApp
{
    public class LoginViewModel : UserViewModel
    {
        private string _errorMessage;

        public LoginViewModel() : base(new User()) // Initialize with a new User or provide a default User if necessary
        {
            LoginCommand = new Command(Login);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        private void Login()
        {
            using (var context = new DatabaseContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
                if (user == null)
                {
                    ErrorMessage = "Invalid credentials!";
                    return;
                }

                if (user.Role == UserRolesEnum.ADMIN)
                {
                    Application.Current.MainPage = new AdminPage(new AdminUserViewModel(user));
                }
                else
                {
                    Application.Current.MainPage = new WelcomePage(new UserViewModel(user));
                }
            }
        }
    }
}
