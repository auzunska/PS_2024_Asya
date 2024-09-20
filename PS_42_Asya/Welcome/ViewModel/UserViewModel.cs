using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Names
        {
            get { return _user.Names; }
            set { 
                _user.Names = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _user.Email; }
            set { 
                _user.Email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _user.Password; }
            set { 
                _user.Password = value;
                OnPropertyChanged();
            }
        }

        public UserRolesEnum Role
        {
            get { return _user.Role; }
            set { 
                _user.Role = value;
                OnPropertyChanged();
            }
        }

        public string FacNum
        {
            get { return _user.FacNum;}
            set {
                _user.FacNum = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
