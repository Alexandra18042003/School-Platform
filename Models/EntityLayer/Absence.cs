using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Absence : BasePropertyChanged
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
                NotifyPropertyChanged("absence_id");
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
                NotifyPropertyChanged("checked_");
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
