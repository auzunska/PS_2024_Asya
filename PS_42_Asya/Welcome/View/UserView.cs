using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView (UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void DisplayMainInfo()
        {
            Console.WriteLine("Welcome\nUser: " + _viewModel.Names + "\nRole: " + _viewModel.Role);
        }

        public void DisplayLoginCredentials() {
            Console.WriteLine("Email: " + _viewModel.Email + "\nPassword hash: " + _viewModel.Password);
        }

        public void DisplayAll()
        {
            Console.WriteLine("Welcome\nNames: " + _viewModel.Names + "\nEmail: " + _viewModel.Email + "\nFac.number: " + _viewModel.FacNum + "\nRole: " + _viewModel.Role);
        }

        public void DisplayError() {
            throw new Exception("Something went wrong!");
        }
    }
}
