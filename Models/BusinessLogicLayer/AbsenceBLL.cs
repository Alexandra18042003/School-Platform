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
    public class AbsenceBLL
    {
        public ObservableCollection<Absence> AbsenceList { get; set; }
        public AbsenceDAL absenceDAL = new AbsenceDAL();
        public AbsenceBLL()
        {
            AbsenceList = new ObservableCollection<Absence>();
            AbsenceList = GetAllAbsences();
        }
        public ObservableCollection<Absence> GetAllAbsences()
        {
            return absenceDAL.GetAllAbsences();
        }
    }
}
