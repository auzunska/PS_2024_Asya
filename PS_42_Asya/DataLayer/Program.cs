using DataLayer.Database;
using DataLayer.Model;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = "password",
                    Email = "email@example.com",
                    FacNum = "12345FFFF",
                    Expires = DateTime.Now,
                    Role = Welcome.Others.UserRolesEnum.STUDENT
                });

                context.SaveChanges();
                var users = context.Users.ToList();
                Console.ReadKey();
                Console.WriteLine(users);
            }
        }
    }
}
