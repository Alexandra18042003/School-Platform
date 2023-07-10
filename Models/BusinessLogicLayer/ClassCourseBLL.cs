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
    public class ClassCourseBLL
    {
        public ObservableCollection<ClassCourse> ClassCoursesList { get; set; }
        public ClassCourseDAL classCourseDAL = new ClassCourseDAL();
        public ClassCourseBLL()
        {
            ClassCoursesList = new ObservableCollection<ClassCourse>();
            ClassCoursesList = GetAllClassCourse();
        }
        public ObservableCollection<ClassCourse> GetAllClassCourse()
        {
            return classCourseDAL.GetAllClassCourse();
        }

        public int GetClassCourse(ClassCourse course)
        {
            return classCourseDAL.GetClassCourse(course);
        }
        public void AddClassCourse(ClassCourse course)
        {
            classCourseDAL.AddClassCourse(course);
            ClassCoursesList = GetAllClassCourse();
        }
        public void DeleteClassCourse(ClassCourse course)
        {
            classCourseDAL.DeleteClassCourse(course);
            ClassCoursesList = GetAllClassCourse();
        }
        public void Sterge_materieclasa(int course)
        {
            classCourseDAL.Sterge_materieclasa(course);
            ClassCoursesList = GetAllClassCourse();
        }
        public int VerifyExistsCourseIDInClassCourse(int courseID)
        {
            return classCourseDAL.VerifyExistsCourseIDInClassCourse(courseID);
        }
    }
}
