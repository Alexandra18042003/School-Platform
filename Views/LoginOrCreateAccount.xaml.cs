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
using System.Windows.Shapes;
using SchoolPlatform.ViewModels;

namespace SchoolPlatform.Views
{
    public partial class LoginOrCreateAccount : Window
    {
        public LoginOrCreateAccount()
        {
            InitializeComponent();
            this.DataContext = new UserVM(this);
            Hidden.Visibility = Visibility.Hidden;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Hidden.Text = Password.Password.ToString();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            ToHide.Visibility = Visibility.Hidden;
            Title.Content = "SIGN IN";
            UserType.SelectedItem = "";
            UserType.Visibility = Visibility.Hidden;
            UserTypeLabel.Visibility = Visibility.Hidden;
            ContinueBtn.Visibility = Visibility.Hidden;
            LoginBtn.Visibility = Visibility.Visible;
        }

        private void ToHide_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            ToHide.Visibility = Visibility.Hidden;
            Title.Content = "SIGN IN";
            UserType.SelectedItem = "-1";
            UserType.Visibility = Visibility.Hidden;
            UserTypeLabel.Visibility = Visibility.Hidden;
            ContinueBtn.Visibility= Visibility.Hidden;
            LoginBtn.Visibility= Visibility.Visible;
        }

    }
}
