using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : UserControl
    {
        public StudentList()
        {
            InitializeComponent();

            // Load the data from your database or other data source
            LoadData();
        }

        private void LoadData()
        {
            // Create a new instance of the database context
            using (var context = new DatabaseContext())
            {
                // Fetch all users from the database
                var users = context.Users.ToList();

                // Set the DataGrid's ItemsSource to the list of users
                students.ItemsSource = users;
            }
        }
    }

}
