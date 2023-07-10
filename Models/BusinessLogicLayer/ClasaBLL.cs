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
    public class ClasaBLL
    {
        public ObservableCollection<Clasa> ClassesList { get; set; }
        public ClasaDAL clasaDAL = new ClasaDAL();
        public ClasaBLL()
        {
            ClassesList = new ObservableCollection<Clasa>();
            ClassesList = GetAllClasses();
        }
        public ObservableCollection<Clasa> GetAllClasses()
        {
            return clasaDAL.GetAllClasses();
        }

        public void AddClass(Clasa c)
        {
            clasaDAL.AddClass(c);
            ClassesList.Add(c);
        }

        public void DeleteClass(Clasa c)
        {
            clasaDAL.DeleteClass(c);
            ClassesList.Remove(c);
        }
    }
}
