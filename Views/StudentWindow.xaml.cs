using SchoolPlatform.Models.EntityLayer;
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
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow(User user)
        {
            InitializeComponent();
            StudentVM studentVM= new StudentVM(user);
            this.DataContext= studentVM;
        }

        private void MaterialDidacticBtn_Click(object sender, RoutedEventArgs e)
        {
            CourseMaterialGrid.Visibility = Visibility.Visible;
            GoBackBtn.Visibility = Visibility.Visible;
            Buttons.Visibility = Visibility.Hidden;
        }

        private void NoteBtn_Click(object sender, RoutedEventArgs e)
        {
            GradesGrid.Visibility= Visibility.Visible;
            GoBackBtn.Visibility = Visibility.Visible;

            Buttons.Visibility = Visibility.Hidden;

        }

        private void AbsenteBtn_Click(object sender, RoutedEventArgs e)
        {
            Buttons.Visibility = Visibility.Hidden;
            GoBackBtn.Visibility = Visibility.Visible;
            AbsencesGrid.Visibility = Visibility.Visible;
        }

        private void MediiBtn_Click(object sender, RoutedEventArgs e)
        {
            Buttons.Visibility = Visibility.Hidden;
            GoBackBtn.Visibility = Visibility.Visible;


        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            CourseMaterialGrid.Visibility = Visibility.Hidden;
            GradesGrid.Visibility = Visibility.Hidden;
            AbsencesGrid.Visibility= Visibility.Hidden;
            GoBackBtn.Visibility = Visibility.Hidden;

            Buttons.Visibility = Visibility.Visible;

        }
    }
}
