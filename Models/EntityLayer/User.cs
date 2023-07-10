using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class User : BasePropertyChanged
    {
        private int userID;
        private string userType;
        private string username;
        private string password;

        public int UserID
        {
            get => userID;
            set
            {
                userID = value;
                NotifyPropertyChanged("UserID");
            }
        }
        public string UserType
        {
            get => userType;
            set
            {
                userType = value;
                NotifyPropertyChanged("UserType");
            }

        }
        public string Username { get => username; set { username = value; NotifyPropertyChanged("Username"); } }
        public string Password { get => password; set { password = value; NotifyPropertyChanged("Password"); } }
    }
}
