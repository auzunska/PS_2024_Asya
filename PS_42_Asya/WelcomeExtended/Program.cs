using Welcome.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    internal class Program
    {

        public static ActionOnError Log { get; private set; } = Console.WriteLine;
        private static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();
                User studentUser = new User() { Names = "Student", Password = "123", Role = UserRolesEnum.STUDENT };
                User studentUser2 = new User() { Names = "Student2", Password = "123456", Role = UserRolesEnum.STUDENT };
                User teacher = new User() { Names = "Teacher", Password = "1234", Role = UserRolesEnum.PROFESSOR };
                User admin = new User() { Names = "Admin", Password = "12345", Role = UserRolesEnum.ADMIN };

                userData.AddUser(studentUser);
                userData.AddUser(studentUser2);
                userData.AddUser(teacher);
                userData.AddUser(admin);

                // Prompt user to enter credentials
                Console.WriteLine("Please enter your username:");
                string username = Console.ReadLine();

                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();

                // Validate credentials
                string error = UserHelper.ValidateCredentials(userData, username, password);
                if (error != null)
                {
                    throw new Exception("User not found");
                }

                // Get user
                User user = UserHelper.GetUser(userData, username, password);

                // Display user information
                Console.WriteLine(user.ToString());

                userData.AddUser(studentUser);
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