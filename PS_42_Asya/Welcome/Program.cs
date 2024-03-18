using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            user1.Names = "Test Test";
            user1.Email = "test_test@example.com";
            user1.FacNum = "1234ABC12";
            user1.Role = Others.UserRolesEnum.STUDENT;
            user1.Password = "1234NBT56789";

            UserViewModel userViewModel = new UserViewModel(user1);
            UserView userView = new UserView(userViewModel);

            userView.DisplayMainInfo();
            userView.DisplayLoginCredentials();
            userView.DisplayAll();
        }
    }
}