using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class ClassCourse : BasePropertyChanged
    {
        
        private int classCourseID;
        public int ClassCourseID
        {
            get
            {
                return classCourseID;
            }
            set
            {
                classCourseID = value;
                NotifyPropertyChanged("ClassCourseID");
            }
        }
         private int courseID;
        public int CourseID
        {
            get
            {
                return courseID;
            }
            set
            {
                courseID = value;
                NotifyPropertyChanged("CourseID");
            }
        }
        private int clasaID;

        public int ClasaID
        {
            get
            {
                return clasaID;
            }
            set
            {
                clasaID = value;
                NotifyPropertyChanged("ClasaID");
            }
        }

        private bool teza;
        public bool Teza
        {
            get
            {
                return teza;
            }
            set
            {
                teza = value;
                NotifyPropertyChanged("Teza");
            }
        }
    }
}
