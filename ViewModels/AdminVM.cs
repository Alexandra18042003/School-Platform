using SchoolPlatform.Commands;
using SchoolPlatform.Models.BusinessLogicLayer;
using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class StudentView
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Spec { get; set; }
    }
    public class ClassCourseView
    {
        public int ClassCourseID { get; set; }
        public string CourseName { get; set; }
        public int ClasaAnStudiu { get; set; }
        public string ClasaSpecializare { get; set; }
    }
    public class AdminVM : BasePropertyChanged
    {
        //student stuff
        StudentBLL studentBLL = new StudentBLL();
        private string firstNameStudent;
        private string secondNameStudent;
        private string selectedClass;
        private StudentView selectedStudentView;
        public StudentView SelectedStudentView
        {
            get { return selectedStudentView; }
            set
            {
                selectedStudentView = value;
                IsSelected = selectedStudentView != null;
                if (selectedStudentView != null)
                    SelectedStudent = StudentConverter(selectedStudentView);
                NotifyPropertyChanged("SelectedStudentView");
            }
        }
        public Student SelectedStudent { get; set; }
        public ObservableCollection<Student> AllStudents { get; set; }
        public ObservableCollection<StudentView> StudentViews { get; set; }
        public RelayCommand OpenFindWindow { get; set; }
        public RelayCommand DeleteStudent { get; set; }
        public RelayCommand EditStudent { get; set; }
        public RelayCommand Refresh { get; set; }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyPropertyChanged("Text");
            }
        }

        private string _text1;
        public string Text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                NotifyPropertyChanged("Text1");
            }
        }
        //teacher stuff
        TeacherBLL teacherBLL = new TeacherBLL();
        private string firstNameTeacher;
        private string secondNameTeacher;
        public Teacher SelectedTeacher { get; set; }
        public string SelectedAvailableTeacher { get; set; }

        public ObservableCollection<Teacher> AllTeachers { get; set; }
        public ObservableCollection<string> AvailableTeachers { get; set; }
        public RelayCommand DeleteTeacher { get; set; }
        public RelayCommand EditTeacher { get; set; }

        //course stuff
        CourseBLL courseBLL = new CourseBLL();
        public ObservableCollection<Course> AllCourses { get; set; }
        private string nameCourse;
        public Course SelectedCourse { get; set; }
        public RelayCommand DeleteCourse { get; set; }
        public RelayCommand EditCourse { get; set; }
        private ObservableCollection<string> availableCourses;
        public ObservableCollection<string> AvailableCourses
        {
            get => availableCourses;
            set
            {
                availableCourses = value;

                NotifyPropertyChanged("AvailableCourses");
            }
        }

        public string selectedAvailableCourse;
        public string SelectedAvailableCourse
        {
            get { return selectedAvailableCourse; }
            set
            {
                selectedAvailableCourse = value;
                IsSelected = selectedAvailableCourse != null;
                if (selectedAvailableCourse != null)
                    SelectedCourse = GetSelectedCourse(selectedAvailableCourse); // functie care primeste numele unei materii si returneaza obiectul materie ce contine acest nume
                NotifyPropertyChanged("SelectedClassCourseView");
            }
        }

        //clasa stuff
        ClasaBLL clasaBLL = new ClasaBLL();
        public ObservableCollection<Clasa> AllClasses { get; set; }
        private ObservableCollection<string> availableClasses;
        public ObservableCollection<string> AvailableClasses
        {
            get => availableClasses;
            set
            {
                availableClasses = value;

                NotifyPropertyChanged("AvailableClasses");
            }
        }
        public Clasa SelectedClasa { get; set; }
        public RelayCommand AddClass{ get; set; }

        public RelayCommand DeleteClass { get; set; }


        //classCourse stuff / materieClasa


        ClassCourseBLL classCourseBLL = new ClassCourseBLL();
        public ObservableCollection<ClassCourse> AllClassCourse { get; set; }
        public ClassCourse SelectedClassCourse { get; set; }
        public RelayCommand DeleteClassCourse { get; set; }
        public RelayCommand EditClassCourse { get; set; }
        public ObservableCollection<ClassCourseView> ClassCourseViews { get; set; }
        private ClassCourseView selectedClassCourseView;
        public ClassCourseView SelectedClassCourseView
        {
            get { return selectedClassCourseView; }
            set
            {
                selectedClassCourseView = value;
                IsSelected = selectedClassCourseView != null;
                if (selectedClassCourseView != null)
                    SelectedClassCourse = ClassCourseConverter(selectedClassCourseView);
                NotifyPropertyChanged("SelectedClassCourseView");
            }
        }
        public RelayCommand AddClassCourse { get; set; }


        public AdminVM()
        {
            Refresh = new RelayCommand(o => RefreshPage());

            OpenFindWindow = new RelayCommand(o => OpenFind());
            DeleteStudent = new RelayCommand(o => Delete());
            EditStudent = new RelayCommand(o => Edit());
            AllStudents = new ObservableCollection<Student>();
            AllStudents = studentBLL.StudentsList;

            DeleteTeacher = new RelayCommand(o => DeleteT());
            EditTeacher = new RelayCommand(o => EditT());
            AllTeachers = new ObservableCollection<Teacher>();
            AvailableTeachers = new ObservableCollection<string>();
            AllTeachers = teacherBLL.TeachersList;

            DeleteCourse = new RelayCommand(o => DeleteC());
            EditCourse = new RelayCommand(o => EditC());
            AllCourses = new ObservableCollection<Course>();
            AllCourses = courseBLL.CoursesList;
            AvailableCourses = new ObservableCollection<string>();

            DeleteClassCourse = new RelayCommand(o => DeleteCC());
            AddClassCourse = new RelayCommand(o => AddCC());
            AllClassCourse = new ObservableCollection<ClassCourse>();
            AllClassCourse = classCourseBLL.GetAllClassCourse();

            AllClasses = new ObservableCollection<Clasa>();
            AllClasses = clasaBLL.ClassesList;
            AvailableClasses = new ObservableCollection<string>();
            AddClass = new RelayCommand(o => AddClassF());
            DeleteClass = new RelayCommand(o => DeleteClass1());

            FormStudView();
            FormClassCourseView();
            foreach (Clasa clasa in AllClasses)
                AvailableClasses.Add($"{clasa.DenumireSpecializare}-Clasa a {clasa.AnStudiu}-a");

            foreach (Course course in AllCourses)
                AvailableCourses.Add(course.CourseName);

            foreach (Teacher t in AllTeachers)
                AvailableTeachers.Add(t.Name + " " + t.SecondName);

        }

        //student stuff
        private void Edit()
        {
            studentBLL.ModifyStudent(SelectedStudent, Text, Text1);
            string name = SelectedStudent.Name;

            foreach (var stud in AllStudents)
            {
                if (stud.ID == SelectedStudent.ID)
                {
                    stud.Name = Text;
                    stud.SecondName = Text1;
                    break;
                }
            }

            foreach (var stud in StudentViews)
            {
                if (stud.Name == name)
                {
                    stud.Name = Text + " " + Text1;
                }
            }
            Text = String.Empty;
        }
        private void OpenFind()
        {
            FindClass findWindow = new FindClass(this);
            findWindow.Show();
        }
        private void Delete()
        {
            studentBLL.DeleteStudent(SelectedStudent);
            AllStudents.Remove(SelectedStudent);
            StudentViews.Remove(SelectedStudentView);
        }
        public Student StudentConverter(StudentView view)
        {
            foreach (Student stud in AllStudents)
            {
                if (stud.Name + " " + stud.SecondName == view.Name)
                    return stud;
            }
            return null;
        }
        private void FormStudView()
        {
            StudentViews = new ObservableCollection<StudentView>();
            foreach (Student stud in AllStudents)
            {
                foreach (Clasa clasa in AllClasses)
                    if (clasa.Id == stud.ClasaiD)
                        StudentViews.Add(new StudentView { Name = stud.Name + " " + stud.SecondName, Year = clasa.AnStudiu, Spec = clasa.DenumireSpecializare });
            }
        }
        private void RefreshPage()
        {
            AllStudents = studentBLL.StudentsList;
            FormStudView();
            AllTeachers = teacherBLL.TeachersList;
            AllCourses = courseBLL.CoursesList;
            AllClasses = clasaBLL.ClassesList;
        }
        public string SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                NotifyPropertyChanged("SelectedClass");
            }
        }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }
        public string FirstNameStudent
        {
            get => firstNameStudent;
            set
            {
                firstNameStudent = value;

                NotifyPropertyChanged("FirstNameStudent");
            }
        }
        public string SecondNameStudent
        {
            get => secondNameStudent;
            set
            {
                secondNameStudent = value;

                NotifyPropertyChanged("SecondNameStudent");
            }
        }
        private ICommand addStudent;
        public ICommand AddStudent
        {
            get
            {
                if (addStudent == null)
                {
                    addStudent = new RelayCommand<Student>(studentBLL.AddStudent);
                }
                return addStudent;
            }
        }

        //teacher stuff

        public string FirstNameTeacher
        {
            get => firstNameTeacher;
            set
            {
                firstNameTeacher = value;

                NotifyPropertyChanged("FirstNameTeacher");
            }
        }
        public string SecondNameTeacher
        {
            get => secondNameTeacher;
            set
            {
                secondNameTeacher = value;

                NotifyPropertyChanged("SecondNameTeacher");
            }
        }

        private ICommand addTeacher;
        public ICommand AddTeacher
        {
            get
            {
                if (addTeacher == null)
                {
                    addTeacher = new RelayCommand<Teacher>(teacherBLL.AddTeacher);
                }
                return addTeacher;
            }
        }
        private void DeleteT()
        {
            teacherBLL.DeleteTeacher(SelectedTeacher);
            AllTeachers.Remove(SelectedTeacher);
        }

        private void EditT()
        {
            teacherBLL.ModifyTeacher(SelectedTeacher, Text);
            string name = SelectedTeacher.Name;
            foreach (var teacher in AllTeachers)
            {
                if (teacher.Name == name)
                    teacher.Name = Text;
            }
            Text = string.Empty;
        }
        //course stuff
        public string NameCourse
        {
            get => nameCourse;
            set
            {
                nameCourse = value;

                NotifyPropertyChanged("NameCourse");
            }
        }
        private ICommand addCourse;
        public ICommand AddCourse
        {
            get
            {
                if (addCourse == null)
                {
                    addCourse = new RelayCommand<Course>(courseBLL.AddCourse);
                }
                return addCourse;
            }
        }

        private void DeleteC()
        {
            courseBLL.DeleteCourse(SelectedCourse);
            AllCourses.Remove(SelectedCourse);
        }
        private void EditC()
        {
            courseBLL.ModifyCourse(SelectedCourse, Text);
            string name = SelectedCourse.CourseName;
            foreach (var course in AllCourses)
            {
                if (course.CourseName == name)
                    course.CourseName = Text;
            }
            Text = string.Empty;
        }
        // class course stuff
        private void AddCC()
        {
            string pattern = @"\b\d+\b";
            Match match = Regex.Match(SelectedClass, pattern);

            int idClasa = 0;
            //clase = clasaBLL.ClassesList;
            foreach (Clasa c in AllClasses)
            {
                if (SelectedClass.Contains(c.DenumireSpecializare) && c.AnStudiu == int.Parse(match.Value))
                {
                    idClasa = c.Id;
                    break;
                }
            }
            int idCourse = 0;
            foreach(Course c in AllCourses)
            {
                if (c.CourseName == SelectedAvailableCourse)
                {
                    idCourse = c.CourseID;
                    break;
                }
            }
            classCourseBLL.AddClassCourse(new ClassCourse() { CourseID = idCourse, ClasaID = idClasa, Teza = false });
            
        }
        private void DeleteCC()
        {
            //var ceva = SelectedClassCourse.ClassCourseID;
            classCourseBLL.Sterge_materieclasa(SelectedClassCourse.ClassCourseID);
            AllClassCourse.Remove(SelectedClassCourse);
            ClassCourseViews.Remove(SelectedClassCourseView);
        }

        public ClassCourse ClassCourseConverter(ClassCourseView view)
        {
            foreach (ClassCourse stud in AllClassCourse)
            {
                if (stud.ClassCourseID == view.ClassCourseID)
                    return stud;
            }
            return null;
        }
        private void FormClassCourseView()
        {
            //avem nevoie de classCourseViews pt ca materie clasa contine doar niste id-uri ale: materiei si clasei
            //cu ajutorul acestor id-uri cautam numele materiei si numele clasei, anul de studiu si specializarea
            //si le bagam in obiectul ClassCourseView
            ClassCourseViews = new ObservableCollection<ClassCourseView>();
            foreach (ClassCourse stud in AllClassCourse)
            {
                foreach (Course course in AllCourses)
                    if (course.CourseID == stud.CourseID) // => ii bag course.CourseName
                    {
                        foreach (Clasa clasa in AllClasses) // ii bag anul si specializarea 
                            if (clasa.Id == stud.ClasaID)
                            {
                                ClassCourseViews.Add(new ClassCourseView { ClassCourseID = stud.ClassCourseID, CourseName = course.CourseName, ClasaAnStudiu = clasa.AnStudiu, ClasaSpecializare = clasa.DenumireSpecializare });
                            }
                    }
            }
        }
        public Course GetSelectedCourse(string name)
        {
            foreach (Course c in AllCourses)
            {
                if (c.CourseName == name)
                    return c;
            }
            return null;
        }

        //class stuff
        private void AddClassF()
        {
            int idTeacher = 0;

            foreach(Teacher c in AllTeachers)
            {
                if(SelectedAvailableTeacher.Contains(c.Name))
                {
                    idTeacher=c.ID; 
                    break;
                }
            }
            clasaBLL.AddClass(new Clasa() { AnStudiu = int.Parse(FirstNameStudent), ProfID=idTeacher, DenumireSpecializare = SecondNameStudent });
        }
        private void DeleteClass1()
        {
            clasaBLL.DeleteClass(SelectedClasa);
            AllClasses.Remove(SelectedClasa);
        }

    }

}
