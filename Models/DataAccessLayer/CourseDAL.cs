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
    public class CourseDAL
    {
        public ObservableCollection<Course> GetAllCourses()
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllCourses", con);
                ObservableCollection<Course> result = new ObservableCollection<Course>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course p = new Course();
                    p.CourseID = (int)(reader[0]);
                    p.CourseName = reader.GetString(1);

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
        public int GetCourse(Course course)
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("GetCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("nume_materie_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramName.Value = course.CourseName;

            cmd.Parameters.Add(paramName);
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
        public void AddCourse(Course course)
        {
            NpgsqlConnection con = DALHelper.Connection;

            if (GetCourse(course) > 0)
            {
                MessageBox.Show("Course already exists!");
                return;
            }
            
            NpgsqlCommand cmd = new NpgsqlCommand("AddCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("nume_materie_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramName.Value = course.CourseName;

            cmd.Parameters.Add(paramName);
            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Course added successfully!");

            con.Close();
        }
        public void DeleteCourse(Course course)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("DeleteCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("in_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = course.CourseID;

            cmd.Parameters.Add(paramID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void ModifyCourse(Course course, string nume_nou)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("ModifyCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("in_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = GetCourse(course);

            NpgsqlParameter paramNumeNou = new NpgsqlParameter("in_nume_nou", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramNumeNou.Value = nume_nou;

            cmd.Parameters.Add(paramID);
            cmd.Parameters.Add(paramNumeNou);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}
