using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Clasa : BasePropertyChanged
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged("ClasaID");
            }
        }
        private int _an_studiu;
        public int AnStudiu
        {
            get
            {
                return _an_studiu;
            }
            set
            {
                _an_studiu = value;
                NotifyPropertyChanged("StudentID");
            }
        }
        private int _prof_id;
        public int ProfID
        {
            get
            {
                return _prof_id;
            }
            set
            {
                _prof_id = value;
                NotifyPropertyChanged("ProfID");
            }
        }

        private string  _denumire_specializare;
        public string DenumireSpecializare
        {
            get
            {
                return _denumire_specializare;
            }
            set
            {
                _denumire_specializare = value;
                NotifyPropertyChanged("Denumire specializare");
            }
        }

    }
}
