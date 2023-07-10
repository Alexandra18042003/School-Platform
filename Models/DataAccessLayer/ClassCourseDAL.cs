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
    public class ClassCourseDAL
    {
        public ObservableCollection<ClassCourse> GetAllClassCourse()
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllClassCourse", con);
                ObservableCollection<ClassCourse> result = new ObservableCollection<ClassCourse>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassCourse p = new ClassCourse();
                    p.ClassCourseID = (int)(reader[0]);
                    p.CourseID = (int)(reader[1]);
                    p.ClasaID = (int)(reader[2]);
                    p.Teza = (bool)(reader[3]);

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
        public int GetClassCourse(ClassCourse course)
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("GetClassCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("id_materieclasa", NpgsqlTypes.NpgsqlDbType.Integer);
            paramName.Value = course.ClassCourseID;

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

        public void AddClassCourse(ClassCourse course)
        {
            NpgsqlConnection con = DALHelper.Connection;

            //if (GetClassCourse(course) > 0)
            //{
            //    MessageBox.Show("ClassCourse already exists!");
            //    return;
            //}

            NpgsqlCommand cmd = new NpgsqlCommand("AddClassCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("p_materie_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramName.Value = course.CourseID;

            NpgsqlParameter paramName2 = new NpgsqlParameter("p_clasa_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramName2.Value = course.ClasaID;

            NpgsqlParameter paramName3 = new NpgsqlParameter("p_teza", NpgsqlTypes.NpgsqlDbType.Boolean);
            paramName3.Value = course.Teza;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramName2);
            cmd.Parameters.Add(paramName3);
            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("ClassCourse added successfully!");

            con.Close();
        }
        public void DeleteClassCourse(ClassCourse course)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("DeleteClassCourse2", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("p_materieClasa_id ", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = course.ClassCourseID;

            cmd.Parameters.Add(paramID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public void Sterge_materieclasa(int course)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("sterge_materieclasa", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("id_param ", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = course;

            cmd.Parameters.Add(paramID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public int VerifyExistsCourseIDInClassCourse(int courseID)
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("VerifyExistsCourseIDInClassCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("p_materie_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramName.Value = courseID;

            cmd.Parameters.Add(paramName);
            con.Open();
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return -1;
        }
    }
}
