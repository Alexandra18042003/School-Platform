using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Course : BasePropertyChanged
    {
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

        private string course_name;
        public string CourseName
        {
            get
            {
                return course_name;
            }
            set
            {
                course_name = value;
                NotifyPropertyChanged("course_name");
            }
        }
    }
}
