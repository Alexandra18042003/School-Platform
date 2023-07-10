using SchoolPlatform.Commands;
using SchoolPlatform.Models.BusinessLogicLayer;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class FindClassVM : BasePropertyChanged
    {
        public AdminVM AdminVM { get; set; }

        public RelayCommand FindClass { get; set; }

        public ObservableCollection<StudentView> FilteredStudents { get; set; }
        public ObservableCollection<string> AvailableClasses { get; set; }
        public Student SelectedStudent { get; set; }
        public RelayCommand DeleteStudent { get; set; }
        StudentBLL studentBLL = new StudentBLL();
        private StudentView selectedStudentView;
        public StudentView SelectedStudentView
        {
            get { return selectedStudentView; }
            set
            {
                selectedStudentView = value;
                IsSelected = selectedStudentView != null;
                if (selectedStudentView != null)
                    SelectedStudent = AdminVM.StudentConverter(selectedStudentView);
                NotifyPropertyChanged("");
            }
        }
        public FindClassVM() { }
        public FindClassVM(AdminVM adminVM)
        {
            FindClass = new RelayCommand(o => FindStudents());

            AdminVM = adminVM;
            
            AvailableClasses = new ObservableCollection<string>();

            AvailableClasses = adminVM.AvailableClasses;

            FilteredStudents = new ObservableCollection<StudentView>();

            DeleteStudent = new RelayCommand(o => Delete());
        }
        private void Delete()
        {
            studentBLL.DeleteStudent(SelectedStudent);
            AdminVM.AllStudents.Remove(SelectedStudent);
            FilteredStudents.Remove(SelectedStudentView);
        }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged("");
            }
        }
        private void FindStudents()
        {
            FilteredStudents.Clear();
            FormStudView();
        }
        private void FormStudView()
        {
            string pattern = @"\b\d+\b";

            Match match = Regex.Match(SelectedClass, pattern);

            StudentBLL studentBLL = new StudentBLL();
            ObservableCollection<Student> all = new ObservableCollection<Student>();
            foreach (Clasa cls in AdminVM.AllClasses)
            {
                if (SelectedClass.Contains(cls.DenumireSpecializare) && cls.AnStudiu == int.Parse(match.Value))
                {
                    all = studentBLL.GetStudentsByClassId(cls.Id);
                    break;
                }
            }
            foreach (Student stud in all)
            {
                foreach (Clasa clasa in AdminVM.AllClasses)
                    if (clasa.Id == stud.ClasaiD)
                        FilteredStudents.Add(new StudentView { Name = stud.Name + " " + stud.SecondName, Year = clasa.AnStudiu, Spec = clasa.DenumireSpecializare });
            }
        }
        private string selectedClass;
        public string SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                NotifyPropertyChanged("SelectedClass");
            }
        }
    }
}
