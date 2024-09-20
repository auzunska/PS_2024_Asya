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
        private ObservableCollection<User> _users;

        public AdminUserViewModel(User user) : base(user)
        {
            RegisterUserCommand = new Command(RegisterUser);
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

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterUserCommand { get; }

        private void RegisterUser()
        {
            using (var context = new DatabaseContext())
            {
                var newUser = new DatabaseUser
                {
                    Names = NewUserNames,
                    Email = NewUserEmail,
                    Password = NewUserPassword,
                    FacNum = NewUserFacNum,
                    Role = UserRolesEnum.USER
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                LoadUsers();
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
