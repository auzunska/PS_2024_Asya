using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    internal class User
    {
        private string _names;
        private string _password;
        private UserRolesEnum _role;
        private string _email;
        private string _facNum;

        public string Name
        {
            get { return _names; }
            set { _names = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public UserRolesEnum Role
        {
            get { return _role; }   
            set { _role = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string FacNum
        {
            get { return _facNum; }
            set { _facNum = value; }
        }
    }
}
