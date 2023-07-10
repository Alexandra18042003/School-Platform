using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class CourseMaterial : BasePropertyChanged
    {
        private int courseMaterial_id;
        public int CourseMaterialID
        {
            get
            {
                return courseMaterial_id;
            }
            set
            {
                courseMaterial_id = value;
                NotifyPropertyChanged("courseMaterial_id");
            }
        }
        private int course_id;
        public int CourseID
        {
            get
            {
                return course_id;
            }
            set
            {
                course_id = value;
                NotifyPropertyChanged("course_id");
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
                NotifyPropertyChanged("semester");
            }
        }

        private string courseMaterial_name;
        public string CourseMaterial_name
        {
            get
            {
                return courseMaterial_name;
            }
            set
            {
                courseMaterial_name = value;
                NotifyPropertyChanged("CourseMaterial_name");
            }
        }
    }
}
