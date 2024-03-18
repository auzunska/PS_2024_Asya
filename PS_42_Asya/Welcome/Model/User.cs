using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _names;
        private string _email;
        private int _password;
        private UserRolesEnum _role;
        private string _facNum;

        public string Names { 
            get { return _names; } 
            set { _names = value; }
        }

        public string Email { 
            get { return _email; } 
            set { _email = value; } 
        }

        public string Password
        {
            get { return _password.ToString(); }
            set { int hash = value.GetHashCode();
                  _password = hash;
            }
        }

        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public string FacNum
        {
            get { return _facNum; }
            set { _facNum = value; }
        }
    }
}
