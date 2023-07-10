using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Grade: BasePropertyChanged
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
                NotifyPropertyChanged("grade_id");
            }
        }
        private int student_id;
        public int Student_id
        {
            get
            {
                return student_id;
            }
            set
            {
                student_id = value;
                NotifyPropertyChanged("student_id");
            }
        }
        private int course_id;
        public int Course_id
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
                NotifyPropertyChanged("grade_value");
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

    }
}
