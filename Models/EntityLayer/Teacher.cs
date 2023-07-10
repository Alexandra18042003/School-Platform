using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Teacher : BasePropertyChanged
    {
        private int iD;
        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
                NotifyPropertyChanged("StudentID");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string secondName;
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
                NotifyPropertyChanged("secondName");
            }
        }

       
    }
}

