using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        public ObservableCollection<User> UsersList { get; set; }
        UserDAL userDAL = new UserDAL();

        public UserBLL()
        {
            UsersList = new ObservableCollection<User>();
            UsersList = GetAllUsers();
        }
        public ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }
        public void AddUser(User user)
        {
            userDAL.AddUser(user);
            UsersList.Add(user);
        }
        public int GetUser(User user)
        {
            return userDAL.GetUser(user);
        }
        public string GetUserType(int userID)
        {
            if (userID != -1)
                return UsersList.FirstOrDefault(p => p.UserID == userID).UserType;
            return "";
        }
        public int GetUserIDByName(string username)
        {
            return userDAL.GetUserIDByName(username);
        }
        public void GetType(User user)
        {
            //TODO: de trimis ca parametru fereastra loginOrCreateAccount ca sa ii dai close aici
            string type = userDAL.GetType(user);

            if (type != null)
            {
                switch (type)
                {
                    case "Administrator":
                        Administrator admin = new Administrator();
                        admin.Show();
                        break;
                    case "Profesor":
                        //Administrator admin = new Administrator();
                        //admin.Show();
                        break;
                    case "Diriginte":
                        //Administrator admin = new Administrator();
                        //admin.Show();
                        break;
                    case "Elev":
                        StudentWindow sw = new StudentWindow(user);
                        sw.Show();
                        break;
                }
            }
            else
                MessageBox.Show("Your account doesn't exist!");
        }

    }
}
