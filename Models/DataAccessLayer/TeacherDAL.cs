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
    public class TeacherDAL
    {
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher p = new Teacher();
                    p.ID = (int)(reader[0]);
                    p.Name = reader.GetString(1);
                    p.SecondName = reader.GetString(2);


                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }

        public int GetTeacher(Teacher teacher)
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("GetTeacher", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("nume_prof_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramName.Value = teacher.Name;

            NpgsqlParameter paramSecondName = new NpgsqlParameter("prenume_prof_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramSecondName.Value = teacher.SecondName;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramSecondName);
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
        public void AddTeacher(Teacher teacher)
        {
            NpgsqlConnection con = DALHelper.Connection;

            if (GetTeacher(teacher) > 0)
            {
                MessageBox.Show("Teacher already exists!");
                return;
            }


            NpgsqlCommand cmd = new NpgsqlCommand("AddTeacher", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("nume_prof_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramName.Value = teacher.Name;

            NpgsqlParameter paramSecondName = new NpgsqlParameter("prenume_prof_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramSecondName.Value = teacher.SecondName;


            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramSecondName);

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Teacher added successfully!");

            con.Close();
        }
        public void DeleteTeacher(Teacher teacher)
        {
            //TODO: intra pe codul asta daca nu exista nicio clasa CARE IL ARE DIRIGINTE PE TEACHER

            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("delete_profesor_with_clase", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("id_profesor", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = teacher.ID;

            cmd.Parameters.Add(paramID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public void ModifyTeacher(Teacher teacher, string nume_nou)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("ModifyTeacher", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("in_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = GetTeacher(teacher);

            NpgsqlParameter paramNumeNou = new NpgsqlParameter("nume_nou", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramNumeNou.Value = nume_nou;

            cmd.Parameters.Add(paramID);
            cmd.Parameters.Add(paramNumeNou);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
