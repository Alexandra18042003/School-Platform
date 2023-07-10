using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.BusinessLogicLayer
{
    public class StudentBLL
    {
        public ObservableCollection<Student> StudentsList { get; set; }
        public StudentDAL studentDAL = new StudentDAL();
        public UserBLL userBLL = new UserBLL();
        public StudentBLL()
        {
            StudentsList = new ObservableCollection<Student>();
            StudentsList = GetAllStudents();
        }
        public ObservableCollection<Student> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }
        public ObservableCollection<Student> GetStudentsByClassId(int id)
        {
            return studentDAL.GetStudentsByClassId(id);
        }
        public int GetStudent(Student student)
        {
            return studentDAL.GetStudent(student);
        }
        public void AddStudent(Student student)
        {
            studentDAL.AddStudent(student);
            userBLL.AddUser(new User() { Username = student.Name+"."+student.SecondName, Password = "123", UserType = "Elev" });
            StudentsList = GetAllStudents();
        }
        public void DeleteStudent(Student student)
        {
            studentDAL.DeleteStudent(student);
            StudentsList = GetAllStudents();
        }

        public void ModifyStudent(Student student, string nume_nou, string prenume_nou)
        {
            studentDAL.ModifyStudent(student, nume_nou, prenume_nou);
            StudentsList = GetAllStudents();
        }

    }
}
