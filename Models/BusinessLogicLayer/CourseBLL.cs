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
    public class CourseBLL
    {
        public ObservableCollection<Course> CoursesList { get; set; }
        public CourseDAL courseDAL = new CourseDAL();
        public ClassCourseBLL classCourseBLL = new ClassCourseBLL();
        public CourseBLL()
        {
            CoursesList = new ObservableCollection<Course>();
            CoursesList = GetAllCourses();
        }
        public ObservableCollection<Course> GetAllCourses()
        {
            return courseDAL.GetAllCourses();
        }

        public int GetCourse(Course course)
        {
            return courseDAL.GetCourse(course);
        }
        public void AddCourse(Course course)
        {
            courseDAL.AddCourse(course);
            CoursesList = GetAllCourses();
        }
        public void DeleteCourse(Course course)
        {
            //+ se sterge materieClasa care contine courseID
            if (classCourseBLL.VerifyExistsCourseIDInClassCourse(course.CourseID)!=-1)
            {
                classCourseBLL.Sterge_materieclasa(course.CourseID);
            }
            //DACA FACI PROFESOR FA SI :
            //+ se sterge materialDidactic care contine courseID
            //+ se sterge medie, nota, absenta care contin courseID

            courseDAL.DeleteCourse(course);
            CoursesList = GetAllCourses();
        }

        public void ModifyCourse(Course course, string nume_nou)
        {
            courseDAL.ModifyCourse(course, nume_nou);
            CoursesList = GetAllCourses();
        }

        public string GetCourseNameByID( int courseID)
        {
            foreach( Course course in CoursesList)
            {
                if (course.CourseID == courseID)
                    return course.CourseName;
            }
            return null;
        }
    }
}

