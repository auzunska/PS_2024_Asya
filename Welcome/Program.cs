using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Test";
            user.Password = "Test";
            user.Role = Others.UserRolesEnum.ADMIN;
            user.Email = "test@example.com";
            user.FacNum = "123456789";

            UserViewModel viewModel = new UserViewModel(user);
            UserView view = new UserView(viewModel);

            view.DisplayNameRole();
            view.DisplayInfo();
            view.displayLoginCredentials();
        }
    }
}