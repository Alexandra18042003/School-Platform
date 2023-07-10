using SchoolPlatform.Models.BusinessLogicLayer;
using SchoolPlatform.Views;
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

namespace SchoolPlatform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserBLL u = new UserBLL();
            //u.GetUser(new User() { Username = "utilizator2", Password = "parola2" });
            //u.GetUserIDByName("utilizator2");
            //u.AddUser(new User() { Username = "util345", Password = "12433", UserType = "administrator" });
        }


        private void Registered_Click(object sender, RoutedEventArgs e)
        {
            LoginOrCreateAccount login = new LoginOrCreateAccount();
            login.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
