using SchoolPlatform.Models.BusinessLogicLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SchoolPlatform.Models.Converter
{
    public class StudentConvert : IMultiValueConverter
    {
        private readonly ClasaBLL clasaBLL = new ClasaBLL();
        private ObservableCollection<Clasa> clase = new ObservableCollection<Clasa>();
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string pattern = @"\b\d+\b";

            Match match = Regex.Match(values[2].ToString(), pattern);

            if (values[0] != null && values[1] != null && values[2] != null)
            {
                int idClasa = 0;
                clase = clasaBLL.ClassesList;
                foreach (Clasa c in clase)
                {
                    if (values[2].ToString().Contains(c.DenumireSpecializare) && c.AnStudiu == int.Parse(match.Value))
                        idClasa = c.Id;
                }
                return new Student()
                {
                    Name = values[0].ToString(),
                    SecondName = values[1].ToString(),
                    ClasaiD = idClasa
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
