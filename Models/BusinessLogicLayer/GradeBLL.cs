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
    public class GradeBLL
    {
        public ObservableCollection<Grade> GradeList { get; set; }
        public GradeDAL gradeDAL = new GradeDAL();
        public GradeBLL()
        {
            GradeList = new ObservableCollection<Grade>();
            GradeList = GetAllGrades();
        }
        public ObservableCollection<Grade> GetAllGrades()
        {
            return gradeDAL.GetAllGrades();
        }

    }
}
