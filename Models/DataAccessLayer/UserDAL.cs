using Npgsql;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class UserDAL
    {
        public ObservableCollection<User> GetAllUsers() 
        {
            NpgsqlConnection con = DALHelper.Connection;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllUsers", con);
                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User u = new User();
                    u.UserID = (int)(reader[0]);
                    u.UserType = reader[3].ToString();
                    u.Username = reader[1].ToString();
                    u.Password = reader[2].ToString();
                    result.Add(u);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public int GetUser(User user) 
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("GetUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlParameter paramUsername = new NpgsqlParameter("nume_utilizator_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramUsername.Value = user.Username;

            NpgsqlParameter paramPassword = new NpgsqlParameter("parola_utilizator_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramPassword.Value = user.Password;

            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPassword);
            con.Open();
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                con.Close();
                return Convert.ToInt32(result);
            }
            con.Close();

            return -1;

        }
        public string GetType(User user) 
        {
            if (GetUser(user) > -1)
            {
                int id = GetUser(user);
                NpgsqlConnection con = DALHelper.Connection;

                NpgsqlCommand cmd = new NpgsqlCommand("GetUserType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                NpgsqlParameter paramId = new NpgsqlParameter("in_id", NpgsqlTypes.NpgsqlDbType.Integer);
                paramId.Value = id;


                cmd.Parameters.Add(paramId);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    con.Close();
                    return Convert.ToString(result);
                }
                con.Close();

            }
                return null;

        }
        public void AddUser(User user) 
        {
            NpgsqlConnection con = DALHelper.Connection;

            if (GetUser(user) > 0)
            {
                MessageBox.Show("User already exists!");
                return;
            }

            if (string.IsNullOrEmpty(user.UserType))
            {
                MessageBox.Show("User type is required!");
                return;
            }

            NpgsqlCommand cmd = new NpgsqlCommand("AddUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramUserType = new NpgsqlParameter("tip_utilizator_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramUserType.Value = user.UserType;

            NpgsqlParameter paramUsername = new NpgsqlParameter("nume_utilizator_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramUsername.Value = user.Username;

            NpgsqlParameter paramPassword = new NpgsqlParameter("parola_utilizator_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramPassword.Value = user.Password;

            cmd.Parameters.Add(paramUserType);
            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPassword);

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Account created successfully!");

            con.Close();
        }
        public int GetUserIDByName(string username) 
        {
            using (NpgsqlConnection con = DALHelper.Connection)
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetUserIDByName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                NpgsqlParameter name = new NpgsqlParameter("username", NpgsqlTypes.NpgsqlDbType.Varchar);
                name.Value = username;
                cmd.Parameters.Add(name);
                con.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);

            }
        }
    }
}
