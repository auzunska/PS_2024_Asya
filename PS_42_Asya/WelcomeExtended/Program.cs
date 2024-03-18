using Welcome.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;

namespace WelcomeExtended
{
    internal class Program
    {

        public static ActionOnError Log {  get; private set; }
        private static void Main(string[] args)
        {
            try
            {
                var user = new User {
                    Names = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };

                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);

                view.DisplayMainInfo();
                view.DisplayError();
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}