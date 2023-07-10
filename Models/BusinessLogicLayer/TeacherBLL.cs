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
    public class TeacherBLL
    {
        public ObservableCollection<Teacher> TeachersList { get; set; }
        public TeacherDAL teacherDAL = new TeacherDAL();
        public TeacherBLL()
        {
            TeachersList = new ObservableCollection<Teacher>();
            TeachersList = GetAllTeachers();
        }
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return teacherDAL.GetAllTeachers();
        }

        public int GetTeacher(Teacher teacher)
        {
            return teacherDAL.GetTeacher(teacher);
        }
        public void AddTeacher(Teacher teacher)
        {
            teacherDAL.AddTeacher(teacher);
        }
        public void DeleteTeacher(Teacher teacher)
        {
            teacherDAL.DeleteTeacher(teacher);
        }

        public void ModifyTeacher(Teacher teacher, string nume_nou)
        {
            teacherDAL.ModifyTeacher(teacher, nume_nou);
        }

    }
}

