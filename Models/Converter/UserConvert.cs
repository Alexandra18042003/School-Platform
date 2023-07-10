using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SchoolPlatform.Models.Converter
{
    public class UserConvert : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                return new User()
                {
                    Username = values[0].ToString(),
                    Password = values[1].ToString(),
                    UserType = values[2].ToString()
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
