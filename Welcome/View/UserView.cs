using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    internal class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void DisplayNameRole()
        {
            Console.WriteLine("Welcome\nUser: " + _viewModel.Name + "\nRoles: " + _viewModel.Role);
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Welcome\nName:" + 
                _viewModel.Name + "\nEmail: " + _viewModel.Email + 
                "\nFaculty Number: " + _viewModel.facNum);
        }

        public void displayLoginCredentials()
        {
            Console.WriteLine("Welcome\nEmail: " + _viewModel.Email +
                "\nHashed password: " + _viewModel.Password);
        }
    }
}
