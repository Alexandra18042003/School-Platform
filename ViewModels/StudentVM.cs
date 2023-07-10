using SchoolPlatform.Commands;
using SchoolPlatform.Models.BusinessLogicLayer;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class GradeView
    {
        private int grade_id;
        public int Grade_id
        {
            get
            {
                return grade_id;
            }
            set
            {
                grade_id = value;
            }
        }
       
        private string course_name;
        public string Course_name
        {
            get
            {
                return course_name;
            }
            set
            {
                course_name = value;
            }
        }
        private int grade_value;
        public int Grade_value
        {
            get
            {
                return grade_value;
            }
            set
            {
                grade_value = value;
            }
        }
        private int semester;
        public int Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
            }
        }

    }
    public class AbsenceView
    {
        private int absence_id;
        public int Absence_id
        {
            get
            {
                return absence_id;
            }
            set
            {
                absence_id = value;
            }
        }

        private string course_name;
        public string Course_name
        {
            get
            {
                return course_name;
            }
            set
            {
                course_name = value;
            }
        }

        private bool checked_;
        public bool Checked_
        {
            get
            {
                return checked_;
            }
            set
            {
                checked_ = value;
            }
        }
        private int semester;
        public int Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
            }
        }
    }
    public class StudentVM : BasePropertyChanged
    {
        StudentBLL studentBLL = new StudentBLL();
        ClasaBLL clasaBLL = new ClasaBLL();
        ClassCourseBLL classCourseBLL = new ClassCourseBLL();
        CourseBLL courseBLL = new CourseBLL();
        CourseMaterialBLL courseMaterialBLL = new CourseMaterialBLL();
        GradeBLL gradeBLL = new GradeBLL();
        AbsenceBLL absenceBLL = new AbsenceBLL();
        public ObservableCollection<ClassCourse> ClassCourses { get; set; }
        public ObservableCollection<CourseMaterial> CourseMaterials { get; set; }
        public ObservableCollection<GradeView> GradeViews { get; set; }
        public ObservableCollection<Grade> GradeList { get; set; }
        public ObservableCollection<Absence> AbsenceList { get; set; }
        public ObservableCollection<AbsenceView> AbsenceViews { get; set; }
        public Student Student { get; set; }
        public Clasa Clasa { get; set; }


        public StudentVM(User user)
        {
            
            StudentsList = studentBLL.GetAllStudents();

            ClassCourses = new ObservableCollection<ClassCourse>();
            CourseMaterials = new ObservableCollection<CourseMaterial>();
            GradeList = new ObservableCollection<Grade>();
            GradeViews = new ObservableCollection<GradeView>();
            AbsenceList= new ObservableCollection<Absence>();
            AbsenceViews = new ObservableCollection<AbsenceView>();

            Student = new Student();
            Clasa = new Clasa();

            foreach(Student s in StudentsList)
            {
                if(user.Username.Contains(s.Name) && user.Username.Contains(s.SecondName))
                {
                    Student = s;
                    break;
                }
            }
            GradeList = gradeBLL.GetAllGrades();
            AbsenceList = absenceBLL.GetAllAbsences();

            foreach(Clasa clasa in clasaBLL.ClassesList)
            {
                if(clasa.Id == Student.ClasaiD)
                {
                    Clasa=clasa;
                    break;
                }
            }

            foreach(ClassCourse c in classCourseBLL.ClassCoursesList)
            {
                if(c.ClasaID == Clasa.Id)
                    ClassCourses.Add(c);
            }

            foreach( ClassCourse c in ClassCourses)
            {
                //c.materieID
                foreach(CourseMaterial cm in courseMaterialBLL.CourseMaterialList)
                {
                    if (cm.CourseID == c.CourseID)
                    {
                        CourseMaterials.Add(cm);
                    }
                }
            }

            foreach( Grade grade in GradeList)
            {
                if(grade.Student_id == Student.ID)
                    GradeViews.Add(new GradeView() { Grade_id = grade.Grade_id, Course_name = courseBLL.GetCourseNameByID(grade.Course_id), Grade_value = grade.Grade_value, Semester = grade.Semester });

            }

            foreach( Absence a in AbsenceList)
            {
                if(a.Student_id == Student.ID)
                {
                    AbsenceViews.Add(new AbsenceView() { Absence_id = a.Absence_id, Course_name = courseBLL.GetCourseNameByID(a.CourseID), Checked_ = a.Checked_, Semester = a.Semester });
                }
            }
        }
        public ObservableCollection<Student> StudentsList
        {
            get => studentBLL.StudentsList;
            set
            {
                studentBLL.StudentsList = value;
                NotifyPropertyChanged("StudentsList");

            }
        }
      

        //PT BINDING DIN FEREASTRA

        //private string username;
        //private string userType;
        //private string password;
        //public bool CanExecute { get; set; }
        //public string Username
        //{
        //    get => username;
        //    set
        //    {
        //        username = value;
        //        if (Password != null)
        //            UserType = userBLL.GetUserType(userBLL.GetUser(new User() { Password = Password, Username = Username }));
        //        NotifyPropertyChanged("Username");
        //    }
        //}
        //public string UserType
        //{
        //    get => userType;
        //    set
        //    {
        //        userType = value;
        //        NotifyPropertyChanged("UserType");
        //    }
        //}
        //public string Password
        //{
        //    get => password;
        //    set
        //    {
        //        password = value;
        //        if (Username != null)
        //            UserType = userBLL.GetUserType(userBLL.GetUser(new User() { Password = Password, Username = Username }));
        //        NotifyPropertyChanged("Password");
        //    }
        //}



        //private ICommand addCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (addCommand == null)
        //        {
        //            addCommand = new RelayCommand<User>(userBLL.AddUser);
        //        }
        //        return addCommand;
        //    }
        //}
    }
}
