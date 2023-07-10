using SchoolPlatform.Commands;
using SchoolPlatform.Models.BusinessLogicLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class UserVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();
        LoginOrCreateAccount _window;
        //public RelayCommand Continue { get; set; }

        public UserVM(LoginOrCreateAccount window)
        {
            UsersList = userBLL.GetAllUsers();
            _window= window;

        }
        public ObservableCollection<User> UsersList
        {
            get => userBLL.UsersList;
            set
            {
                userBLL.UsersList = value;
                NotifyPropertyChanged("UsersList");

            }
        }
        private string username;
        private string userType;
        private string password;
        public bool CanExecute { get; set; }
        public string Username
        {
            get => username;
            set
            {
                username = value;
                if (Password != null)
                    UserType = userBLL.GetUserType(userBLL.GetUser(new User() { Password = Password, Username = Username }));
                NotifyPropertyChanged("Username");
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
        public string Password
        {
            get => password;
            set
            {
                password = value;
                if (Username != null)
                    UserType = userBLL.GetUserType(userBLL.GetUser(new User() { Password = Password, Username = Username }));
                NotifyPropertyChanged("Password");
            }
        }



        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<User>(userBLL.AddUser);
                }
                return addCommand;
            }
        }
        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<User>(userBLL.GetType);
                }
                return loginCommand;
            }
        }
        //de scris toate comenzile
    }
}
