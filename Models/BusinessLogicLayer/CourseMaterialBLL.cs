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
    public class CourseMaterialBLL
    {
        public ObservableCollection<CourseMaterial> CourseMaterialList { get; set; }
        public CourseMaterialDAL courseMaterialDAL = new CourseMaterialDAL();
        public CourseMaterialBLL()
        {
            CourseMaterialList = new ObservableCollection<CourseMaterial>();
            CourseMaterialList = GetAllCourseMaterial();
        }
        public ObservableCollection<CourseMaterial> GetAllCourseMaterial()
        {
            return courseMaterialDAL.GetAllCourseMaterial();
        }
    }
}
