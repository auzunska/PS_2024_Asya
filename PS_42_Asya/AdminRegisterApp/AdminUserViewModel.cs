using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;

namespace AdminRegisterApp
{
    public class AdminUserViewModel : UserViewModel
    {
        private string _newUserNames;
        private string _newUserEmail;
        private string _newUserPassword;
        private string _newUserFacNum;
        private UserRolesEnum _newUserRole;
        private ObservableCollection<User> _users;
        public ObservableCollection<UserRolesEnum> Roles { get; }
        private string _errorMessage;

        public AdminUserViewModel(User user) : base(user)
        {
            Roles = new ObservableCollection<UserRolesEnum>(Enum.GetValues(typeof(UserRolesEnum)).Cast<UserRolesEnum>());
            RegisterUserCommand = new Command(RegisterUser);
            DeleteUserCommand = new Command<DatabaseUser>(DeleteUser);
            LoadUsers();
        }

        public string NewUserNames
        {
            get => _newUserNames;
            set
            {
                _newUserNames = value;
                OnPropertyChanged();
            }
        }

        public string NewUserEmail
        {
            get => _newUserEmail;
            set
            {
                _newUserEmail = value;
                OnPropertyChanged();
            }
        }

        public string NewUserPassword
        {
            get => _newUserPassword;
            set
            {
                _newUserPassword = value;
                OnPropertyChanged();
            }
        }

        public string NewUserFacNum
        {
            get => _newUserFacNum;
            set
            {
                _newUserFacNum = value;
                OnPropertyChanged();
            }
        }

        public UserRolesEnum NewUserRole
        {
            get => _newUserRole;
            set
            {
                _newUserRole = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
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

        public ICommand RegisterUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        private void RegisterUser()
        {

            if (string.IsNullOrWhiteSpace(NewUserNames) ||
                string.IsNullOrWhiteSpace(NewUserEmail) ||
                string.IsNullOrWhiteSpace(NewUserPassword) ||
                string.IsNullOrWhiteSpace(NewUserFacNum))
            {
                ErrorMessage = "All fields are required!";
                Application.Current.MainPage.DisplayAlert("Error", "All fields are required for registration!", "OK");
                return;
            }

            ErrorMessage = string.Empty;

            using (var context = new DatabaseContext())
            {
                var newUser = new DatabaseUser
                {
                    Names = NewUserNames,
                    Email = NewUserEmail,
                    Password = NewUserPassword,
                    FacNum = NewUserFacNum,
                    Role = NewUserRole,
                    Expires = DateTime.Now.AddYears(10)
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                LoadUsers();
            }
        }

        private void DeleteUser(DatabaseUser user)
        {
            using (var context = new DatabaseContext())
            {
                var userToDelete = context.Users.Find(user.ID);
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                    LoadUsers(); // Reload the users list after deletion
                }
            }
        }

        private void LoadUsers()
        {
            using (var context = new DatabaseContext())
            {
                Users = new ObservableCollection<User>(context.Users.ToList());
            }
        }
    }
}
