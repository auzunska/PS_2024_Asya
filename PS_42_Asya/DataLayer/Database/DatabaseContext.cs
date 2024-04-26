using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    internal class DatabaseContext : DbContext
    {

        public DbSet<DatabaseUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.ID).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                ID = 1,
                Names = "John Doe",
                Password = "1234",
                Email = "ex@example.com",
                FacNum = "11111111",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
        }
    }
}
