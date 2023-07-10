using SchoolPlatform.ViewModels;
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

namespace SchoolPlatform.Views
{
    /// <summary>
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
            this.DataContext = new AdminVM();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow.Visibility = Visibility.Visible;
            Buttons.Visibility = Visibility.Hidden;
            GoBack.Visibility = Visibility.Visible;
            RefreshBtn.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TeacherWindow.Visibility = Visibility.Visible;
            GoBack.Visibility = Visibility.Visible;
            Buttons.Visibility = Visibility.Hidden;
            RefreshBtn.Visibility = Visibility.Visible;
            GoBack.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CourseWindow.Visibility= Visibility.Visible;
            Buttons.Visibility = Visibility.Hidden;
            RefreshBtn.Visibility = Visibility.Visible;
            GoBack.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //....
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow.Visibility = Visibility.Hidden;
            TeacherWindow.Visibility = Visibility.Hidden;
            CourseWindow.Visibility= Visibility.Hidden;
            ClassCourseWindow.Visibility= Visibility.Hidden;
            ClassWindow.Visibility= Visibility.Hidden;

            Buttons.Visibility = Visibility.Visible;
            RefreshBtn.Visibility = Visibility.Hidden;
            GoBack.Visibility = Visibility.Hidden;
        }

        private void ClassCoursesBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassCourseWindow.Visibility = Visibility.Visible;
            Buttons.Visibility = Visibility.Hidden;
            RefreshBtn.Visibility = Visibility.Visible;
            GoBack.Visibility = Visibility.Visible;
        }

        private void ClassBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassWindow.Visibility = Visibility.Visible;
            Buttons.Visibility = Visibility.Hidden;
            RefreshBtn.Visibility = Visibility.Visible;
            GoBack.Visibility = Visibility.Visible;
        }
    }
}
