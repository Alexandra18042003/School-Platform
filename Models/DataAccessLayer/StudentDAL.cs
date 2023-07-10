using Npgsql;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class StudentDAL
    {
        public ObservableCollection<Student> GetAllStudents()
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student p = new Student();
                    p.ID = (int)(reader[0]);
                    p.Name = reader.GetString(1);
                    p.SecondName = reader.GetString(2);
                    p.ClasaiD = (int)(reader[3]);

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
        public int GetStudent(Student student)
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("GetStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("nume_student_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramName.Value = student.Name;

            NpgsqlParameter paramSecondName = new NpgsqlParameter("prenume_student_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramSecondName.Value = student.SecondName;

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
        public void AddStudent(Student student)
        {
            NpgsqlConnection con = DALHelper.Connection;

            if (GetStudent(student) > 0)
            {
                MessageBox.Show("Student already exists!");
                return;
            }


            NpgsqlCommand cmd = new NpgsqlCommand("AddStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("nume_student_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramName.Value = student.Name;

            NpgsqlParameter paramSecondName = new NpgsqlParameter("prenume_student_in", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramSecondName.Value = student.SecondName;

            NpgsqlParameter paramClasaID = new NpgsqlParameter("clasa_id_in", NpgsqlTypes.NpgsqlDbType.Integer);
            paramClasaID.Value = student.ClasaiD;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramSecondName);
            cmd.Parameters.Add(paramClasaID);

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Student added successfully!");

            con.Close();
        }
        public void DeleteStudent(Student student)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("in_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = student.ID;

            cmd.Parameters.Add(paramID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void ModifyStudent(Student student, string nume_nou, string prenume_nou)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("ModifyStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("in_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = GetStudent(student);

            NpgsqlParameter paramNumeNou = new NpgsqlParameter("in_nume_nou", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramNumeNou.Value = nume_nou;

            NpgsqlParameter paramPrenumeNou = new NpgsqlParameter("in_prenume_nou", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramPrenumeNou.Value = prenume_nou;

            cmd.Parameters.Add(paramID);
            cmd.Parameters.Add(paramNumeNou);
            cmd.Parameters.Add(paramPrenumeNou);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public ObservableCollection<Student> GetStudentsByClassId(int id)
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetStudentsByClassId", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramClassID = new NpgsqlParameter("class_id_in", NpgsqlTypes.NpgsqlDbType.Integer);
                paramClassID.Value = id;

                cmd.Parameters.Add(paramClassID);
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student p = new Student();
                    p.ID = (int)(reader[0]);
                    p.Name = reader.GetString(1);
                    p.SecondName = reader.GetString(2);
                    p.ClasaiD = (int)(reader[3]);

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
    }

}

